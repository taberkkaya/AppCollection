using AppCollection.Application.Interfaces.AutoMapper;
using AppCollection.Application.Interfaces.Repositories;
using AppCollection.Application.Interfaces.UnitOfWorks;
using AppCollection.Domain.Entities;
using AppCollection.Persistence.AutoMapper;
using AppCollection.Persistence.Context;
using AppCollection.Persistence.Repositories;
using AppCollection.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppCollection.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<AppUser>().
                AddRoles<AppRole>().
                AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IMapper, Mapper>();
        }
    }
}
