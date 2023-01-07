﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesApi.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        [Range(1, 600)]
        public int Duracao { get; set; }

        [StringLength(100)]
        public string Diretor { get; set; }

        public string Genero { get; set; }

    }
}
