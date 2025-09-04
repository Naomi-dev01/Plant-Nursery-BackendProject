using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNursery.BLL.Interfaces;
using PlantNursery.DTO;
using PlantNursery.DTO.UserDto;

namespace PlantNursery.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        // POST api/user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userDto)
        {
            try
            {
                var user = await _userService.PostUser(userDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        //POST api/user
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            var user = await _userService.LoginAsync(login.Username, login.Password);
            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            return Ok(user);
        }

        //PUT api/user/{Id}
        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdatedDto dto)
        {
            var updated = await _userService.UpdateUserAsync(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }
    }
}
