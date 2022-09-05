using SimpleStackOverflow.Infrastructure.BusinessObjects.Membership;

namespace SimpleStackOverflow.Infrastructure.BusinessObjects
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; } = null!;
        public ApplicationUser Author { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public IList<Vote>? Votes { get; set; }
        public Post Post { get; set; } = null!;
        public int PostId { get; set; }
        public bool IsVerified { get; set; }
        public DateTimeOffset CreateTime { get; set; }
    }
}
