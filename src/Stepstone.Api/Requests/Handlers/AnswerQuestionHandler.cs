using MediatR;
using Stepstone.Api.Requests.Responses;
using Stepstone.Domain;

namespace Stepstone.Api.Requests.Handlers
{
    public class AnswerQuestionHandler : IRequestHandler<AnswerQuestionRequest, AnswerQuestionResponse>
    {
        private readonly IQuestionnaire _questionnaire;
        public AnswerQuestionHandler(IQuestionnaire questionnaire)
        {
            _questionnaire = questionnaire;
        }
        public async Task<AnswerQuestionResponse> Handle(AnswerQuestionRequest request, CancellationToken cancellationToken)
        {
            (bool, string) answer = _questionnaire.AnswerQuestion(Guid.Parse(request.Id), request.Answer);
            return new AnswerQuestionResponse(answer.Item1, answer.Item2);
        }
    }
}
