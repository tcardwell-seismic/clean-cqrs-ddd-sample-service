using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Seismic.Clean.Application.Common.Exceptions;
using Seismic.Clean.Application.Common.Interfaces;

namespace Seismic.Clean.Application.Contents.Queries.GetContent
{
    public class GetContentQueryHandler : IRequestHandler<GetContentQuery, GetContentQueryVm>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetContentQueryHandler(IContentRepository contentRepository, ILogger logger, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetContentQueryVm> Handle(GetContentQuery request, CancellationToken cancellationToken)
        {
            var content = await _contentRepository.GetContent(request.ContentId);
            if (content == null)
            {
                _logger.LogError("Content {ContentId} does not exist", request.ContentId);
                throw new NotFoundException($"Content {request.ContentId} does not exist");
            }

            return _mapper.Map<GetContentQueryVm>(content);
        }
    }
}