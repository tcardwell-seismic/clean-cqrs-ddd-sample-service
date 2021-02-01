using FluentValidation;

namespace Seismic.Clean.Application.Contents.Commands.CopyContentToWorkspace
{
    public class CopyContentToWorkspaceCommandValidator : AbstractValidator<CopyContentToWorkspaceCommand>
    {
        public CopyContentToWorkspaceCommandValidator()
        {
            RuleFor(v => v.ContentId).NotEmpty();
            RuleFor(v => v.UserId).NotEmpty();
            RuleFor(v => v.VersionId).NotEmpty();
        }
    }
}