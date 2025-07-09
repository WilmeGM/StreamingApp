using ItlaTv.Infrastructure.Persistence.Contexts;
using ItlaTv.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ItlaTv.Core.Application.Interfaces.Repositories;

namespace ItlaTv.Infrastructure.Persistence.Repositories
{
    public class SerieRepository : GenericRepository<Serie>, ISerieRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SerieRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Serie>> GetAllWithIncludesAsync()
        {
            return await _databaseContext.Set<Serie>()
                .Include(serie => serie.Producer)
                .Include(serie => serie.PrimaryGenre)
                .Include(serie => serie.SecundaryGenre)
                .ToListAsync();
        }
    }
}
