using System;
using System.IO;
using MediatR;

namespace Seismic.Clean.Application.Contents.Commands.CreateContentVersion
{
    public class CreateContentVersionCommand : IRequest
    {
        public Guid ContentId { get; private set; }
        public Guid AuthorId { get; private set; }
        public bool IsMajor { get; private set; }
        public FileInfo File { get; private set; }

        public CreateContentVersionCommand(
            Guid contentId,
            Guid authorId,
            bool isMajor,
            FileInfo file)
        {
            ContentId = contentId;
            AuthorId = authorId;
            IsMajor = isMajor;
            File = file;
        }
    }
}