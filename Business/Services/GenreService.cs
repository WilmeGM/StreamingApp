using ItlaTv.Core.Application.ViewModels.Genres;
using ItlaTv.Core.Domain.Entities;
using ItlaTv.Core.Application.Interfaces.Repositories;
using ItlaTv.Core.Application.Interfaces.Services;

namespace ItlaTv.Core.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task AddAsync(CreateGenreViewModel createViewModel)
        {
            var genre = new Genre
            {
                Id = createViewModel.Id,
                Name = createViewModel.Name
            };

            await _genreRepository.AddAsync(genre);
        }

        public async Task UpdateAsync(CreateGenreViewModel viewModel)
        {
            var genre = new Genre
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };

            await _genreRepository.UpdateAsync(genre);
        }

        public async Task<bool> TryRemoveGenreAsync(int id)
        {
            var isPrimaryGenre = await _genreRepository.IsPrimaryGenre(id);

            if (isPrimaryGenre)
                return false;

            var genre = await _genreRepository.GetByIdAsync(id);
            await _genreRepository.RemoveAsync(genre);
            return true;
        }

        public async Task<CreateGenreViewModel> GetByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdWithIncludes(id);

            var createViewModel = new CreateGenreViewModel
            {
                Id = genre.Id,
                Name = genre.Name
            };

            return createViewModel;
        }

        public async Task<List<GenreViewModel>> GetAllAsync()
        {
            var genreList = await _genreRepository.GetAllWithIncludes();

            return genreList.Select(genre => new GenreViewModel
            {
                Id = genre.Id,
                Name = genre.Name
            }).ToList();
        }
    }
}
