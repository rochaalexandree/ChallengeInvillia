using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChallengeInvillia.API.Dtos;
using ChallengeInvillia.Domain;
using ChallengeInvillia.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeInvillia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameRentedController : ControllerBase
    {
        public readonly IChallengeInvilliaRepository _repo;
        public readonly IMapper _mapper;
        public GameRentedController(IChallengeInvilliaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var gamesRented = await _repo.GetAllGameRentedAsync();

                var results = _mapper.Map<IEnumerable<GameRentedDto>>(gamesRented);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var gameRented = await _repo.GetGameRentedAsyncById(id);

                var results = _mapper.Map<GameRentedDto>(gameRented);
                
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(GameRentedDto model)
        {
            try
            {
                var gameRented = _mapper.Map<GameRented>(model);
                _repo.Add(gameRented);
                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/gameRented/{model.Id}", _mapper.Map<GameRentedDto>(gameRented));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }

            return BadRequest();
        }

        [HttpPut("{GameRentedId}")]
        public async Task<IActionResult> Put(int GameRentedId, GameRentedDto model)
        {
            try
            {
                var gameRented = await _repo.GetGameRentedAsyncById(GameRentedId);
                
                if(gameRented == null) 
                    return NotFound();

                _mapper.Map(model, gameRented);

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/gameRented/{model.Id}", _mapper.Map<GameRentedDto>(gameRented));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }

            return BadRequest();
        }

        [HttpDelete("{GameRentedId}")]
        public async Task<IActionResult> Delete(int GameRentedId)
        {
            try
            {
                var gameRented = await _repo.GetGameRentedAsyncById(GameRentedId);
                
                if(gameRented == null) 
                    return NotFound();

                _repo.Delete(gameRented);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }

            return BadRequest();
        }
    }
}