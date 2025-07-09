namespace ItlaTv.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity: class
    {
        Task AddAsync(Entity entity);
        Task UpdateAsync(Entity entity);
        Task RemoveAsync(Entity entity);
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
    }
}
