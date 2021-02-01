using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Seismic.Clean.Application.Common.Exceptions;
using Seismic.Clean.Application.Common.Interfaces;

namespace Seismic.Clean.Application.Contents.Commands.CreateContentVersion
{
    public class CreateContentVersionCommandHandler : IRequestHandler<CreateContentVersionCommand>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IBlobStorageService _blobStorageService;
        private readonly ILogger _logger;

        public CreateContentVersionCommandHandler(
            IContentRepository contentRepository,
            IBlobStorageService blobStorageService,
            ILogger logger)
        {
            _contentRepository = contentRepository;
            _blobStorageService = blobStorageService;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateContentVersionCommand request, CancellationToken cancellationToken)
        {
            var content = await _contentRepository.GetContent(request.ContentId);
            if (content == null)
            {
                _logger.LogError("Content {ContentId} does not exist", request.ContentId);
                throw new NotFoundException($"Content {request.ContentId} does not exist");
            }

            // Add the new version
            var contentVersion = content.AddContentVersion(request.AuthorId, request.IsMajor);
            await _contentRepository.MergeContent(content);

            // Upload to blob storage --> See async solution for this in Seismic.Clean.Application.Contents.EventHandlers
            await _blobStorageService.UploadFile(request.File, contentVersion.Id);

            return Unit.Value;
        }
    }
}