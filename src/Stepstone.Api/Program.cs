using FluentValidation;
using MediatR;
using Stepstone.Api.Core;
using Stepstone.Api.Requests;
using Stepstone.Api.Requests.Validators;
using Stepstone.DataMock;
using Stepstone.Domain;
using Stepstone.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
    cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});

// Register Services
builder.Services.AddScoped<IQuestionnaire, QuestionnaireService>();
builder.Services.AddSingleton<DataInitializer>();

// Register Validation and ErrorHandling
builder.Services.AddTransient<ErrorHandlingMiddleWare>();

// Register Validators
builder.Services.AddScoped<IValidator<AnswerQuestionRequest>, AnswerQuestionValidator>();
builder.Services.AddScoped<IValidator<GetQuestionByIdRequest>, GetQuestionByIdValidator>();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandlingMiddleWare>();

// Load fake data into cache
var initializationService = app.Services.GetRequiredService<DataInitializer>();
initializationService.GenerateFakeData();

app.MapControllers();

app.Run();
