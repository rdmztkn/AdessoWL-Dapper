using AdessoWL.Application.Interfaces.DapperContext;
using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Persistence.Context;
using AdessoWL.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AdessoWL.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, DapperTeamRepository>();
            services.AddScoped<ICountryRepository, DapperCountryRepository>();
            services.AddScoped<IDapperContext, DapperContext>();
        }
    }
}
