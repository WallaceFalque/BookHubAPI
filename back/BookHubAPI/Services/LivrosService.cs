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

         public List<LivroResponseDto>? ListarPorAutor (int Autorid)
        {
            var livros = db.Livros
            .Where(c => c.AutorId == Autorid)
            .Select(c => new LivroResponseDto
            {
                Id = c.Id,
                Titulo = c.Titulo,
                AnoPublicacao = c.AnoPublicacao,
                Autor = c.Autor!.Nome,
                Categoria = c.Categoria!.Nome
            }); 
           if (livros.Count() == 0) return null;
            return livros.ToList();
        }

        public List<LivroResponseDto>? ListarPorCategoria (int categoriaId)
        {
            var livros = db.Livros
            .Where(c => c.CategoriaId == categoriaId)
            .Select(c => new LivroResponseDto
            {
                Id = c.Id,
                Titulo = c.Titulo,
                AnoPublicacao = c.AnoPublicacao,
                Autor = c.Autor!.Nome,
                Categoria = c.Categoria!.Nome
                
            });
            if (livros.Count() == 0) return null;
            return livros.ToList();
        }


        public Livro? CriarLivro(LivroCreateDto dto)
        {
            if (dto is null) return null;
            if (db.Autores.FirstOrDefault(c => c.Id == dto.AutorId) is null) return null;

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
            livroEscolhido?.AutorId = dto.AutorId;
            livroEscolhido?.CategoriaId = dto.CategoriaId;

            db.SaveChanges();

            return livroEscolhido;            
        }

        public bool DeletarLivro (int id)
        {
            var livroDelete = db.Livros.FirstOrDefault(c => c.Id == id);

            if (livroDelete is null) return false;

            db.Livros.Remove(livroDelete);
            db.SaveChanges();
            return true;
        }
    }
}