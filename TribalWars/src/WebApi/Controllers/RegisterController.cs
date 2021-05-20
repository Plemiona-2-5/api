using System;
using System.Threading.Tasks;
using ApplicationCore.Contract.Requests;
using ApplicationCore.Contract.Responses;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public RegisterController(IUserService userService, IMapper mapper, IPlayerService playerService)
        {
            _userService = userService;
            _mapper = mapper;
            _playerService = playerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (await _userService.UserExistsByEmailAsync(request.Email))
                return BadRequest(new ErrorsResponse("user with this email already exists"));

            if (await _playerService.PlayerExistsByNicknameAsync(request.Nickname))
                return BadRequest(new ErrorsResponse("nickname is already taken"));

            var userDto = _mapper.Map<UserDto>(request);

            var (registerResult, emailConfirmationToken) =
                await _userService.CreateUserAsync(userDto, request.Password);

            if (!registerResult.Succeeded)
                BadRequest(new ErrorsResponse(registerResult.Errors));

            var playerResult = await _playerService.CreatePlayerAsync(userDto.Id, request.Nickname);

            return playerResult.Succeeded
                ? Ok(new {EmailConfirmationToken = emailConfirmationToken})
                : BadRequest(new ErrorsResponse(playerResult.Errors));
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