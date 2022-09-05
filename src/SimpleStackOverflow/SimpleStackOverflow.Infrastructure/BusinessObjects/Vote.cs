using SimpleStackOverflow.Infrastructure.BusinessObjects.Membership;

namespace SimpleStackOverflow.Infrastructure.BusinessObjects
{
    public class Vote
    {
        public int Id { get; set; }
        public ApplicationUser Author { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
    }
}
