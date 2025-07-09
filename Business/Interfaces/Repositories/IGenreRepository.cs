using ItlaTv.Core.Domain.Entities;

namespace ItlaTv.Core.Application.Interfaces.Repositories
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {       
        Task<bool> IsPrimaryGenre(int id);
        Task<List<Genre>> GetAllWithIncludes();
        Task<Genre> GetByIdWithIncludes(int id);
    }
}