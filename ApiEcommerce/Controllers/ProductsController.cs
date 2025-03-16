using ApiEcommerce.Models;
using ApiEcommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {   
        private readonly IProdutoService _productService;
        public ProductsController(IProdutoService produtoService) { 
            _productService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> FindAll()
        {
            return Ok(await _productService.FindAll());
        }

        [HttpPost]

        public async Task<ActionResult<Products>> Create([FromBody] Products produto)
        {
            Products product = await _productService.Create(produto);
             return CreatedAtAction(nameof(FindAll), new { id = produto.Id }, produto);
        }

    }
}
