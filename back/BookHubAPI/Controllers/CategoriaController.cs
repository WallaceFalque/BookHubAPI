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
            var categorias = cs.ListarTodas();
            var response = categorias.Select(categorias => new CategoriaResponseDto
            {
                Nome = categorias.Nome
            });              
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult GetById (int id)
        {
            var response = cs.ListarCategoria(id);
            return response is null ? NotFound() : Ok(response);  
        }

        [HttpPost]
        public ActionResult Create (CategoriaCreateDto dto)
        {
            if (dto != null)
            {
                cs.CriarCategoria(dto);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Edit (CategoriaUpdateDto dto, int id)
        {
            var categoria = cs.EditarCategoria(dto, id);
            return categoria ? NotFound() : Ok(dto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            return cs.DeletarCategoria(id) ? NotFound() : Ok(); 
        }
    }
}