using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Seismic.Clean.Application.Common.Exceptions;
using Seismic.Clean.Application.Common.Interfaces;
using Seismic.Clean.Domain.Common.ValueObjects;

namespace Seismic.Clean.Application.Contents.Commands.RateContent
{
    public class RateContentCommand : IRequest
    {
        public class RateContentCommandHandler : IRequestHandler<RateContentCommand>
        {
            private readonly IContentRepository _contentRepository;
            private readonly ILogger _logger;

            public RateContentCommandHandler(IContentRepository contentRepository, ILogger logger)
            {
                _contentRepository = contentRepository;
                _logger = logger;
            }

            public async Task<Unit> Handle(RateContentCommand request, CancellationToken cancellationToken)
            {
                var content = await _contentRepository.GetContent(request.ContentId);
                if (content == null)
                {
                    _logger.LogError("Content {ContentId} does not exist", request.ContentId);
                    throw new NotFoundException($"Content {request.ContentId} does not exist");
                }

                content.AddRating(request.VersionId, request.Rating);
                await _contentRepository.MergeContent(content);

                return Unit.Value;
            }
        }

        public Guid ContentId { get; private set; }
        public Guid VersionId { get; private set; }
        public Rating Rating { get; private set; }

        public RateContentCommand(Guid contentId, Guid versionId, int rating)
        {
            ContentId = contentId;
            VersionId = versionId;
            Rating = Rating.From(rating);
        }
    }
}