using Stepstone.Domain.Models;

namespace Stepstone.Domain
{
    public interface IQuestionnaire
    {
        List<Question>? GetQuestions();
        Question GetQuestionById(Guid guid);
        (bool, string) AnswerQuestion(Guid guid, string answer);
    }
}