using Autofac;
using SimpleStackOverflow.Infrastructure.Services;
using PostBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Post;

namespace SimpleStackOverflow.Web.Models.Post
{
    public class PostListModel
    {
        private IPostService _postService;
        private ILifetimeScope _scope;

        public PostListModel(IPostService postService, ILifetimeScope scope)
        {
            _postService = postService;
            _scope = scope;
        }

        public PostListModel()
        {

        }

        public string Pagination { get; set; }
        public int PageNumber { get; set; }
        public List<PostBO>? Posts { get; set; }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _postService = _scope.Resolve<IPostService>();
        }

        public async Task<(int total, int totalDisplay, List<PostBO>)> PostListAsync()
        {
            var data = await _postService.GetAllPostsAsync(PageNumber, 2);
            return (data.total, data.totalDisplay, data.Item3);
        }
    }
}
