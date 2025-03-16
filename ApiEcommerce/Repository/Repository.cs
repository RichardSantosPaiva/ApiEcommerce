using ApiEcommerce.Context;
using ApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Repository
{

    public class Repository : IRepository
    {

        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> FindAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Products> Create(Products produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;

        }
    }
}
