using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Authorize]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [Authorize]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await categoryService.GetCategoriesByIdAsync(id);
            return Ok(category);
        }
    }
}
