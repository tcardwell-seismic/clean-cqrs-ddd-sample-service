using System.Threading.Tasks;
using Seismic.Clean.Domain.Common.Events;

namespace Seismic.Clean.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}