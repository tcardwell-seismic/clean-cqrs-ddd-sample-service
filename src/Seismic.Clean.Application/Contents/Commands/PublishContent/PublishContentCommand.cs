using System;
using MediatR;

namespace Seismic.Clean.Application.Contents.Commands.PublishContent
{
    public class PublishContentCommand : IRequest
    {
        public Guid ContentId { get; private set; }
        public Guid VersionId { get; private set; }

        public PublishContentCommand(Guid contentId, Guid versionId)
        {
            ContentId = contentId;
            VersionId = versionId;
        }
    }
}