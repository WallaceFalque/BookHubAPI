using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BookHubAPI.DataBase;
using BookHubAPI.DTOs.Livro;
using BookHubAPI.models;
using BookHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosService ls;
        public LivrosController(LivrosService ls)
        {
            this.ls = ls;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var livros = ls.ListarTodos();

            var response = livros.Select(livro => new LivroResponseDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                AnoPublicacao = livro.AnoPublicacao,
                Autor = livro.Autor!.Nome,
                Categoria = livro.Categoria!.Nome
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var livro = ls.ListarPorId(id);
            if (livro is null) return NotFound();

            LivroResponseDto response = new LivroResponseDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                AnoPublicacao = livro.AnoPublicacao,
                Autor = livro.Autor!.Nome,
                Categoria = livro.Categoria!.Nome

            };

            return Ok(response);
        }

        [HttpGet("Autor/{AutorId}")]
        public ActionResult GetByAutor (int AutorId)
        {
            var response = ls.ListarPorAutor(AutorId);
            return response is null ? NotFound() : Ok(response);
        }

        [HttpPost]
        public ActionResult Create(LivroCreateDto dto)
        {
            var livro = ls.CriarLivro(dto);
            return livro is null ? BadRequest() : Ok(livro);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(LivroUpdateDto dto, int id)
        {
            var livro = ls.EditarLivro(dto, id);
            return livro is null ? NotFound() : Ok(dto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delet(int id)
        {
            bool deletado = ls.DeletarLivro(id);

            return deletado ? Ok() : NotFound();
        }
    }
}