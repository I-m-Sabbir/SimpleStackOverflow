using SimpleStackOverflow.Data;
using SimpleStackOverflow.Infrastructure.Entities.Membership;

namespace SimpleStackOverflow.Infrastructure.Entities
{
    public class Comment : IEntity<int>
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
