using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHubAPI.models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}