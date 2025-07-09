using ItlaTv.Infrastructure.Persistence.Contexts;
using ItlaTv.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ItlaTv.Core.Application.Interfaces.Repositories;

namespace ItlaTv.Infrastructure.Persistence.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly DatabaseContext _databaseContext;

        public GenreRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Genre>> GetAllWithIncludes()
        {
            return await _databaseContext.Set<Genre>()
                .Include(genre => genre.PrimarySeries)
                .Include(genre => genre.SecundarySeries)
                .ToListAsync();
        }

        public async Task<Genre> GetByIdWithIncludes(int id)
        {
            return await _databaseContext.Set<Genre>()
                .Include(genre => genre.PrimarySeries)
                .Include(genre => genre.SecundarySeries)
                .FirstOrDefaultAsync(genre => genre.Id == id);
        }

        public async Task<bool> IsPrimaryGenre(int id)
        {
            return await _databaseContext.Series.AnyAsync(register => register.PrimaryGenreId == id);
        }
    }
}
