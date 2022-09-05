using Autofac;
using SimpleStackOverflow.Web.Models;
using SimpleStackOverflow.Web.Models.Comment;
using SimpleStackOverflow.Web.Models.Post;
using SimpleStackOverflow.Web.Models.Vote;

namespace SimpleStackOverflow.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginModel>().AsSelf();
            builder.RegisterType<RegisterModel>().AsSelf();

            builder.RegisterType<PostCreateModel>().AsSelf();
            builder.RegisterType<UserPostListModel>().AsSelf();
            builder.RegisterType<PostUpdateModel>().AsSelf();
            builder.RegisterType<PostListModel>().AsSelf();

            builder.RegisterType<CreateCommentModel>().AsSelf();
            builder.RegisterType <CommentUpdateModel>().AsSelf();

            builder.RegisterType<VoteCreateModel>().AsSelf();

            base.Load(builder);
        }
    }
}
