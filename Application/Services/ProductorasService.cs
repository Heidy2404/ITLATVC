using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductorasService
    {
        private readonly ProductoraRepository repository;

        public ProductorasService(ApplicationContext context)
        {
           repository = new ProductoraRepository(context);
        }

        public async Task<List<ProductoraViewModel>> GetAllAsync()
        {
            var producers = await repository.GetAllProductoraAsync();
            return producers.Select(p => new ProductoraViewModel 
            { Id = p.ProductoraId, Nombre = p.Nombre }).ToList();
        }

        public async Task AddAsync(GuardarProductoraViewModel model)
        {
            var producer = new Productora {ProductoraId= model.Id, Nombre = model.Nombre };
            await repository.AddAsync(producer);
        }

        public async Task UpdateAsync(GuardarProductoraViewModel model)
        {
            var producer = await repository.GetProducerById(model.Id);
            if (producer != null)
            {
                producer.Nombre = model.Nombre;
                await repository.UpdateProducer(producer);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var producer = await repository.GetProducerById(id);
            if (producer != null)
            {
                await repository.Delete(producer);
            }
        }

        public async Task<GuardarProductoraViewModel> GetByIdAsync(int id)
        {
            var producer = await repository.GetProducerById(id);
            if (producer != null)
            {
                return new GuardarProductoraViewModel { Id = producer.ProductoraId, Nombre = producer.Nombre };
            }
            return null;
        }
    }
}

