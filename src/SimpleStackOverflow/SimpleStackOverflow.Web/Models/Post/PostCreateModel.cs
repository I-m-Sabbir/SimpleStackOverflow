using Autofac;
using SimpleStackOverflow.Infrastructure.Services;
using SimpleStackOverflow.Membership.Services;
using System.ComponentModel.DataAnnotations;
using PostBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Post;

namespace SimpleStackOverflow.Web.Models.Post
{
    public class PostCreateModel
    {
        private UserManager _userManager;
        private IPostService _postService;
        private ILifetimeScope _scope;

        public PostCreateModel(UserManager userManager, IPostService postService,
            ILifetimeScope scope)
        {
            _postService = postService;
            _userManager = userManager;
            _scope = scope;
        }

        public PostCreateModel()
        {

        }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
        public DateTimeOffset CreateTime { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _postService = _scope.Resolve<IPostService>();
            _userManager = _scope.Resolve<UserManager>();
        }
        
        public async Task GetUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            AuthorId = user.Id;
        }

        public async Task CreatePostAsync()
        {
            var post = Map();
            await _postService.CreatePostAsync(post);
        }

        private PostBO Map()
        {
            return new PostBO
            {
                Title = Title,
                Description = Description,
                CreateTime = CreateTime,
                AuthorId = AuthorId
            };
        }

    }
}
