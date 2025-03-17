using ApiEcommerce.Models;
using ApiEcommerce.Repository;

namespace ApiEcommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _produtoRepository;
        private readonly IFileService _fileService;

        public ProductService(IRepository produtoRepository, IFileService fileService)
        {
            _produtoRepository = produtoRepository;
            _fileService = fileService;
        }

        public async Task<IEnumerable<Products>> FindAll()
        {
            return await _produtoRepository.FindAll();
        }

        public async Task<Products> Create(Products produto)
        {
            if (produto.ImageFile != null)
            {
                produto.imgURL = await _fileService.SaveFile(produto.ImageFile);
            }

            return await _produtoRepository.Create(produto);
        }
    }
}
