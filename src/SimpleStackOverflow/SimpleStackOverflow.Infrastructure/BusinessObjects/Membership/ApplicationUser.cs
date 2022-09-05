
namespace SimpleStackOverflow.Infrastructure.BusinessObjects.Membership
{
    public class ApplicationUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IList<Post>? Posts { get; set; }
        public IList<Comment>? Comments { get; set; }
    }
}
