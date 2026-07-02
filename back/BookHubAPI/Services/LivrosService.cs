using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHubAPI.DataBase;
using BookHubAPI.models;
using Microsoft.EntityFrameworkCore;

namespace BookHubAPI.Services
{
    public class LivrosService
    {
        private readonly AppDbContext db;
        public LivrosService (AppDbContext db)
        {
            this.db = db;
        }

        public List<Livro> ListarTodos ()
        {
            return db.Livros
            .Include(c => c.Autor)
            .Include(c => c.Categoria)
            .ToList();
        }
        
        public Livro? ListarPorId (int id)
        {
            return(db.Livros
            .Include(c => c.Autor)
            .Include(c => c.Categoria)
            .FirstOrDefault(c => c.Id == id));            
        }
    }
}