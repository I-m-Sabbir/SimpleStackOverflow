using Autofac;
using SimpleStackOverflow.Web.Models;

namespace SimpleStackOverflow.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginModel>().AsSelf();
            builder.RegisterType<RegisterModel>().AsSelf();

            base.Load(builder);
        }
    }
}
