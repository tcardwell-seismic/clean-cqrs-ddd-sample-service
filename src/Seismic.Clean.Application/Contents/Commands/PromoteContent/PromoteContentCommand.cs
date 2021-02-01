using System;
using MediatR;

namespace Seismic.Clean.Application.Contents.Commands.PromoteContent
{
    public class PromoteContentCommand : IRequest
    {
        public Guid ContentId { get; private set; }
        public Guid VersionId { get; private set; }

        public PromoteContentCommand(Guid contentId, Guid versionId)
        {
            ContentId = contentId;
            VersionId = versionId;
        }
    }
}