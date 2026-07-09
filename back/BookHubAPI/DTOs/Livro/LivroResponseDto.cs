using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHubAPI.DTOs.Livro
{
    public class LivroResponseDto
    {
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
    public string Autor { get; set; } = string.Empty;
    
    public string Categoria { get; set; } = string.Empty;
    }
}