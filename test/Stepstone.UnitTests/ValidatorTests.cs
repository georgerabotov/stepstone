using FluentValidation.TestHelper;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Stepstone.DataMock;
using Stepstone.Api.Requests;
using Stepstone.Domain.Models;
using Stepstone.Api.Requests.Validators;

namespace Stepstone.UnitTests
{
    public class ValidatorTests
    {
        private readonly DataInitializer _dataInitializer;
        private readonly IMemoryCache _cache;
        private readonly GetQuestionByIdValidator _getQuestionByIdValidator;
        private readonly AnswerQuestionValidator _answerQuestionByIdValidator;
        public ValidatorTests()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();

            var serviceProvider = services.BuildServiceProvider();
            _cache = serviceProvider.GetService<IMemoryCache>();

            _dataInitializer = new DataInitializer(_cache);
            _getQuestionByIdValidator = new GetQuestionByIdValidator();
            _answerQuestionByIdValidator = new AnswerQuestionValidator();
        }

        [Fact]
        public void GetQuestionById_Should_Be_True()
        {
            // Arrange
            _dataInitializer.GenerateFakeData();

            List<Question>? questions = (List<Question>?)_cache.Get("Questions");
            var firstQuestion = questions.FirstOrDefault();

            var model = new GetQuestionByIdRequest(firstQuestion.Id.ToString());

            // Act
            var result = _getQuestionByIdValidator.TestValidate(model);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Answer_Should_Be_True()
        {
            // Arrange
            _dataInitializer.GenerateFakeData();

            List<Question>? questions = (List<Question>?)_cache.Get("Questions");
            var firstQuestion = questions.FirstOrDefault();

            var model = new AnswerQuestionRequest(firstQuestion.Id.ToString(), "Havana");

            // Act
            var result = _answerQuestionByIdValidator.TestValidate(model);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GetQuestionById_Should_Be_False()
        {
            // Arrange
            _dataInitializer.GenerateFakeData();


            var model = new GetQuestionByIdRequest("asd");

            // Act
            var result = _getQuestionByIdValidator.TestValidate(model);

            // Assert
            result.IsValid.Should().BeFalse();
            result.ShouldHaveValidationErrorFor(x => x.Id).WithErrorMessage("Invalid Guid Format");
        }

        [Fact]
        public void Answer_Should_Be_False()
        {
            // Arrange
            _dataInitializer.GenerateFakeData();

            List<Question>? questions = (List<Question>?)_cache.Get("Questions");
            var firstQuestion = questions.FirstOrDefault();

            var model = new AnswerQuestionRequest(Guid.NewGuid().ToString(), "");

            // Act
            var result = _answerQuestionByIdValidator.TestValidate(model);

            // Assert
            result.IsValid.Should().BeFalse();
            result.ShouldHaveValidationErrorFor(x => x.Answer).WithErrorMessage("'Answer' must not be empty.");
        }
    }
}
