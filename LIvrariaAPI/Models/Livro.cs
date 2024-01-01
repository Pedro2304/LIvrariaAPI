using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIvrariaAPI.Models
{
    public class Livro
    {
       
        public Guid Id { get; set; }

        public string titulo { get; set; }

        public string subtitulo { get; set; }

        public string corDaCapa { get; set; }

        
        public decimal preco { get; set; }
    }
}

