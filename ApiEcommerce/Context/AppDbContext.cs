﻿using ApiEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Products> Produtos { get; set; }
        


    }
}
