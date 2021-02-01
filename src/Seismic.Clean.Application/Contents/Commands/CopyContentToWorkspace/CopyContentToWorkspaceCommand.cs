using System;
using MediatR;

namespace Seismic.Clean.Application.Contents.Commands.CopyContentToWorkspace
{
    public class CopyContentToWorkspaceCommand : IRequest
    {
        public Guid ContentId { get; private set; }
        public Guid VersionId { get; private set; }
        public Guid UserId { get; private set; }

        public CopyContentToWorkspaceCommand(Guid contentId, Guid versionId, Guid userId)
        {
            ContentId = contentId;
            VersionId = versionId;
            UserId = userId;
        }
    }
}