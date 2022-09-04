using AutoMapper;
using SimpleStackOverflow.Web.Models.Post;
using PostBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Post;

namespace SimpleStackOverflow.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            //CreateMap<PostCreateModel, PostBO>().ReverseMap();
        }
    }
}
