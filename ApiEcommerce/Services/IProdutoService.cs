﻿using ApiEcommerce.Models;

namespace ApiEcommerce.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Products>> FindAll();
        Task<Products> Create(Products produto);
    }
}
