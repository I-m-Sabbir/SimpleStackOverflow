using AutoMapper;
using PostBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Post;
using PostEO = SimpleStackOverflow.Infrastructure.Entities.Post;
using CommentBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Comment;
using CommentEO = SimpleStackOverflow.Infrastructure.Entities.Comment;
using VoteBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Vote;
using VoteEO = SimpleStackOverflow.Infrastructure.Entities.Vote;
using ApplicationUserBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Membership.ApplicationUser;
using ApplicationUserEO = SimpleStackOverflow.Infrastructure.Entities.Membership.ApplicationUser;


namespace SimpleStackOverflow.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<PostEO, PostBO>()
                .ReverseMap();

            CreateMap<CommentEO, CommentBO>()
                .ReverseMap();

            CreateMap<VoteEO, VoteBO>()
                .ReverseMap();

            CreateMap<ApplicationUserEO, ApplicationUserBO>()
                .ReverseMap();
        }
    }
}
