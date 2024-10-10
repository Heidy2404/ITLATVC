using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GeneroService
    {
        private readonly GeneroRepository _repository;

        public GeneroService(ApplicationContext context)
        {
            _repository = new GeneroRepository(context);
        }
        public async Task<List<GenerosViewModel>> GetAllAsync()
        {
            var generos = await _repository.GetAllAsync();
            return generos.Select(g => new GenerosViewModel { Id = g.GeneroId, Nombre = g.Nombre }).ToList();
        }

        public async Task AddAsync(GuardarGenerosViewModel model)
        {
            var generos = new Generos { Nombre = model.Nombre };
            await _repository.AddAsync(generos);
        }

        public async Task UpdateAsync(GuardarGenerosViewModel model)
        {
            var generos = await _repository.GetById(model.Id);
            if (generos != null)
            {
                generos.Nombre = model.Nombre;
                await _repository.UpdateAsync(generos);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var generos = await _repository.GetById(id);
            if (generos != null)
            {
                await _repository.Delete(generos);
            }
        }

        public async Task<GuardarGenerosViewModel> GetByIdAsync(int id)
        {
            var generos = await _repository.GetById(id);
            if (generos != null)
            {
                return new GuardarGenerosViewModel { Id = generos.GeneroId, Nombre = generos.Nombre };
            }
            return null;
        }

        public async Task<GuardarGenerosViewModel> GetByNameAsync(string name)
        {
            var genero = await _repository.GetGenrerByName(name);
            if (genero != null)
            {
                return new GuardarGenerosViewModel { Id = genero.GeneroId, Nombre = genero.Nombre };
            }
            return null;
        }
    }
}
