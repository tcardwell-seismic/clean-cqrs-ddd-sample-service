using FluentValidation;

namespace Seismic.Clean.Application.Contents.Commands.DeleteContent
{
    public class DeleteContentCommandValidator : AbstractValidator<DeleteContentCommand>
    {
        public DeleteContentCommandValidator()
        {
            RuleFor(v => v.ContentId).NotEmpty();
            RuleFor(v => v.VersionId).NotEmpty();
        }
    }
}