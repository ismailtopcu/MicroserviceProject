using MicroserviceProject.Catalog.Dtos;
using MicroserviceProject.Catalog.Models;
using MicroserviceProject.Catalog.Services.Abstract;
using MicroserviceProject.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroserviceProject.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomeBaseController
    {
        private readonly IProductService _productService;

        public  ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return CreateActionResultInstance(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var product = await _productService.GetByIDAsync(id);
            return CreateActionResultInstance(product);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.DeleteAsync(id);
            return CreateActionResultInstance(product);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var product = await _productService.UpdateAsync(updateProductDto);
            return CreateActionResultInstance(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            var product = await _productService.CreateAsync(createProductDto);
            return CreateActionResultInstance(product);
        }
    }
}
