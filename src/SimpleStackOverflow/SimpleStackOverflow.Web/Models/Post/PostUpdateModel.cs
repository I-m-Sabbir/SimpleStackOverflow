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
        public Guid AuthorId { get; set; }
        public PostBO Posts { get; set; }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _postService = _scope.Resolve<IPostService>();
        }

        public async Task GetPostWithIncludeAsync(int id)
        {
            Posts = await _postService.GetPostWithIncludeAsync(id);
        }

        public async Task GetPostAsync(int id)
        {
            var post = await _postService.GetPostAsync(id);
            Id = post.Id;
            Title = post.Title;
            Description = post.Description;
            AuthorId = post.AuthorId;
            CreateTime = post.CreateTime;
        }

        public async Task UpdateAsync()
        {
            var model = Map();
            await _postService.UpdateAsync(model);
        }

        private PostBO Map()
        {
            return new PostBO
            {
                Id = Id,
                Title = Title,
                Description = Description,
                AuthorId = AuthorId,
                CreateTime = CreateTime,
            };
        }
    }
}
