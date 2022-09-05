using SimpleStackOverflow.Data;
using SimpleStackOverflow.Infrastructure.DbContexts;
using SimpleStackOverflow.Infrastructure.Repositories;

namespace SimpleStackOverflow.Infrastructure.UnitofWorks
{
    public class InfrastructureUnitOfWork : UnitOfWork, IInfrastructureUnitOfWork
    {
        public IPostRepository Posts { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public IVoteRepository Votes { get; private set; }
        public InfrastructureUnitOfWork(ApplicationDbContext dbContext,
            IPostRepository postRepository,
            ICommentRepository commentRepository,
            IVoteRepository voteRepository)
            : base(dbContext)
        {
            Posts = postRepository;
            Comments = commentRepository;
            Votes = voteRepository;
        }
    }
}
