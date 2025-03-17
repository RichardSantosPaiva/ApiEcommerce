using ApiEcommerce.Models;
using ApiEcommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService produtoService)
        {
            _productService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> FindAll()
        {
            return Ok(await _productService.FindAll());
        }

        [HttpPost]
        public async Task<ActionResult<Products>> Create([FromForm] Products product)
        {
            var createdProduct = await _productService.Create(product);

            return CreatedAtAction(nameof(FindAll), new { id = createdProduct.Id }, createdProduct);
        }
    }
}
