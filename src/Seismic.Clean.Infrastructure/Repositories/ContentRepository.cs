using System;
using System.Threading.Tasks;
using Seismic.Clean.Application.Common.Interfaces;
using Seismic.Clean.Domain.ContentAggregate;

namespace Seismic.Clean.Infrastructure.Repositories
{
    /// <summary>
    /// Not implemented, only showcasing what the class would look like
    /// </summary>
    public class ContentRepository : IContentRepository
    {
        private readonly IDomainEventService _domainEventService;

        public ContentRepository(IDomainEventService domainEventService)
        {
            _domainEventService = domainEventService;
        }

        public Task<Content> GetContent(Guid id)
        {
            throw new NotImplementedException();

            // Pseudologic
            /*
            using (var sqlConnection = new SqlConnection("ISeismicContext.Tenant.ConnectionString"))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleAsync<Content>("SELECT_SQL_STATEMENT", id);
            }
            */
        }

        public Task MergeContent(Content content)
        {
            throw new NotImplementedException();

            // Pseudologic
            /*
            using (var connection = new SqlConnection("ISeismicContext.Tenant.ConnectionString"))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync("MERGE_SQL_STATEMENT", content);
            }

            // NOTE: This logic would likely need to be embedded within the application's individual commands, however
            // if you are using EF Core you can get away with this. Leaving this here for now
            content.DomainEvents.ForEach(async de => await _domainEventService.Publish(de));
            */
        }
    }
}