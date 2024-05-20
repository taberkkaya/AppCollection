using AppCollection.Domain.Entities;
using AppCollection.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppCollection.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<AppUser>().
                AddRoles<AppRole>().
                AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
