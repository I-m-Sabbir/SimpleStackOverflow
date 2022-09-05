using Autofac;
using SimpleStackOverflow.Infrastructure.Services;
using CommentBO = SimpleStackOverflow.Infrastructure.BusinessObjects.Comment;

namespace SimpleStackOverflow.Web.Models.Comment
{
    public class CommentUpdateModel
    {
        private ICommentService _commenService;
        private ILifetimeScope _scope;

        public CommentUpdateModel(ICommentService commenService, ILifetimeScope scope)
        {
            _commenService = commenService;
            _scope = scope;
        }

        public CommentUpdateModel()
        {

        }

        public int Id { get; set; }
        public string CommentText { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public int PostId { get; set; }
        public bool IsVerified { get; set; }
        public DateTimeOffset CreateTime { get; set; }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _commenService = _scope.Resolve<ICommentService>();
        }

        public async Task GetCommentAsync(int id)
        {
            var model = await _commenService.GetAsync(id);
            Id = model.Id;
            CommentText = model.CommentText;
            AuthorId = model.AuthorId;
            PostId = model.PostId;
            IsVerified = model.IsVerified;
            CreateTime = model.CreateTime;
        }

        public async Task UpdateCommentAsync()
        {
            var model = Map();
            await _commenService.UpdateAsync(model);
        }

        private CommentBO Map()
        {
            return new CommentBO
            {
                Id = Id,
                CommentText = CommentText,
                AuthorId = AuthorId,
                PostId = PostId,
                IsVerified = IsVerified,
                CreateTime = CreateTime
            };
        }
    }
}
