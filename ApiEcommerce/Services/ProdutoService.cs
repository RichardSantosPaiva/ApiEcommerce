using ApiEcommerce.Models;
using ApiEcommerce.Repository;

namespace ApiEcommerce.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IRepository _produtoRepository;

        public ProdutoService(IRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Products>> FindAll()
        {
            return await _produtoRepository.FindAll();
        }

        public async Task<Products> Create(Products produto)
        {
           return await _produtoRepository.Create(produto);
        }

       
    }
}
