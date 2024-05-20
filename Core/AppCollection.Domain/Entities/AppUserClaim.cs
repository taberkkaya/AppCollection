using AppCollection.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace AppCollection.Domain.Entities
{
    public class AppUserClaim : IdentityUserClaim<Guid>, IEntityBase
    {
    }
}
