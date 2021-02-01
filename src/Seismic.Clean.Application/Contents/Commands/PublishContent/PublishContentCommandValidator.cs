using FluentValidation;

namespace Seismic.Clean.Application.Contents.Commands.PublishContent
{
    public class PublishContentCommandValidator : AbstractValidator<PublishContentCommand>
    {
        public PublishContentCommandValidator()
        {
            RuleFor(x => x.ContentId).NotEmpty();
            RuleFor(x => x.VersionId).NotEmpty();
        }
    }
}