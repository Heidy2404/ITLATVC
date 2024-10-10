using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITLATVC.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SeriesService _seriesService;
        private readonly ProductorasService _producerService;
        private readonly GeneroService _genderService;

        public SeriesController(SeriesService seriesService, ProductorasService producerService, GeneroService genderService)
        {
            _seriesService = seriesService;
            _producerService = producerService;
            _genderService = genderService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _seriesService.GetAllAsync());
        }

        public async Task<IActionResult> Crear()
        {
            ViewBag.Productores = await _producerService.GetAllAsync();
            ViewBag.Generos = await _genderService.GetAllAsync();
            return View("GuardarSerie", new GuardarSerieViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Crear(GuardarSerieViewModel seriesViewModel)
        {
            if (ModelState.IsValid)
            {
                await _seriesService.AddAsync(seriesViewModel);
                return RedirectToRoute(new { controller = "Series", action = "Index" });
            }
            ViewBag.Productores = await _producerService.GetAllAsync();
            ViewBag.Generos = await _genderService.GetAllAsync();
            return View("GuardarSerie", seriesViewModel);
        }

        public async Task<IActionResult> Editar(int id)
        {
            ViewBag.Productores = await _producerService.GetAllAsync();
            ViewBag.Generos = await _genderService.GetAllAsync();
            var series = await _seriesService.GetByIdAsync(id);
            if (series == null)
            {
                return NotFound();
            }
            return View("GuardarSerie", series);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(GuardarSerieViewModel seriesViewModel)
        {
            if (ModelState.IsValid)
            {
                await _seriesService.UpdateAsync(seriesViewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Productores = await _producerService.GetAllAsync();
            ViewBag.Generos = await _genderService.GetAllAsync();
            return View("GuardarSerie", seriesViewModel);
        }

        public async Task<IActionResult> DeleteSerie(int id)
        {
            var series = await _seriesService.GetByIdAsync(id);
            if (series == null)
            {
                return NotFound();
            }
            return View(series);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _seriesService.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Series", action = "Index" });
        }
    }

}

