
using Microsoft.Extensions.DependencyInjection;
using STGenetics.Application.Common.Interfaces.Persistence;
using STGenetics.Infraestructure.Persistence;

namespace STGenetics.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(
        this IServiceCollection services)
        {
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            return services;
        }
    }
}
