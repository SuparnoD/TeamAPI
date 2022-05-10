using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamAPI.Models;
using TeamAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Team>> GetTeam()
        {
            return await _teamRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            return await _teamRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam([FromBody] Team team)
        {
            var newTeam = await _teamRepository.Create(team);
            return CreatedAtAction(nameof(GetTeam), new { id = newTeam.Id }, newTeam);
        }

        [HttpPut]
        public async Task<ActionResult> PutTeam(int id, [FromBody] Team team)
        {
            if(id != team.Id)
            {
                return BadRequest();
            }

            await _teamRepository.Update(team);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var teamToDelete = await _teamRepository.Get(id);
            if(teamToDelete == null)
            {
                return NotFound();
            }

            await _teamRepository.Delete(teamToDelete.Id);
            return NoContent();
        }
    }
}
