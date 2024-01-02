using Microsoft.EntityFrameworkCore;
using Service_User.Data;
using Service_User.Data.Repository;
using Service_User.Data.Repository.Interface;
using Service_User.Service;
using Service_User.Service.Interface;

namespace Service_User.IoC
{
    public static class IoCApplicationTest
    {
        public static IServiceCollection ConfigureInjectionDependencyRepositoryTest(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection ConfigureInjectionDependencyServiceTest(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection ConfigureDBContextTest(this IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "TestApplication")
            );

            return services;
        }
    }
}
