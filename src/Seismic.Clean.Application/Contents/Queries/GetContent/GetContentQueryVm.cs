using System;

namespace Seismic.Clean.Application.Contents.Queries.GetContent
{
    public class GetContentQueryVm
    {
        public Guid ContentId { get; set; }
        public Guid VersionId { get; set; }
        public string Name { get; set; }
        public int Repository { get; set; }
        public string ContentFormat { get; set; }
        public bool IsActive { get; set; }
        public bool IsPromoted { get; set; }
        public bool IsPublished { get; set; }
        public string VersionNumber { get; set; }
        public double AverageRating { get; set; }
        public int VersionStatus { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime Created { get; set; }
    }
}