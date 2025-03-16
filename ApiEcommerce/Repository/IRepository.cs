using ApiEcommerce.Models;

namespace ApiEcommerce.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Products>> FindAll();
        Task<Products> Create(Products produto);
    }
}
