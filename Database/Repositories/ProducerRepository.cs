using ItlaTv.Infrastructure.Persistence.Contexts;
using ItlaTv.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ItlaTv.Core.Application.Interfaces.Repositories;

namespace ItlaTv.Infrastructure.Persistence.Repositories
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProducerRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Producer>> GetAllWithIncludesAsync()
        {
            return await _databaseContext.Set<Producer>()
                .Include(producer => producer.Series)
                .ToListAsync();
        }

        public async Task<Producer> GetByIdWithIncludesAsync(int id)
        {
            return await _databaseContext.Set<Producer>()
                .Include(producer => producer.Series)
                .FirstOrDefaultAsync(producer => producer.Id == id);
        }
    }
}
