using System.Threading.Tasks;
using ApplicationCore.Contract.Requests;
using ApplicationCore.Contract.Responses;
using ApplicationCore.Interfaces;
using ApplicationCore.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace WebApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public LoginController(IUserService userService, IJwtService jwtService,
            IStringLocalizer<MessageResource> localizer)
        {
            _userService = userService;
            _jwtService = jwtService;
            _localizer = localizer;
        }

        [HttpPost("api/auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var userDto = await _userService.GetUserDtoByCredentialsAsync(request.Email, request.Password);

            if (userDto == null)
                return BadRequest(new ErrorsResponse(_localizer["WrongPasswordOrLogin"]));

            if (!userDto.EmailConfirmed)
                return BadRequest(new ErrorsResponse(_localizer["NotConfirmedEmail"]));

            var accessToken = _jwtService.GenerateJwtToken(userDto.Id.ToString());
            var response = new LoginResponse {AccessToken = accessToken, UserName = userDto.UserName};

            return Ok(response);
        }
    }
}