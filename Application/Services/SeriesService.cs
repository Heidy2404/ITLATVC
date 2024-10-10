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
    public class SeriesService
    {
        private readonly SeriesRepository _repository;

        public SeriesService(ApplicationContext context)
        {
            _repository = new SeriesRepository(context);
        }

        public async Task<List<SeriesViewModel>> GetAllAsync()
        {
            var seriesList = await _repository.GetAllSeries();
            return seriesList.Select(s => new SeriesViewModel
            {
                Id = s.SerieId,
                Nombre = s.Nombre,
                Portada = s.Portada,
                Enlace = s.Enlaces,
                NombreProductora = s.Productora.Nombre,
                Genero = s.SeriesGeneroLista.Where(g => g.primario).Select(g => g.Genero.Nombre).ToList(),
                GeneroSecundario = s.SeriesGeneroLista.Where(g => !g.primario).Select(g => g.Genero.Nombre).ToList()
            }).ToList();
        }

        public async Task AddAsync(GuardarSerieViewModel model)
        {
            var primaryGenders = model.Generos.Select(id => new SeriesGeneros { GeneroId = id, primario = true }).ToList();
            var secondaryGenders = model.GenerosSecundario.Select(id => new SeriesGeneros { GeneroId = id, primario = false }).ToList();
            var allGenders = primaryGenders.Concat(secondaryGenders).ToList();

            var series = new Series
            {
                Nombre = model.Nombre,
                Portada = model.Portada,
                Enlaces = model.Enlace,
                ProductoraId = model.ProductoraId,
                SeriesGeneroLista = allGenders
            };

            await _repository.AddAsync(series);
        }

        public async Task UpdateAsync(GuardarSerieViewModel model)
        {
            var series = await _repository.GetSerieById(model.Id);
            if (series != null)
            {
                series.Nombre = model.Nombre;
                series.Portada = model.Portada;
                series.Enlaces = model.Enlace;
                series.ProductoraId = model.ProductoraId;

                var primaryGenders = model.Generos.Select(id => new SeriesGeneros { GeneroId = id, SerieId = model.Id, primario = true }).ToList();
                var secondaryGenders = model.GenerosSecundario.Select(id => new SeriesGeneros { GeneroId = id, SerieId = model.Id, primario = false }).ToList();
                series.SeriesGeneroLista = primaryGenders.Concat(secondaryGenders).ToList();

                await _repository.UpdateAsync(series);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var series = await _repository.GetSerieById(id);
            if (series != null)
            {
                await _repository.Delete(series);
            }
        }

        public async Task<GuardarSerieViewModel> GetByIdAsync(int id)
        {
            var series = await _repository.GetSerieById(id);
            if (series != null)
            {
                return new GuardarSerieViewModel
                {
                    Id = series.SerieId,
                    Nombre = series.Nombre,
                    Portada = series.Portada,
                    Enlace = series.Enlaces,
                    ProductoraId = series.ProductoraId,
                    Generos = series.SeriesGeneroLista.Where(g => g.primario).Select(g => g.Genero.GeneroId).ToList(),
                    GenerosSecundario = series.SeriesGeneroLista.Where(g => !g.primario).Select(g => g.Genero.GeneroId).ToList()
                };
            }
            return null;
        }

        public async Task<SeriesViewModel> GetByNameAsync(string name)
        {
            var series = await _repository.GetSeriesByName(name);
            if (series != null)
            {
                return new SeriesViewModel
                {
                    Id = series.SerieId,
                    Nombre = series.Nombre,
                    Portada = series.Portada,
                    Enlace = series.Enlaces,
                    NombreProductora = series.Productora.Nombre,
                    Genero = series.SeriesGeneroLista.Select(g => g.Genero.Nombre).ToList()
                };
            }
            return null;
        }

        public async Task<IEnumerable<SeriesViewModel>> GetByProducerAsync(ProductoraViewModel producer)
        {
            var seriesList = await _repository.GetAllSeriesByProducer(new Productora { ProductoraId = producer.Id, Nombre = producer.Nombre });
            return seriesList.Select(s => new SeriesViewModel
            {
                Id = s.SerieId,
                Nombre = s.Nombre,
                Portada = s.Portada,
                Enlace = s.Enlaces,
                NombreProductora = s.Productora.Nombre,
                Genero = s.SeriesGeneroLista.Select(g => g.Genero.Nombre).ToList()
            });
        }

        public async Task<IEnumerable<SeriesViewModel>> GetByGenderAsync(GenerosViewModel gender)
        {
            var seriesList = await _repository.GetAllSeriesByGender(new Generos { GeneroId = gender.Id, Nombre = gender.Nombre });
            return seriesList.Select(g => new SeriesViewModel
            {
                Id = g.Series.SerieId,
                Nombre = g.Series.Nombre,
                Portada = g.Series.Portada,
                Enlace = g.Series.Enlaces,
                NombreProductora = g.Series.Productora.Nombre,
                Genero = g.Series.SeriesGeneroLista.Select(sg => sg.Genero.Nombre).ToList()
            });
        }
    
}
}
