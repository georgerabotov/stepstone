using MediatR;
using Stepstone.Api.Requests.Responses;

namespace Stepstone.Api.Requests
{
    public class AnswerQuestionRequest : IRequest<AnswerQuestionResponse>
    {
        public AnswerQuestionRequest(string id, string answer)
        {
            Id = id;
            Answer = answer;
        }
        public string Id { get; }
        public string Answer { get; }
    }
}
