using FluentValidation;

namespace Seismic.Clean.Application.Contents.Commands.PromoteContent
{
    public class PromoteContentCommandValidator : AbstractValidator<PromoteContentCommand>
    {
        public PromoteContentCommandValidator()
        {
            RuleFor(x => x.ContentId).NotEmpty();
            RuleFor(x => x.VersionId).NotEmpty();
        }
    }
}