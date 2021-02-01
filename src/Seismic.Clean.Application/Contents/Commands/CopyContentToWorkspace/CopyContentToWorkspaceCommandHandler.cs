using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Seismic.Clean.Application.Common.Exceptions;
using Seismic.Clean.Application.Common.Interfaces;
using Seismic.Clean.Domain.Common.Enums;
using Seismic.Clean.Domain.ContentAggregate;

namespace Seismic.Clean.Application.Contents.Commands.CopyContentToWorkspace
{
    public class CopyContentToWorkspaceCommandHandler : IRequestHandler<CopyContentToWorkspaceCommand>
    {
        private readonly IContentRepository _contentRepository;

        private readonly IBlobStorageService _blobStorageService;
        private readonly ILogger _logger;

        public CopyContentToWorkspaceCommandHandler(
            IContentRepository contentRepository,
            IBlobStorageService blobStorageService,
            ILogger logger)
        {
            _contentRepository = contentRepository;
            _blobStorageService = blobStorageService;
            _logger = logger;
        }

        public async Task<Unit> Handle(CopyContentToWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var content = await _contentRepository.GetContent(request.ContentId);
            if (content == null)
            {
                _logger.LogError("Content {ContentId} does not exist", request.ContentId);
                throw new NotFoundException($"Content {request.ContentId} does not exist");
            }

            var contentVersion = content.GetVersion(request.VersionId);
            if (contentVersion == null)
            {
                _logger.LogError("Version {VersionId} for content {ContentId} does not exist", request.VersionId, request.ContentId);
                throw new NotFoundException($"Version {request.VersionId} for content {request.ContentId} does not exist");
            }

            // Save new content
            var copiedContent = new Content(content.Name, content.ContentFormat, Repository.Workspace);
            var copiedContentVersion = copiedContent.AddContentVersion(request.UserId, true);
            await _contentRepository.MergeContent(copiedContent);

            var file = await _blobStorageService.DownloadFile(contentVersion.Id);
            await _blobStorageService.UploadFile(file, copiedContentVersion.Id);

            return Unit.Value;
        }
    }
}