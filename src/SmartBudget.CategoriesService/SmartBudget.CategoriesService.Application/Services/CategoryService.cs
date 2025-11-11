using SmartBudget.CategoriesService.Domain.Entities;
using SmartBudget.CategoriesService.Domain.Interfaces;
using SmartBudget.CategoriesService.Infrastructure.Persistence;
using SmartBudget.Transactions.SharedContracts.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.CategoriesService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(CategoryDto categoryDto)
        {

            if (string.IsNullOrWhiteSpace(categoryDto.Name))
                throw new ArgumentException("Category name can`t be empty.");

            var category = categoryDto.MapToEntity();

            var isExists = await _repository.ExistByName(category.Name);

            if (!isExists)
            {
                await _repository.Add(category);
            }
            else
            {
                throw new InvalidOperationException($"Category {category.Name} already exists.");
            }
                
        }

        public async Task Delete(int id)
        {
            var category = await _repository.GetById(id);

            if (category != null)
            {
                await _repository.Delete(id);
            }
            else
            {
                throw new KeyNotFoundException($"Category with key {id} not found.");
            }
                
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _repository.GetAll();

            return categories.MapToDto();
        }

        public async Task<CategoryDto?> GetById(int id)
        {
            var category = await _repository.GetById(id);

            if (category != null)
                return category.MapToDto();
            else
                throw new KeyNotFoundException($"Category with key {id} not found.");

        }
    }
}
