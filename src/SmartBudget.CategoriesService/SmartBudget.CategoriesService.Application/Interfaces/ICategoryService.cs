using SmartBudget.CategoriesService.Domain.Entities;
using SmartBudget.Transactions.SharedContracts.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.CategoriesService.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task Add(CategoryDto categoryDto);
        Task Delete(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto?> GetById(int id);
    }
}
