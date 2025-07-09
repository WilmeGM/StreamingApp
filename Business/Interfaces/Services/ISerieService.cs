using ItlaTv.Core.Application.ViewModels.Series;

namespace ItlaTv.Core.Application.Interfaces.Services
{
    public interface ISerieService : IGenericService<CreateSerieViewModel, SerieViewModel>, IRemoveService
    {
        Task<List<SerieViewModel>> GetAllWithFiltersAsync(FilterSerieViewModel filterViewModel);
        Task<WatchSerieViewModel> GetWatchSerieViewModelAsync(int id);
    }
}