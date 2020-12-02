using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ChallengeInvillia.Repository;
using ChallengeInvillia.Domain;
using AutoMapper;
using ChallengeInvillia.API.Dtos;

namespace ChallengeInvillia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendsController : ControllerBase
    {
        public readonly IChallengeInvilliaRepository _repo;
        public readonly IMapper _mapper;
        public FriendsController(IChallengeInvilliaRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var friends = await _repo.GetAllFriendAsync();

                var results = _mapper.Map<IEnumerable<FriendDto>>(friends);

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
                var friend = await _repo.GetFriendAsyncById(id);

                var results = _mapper.Map<FriendDto>(friend);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }
        }

        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var friends = await _repo.GetFriendAsyncByName(name);

                var results = _mapper.Map<IEnumerable<FriendDto>>(friends);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FriendDto model)
        {
            try
            {
                var friend = _mapper.Map<Friend>(model);
                _repo.Add(friend);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/friends/{model.Id}", _mapper.Map<FriendDto>(friend));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }

            return BadRequest();
        }

        [HttpPut("{FriendId}")]
        public async Task<IActionResult> Put(int FriendId, FriendDto model)
        {
            try
            {
                var friend = await _repo.GetFriendAsyncById(FriendId);

                if (friend == null){
                    return NotFound();
                }

                _mapper.Map(model, friend);

                _repo.Update(friend);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/friends/{model.Id}", _mapper.Map<FriendDto>(friend));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao acessar banco de dados");
            }

            return BadRequest();
        }

        [HttpDelete("{FriendId}")]
        public async Task<IActionResult> Delete(int FriendId)
        {
            try
            {
                var friend = await _repo.GetFriendAsyncById(FriendId);
                if (friend == null){
                    return NotFound();
                }

                _repo.Delete(friend);
                if (await _repo.SaveChangesAsync())
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
