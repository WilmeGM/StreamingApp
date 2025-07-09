using ItlaTv.Core.Domain.Entities;

namespace ItlaTv.Core.Application.Interfaces.Repositories
{
    public interface IProducerRepository : IGenericRepository<Producer>
    {
        Task<List<Producer>> GetAllWithIncludesAsync();
        Task<Producer> GetByIdWithIncludesAsync(int id);
    }
}