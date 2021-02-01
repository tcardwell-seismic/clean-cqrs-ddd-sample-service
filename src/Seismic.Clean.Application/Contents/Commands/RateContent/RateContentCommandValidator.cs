using FluentValidation;

namespace Seismic.Clean.Application.Contents.Commands.RateContent
{
    public class RateContentCommandValidator : AbstractValidator<RateContentCommand>
    {
        public RateContentCommandValidator()
        {
            RuleFor(x => x.ContentId).NotEmpty();
            RuleFor(x => x.VersionId).NotEmpty();
            RuleFor(x => x.Rating).Must(r => r.RatingValue >= 0 && r.RatingValue <= 5);
        }
    }
}