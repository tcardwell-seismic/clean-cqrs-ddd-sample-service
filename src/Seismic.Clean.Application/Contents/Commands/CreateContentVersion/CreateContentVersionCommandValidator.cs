using FluentValidation;

namespace Seismic.Clean.Application.Contents.Commands.CreateContentVersion
{
    public class CreateContentVersionCommandValidator : AbstractValidator<CreateContentVersionCommand>
    {
        public CreateContentVersionCommandValidator()
        {
            RuleFor(v => v.AuthorId).NotEmpty();
            RuleFor(v => v.ContentId).NotEmpty();
            RuleFor(v => v.File).Must(f => f.Length != 0);
        }
    }
}