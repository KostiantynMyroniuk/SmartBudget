using Microsoft.EntityFrameworkCore;
using SmartBudget.CategoriesService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.CategoriesService.Infrastructure.Persistence.Contexts
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
    }
}
