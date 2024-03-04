
using Microsoft.Extensions.Caching.Memory;
using Stepstone.Domain;
using Stepstone.Domain.Models;

namespace Stepstone.Persistence
{
    public class QuestionnaireService : IQuestionnaire
    {
        private readonly IMemoryCache _cache;
        public QuestionnaireService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public (bool, string) AnswerQuestion(Guid guid, string answer)
        {
            var questions = (List<Question>?)_cache.Get("Questions");
            Question? question = questions.FirstOrDefault(x => x.Id.Equals(guid));
            if (question == null) {
                return (false, "Could not find the question by the Guid provided");
            }
            var response = question.Responses.FirstOrDefault(x => x.ResponseText == answer);
            if (response == null) 
            { 
                return (false, "Incorrect Answer."); 
            }
            return (true, string.Empty);
        }

        public Question GetQuestionById(Guid guid)
        {
            var questions = (List<Question>?)_cache.Get("Questions");
            return questions.FirstOrDefault(x => x.Id.Equals(guid));
        }

        public List<Question>? GetQuestions()
        {
            var questions = (List<Question>?)_cache.Get("Questions");
            return questions;
        }
    }
}