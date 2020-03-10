using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _appDbContext.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            _appDbContext.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _appDbContext.Categories.Remove(category);
        }
    }
}
