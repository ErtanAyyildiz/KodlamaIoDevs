using KodlamaIoDevs.Application.Services.Repositorties;
using KodlamaIoDevs.Persistance.Contexts;
using KodlamaIoDevs.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KodlamaIoDevs.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("KodlamaIoDevsConnectionString"));
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguagesRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            //services.AddScoped<IUserAppRepository, UserAppRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
