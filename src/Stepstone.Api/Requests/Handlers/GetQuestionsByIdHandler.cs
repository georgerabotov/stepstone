using MediatR;
using Stepstone.Api.Requests.Responses;
using Stepstone.Domain;
using Stepstone.Domain.Models;

namespace Stepstone.Api.Requests.Handlers
{
    public class GetQuestionsByIdHandler : IRequestHandler<GetQuestionByIdRequest, GetQuestionByIdResponse>
    {
        private readonly IQuestionnaire _questionnaire;
        public GetQuestionsByIdHandler(IQuestionnaire questionnaire)
        {
            _questionnaire = questionnaire;
        }

        public async Task<GetQuestionByIdResponse> Handle(GetQuestionByIdRequest request, CancellationToken cancellationToken)
        {
            Guid questionGuid = Guid.Parse(request.Id);
            Question question = _questionnaire.GetQuestionById(questionGuid);
            var response = new GetQuestionByIdResponse(question.Text, question.Title, question.Responses
                .Where(x => x.QuestionId == questionGuid)
                .Select(x => x.ResponseText)
                .ToArray());

            return response;
        }
    }
}
