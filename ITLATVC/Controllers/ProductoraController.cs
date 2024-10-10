using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITLATVC.Controllers
{
    public class ProductoraController : Controller
    {
        private readonly ProductorasService _producerService;

        public ProductoraController(ProductorasService producerService)
        {
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var producers = await _producerService.GetAllAsync();
            return View(producers);
        }

        public IActionResult Crear()
        {
            return View("CrearEditarProductora", new GuardarProductoraViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Crear(GuardarProductoraViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearEditarProductora", viewModel);
            }

            await _producerService.AddAsync(viewModel);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            var producer = await _producerService.GetByIdAsync(id);
            return View("CrearEditarProductora", producer);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(GuardarProductoraViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearEditarProductora", viewModel);
            }

            await _producerService.UpdateAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EliminarProductora(int id)
        {
            return View(await _producerService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _producerService.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Productora", action = "Index" }); ;
        }
    }
}

