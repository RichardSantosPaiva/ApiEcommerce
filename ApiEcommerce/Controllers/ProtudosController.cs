using ApiEcommerce.Models;
using ApiEcommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtudosController : ControllerBase
    {   
        private readonly IProdutoService _produtoService;
        public ProtudosController(IProdutoService produtoService) { 
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> FindAll()
        {
            return Ok(await _produtoService.FindAll());
        }
   
    }
}
