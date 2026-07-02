using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHubAPI.DTOs.Livro
{
    public class LivroCreateDto
    {
        public string Titulo { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
    }
}