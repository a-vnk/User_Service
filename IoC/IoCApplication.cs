using Microsoft.EntityFrameworkCore;
using Service_User.Data;
using Service_User.Data.Repository;
using Service_User.Data.Repository.Interface;
using Service_User.Service;
using Service_User.Service.Interface;

namespace Service_User.IoC
{

    public static class IoCApplication
    {
        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(connectionString));


            return services;
        }
    }
}

