using ToDoApp.Services.Dtos.CategoriesDtos;

namespace ToDoApp.Services.Interfaces
{
    public interface ICategoriesService
    {
        public Task<List<GetCategoriesDto>> GetAllCategoriesAsync();
        public Task<GetCategoriesDto> GetCategoriesByIdAsync(int categoryId);
        public bool IsCategories(int categoryId);
    }
}
