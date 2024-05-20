using AppCollection.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace AppCollection.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
    }
}
