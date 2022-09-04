
using SimpleStackOverflow.Data;
using SimpleStackOverflow.Infrastructure.Entities.Membership;

namespace SimpleStackOverflow.Infrastructure.Entities
{
    public class Vote : IEntity<int>
    {
        public int Id { get; set; }
        public ApplicationUser Author { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
    }
}
