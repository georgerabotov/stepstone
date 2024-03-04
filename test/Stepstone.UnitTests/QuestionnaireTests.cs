using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Stepstone.DataMock;
using Stepstone.Domain.Models;
using Stepstone.Persistence;

namespace Stepstone.UnitTests
{
    public class QuestionnaireTests
    {
        private readonly DataInitializer _dataInitializer;
        private readonly IMemoryCache _cache;
        public QuestionnaireTests()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();

            var serviceProvider = services.BuildServiceProvider();
            _cache = serviceProvider.GetService<IMemoryCache>();

            _dataInitializer = new DataInitializer(_cache);
        }

        [Fact]
        public void GetQuestionsById_Should_Return_Correct()
        {
            _dataInitializer.GenerateFakeData();

            List<Question>? questions = (List<Question>?)_cache.Get("Questions");
            var firstQuestion = questions.FirstOrDefault();

            QuestionnaireService service = new(_cache);

            var result = service.GetQuestionById(firstQuestion.Id);
            result.Should().NotBe(0);
        }

        [Fact]
        public void GetQuestionsById_Should_Return_False()
        {
            _dataInitializer.GenerateFakeData();

            QuestionnaireService service = new(_cache);

            var result = service.GetQuestionById(Guid.NewGuid());
            result.Should().BeNull();
        }


        [Fact]
        public void GetQuestions_Should_Return_Correct()
        {
            _dataInitializer.GenerateFakeData();

            QuestionnaireService service = new(_cache);

            var result = service.GetQuestions();
            
            result.Should().NotBeNull();
            result.Should().HaveCount(4);
        }

        [Fact]
        public void AnswerQuestion_Should_Return_Correct()
        {
            _dataInitializer.GenerateFakeData();

            List<Question>? questions = (List<Question>?)_cache.Get("Questions");
            var firstQuestion = questions.FirstOrDefault();

            QuestionnaireService service = new(_cache);

            var result = service.AnswerQuestion(firstQuestion.Id, "Havana");

            result.Item1.Should().BeTrue();
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public void AnswerQuestion_Should_Return_Incorrect_Answer()
        {
            _dataInitializer.GenerateFakeData();

            List<Question>? questions = (List<Question>?)_cache.Get("Questions");
            var firstQuestion = questions.FirstOrDefault();

            QuestionnaireService service = new(_cache);

            var result = service.AnswerQuestion(firstQuestion.Id, "Romania");

            result.Item1.Should().BeFalse();
            result.Item2.Should().Be("Incorrect Answer.");
        }

        [Fact]
        public void AnswerQuestion_Should_Return_False()
        {
            _dataInitializer.GenerateFakeData();

            QuestionnaireService service = new(_cache);

            var result = service.AnswerQuestion(Guid.NewGuid(), "Jersey");

            result.Item1.Should().BeFalse();
            result.Item2.Should().Be("Could not find the question by the Guid provided");
        }
    }
}
