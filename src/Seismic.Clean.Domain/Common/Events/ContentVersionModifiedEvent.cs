using Seismic.Clean.Domain.ContentAggregate;

namespace Seismic.Clean.Domain.Common.Events
{
    public class ContentVersionModifiedEvent : DomainEvent
    {
        public readonly Content Content;
        public readonly ContentVersion ContentVersion;
        public ContentVersionModifiedEvent(Content content, ContentVersion contentVersion) : base()
        {
            Content = content;
            ContentVersion = contentVersion;
        }
    }
}