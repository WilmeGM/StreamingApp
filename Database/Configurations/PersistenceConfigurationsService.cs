using ItlaTv.Core.Application.Interfaces.Repositories;
using ItlaTv.Infrastructure.Persistence.Contexts;
using ItlaTv.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItlaTv.Infrastructure.Persistence.Configurations
{
    public static class PersistenceConfigurationsService
    {
        //Decorator with asp.net extension method ("this ObjetoToExtend")
        public static void AddDbContextAndRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            #region "DbContext Configuration"
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("AppDb"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("Connection");
                services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString, migrations => migrations.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
            }
            #endregion

            #region "Repositories DI"
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddTransient<ISerieRepository, SerieRepository>();
            #endregion
        }
    }
}
