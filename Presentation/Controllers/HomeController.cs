using ItlaTv.Core.Application.ViewModels.Series;
using ItlaTv.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTv.Presentation.WepApp.Presentation
{
    public class HomeController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IProducerService _producerService;
        private readonly IGenreService _genreService;

        public HomeController(ISerieService serieService, IProducerService producerService, IGenreService genreService)
        {
            _serieService = serieService;
            _producerService = producerService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index(FilterSerieViewModel filterViewModel)
        {
            ViewBag.Producers = await _producerService.GetAllAsync();
            ViewBag.Genres = await _genreService.GetAllAsync();
            return View(await _serieService.GetAllWithFiltersAsync(filterViewModel));
        }

        public async Task<IActionResult> WatchSerie(int id)
        {
            return View(await _serieService.GetWatchSerieViewModelAsync(id));
        }
        
    }
}