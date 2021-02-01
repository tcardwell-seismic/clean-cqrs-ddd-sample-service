using AutoMapper;
using Seismic.Clean.Domain.ContentAggregate;

namespace Seismic.Clean.Application.Contents.Queries.GetContent
{
    public class GetContentQueryProfile : Profile
    {
        public GetContentQueryProfile()
        {
            CreateMap<Content, GetContentQueryVm>()
                .ForMember(vm => vm.ContentId, opt => opt.MapFrom(c => c.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(vm => vm.Repository, opt => opt.MapFrom(c => c.Repository))
                .ForMember(vm => vm.VersionId, opt => opt.MapFrom(c => c.GetCurrentVersion().Id))
                .ForMember(vm => vm.IsActive, opt => opt.MapFrom(c => c.GetCurrentVersion().IsActive))
                .ForMember(vm => vm.IsPromoted, opt => opt.MapFrom(c => c.GetCurrentVersion().IsPromoted))
                .ForMember(vm => vm.IsPublished, opt => opt.MapFrom(c => c.GetCurrentVersion().IsPublished))
                .ForMember(vm => vm.VersionNumber, opt => opt.MapFrom(c => c.GetCurrentVersion().VersionNumber.ToString()))
                .ForMember(vm => vm.AverageRating, opt => opt.MapFrom(c => c.GetCurrentVersion().GetAverageRating()))
                .ForMember(vm => vm.VersionStatus, opt => opt.MapFrom(c => c.GetCurrentVersion().VersionStatus))
                .ForMember(vm => vm.AuthorId, opt => opt.MapFrom(c => c.GetCurrentVersion().AuthorId))
                .ForMember(vm => vm.Created, opt => opt.MapFrom(c => c.GetCurrentVersion().Created));
        }
    }
}