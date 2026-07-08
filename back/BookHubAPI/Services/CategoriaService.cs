using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHubAPI.DataBase;
using BookHubAPI.DTOs.Livro.Autor.Categoria;
using BookHubAPI.models;

namespace BookHubAPI.Services
{
    public class CategoriaService
    {
        private readonly AppDbContext db;
        public CategoriaService(AppDbContext db)
        {
            this.db = db;
        }

        public List<Categoria> ListarTodas()
        {
            return (db.Categorias.ToList());
        }

        public CategoriaResponseDto? ListarCategoria(int id)
        {
            var categoria = db.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria is null) return null;

            var response = new CategoriaResponseDto
            {
                Nome = categoria.Nome
            };

            return response;
        }

        public void CriarCategoria(CategoriaCreateDto dto)
        {
            db.Add(dto);
            db.SaveChanges();
        }

        public bool EditarCategoria(CategoriaUpdateDto dto, int id)
        {
            var categoria = db.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria is null)
            {
                return true;
            }
            categoria.Nome = dto.Nome;
            db.SaveChanges();
            return false;
        }

        public bool DeletarCategoria (int id)
        {
            var categoria = db.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria is null)
            {
                return true;
            }
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            return false;
        }
    }
}