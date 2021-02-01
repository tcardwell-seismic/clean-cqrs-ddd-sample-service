using FluentValidation;
using Seismic.Clean.Domain.Common.Enums;

namespace Seismic.Clean.Application.Contents.Commands.CreateContent
{
    public class CreateContentCommandValidator : AbstractValidator<CreateContentCommand>
    {
        public CreateContentCommandValidator()
        {
            RuleFor(v => v.AuthorId).NotEmpty();
            RuleFor(v => v.Repository).NotEqual(Repository.Unknown);
            RuleFor(v => v.File).Must(f => f.Length != 0);
        }
    }
}