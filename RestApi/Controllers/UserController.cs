using BussinessLayer;
using Microsoft.AspNetCore.Mvc;
using PersistenceLayer.Dtos;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("id")]
        public async Task<IActionResult> AppUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }        
        [HttpPost]
        public async Task<IActionResult> AppUser(CreateUserDto dto)
        {
            var userId = await _userService.CreateAsync(dto);
            return Ok(userId);
        }        
        [HttpPost("id")]
        public IActionResult UserRemove(int id)
        {
            _userService.Delete(id);
            return Ok("Deleted");
        }
        [HttpPut("id")]
        public async Task<IActionResult> UserUodate(int id, UpdateUserDto dto)
        {
            var user = await _userService.UpdateAsync(id, dto);
            return Ok(user);
        }
    }
}
