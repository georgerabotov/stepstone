using FluentValidation;
using Stepstone.Api.Extensions;

namespace Stepstone.Api.Requests.Validators
{
    public class GetQuestionByIdValidator : AbstractValidator<GetQuestionByIdRequest>
    {
        public GetQuestionByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .Must(id => ValidationExtension.BeAGuid(id)).WithMessage("Invalid Guid Format");
        }
    }
}
