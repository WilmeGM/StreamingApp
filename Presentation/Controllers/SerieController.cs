using ItlaTv.Core.Application.Interfaces.Services;
using ItlaTv.Core.Application.ViewModels.Series; 
using Microsoft.AspNetCore.Mvc;

namespace ItlaTv.Presentation.WepApp.Presentation
{
    public class SerieController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IProducerService _producerService; 
        private readonly IGenreService _genreService;

        public SerieController(ISerieService serieService, IProducerService producerService, IGenreService genreService)
        {
            _serieService = serieService;
            _producerService = producerService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _serieService.GetAllAsync());
        }

        public async Task<IActionResult> CreateSerie()
        {
            var viewModel = new CreateSerieViewModel
            {
                Producers = await _producerService.GetAllAsync(),
                Genres = await _genreService.GetAllAsync()
            };

            ViewBag.EqualsGenres = false;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSerie(CreateSerieViewModel createViewModel)
        {
            createViewModel.Producers ??= await _producerService.GetAllAsync();
            createViewModel.Genres ??= await _genreService.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return View("CreateSerie", createViewModel);
            }
            
            if(createViewModel.PrimaryGenreId == createViewModel.SecundaryGenreId)
            {
                ViewBag.EqualsGenres = true;
                return View("CreateSerie", createViewModel);
            }

            await _serieService.AddAsync(createViewModel);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> UpdateSerie(int id)
        {
            var createViewModel = await _serieService.GetByIdAsync(id);

            createViewModel.Producers = await _producerService.GetAllAsync();
            createViewModel.Genres = await _genreService.GetAllAsync();

            ViewBag.EqualsGenres = false;
            return View(createViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSerie(CreateSerieViewModel createViewModel)
        {
            createViewModel.Producers ??= await _producerService.GetAllAsync();
            createViewModel.Genres ??= await _genreService.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return View("UpdateSerie", createViewModel);
            }

            if (createViewModel.PrimaryGenreId == createViewModel.SecundaryGenreId)
            {
                ViewBag.EqualsGenres = true;
                return View("UpdateSerie", createViewModel);
            }

            await _serieService.UpdateAsync(createViewModel);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> RemoveSerie(int id)
        {
            return View(await _serieService.GetByIdAsync(id));
        }

        [HttpPost] 
        public async Task<IActionResult> RemoveSeriePost(int id)
        {
            await _serieService.RemoveAsync(id);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }
    }
}
