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
    public class GeneroRepository
    {
        private readonly ApplicationContext _context;

        public GeneroRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public async Task<List<Generos>> GetAllAsync()
        {
            return await _context.Set<Generos>().ToListAsync();
        }

        public async Task AddAsync(Generos gender)
        {
            await _context.Generos.AddAsync(gender);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Generos gender)
        {
            _context.Generos.Update(gender);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Generos gender)
        {
            _context.Generos.Remove(gender);
            await _context.SaveChangesAsync();
        }

        public async Task<Generos> GetById(int id)
        {
            var serieId = await _context.Generos.FirstOrDefaultAsync(i => i.GeneroId == id);
            return serieId;
        }

        public async Task<Generos> GetGenrerByName(string name)
        {
            return await _context.Generos.FirstOrDefaultAsync(g => g.Nombre == name);
        }
    }



}
