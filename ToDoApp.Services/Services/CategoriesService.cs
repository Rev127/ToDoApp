using ToDoApp.Services.Dtos.CategoriesDtos;
using ToDoApp.Services.Interfaces;
using ToDoApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Services.Exceptions.CategoriesExceptions;

namespace ToDoApp.Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ToDoAppContext context;

        public CategoriesService(ToDoAppContext context)
        {
            this.context = context;
        }

        public async Task<List<GetCategoriesDto>> GetAllCategoriesAsync()
        {
            return await this.context.Categories
                .Select(c => new GetCategoriesDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<GetCategoriesDto> GetCategoriesByIdAsync(int categoryId)
        {
            var category = await this.context.Categories.FindAsync(categoryId);

            if (category is null)
            {
                throw new CategoriesNotFoundException($"Category with the ID {categoryId} was not found");
            }

            return new GetCategoriesDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public bool IsCategories(int categoryId)
        {
            if(this.context.Categories.Any(c => c.Id == categoryId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
