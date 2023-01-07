﻿using AutoMapper;
using FilmesApi.Data.Dtos.Endereco;
using FilmesAPI.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
