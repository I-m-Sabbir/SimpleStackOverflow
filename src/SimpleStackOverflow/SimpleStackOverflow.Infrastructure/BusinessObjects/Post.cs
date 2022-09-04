using SimpleStackOverflow.Infrastructure.BusinessObjects.Membership;


namespace SimpleStackOverflow.Infrastructure.BusinessObjects
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTimeOffset CreateTime { get; set; }
        public ApplicationUser Author { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public IList<Comment>? Comments { get; set; }
        public IList<Vote>? Votes { get; set; }
    }
}
