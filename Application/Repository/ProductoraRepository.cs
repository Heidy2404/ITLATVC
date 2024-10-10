using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ProductoraRepository
    {
        private readonly ApplicationContext _context;

        public ProductoraRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<Productora>> GetAllProductoraAsync()
        {
            return await _context.Set<Productora>().ToListAsync();
        }

        public async Task AddAsync(Productora producer)
        {
            await _context.Productoras.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProducer(Productora producer)
        {
            _context.Productoras.Update(producer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Productora producer)
        {
            _context.Productoras.Remove(producer);
            await _context.SaveChangesAsync();
        }

        public async Task<Productora> GetProducerById(int id)
        {
            return await _context.Productoras.FindAsync(id);
        }
    }
}

