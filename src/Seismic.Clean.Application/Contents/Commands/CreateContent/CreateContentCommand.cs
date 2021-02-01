using System;
using System.IO;
using MediatR;
using Seismic.Clean.Domain.Common.Enums;
using Seismic.Clean.Domain.ContentAggregate;

namespace Seismic.Clean.Application.Contents.Commands.CreateContent
{
    public class CreateContentCommand : IRequest<Content>
    {
        public FileInfo File { get; private set; }
        public Guid AuthorId { get; private set; }
        public Repository Repository { get; private set; }

        public CreateContentCommand(FileInfo file, Guid authorId, Repository repository)
        {
            File = file;
            AuthorId = authorId;
            Repository = repository;
        }
    }
}