using Autofac;
using Microsoft.AspNetCore.Hosting;
using SimpleStackOverflow.Infrastructure.DbContexts;
using SimpleStackOverflow.Infrastructure.Repositories;
using SimpleStackOverflow.Infrastructure.Services;
using SimpleStackOverflow.Infrastructure.UnitofWorks;

namespace SimpleStackOverflow.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InfrastructureModule(string connectionString, string migrationAssemblyName,
            IWebHostEnvironment webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<InfrastructureUnitOfWork>().As<IInfrastructureUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommentRepository>().As<ICommentRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CommentService>().As<ICommentService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostRepository>().As<IPostRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PostService>().As<IPostService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<VoteRepository>().As<IVoteRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<VoteService>().As<IVoteService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
