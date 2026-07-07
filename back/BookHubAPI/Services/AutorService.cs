using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHubAPI.DataBase;
using BookHubAPI.models;
using Microsoft.EntityFrameworkCore;
using BookHubAPI.DTOs.Livro.Autor;

namespace BookHubAPI.Services
{
    public class AutorService
    {
        private readonly AppDbContext db;
        public AutorService(AppDbContext db)
        {
            this.db = db;
        }

        public List<Autor> ListarTodos()
        {
            return (db.Autores.ToList());
        }

        public Autor? ListarAutor(int id)
        {
            return (db.Autores.FirstOrDefault(c => c.Id == id));
        }

        public AutorCreateDto? CriarAutor(AutorCreateDto dto)
        {
            if (dto is null) return null;
            Autor autor = new Autor
            {
                Nome = dto.Nome
            };
            db.Add(autor);
            db.SaveChanges();
            return dto;
        }

        public bool EditarAutor(int id, AutorUpdateDto dto)
        {
            var autor = db.Autores.FirstOrDefault(c => c.Id == id);
            if (autor is null) return false;
            autor.Nome = dto.Nome;
            db.SaveChanges();
            return true;
        }

        public AutorResponseDto? DeletarAutor(int id)
        {
            var autor = db.Autores.FirstOrDefault(c => c.Id == id);
            if (autor is null) return null;

            db.Autores.Remove(autor);
            db.SaveChanges();
            AutorResponseDto response = new AutorResponseDto
            {
                Nome = autor.Nome
            };

            return response;
        }
    }
}