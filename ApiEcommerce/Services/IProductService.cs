using ApiEcommerce.Models;

namespace ApiEcommerce.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> FindAll();
        Task<Products> Create(Products produto);
    }
}
