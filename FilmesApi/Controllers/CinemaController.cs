using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.Create(cinemaDto);
            if (readDto == null) return NotFound();
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.FindAll(nomeDoFilme);
            if(readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.FindById(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.Update(id, cinemaDto);
            if (resultado.IsSuccess) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _cinemaService.Detele(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
