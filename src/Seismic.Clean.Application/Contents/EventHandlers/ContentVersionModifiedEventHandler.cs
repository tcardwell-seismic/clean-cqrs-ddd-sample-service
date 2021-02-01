using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Seismic.Clean.Application.Common.Models;
using Seismic.Clean.Domain.Common.Events;

namespace Seismic.Clean.Application.Contents.EventHandlers
{
    public class ContentVersionModifiedEventHandler : INotificationHandler<DomainEventNotification<ContentVersionModifiedEvent>>
    {
        /// <summary>
        /// For this sample repo we have nothing to do for these events, but some options could be:
        /// - Write a message to a private (i.e. owned by this service) message broker to start asynchronous work
        /// - Write a message to a shared (i.e. used by all services) message broker for loosely coupled eventing, such as auditing
        /// - Update an index for your read stores, if you use separate read and write persistence technologies
        /// </summary>
        public Task Handle(DomainEventNotification<ContentVersionModifiedEvent> notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}