using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Data.Dtos.Endereco;

namespace FilmesApi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadCinemaDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
