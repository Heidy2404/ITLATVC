using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class SeriesRepository
    {
        private readonly ApplicationContext _context;

        public SeriesRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Series>> GetAllSeries()
        {
            return await _context.Series.Include(s => s.Productora)
                                        .Include(s => s.SeriesGeneroLista)
                                        .ThenInclude(sg => sg.Genero)
                                        .ToListAsync();
        }
        public async Task AddAsync(Series series)
        {
            await _context.Series.AddAsync(series);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Series series)
        {
            _context.Series.Update(series);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Series series)
        {
            _context.Series.Remove(series);
            await _context.SaveChangesAsync();
        }

        public async Task<Series> GetSerieById(int id)
        {
            return await _context.Series.Include(s => s.Productora)
                                        .Include(s => s.SeriesGeneroLista)
                                        .ThenInclude(sg => sg.Genero)
                                        .FirstOrDefaultAsync(s => s.SerieId == id);
        }

        public async Task<Series> GetSeriesByName(string name)
        {
            return await _context.Series.Include(s => s.Productora)
                                        .Include(s => s.SeriesGeneroLista)
                                        .ThenInclude(sg => sg.Genero)
                                        .FirstOrDefaultAsync(s => s.Nombre == name);
        }

        public async Task<IEnumerable<Series>> GetAllSeriesByProducer(Productora producer)
        {
            return await _context.Series.Where(s => s.ProductoraId == producer.ProductoraId)
                                        .Include(s => s.Productora)
                                        .Include(s => s.SeriesGeneroLista)
                                        .ThenInclude(sg => sg.Genero)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<SeriesGeneros>> GetAllSeriesByGender(Generos gender)
        {
            return await _context.SeriesGeneros.Where(sg => sg.GeneroId == gender.GeneroId)
                                               .Include(sg => sg.Series)
                                               .ThenInclude(s => s.Productora)
                                               .Include(sg => sg.Genero)
                                               .ToListAsync();
        }
    }


}

