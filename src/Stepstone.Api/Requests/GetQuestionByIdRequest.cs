using MediatR;
using Stepstone.Api.Requests.Responses;

namespace Stepstone.Api.Requests
{
    public record GetQuestionByIdRequest : IRequest<GetQuestionByIdResponse>
    {
        public GetQuestionByIdRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
