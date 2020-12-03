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
    public class GameController : ControllerBase
    {
        public readonly IChallengeInvilliaRepository _repo;
        public readonly IMapper _mapper;
        public GameController(IChallengeInvilliaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var games = await _repo.GetAllGameAsync();

                var results = _mapper.Map<IEnumerable<GameDto>>(games);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }
            
        }

        [HttpGet("{GameId}")]
        public async Task<IActionResult> Get(int GameId)
        {
            try
            {
                var game = await _repo.GetGameAsyncById(GameId);

                var results = _mapper.Map<GameDto>(game);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }
        }

        [HttpGet("getByFriend/{FriendId}")]
        public async Task<IActionResult> GetByFriend(int FriendId)
        {
            try
            {
                var games = await _repo.GetGameAsyncByFriend(FriendId);
                var results = _mapper.Map<IEnumerable<GameDto>>(games);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(GameDto model)
        {
            try
            {
                var game = _mapper.Map<Game>(model);
                _repo.Add(game);
                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/game/{model.GameId}", _mapper.Map<GameDto>(game));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao acessar banco de dados : {ex}");
            }

            return BadRequest();
        }

        [HttpPut("{GameId}")]
        public async Task<IActionResult> Put(int GameId, GameDto model)
        {
            try
            {
                var game = await _repo.GetGameAsyncById(GameId);
                
                if(game == null) 
                    return NotFound();

                _mapper.Map(model, game);

                _repo.Update(game);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/game/{model.GameId}", _mapper.Map<GameDto>(game));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }

            return BadRequest();
        }

        [HttpDelete("{GameId}")]
        public async Task<IActionResult> Delete(int GameId)
        {
            try
            {
                var game = await _repo.GetGameAsyncById(GameId);
                
                if(game == null) 
                    return NotFound();

                _repo.Delete(game);

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