using Microsoft.AspNetCore.Identity;

namespace SimpleStackOverflow.Infrastructure.Entities.Membership
{
    public class UserToken
        : IdentityUserToken<Guid>
    {

    }
}