using Microsoft.EntityFrameworkCore;
using SmartBudget.CategoriesService.Domain.Entities;
using SmartBudget.CategoriesService.Domain.Interfaces;
using SmartBudget.CategoriesService.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.CategoriesService.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext context) => _context = context;
        
        public async Task Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            _context.Categories.Remove(category!);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistByName(string name)
        {
            return await _context.Categories
                .AnyAsync(x=> x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
