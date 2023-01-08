﻿using FilmesApi.Models;
using System.Text.Json.Serialization;

namespace FilmesAPI.Data.Dtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }       
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
    }
}
