using ItlaTv.Core.Application.ViewModels.Series;
using ItlaTv.Core.Domain.Entities;
using ItlaTv.Core.Application.Interfaces.Repositories;
using ItlaTv.Core.Application.Interfaces.Services;

namespace ItlaTv.Core.Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;

        public SerieService(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public async Task AddAsync(CreateSerieViewModel createViewModel)
        {
            var serie = new Serie
            {
                Id = createViewModel.Id,
                Name = createViewModel.Name,
                ImageUrl = createViewModel.ImageUrl,
                VideoUrl = createViewModel.VideoUrl,
                ProducerId = createViewModel.ProducerId,
                PrimaryGenreId = createViewModel.PrimaryGenreId,
                SecundaryGenreId = createViewModel.SecundaryGenreId
            };

            await _serieRepository.AddAsync(serie);
        }

        public async Task UpdateAsync(CreateSerieViewModel createViewModel)
        {
            var existingRegister = await _serieRepository.GetByIdAsync(createViewModel.Id) ?? throw new Exception("Serie not found");

            existingRegister.Id = createViewModel.Id;
            existingRegister.Name = createViewModel.Name;
            existingRegister.ImageUrl = createViewModel.ImageUrl;
            existingRegister.VideoUrl = createViewModel.VideoUrl;
            existingRegister.ProducerId = createViewModel.ProducerId;
            existingRegister.PrimaryGenreId = createViewModel.PrimaryGenreId;
            existingRegister.SecundaryGenreId = createViewModel.SecundaryGenreId;

            await _serieRepository.UpdateAsync(existingRegister);
        }

        public async Task RemoveAsync(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            await _serieRepository.RemoveAsync(serie);
        }

        public async Task<CreateSerieViewModel> GetByIdAsync(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);

            var createViewModel = new CreateSerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImageUrl = serie.ImageUrl,
                VideoUrl = serie.VideoUrl,
                ProducerId = serie.ProducerId,
                PrimaryGenreId = serie.PrimaryGenreId,
                SecundaryGenreId = serie.SecundaryGenreId
            };

            return createViewModel;
        }

        public async Task<List<SerieViewModel>> GetAllAsync()
        {
            var seriesList = await _serieRepository.GetAllWithIncludesAsync();

            return seriesList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImageUrl = serie.ImageUrl,
                VideoUrl = serie.VideoUrl,
                Producer = serie.Producer.Name,
                PrimaryGenre = serie.PrimaryGenre.Name,
                SecundaryGenre = serie.SecundaryGenre != null ? ", " + serie.SecundaryGenre.Name : ""
            }).ToList();
        }

        public async Task<List<SerieViewModel>> GetAllWithFiltersAsync(FilterSerieViewModel filterViewModel)
        {
            var seriesList = await _serieRepository.GetAllWithIncludesAsync();

            var viewModelList = seriesList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                ImageUrl = serie.ImageUrl,
                VideoUrl = serie.VideoUrl,
                ProducerId = serie.Producer.Id,
                Producer = serie.Producer.Name,
                PrimaryGenreId = serie.PrimaryGenre.Id,
                PrimaryGenre = serie.PrimaryGenre.Name,
                SecundaryGenreId = serie.SecundaryGenre != null ? serie.SecundaryGenre.Id : null,
                SecundaryGenre = serie.SecundaryGenre != null ? ", " + serie.SecundaryGenre.Name : ""
            }).ToList();

            if (filterViewModel.ProducerId is not null)
                viewModelList = viewModelList.Where(serie => serie.ProducerId == filterViewModel.ProducerId.Value).ToList();

            if (filterViewModel.GenreId is not null)
                viewModelList = viewModelList.Where(serie => serie.PrimaryGenreId == filterViewModel.GenreId.Value || serie.SecundaryGenreId == filterViewModel.GenreId.Value).ToList();

            if (filterViewModel.Name is not null)
                viewModelList = viewModelList.Where(serie => serie.Name.ToLower() == filterViewModel.Name.ToLower()).ToList();

            return viewModelList;
        }

        public async Task<WatchSerieViewModel> GetWatchSerieViewModelAsync(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);

            var watchSerieViewModel = new WatchSerieViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                VideoUrl = serie.VideoUrl
            };

            return watchSerieViewModel;
        }
    }
}
