using ItlaTv.Core.Application.ViewModels.Genres;
using ItlaTv.Core.Domain.Entities;

namespace ItlaTv.Core.Application.Interfaces.Services
{
    public interface IGenreService : IGenericService<CreateGenreViewModel, GenreViewModel>
    {
        Task<bool> TryRemoveGenreAsync(int id);
    }
}