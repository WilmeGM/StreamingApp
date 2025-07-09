using ItlaTv.Core.Application.ViewModels.Producers;
using ItlaTv.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTv.Presentation.WepApp.Presentation
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _producerService.GetAllAsync());
        }

        public IActionResult CreateProducer()
        {
            return View(new CreateProducerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducer(CreateProducerViewModel createViewModel)
        {
            if (!ModelState.IsValid)
                return View(createViewModel);

            await _producerService.AddAsync(createViewModel);

            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }

        public async Task<IActionResult> UpdateProducer(int id)
        {
            return View(await _producerService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProducer(CreateProducerViewModel updateViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateViewModel);

            await _producerService.UpdateAsync(updateViewModel);

            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }

        public async Task<IActionResult> RemoveProducer(int id)
        {
            return View(await _producerService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProducer(CreateProducerViewModel removeViewModel)
        {
            await _producerService.RemoveAsync(removeViewModel.Id);

            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }
    }
}
