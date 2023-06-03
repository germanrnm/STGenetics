
using STGenetics.UI.Common.Mapping;

namespace STGenetics.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();
            return services;
        }
    }
}
