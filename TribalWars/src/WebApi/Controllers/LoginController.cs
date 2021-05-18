using System.Threading.Tasks;
using ApplicationCore.Contract.Requests;
using ApplicationCore.Contract.Responses;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public LoginController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("api/auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var userDto = await _userService.GetUserDtoByCredentialsAsync(request.Email, request.Password);

            if (userDto == null)
                return BadRequest(new ErrorsResponse("login or password are wrong"));

            if (!userDto.EmailConfirmed)
                return BadRequest(new ErrorsResponse("email isn't confirmed"));

            var accessToken = _jwtService.GenerateJwtToken(userDto.Id.ToString());
            var response = new LoginResponse {AccessToken = accessToken, UserName = userDto.UserName};
            
            return Ok(response);
        }
    }
}