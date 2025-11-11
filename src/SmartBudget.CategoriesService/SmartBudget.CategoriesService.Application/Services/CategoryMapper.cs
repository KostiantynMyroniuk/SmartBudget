using SmartBudget.CategoriesService.Domain.Entities;
using SmartBudget.Transactions.SharedContracts.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBudget.CategoriesService.Application.Services
{
    public static class CategoryMapper
    {
        public static CategoryDto MapToDto(this Category category)
        {
            var categoryMap = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };

            return categoryMap;
        }

        public static Category MapToEntity(this CategoryDto categoryDto)
        {
            var categoryMap = new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
            };

            return categoryMap;
        }

        public static IEnumerable<CategoryDto> MapToDto(this IEnumerable<Category> categories)
        {
            return categories.Select(x => x.MapToDto());
        }

        public static IEnumerable<Category> MapToEntity(this IEnumerable<CategoryDto> categoriesDto)
        {
            return categoriesDto.Select(x => x.MapToEntity());
        }
    }
}
