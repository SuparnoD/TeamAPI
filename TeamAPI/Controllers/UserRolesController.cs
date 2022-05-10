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
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRolesController(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserRole>> GetUserRoles()
        {
            return await _userRoleRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetUserRoles(int id)
        {
            return await _userRoleRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserRole>> PostUserRoles([FromBody] UserRole userRole)
        {
            var newUserRole = await _userRoleRepository.Create(userRole);
            return CreatedAtAction(nameof(GetUserRoles), new { id = newUserRole.Id }, newUserRole);
        }

        [HttpPut]
        public async Task<ActionResult> PutUserRoles(int id, [FromBody] UserRole userRole)
        {
            if(id != userRole.Id)
            {
                return BadRequest();
            }

            await _userRoleRepository.Update(userRole);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete (int id)
        {
            var userRoleToDelete = await _userRoleRepository.Get(id);
            if (userRoleToDelete == null)
            {
                return NotFound();
            }

            await _userRoleRepository.Delete(userRoleToDelete.Id);
            return NoContent();
        }
    }
}
