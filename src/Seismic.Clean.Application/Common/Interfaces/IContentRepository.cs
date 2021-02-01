using System;
using System.Threading.Tasks;
using Seismic.Clean.Domain.ContentAggregate;

namespace Seismic.Clean.Application.Common.Interfaces
{
    public interface IContentRepository
    {
        /// <summary>
        /// Retrieves a single piece of content
        /// </summary>
        /// <param name="id">ContentId</param>
        Task<Content> GetContent(Guid id);

        /// <summary>
        /// Create or update a piece of content
        /// </summary>
        /// <param name="content">The content object to create or update</param>
        Task MergeContent(Content content);
    }
}