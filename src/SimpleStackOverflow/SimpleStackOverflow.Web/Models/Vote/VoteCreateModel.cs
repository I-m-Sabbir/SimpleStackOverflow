using Autofac;
using SimpleStackOverflow.Infrastructure.Services;
using SimpleStackOverflow.Membership.Services;
using VoteBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Vote;

namespace SimpleStackOverflow.Web.Models.Vote
{
    public class VoteCreateModel
    {
        private IVoteService _voteService;
        private ILifetimeScope _scope;
        private UserManager _userManager;

        public VoteCreateModel(IVoteService voteService, ILifetimeScope scope, UserManager userManager)
        {
            _voteService = voteService;
            _scope = scope;
            _userManager = userManager;
        }

        public VoteCreateModel()
        {

        }

        public int? CommentId { get; set; }
        public int? PostId { get; set; }
        public Guid AuthorId { get; set; }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _userManager = _scope.Resolve<UserManager>();
            _voteService = _scope.Resolve<VoteService>();
        }

        public async Task GetAuthorAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            AuthorId = user.Id;
        }

        public async Task VoteCommentAsync()
        {
            var model = Map();
            await _voteService.VoteAsync(model);
        }

        public async Task RemoveVoteAsync(int commentId)
        {
            await _voteService.DeleteVoteAsync(commentId, AuthorId);
        }

        public VoteBO Map()
        {
            return new VoteBO
            {
                CommentId = CommentId,
                PostId = PostId,
                AuthorId = AuthorId,
            };
        }
    }
}
