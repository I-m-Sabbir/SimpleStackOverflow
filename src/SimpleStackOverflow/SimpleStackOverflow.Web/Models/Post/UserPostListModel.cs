using Autofac;
using PostBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Post;
using SimpleStackOverflow.Infrastructure.Services;
using SimpleStackOverflow.Membership.Services;

namespace SimpleStackOverflow.Web.Models.Post
{
    public class UserPostListModel
    {
        private IPostService _postService;
        private UserManager _userManager;
        private ILifetimeScope _Scope;

        public UserPostListModel(IPostService postService, ILifetimeScope scope, UserManager userManager)
        {
            _postService = postService;
            _Scope = scope;
            _userManager = userManager;
        }

        public UserPostListModel()
        {

        }

        public Guid UserId { get; set; }
        public string Pagination { get; set; }
        public int PageNumber { get; set; }
        public List<PostBO>? Posts { get; set; }

        public void Resolve(ILifetimeScope scope)
        {
            _Scope = scope;
            _postService = _Scope.Resolve<IPostService>();
        }

        public async Task GetUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            UserId = user.Id;
        }

        public async Task<(int total, int totalDisplay, List<PostBO>)> PostListAsync()
        {
            var data = await _postService.GetPostsAsync(UserId, PageNumber, 2);
            return (data.total, data.totalDisplay, data.Item3);
        }
    }
}
