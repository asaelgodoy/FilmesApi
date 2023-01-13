using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto Create(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> FindAll(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context
                .Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }
            return null;

        }

        public ReadFilmeDto FindById(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return filmeDto;
            }
            return null;
        }
        
        public Result Update(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                _mapper.Map(filmeDto, filme);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Filme não encontrado");
            
            
        }

        public Result Delete(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return Result.Ok();

            }
            return Result.Fail("Filme não encontrado");
        }
    }
}
