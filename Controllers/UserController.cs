using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.DTOs;
using Website.Services;

namespace Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _User;
        public UserController(IUserServices User)
        {
            _User = User;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDto data)
        {
            var dub=await _User.AddUser(data);
            return Ok(dub);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDto data)
        {
            var dub = await _User.GetUserbyEmail(data);

            return Ok(dub);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dub = await _User.GetAllUsers();
            return Ok(dub);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> GEtAllByID([FromQuery]int id)
        {
            var dub = await _User.GetbyId(id);
            if (dub == null)
            {
                return NotFound("User ID Not Found");
            }
            return Ok(dub);
        }
    }
}
