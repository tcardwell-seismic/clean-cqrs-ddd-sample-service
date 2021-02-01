using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Seismic.Clean.Application.Common.Exceptions;
using Seismic.Clean.Application.Common.Interfaces;

namespace Seismic.Clean.Application.Contents.Commands.PublishContent
{
    public class PublishContentCommandHandler : IRequestHandler<PublishContentCommand>
    {
        private readonly IContentRepository _contentRepository;
        private readonly ILogger _logger;

        public PublishContentCommandHandler(IContentRepository contentRepository, ILogger logger)
        {
            _contentRepository = contentRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(PublishContentCommand request, CancellationToken cancellationToken)
        {
            var content = await _contentRepository.GetContent(request.ContentId);
            if (content == null)
            {
                _logger.LogError("Content {ContentId} does not exist", request.ContentId);
                throw new NotFoundException($"Content {request.ContentId} does not exist");
            }

            content.Publish(request.VersionId);
            await _contentRepository.MergeContent(content);

            return Unit.Value;
        }
    }
}