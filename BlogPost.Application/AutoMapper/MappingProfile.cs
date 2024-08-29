using AutoMapper;
using BlogManagement.Application.Model;
using BlogManagement.Core.Entity;

namespace BlogManagement.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, BlogPostModel>().ReverseMap();           
        }
    }
}
