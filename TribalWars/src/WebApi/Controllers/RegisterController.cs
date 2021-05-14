using System.Threading.Tasks;
using ApplicationCore.Contract.Requests;
using ApplicationCore.Contract.Responses;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RegisterController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (await _userService.UserExistsByEmailAsync(request.Email))
                return BadRequest(new ErrorsResponse("user with this email already exists"));

            if (await _userService.UserExistsByUserNameAsync(request.UserName))
                return BadRequest(new ErrorsResponse("user with this user name already exists"));

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
                return BadRequest(new ErrorsResponse("user with this email doesn't exist"));

            if (await _userService.EmailConfirmedAsync(request.Email))
                return BadRequest(new ErrorsResponse("user email is already confirmed"));

            var result = await _userService.ConfirmUserEmailAsync(request.Email, request.EmailConfirmationToken);

            return result.Succeeded
                ? NoContent()
                : BadRequest(new ErrorsResponse(result.Errors));
        }
    }
}