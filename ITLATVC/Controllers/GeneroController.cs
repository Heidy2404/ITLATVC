using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITLATVC.Controllers
{
    public class GeneroController : Controller
    {
        private readonly GeneroService _generoService;

        public GeneroController(GeneroService generoService)
        {
            _generoService = generoService;
        }


        public async Task<IActionResult> Index()
        {
            var generos = await _generoService.GetAllAsync();
            return View(generos);
        }

        public IActionResult Crear()
        {
            return View("CrearEditarGenero", new GuardarGenerosViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Crear(GuardarGenerosViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearEditarGenero", viewModel);
            }

            await _generoService.AddAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            return View("CrearEditarGenero", await _generoService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(GuardarGenerosViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CrearEditarGenero", viewModel);
            }

            await _generoService.UpdateAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EliminarGenero(int id)
        {
            return View(await _generoService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await _generoService.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Genero", action = "Index" }); ;
        }
    }
}

