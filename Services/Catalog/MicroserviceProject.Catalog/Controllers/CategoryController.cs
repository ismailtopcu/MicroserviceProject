using MicroserviceProject.Catalog.Dtos;
using MicroserviceProject.Catalog.Services.Abstract;
using MicroserviceProject.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroserviceProject.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomeBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var category = await _categoryService.GetByIDAsync(id);
            return CreateActionResultInstance(category);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
           var category= await _categoryService.DeleteAsync(id);
            return CreateActionResultInstance(category);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryService.UpdateAsync(updateCategoryDto);
            return CreateActionResultInstance(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var category = await _categoryService.CreateAsync(createCategoryDto);
            return CreateActionResultInstance(category);
        }
    }
}
