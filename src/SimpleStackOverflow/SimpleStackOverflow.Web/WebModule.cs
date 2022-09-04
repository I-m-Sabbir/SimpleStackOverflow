using Autofac;
using SimpleStackOverflow.Web.Models;
using SimpleStackOverflow.Web.Models.Post;

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

            base.Load(builder);
        }
    }
}
