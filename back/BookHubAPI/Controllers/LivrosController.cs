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
        public LivrosController (LivrosService ls)
        {
            this.ls = ls;
        }

        [HttpGet]
        public ActionResult GetAll ()
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
        public ActionResult GetById (int id)
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
    }
}