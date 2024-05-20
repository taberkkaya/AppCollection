using AppCollection.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace AppCollection.Domain.Entities
{
    public class AppUserRole : IdentityUserRole<Guid>, IEntityBase
    {
    }
}
