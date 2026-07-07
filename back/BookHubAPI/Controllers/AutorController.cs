using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHubAPI.DTOs.Livro.Autor;
using BookHubAPI.models;
using BookHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly AutorService ats;
        public AutorController(AutorService ats)
        {
            this.ats = ats;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var response = ats.ListarTodos();

            var responseList = response.Select(Autor => new AutorResponseDto
            {
                Nome = Autor.Nome
            });

            return Ok(responseList);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var autor = ats.ListarAutor(id);
            return autor is null ? NotFound() : Ok(autor);
        }

        [HttpPost]
        public ActionResult Create(AutorCreateDto dto)
        {
            var autor = ats.CriarAutor(dto);
            return dto is null ? BadRequest() : Ok(autor);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, AutorUpdateDto dto)
        {
            bool editou = ats.EditarAutor(id, dto);
            return editou ? Ok(dto) : NotFound(); 
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var response = ats.DeletarAutor(id);
            return response is null ? NotFound() : Ok(response);
        }
    }
}