using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public class ProductRepository: BaseRepository,IProductReposiroty
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> ListAsync()
        {
            return await _context.Products.Include(p=>p.Category).ToListAsync();
        }

        public async Task PostAsync(Product producto)
        {
            await _context.Products.AddAsync(producto);
        }

    }
}
