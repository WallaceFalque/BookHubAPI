using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHubAPI.models;
using Microsoft.EntityFrameworkCore;

namespace BookHubAPI.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) 
        : base(options)
        {
            
        }

        public DbSet<Livro> Livros {get; set;}
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}