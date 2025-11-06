using SmartBudget.CategoriesService.Domain.Entities;
using SmartBudget.CategoriesService.Domain.Interfaces;
using SmartBudget.CategoriesService.Infrastructure.Persistance;
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

        public async Task Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ArgumentException("Category name can`t be empty.");

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
                await _repository.Delete(category);
            }
            else
            {
                throw new KeyNotFoundException($"Category with key {id} not found.");
            }
                
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Category?> GetById(int id)
        {
            var category = await _repository.GetById(id);

            if (category != null)
                return category;
            else
                throw new KeyNotFoundException($"Category with key {id} not found.");

        }
    }
}
