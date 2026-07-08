using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHubAPI.DataBase;
using BookHubAPI.models;

namespace BookHubAPI.Services
{
    public class CategoriaService
    {
        private readonly AppDbContext db;
        public CategoriaService (AppDbContext db)
        {
            this.db = db;
        }
        
        public List<Categoria> ListarCategorias ()
        {
            return (db.Categorias.ToList());
        }
    }
}