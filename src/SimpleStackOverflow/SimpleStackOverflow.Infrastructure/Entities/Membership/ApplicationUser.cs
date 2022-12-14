using Microsoft.AspNetCore.Identity;

namespace SimpleStackOverflow.Infrastructure.Entities.Membership
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IList<Post>? Posts { get; set; }
        public IList<Comment>? Comments { get; set; }
    }
}
