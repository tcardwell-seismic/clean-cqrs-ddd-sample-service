using System;
using System.Collections.Generic;
using System.Linq;
using Seismic.Clean.Domain.Common.Enums;
using Seismic.Clean.Domain.Common.ValueObjects;

namespace Seismic.Clean.Domain.ContentAggregate
{
    /// <summary>
    /// Aggregate Root for the content model
    /// </summary>
    /// <remarks>
    /// 1
    /// </remarks>
    public class Content
    {
        public Guid Id { get; private set; } // ContentId in Seismic's platform
        public string Name { get; private set; }
        public Repository Repository { get; private set; }
        public ContentFormat ContentFormat { get; private set; }
        public List<ContentVersion> Versions { get; private set; }

        public Content(string name, ContentFormat format, Repository repository)
        {
            Id = Guid.NewGuid();
            Name = name;
            Repository = repository;
            ContentFormat = format;
            Versions = new List<ContentVersion>();
        }

        public ContentVersion AddContentVersion(Guid authorId, bool isMajor)
        {
            var maxVersion = Versions.OrderByDescending(v => v.VersionNumber).Select(v => v.VersionNumber).First();

            var versionNumber = VersionNumber.InitialVersion;
            if (maxVersion != null)
            {
                versionNumber = isMajor ? maxVersion.GetNextMajorVersion() : maxVersion.GetNextMinorVersion();
            }

            var newContentVersion = new ContentVersion(versionNumber, authorId);
            Versions.Add(newContentVersion);

            return newContentVersion;
        }

        public void AddRating(Guid versionId, Rating rating)
        {
            Versions.Single(v => v.Id == versionId).AddRating(rating);
        }

        public void DeactivateVersion(Guid versionId)
        {
            Versions.Single(v => v.Id == versionId).Deactivate();
        }

        public ContentVersion GetCurrentVersion()
        {
            return Versions.Where(v => v.IsActive).OrderByDescending(v => v.VersionNumber).First();
        }

        public ContentVersion GetVersion(Guid versionId)
        {
            return Versions.Where(v => v.Id == versionId).First();
        }

        public ContentVersion GetVersion(VersionNumber versionNumber)
        {
            return Versions.Where(v => v.VersionNumber == versionNumber).First();
        }

        public void Promote(Guid versionId)
        {
            Versions.Single(v => v.Id == versionId).Promote();
        }

        public void Publish(Guid versionId)
        {
            Versions.ForEach(v => v.Deactivate());
            Versions.Single(v => v.Id == versionId).Publish();
        }

        public void Rate(Guid versionId, Rating rating)
        {
            Versions.Single(v => v.Id == versionId).AddRating(rating);
        }
    }
}