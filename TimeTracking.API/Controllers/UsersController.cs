using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracking.Data.DTOs;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UsersController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.UserService.GetAllUsersAsync(false);

            return Ok(users);
        }
        [HttpGet("{id:guid}", Name = "UserById")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _service.UserService.GetUserAsync(id, false);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateAndUpdateDTO user)
        {
            var createdUser = await _service.UserService.CreateUserAsync(user);

            return CreatedAtRoute("UserById", new { id = createdUser.Id }, user);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _service.UserService.DeleteUserAsync(id, false);

            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserCreateAndUpdateDTO user)
        {
            await _service.UserService.UpdateUserAsync(id, user, true);

            return NoContent();
        }
    }
}
