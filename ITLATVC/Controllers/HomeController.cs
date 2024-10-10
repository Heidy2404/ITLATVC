using Application.Services;
using Application.ViewModels;
using ITLATVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITLATVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly SeriesService _seriesService;
        private readonly GeneroService _genderService;
        private readonly ProductorasService _producerService;

        public HomeController(SeriesService seriesService, GeneroService genderService, ProductorasService producerService) 
        {
            _seriesService = seriesService;
            _genderService = genderService;
                _producerService = producerService;
        }



        public async Task<IActionResult> Index()
        {
            List<ProductoraViewModel> producers = await _producerService.GetAllAsync();
            ViewBag.Productores = producers;

            List<GenerosViewModel> Gender = await _genderService.GetAllAsync();
            ViewBag.Generos = Gender;

            return View(await _seriesService.GetAllAsync());
        }

        public async Task<IActionResult> Video(int id)
        {
            var generos = await _genderService.GetAllAsync();
            ViewBag.Generos = generos;

            var serie = await _seriesService.GetByIdAsync(id);
            return View("Video", serie);
        }

        public async Task<IActionResult> BuscarNombre(string nombre)
        {
            var productores = await _producerService.GetAllAsync();
            var generos = await _genderService.GetAllAsync();
            var serieViewModel = await _seriesService.GetByNameAsync(nombre);

            ViewBag.Productores = productores;
            ViewBag.Generos = generos;

            List<SeriesViewModel> series = new List<SeriesViewModel> { serieViewModel };
            return View("Index", series.ToList());
        }

        public async Task<IActionResult> BuscarProductor(ProductoraViewModel productor)
        {
            var productores = await _producerService.GetAllAsync();
            var generos = await _genderService.GetAllAsync();
            var serieViewModel = await _seriesService.GetByProducerAsync(productor);

            ViewBag.Productores = productores;
            ViewBag.Generos = generos;

            return View("Index", serieViewModel.ToList());
        }

        public async Task<IActionResult> BuscarGenero(GenerosViewModel género)
        {
            var generos = await _genderService.GetAllAsync();
            var productores = await _producerService.GetAllAsync();
            var seriesViewModels = await _seriesService.GetByGenderAsync(género);

            ViewBag.Productores = productores;
            ViewBag.Generos = generos;

            return View("Index", seriesViewModels.ToList());
        }
    }


}
