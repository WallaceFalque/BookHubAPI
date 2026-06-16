using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookHubAPI.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace BookHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly AppDbContext db;
        public LivrosController (AppDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult GetAll ()
        {
            return Ok(db.Livros);
        }
    }
}