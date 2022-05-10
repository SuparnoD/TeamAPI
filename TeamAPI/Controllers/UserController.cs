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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _userRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _userRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            var newUser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> PutUser(int id, [FromBody] User user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.Update(user);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete (int id)
        {
            var userToDelete = await _userRepository.Get(id);
            if(userToDelete == null)
            {
                return NotFound();
            }

            await _userRepository.Delete(userToDelete.Id);
            return NoContent();
        }
    }
}
