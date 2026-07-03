using System;
using System.Collections.Generic;
using System.Formats.Cbor;
using System.Linq;
using System.Threading.Tasks;
using BookHubAPI.DataBase;
using BookHubAPI.DTOs.Livro;
using BookHubAPI.models;
using Microsoft.EntityFrameworkCore;

namespace BookHubAPI.Services
{
    public class LivrosService
    {
        private readonly AppDbContext db;
        public LivrosService(AppDbContext db)
        {
            this.db = db;
        }

        public List<Livro> ListarTodos()
        {
            return db.Livros
            .Include(c => c.Autor)
            .Include(c => c.Categoria)
            .ToList();
        }

        public Livro? ListarPorId(int id)
        {
            return (db.Livros
            .Include(c => c.Autor)
            .Include(c => c.Categoria)
            .FirstOrDefault(c => c.Id == id));
        }

        public Livro? CriarLivro(LivroCreateDto dto)
        {
            if (dto is null) return null;

            Livro response = new Livro
            {
                Titulo = dto.Titulo,
                AnoPublicacao = dto.AnoPublicacao,
                AutorId = dto.AutorId,
                CategoriaId = dto.CategoriaId
            };

            db.Livros.Add(response);
            db.SaveChanges();

            return response;
        }

        public Livro? EditarLivro (LivroUpdateDto dto, int id)
        {
            if (dto is null) return null;

            var livroEscolhido = db.Livros.FirstOrDefault(c => c.Id == id);

            livroEscolhido?.Titulo = dto.Titulo;
            livroEscolhido?.AnoPublicacao = dto.AnoPublicacao;       
            livroEscolhido?.AutorId = dto.CategoriaId;

            db.SaveChanges();

            return livroEscolhido;
            
        }
    }
}