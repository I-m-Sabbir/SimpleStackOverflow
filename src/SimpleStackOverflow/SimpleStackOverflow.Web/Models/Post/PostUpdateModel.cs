using Autofac;
using SimpleStackOverflow.Infrastructure.Services;
using PostBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Post;

namespace SimpleStackOverflow.Web.Models.Post
{
    public class PostUpdateModel
    {
        private IPostService _postService;
        private ILifetimeScope _scope;
        public PostUpdateModel(IPostService postService, ILifetimeScope scope)
        {
            _postService = postService;
            _scope = scope;
        }

        public PostUpdateModel()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTimeOffset CreateTime { get; set; }
        public PostBO Posts { get; set; }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _postService = _scope.Resolve<IPostService>();
        }

        public async Task GetPostAsync(int id)
        {
            Posts = await _postService.GetPostAsync(id);
        }
    }
}
