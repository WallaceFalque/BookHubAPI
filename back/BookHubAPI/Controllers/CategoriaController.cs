using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHubAPI.DTOs.Livro.Autor.Categoria;
using BookHubAPI.models;
using BookHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService cs;
        public CategoriaController (CategoriaService cs)
        {
            this.cs = cs;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var categorias = cs.ListarCategorias();
            var response = categorias.Select(categorias => new CategoriaResponseDto
            {
                Nome = categorias.Nome
            });              
            
            return Ok(response);
        }
    }
}