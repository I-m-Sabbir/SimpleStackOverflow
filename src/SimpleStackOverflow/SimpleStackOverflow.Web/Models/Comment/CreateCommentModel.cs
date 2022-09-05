using Autofac;
using SimpleStackOverflow.Infrastructure.Services;
using SimpleStackOverflow.Membership.Services;
using CommentBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Comment;

namespace SimpleStackOverflow.Web.Models.Comment
{
    public class CreateCommentModel
    {
        private ICommentService _commentService;
        private UserManager _userManager;
        private ILifetimeScope _scope;

        public CreateCommentModel(ICommentService commentService, UserManager userManager, ILifetimeScope scope)
        {
            _commentService = commentService;
            _userManager = userManager;
            _scope = scope;
        }

        public CreateCommentModel()
        {

        }

        public int Id { get; set; }
        public string CommentText { get; set; }
        public int PostId { get; set; }
        public Guid AuthorId { get; set; }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _commentService = _scope.Resolve<ICommentService>();
            _userManager = _scope.Resolve<UserManager>();
        }

        public async Task GetAuthor(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            AuthorId = user.Id;
        }

        public async Task CreateCommentAsync()
        {
            var model = Map();
            await _commentService.CreateAsync(model);
        }

        public async Task<CommentBO> GetCommentAsync(int id)
        {
            return await _commentService.GetAsync(id);
        }

        public async Task VerifyCommentAsync(int id)
        {
            var post = await GetCommentAsync(id);
            post.IsVerified = true;
            await _commentService.VerifyCommentAsync(post);
        }

        public async Task CencelVerificationAsync(int id)
        {
            var post = await GetCommentAsync(id);
            post.IsVerified = false;
            await _commentService.VerifyCommentAsync(post);
        }

        public async Task CommentDeleteAsync(int id)
        {
            await _commentService.DeleteAsync(id);
        }

        private CommentBO Map()
        {
            return new CommentBO
            {
                AuthorId = AuthorId,
                PostId = PostId,
                CommentText = CommentText,
                CreateTime = DateTime.Now,
                IsVerified = false
            };
        }
    }
}
