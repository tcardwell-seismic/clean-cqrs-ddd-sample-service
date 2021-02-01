using System;
using MediatR;

namespace Seismic.Clean.Application.Contents.Queries.GetContent
{
    public class GetContentQuery : IRequest<GetContentQueryVm>
    {
        public Guid ContentId { get; private set; }
        public Guid VersionId { get; private set; }

        public GetContentQuery(Guid contentId, Guid versionId)
        {
            ContentId = contentId;
            VersionId = versionId;
        }
    }
}