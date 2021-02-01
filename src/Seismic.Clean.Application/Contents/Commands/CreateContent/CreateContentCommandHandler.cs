using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seismic.Clean.Application.Common.Exceptions;
using Seismic.Clean.Application.Common.Interfaces;
using Seismic.Clean.Domain.Common.ValueObjects;
using Seismic.Clean.Domain.ContentAggregate;

namespace Seismic.Clean.Application.Contents.Commands.CreateContent
{
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommand, Content>
    {
        private readonly IContentRepository _contentRepository;

        private readonly IBlobStorageService _blobStorageService;

        public CreateContentCommandHandler(
        IContentRepository contentRepository,
        IBlobStorageService blobStorageService)
        {
            _contentRepository = contentRepository;
            _blobStorageService = blobStorageService;
        }

        public async Task<Content> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
            var content = new Content(request.File.Name, ContentFormat.From(request.File.Extension), request.Repository);
            var contentVersion = content.AddContentVersion(request.AuthorId, true);

            await _contentRepository.MergeContent(content);

            // Upload to blob storage --> See async solution for this in Seismic.Clean.Application.Contents.EventHandlers
            await _blobStorageService.UploadFile(request.File, contentVersion.BlobId);
            return content;
        }
    }
}