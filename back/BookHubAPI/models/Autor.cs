using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHubAPI.models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Livro> Livros { get; set; } = [];
    }
}