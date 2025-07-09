using ItlaTv.Core.Application.Interfaces.Services;
using ItlaTv.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ItlaTv.Core.Application.Configurations
{
    public static class ApplicationConfigurationsService
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IProducerService, ProducerService>();
            services.AddTransient<ISerieService, SerieService>();
        }
    }
}
