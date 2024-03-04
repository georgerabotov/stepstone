using Microsoft.Extensions.Caching.Memory;
using Stepstone.Domain.Models;

namespace Stepstone.DataMock
{
    public class DataInitializer
    {
        private readonly IMemoryCache _cache;
        public DataInitializer(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void GenerateFakeData() => GenerateQuestionnaire();

        private void GenerateQuestionnaire()
        {
            List<Question> questions = new();
            
            Question question1 = new()
            {
                Id = Guid.NewGuid(),
                Title = "Geography Questions",
                Text = "What is the Capital of Cuba?",
            };

            question1.Responses = new List<QuestionResponse>
            {
                new QuestionResponse
                {
                    IsCorrect = true,
                    QuestionId = question1.Id,
                    ResponseText = "Havana"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question1.Id,
                    ResponseText = "Bogota"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question1.Id,
                    ResponseText = "Buenos Aires"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question1.Id,
                    ResponseText = "Brasilia"
                }
            };

            Question question2 = new Question
            {
                Id = Guid.NewGuid(),
                Text = "What is the capital of France?",
                Title = "Geography Questions"
            };

            question2.Responses = new List<QuestionResponse>
            {
                new QuestionResponse
                {
                    IsCorrect = true,
                    QuestionId = question2.Id,
                    ResponseText = "Paris"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question2.Id,
                    ResponseText = "London"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question2.Id,
                    ResponseText = "Berlin"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question2.Id,
                    ResponseText = "Madrid"
                }
            };

            Question question3 = new Question
            {
                Id = Guid.NewGuid(),
                Title = "Geography Questions",
                Text = "What is the capital of Poland?",
            };

            question3.Responses = new List<QuestionResponse>
            {
                new QuestionResponse
                {
                    IsCorrect = true,
                    QuestionId = question3.Id,
                    ResponseText = "Warsaw"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question3.Id,
                    ResponseText = "Berlin"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question3.Id,
                    ResponseText = "Moscow"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question3.Id,
                    ResponseText = "Budapest"
                }
            };

            Question question4 = new Question
            {
                Id = Guid.NewGuid(),
                Title = "Geography Questions",
                Text = "What is the capital of Germany?",
            };

            question4.Responses = new List<QuestionResponse>
            {
                new QuestionResponse
                {
                    IsCorrect = true,
                    QuestionId = question4.Id,
                    ResponseText = "Berlin"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question4.Id,
                    ResponseText = "Paris"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question4.Id,
                    ResponseText = "Rome"
                },
                new QuestionResponse
                {
                    IsCorrect = false,
                    QuestionId = question4.Id,
                    ResponseText = "Madrid"
                }
            };

            questions.Add(question1);
            questions.Add(question2);
            questions.Add(question3);
            questions.Add(question4);

            _cache.Set("Questions", questions);
        }
    }
}