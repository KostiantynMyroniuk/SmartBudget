using SmartBudget.CategoriesService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.CategoriesService.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task Add(Category category);
        Task Delete(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<Category?> GetById(int id);
    }
}
