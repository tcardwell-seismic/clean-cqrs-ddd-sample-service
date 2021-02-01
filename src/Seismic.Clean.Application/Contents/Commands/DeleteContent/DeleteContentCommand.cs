using System;
using MediatR;

namespace Seismic.Clean.Application.Contents.Commands.DeleteContent
{
    public class DeleteContentCommand : IRequest
    {
        public Guid ContentId { get; private set; }
        public Guid VersionId { get; private set; }

        public DeleteContentCommand(Guid contentId, Guid versionId)
        {
            ContentId = contentId;
            VersionId = versionId;
        }
    }
}