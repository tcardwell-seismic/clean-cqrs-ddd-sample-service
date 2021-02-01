using Seismic.Clean.Domain.ContentAggregate;

namespace Seismic.Clean.Domain.Common.Events
{
    public class ContentVersionCreatedEvent : DomainEvent
    {
        public readonly Content Content;
        public readonly ContentVersion ContentVersion;
        public ContentVersionCreatedEvent(Content content, ContentVersion contentVersion) : base()
        {
            Content = content;
            ContentVersion = contentVersion;
        }
    }
}