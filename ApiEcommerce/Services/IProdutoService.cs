using ApiEcommerce.Models;

namespace ApiEcommerce.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> FindAll();
    }
}
