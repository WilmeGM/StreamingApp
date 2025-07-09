using ItlaTv.Core.Application.Interfaces.Repositories;
using ItlaTv.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ItlaTv.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly DatabaseContext _databaseContext;

        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddAsync(Entity entity)
        {
            await _databaseContext.Set<Entity>().AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entity entity)
        {
            _databaseContext.Entry(entity).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Entity entity)
        {
            _databaseContext.Set<Entity>().Remove(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            return await _databaseContext.Set<Entity>().ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _databaseContext.Set<Entity>().FindAsync(id);
        }
    }
}
