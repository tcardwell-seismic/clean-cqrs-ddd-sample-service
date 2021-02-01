using System;
using System.Collections.Generic;
using System.Linq;
using Seismic.Clean.Domain.Common.Enums;
using Seismic.Clean.Domain.Common.Exceptions;
using Seismic.Clean.Domain.Common.ValueObjects;

namespace Seismic.Clean.Domain.ContentAggregate
{
    public class ContentVersion
    {
        public Guid Id { get; private set; } // VersionId in Seismic's platform
        public Guid BlobId { get; private set; } // SourceBlobId in Seismic's platform
        public bool IsActive { get; private set; }
        public bool IsPromoted { get; private set; }
        public bool IsPublished => VersionStatus == VersionStatus.Published;
        public VersionNumber VersionNumber { get; private set; }
        public List<Rating> Ratings { get; private set; }
        public VersionStatus VersionStatus { get; private set; }
        public Guid AuthorId { get; private set; }
        public DateTime Created { get; private set; }

        internal ContentVersion(VersionNumber versionNumber, Guid ownerId)
        {
            BlobId = Guid.NewGuid();
            IsActive = true;
            VersionNumber = versionNumber;
            VersionStatus = VersionStatus.Draft;
            AuthorId = ownerId;
            Created = DateTime.UtcNow;
            Ratings = new List<Rating>();
        }

        public double GetAverageRating()
        {
            return Ratings.Select(x => x.RatingValue).Average();
        }

        internal void Activate()
        {
            IsActive = true;
        }

        internal void AddRating(Rating rating)
        {
            Ratings.Add(rating);
        }

        internal void CompleteDraft()
        {
            VersionStatus = VersionStatus.ReadyForPublish;
        }

        internal void Deactivate()
        {
            VersionStatus = VersionStatus.ReadyForPublish;
            IsActive = false;
            IsPromoted = false;
        }

        internal void Promote()
        {
            if (!IsActive)
            {
                throw new InvalidVersionOperationException("Cannot promote inactive content");
            }

            if (VersionStatus == VersionStatus.Draft)
            {
                throw new InvalidVersionOperationException("Cannot promote draft content");
            }

            VersionStatus = VersionStatus.Published;
            IsPromoted = true;
        }

        internal void Publish()
        {
            IsActive = true;
            VersionStatus = VersionStatus.Published;
        }
    }
}