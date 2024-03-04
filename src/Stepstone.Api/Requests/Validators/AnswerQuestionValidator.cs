using FluentValidation;
using Stepstone.Api.Extensions;

namespace Stepstone.Api.Requests.Validators
{
    public class AnswerQuestionValidator : AbstractValidator<AnswerQuestionRequest>
    {
        public AnswerQuestionValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .Must(id => ValidationExtension.BeAGuid(id)).WithMessage("Invalid Guid Format");

            RuleFor(x => x.Answer)
                .NotEmpty()
                .NotNull();
        }
    }
}
