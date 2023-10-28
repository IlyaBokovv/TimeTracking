using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TimeTracking.Data;
using TimeTracking.Data.DTOs;
using TimeTracking.Data.Models;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ApplicationDbContext _db;
        private readonly IValidator<UserCreateAndUpdateDTO> _validator;

        public UsersController(IServiceManager service, ApplicationDbContext db, IValidator<UserCreateAndUpdateDTO> validator)
        {
            _service = service;
            _db = db;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.UserService.GetAllUsersAsync(false);

            return Ok(users);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _service.UserService.GetUserAsync(id, false);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateAndUpdateDTO user)
        {
            var result = await _validator.ValidateAsync(user);
            if (!result.IsValid)
            {
                return UnprocessableEntity(result.ToDictionary());
            }
            var createdUser = await _service.UserService.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, user);
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
            var result = await _validator.ValidateAsync(user);
            if (!result.IsValid)
            {
                return UnprocessableEntity(result.ToDictionary());
            }
            await _service.UserService.UpdateUserAsync(id, user, true);

            return NoContent();
        }
        private bool IsValidEmail(UserCreateAndUpdateDTO user)
        {
            return _db.Set<User>().Any(e => e.Email == user.Email);
        }
    }
}
