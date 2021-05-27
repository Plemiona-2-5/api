using System.Threading.Tasks;
using ApplicationCore.Contract.Requests;
using ApplicationCore.Contract.Responses;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public RegisterController(IUserService userService, IMapper mapper, IStringLocalizer<MessageResource> localizer)
        {
            _userService = userService;
            _mapper = mapper;
            _localizer = localizer;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (await _userService.UserExistsByEmailAsync(request.Email))
                return BadRequest(new ErrorsResponse(_localizer["EmailIsTaken"]));

            if (await _userService.UserExistsByUserNameAsync(request.UserName))
                return BadRequest(new ErrorsResponse(_localizer["UsernameIsTaken"]));

            var userDto = _mapper.Map<UserDto>(request);

            var (result, emailConfirmationToken) = await _userService.CreateUserAsync(userDto, request.Password);

            return result.Succeeded
                ? Ok(new {EmailConfirmationToken = emailConfirmationToken})
                : BadRequest(new ErrorsResponse(result.Errors));
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            if (!await _userService.UserExistsByEmailAsync(request.Email))
                return BadRequest(new ErrorsResponse(_localizer["UserNotFoundByEmail"]));

            if (await _userService.EmailConfirmedAsync(request.Email))
                return BadRequest(new ErrorsResponse(_localizer["EmailAlreadyConfirmed"]));

            var result = await _userService.ConfirmUserEmailAsync(request.Email, request.EmailConfirmationToken);

            return result.Succeeded
                ? NoContent()
                : BadRequest(new ErrorsResponse(result.Errors));
        }
    }
}