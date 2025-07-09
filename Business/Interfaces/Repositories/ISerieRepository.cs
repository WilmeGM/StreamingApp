using ItlaTv.Core.Domain.Entities;

namespace ItlaTv.Core.Application.Interfaces.Repositories
{
    public interface ISerieRepository : IGenericRepository<Serie>
    {
        Task<List<Serie>> GetAllWithIncludesAsync();
    }
}