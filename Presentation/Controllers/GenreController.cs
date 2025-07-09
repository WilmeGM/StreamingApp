using ItlaTv.Core.Application.ViewModels.Genres;
using ItlaTv.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTv.Presentation.WepApp.Presentation
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _genreService.GetAllAsync());
        }

        public IActionResult CreateGenre()
        {
            return View(new CreateGenreViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreViewModel createViewModel)
        {
            if (!ModelState.IsValid)
                return View(createViewModel);

            await _genreService.AddAsync(createViewModel);
            return RedirectToRoute(new { controller = "Genre", action = "Index" });
        }

        public async Task<IActionResult> UpdateGenre(int id)
        {
            return View(await _genreService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGenre(CreateGenreViewModel updateViewModel)
        {   
            if (!ModelState.IsValid)
                return View(updateViewModel);

            await _genreService.UpdateAsync(updateViewModel);
            return RedirectToRoute(new { controller = "Genre", action = "Index" });
        }

        public async Task<IActionResult> RemoveGenre(int id)
        {
            return View(await _genreService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveGenrePost(int id)
        {
            var wasDeleted = await _genreService.TryRemoveGenreAsync(id);

            if(!wasDeleted)
            {
                return View("Error");
            }

            return RedirectToRoute(new { controller = "Genre", action = "Index" });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
