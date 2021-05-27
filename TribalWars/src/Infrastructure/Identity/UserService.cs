using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<(ServiceResult, string)> CreateUserAsync(UserDto userDto, string password)
        {
            var newUser = _mapper.Map<User>(userDto);

            var identityResult = await _userManager.CreateAsync(newUser, password);

            if (!identityResult.Succeeded)
                return (ServiceResult.Failure(identityResult.Errors.Select(error => error.Description)), null);

            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            _mapper.Map(newUser, userDto);

            return (ServiceResult.Success(), emailConfirmationToken);
        }

        public async Task<ServiceResult> ConfirmUserEmailAsync(string email, string confirmationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var identityResult = await _userManager.ConfirmEmailAsync(user, confirmationToken);

            return identityResult.Succeeded
                ? ServiceResult.Success()
                : ServiceResult.Failure(identityResult.Errors.Select(error => error.Description));
        }

        public async Task<UserDto> GetUserDtoByCredentialsAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return null;

            var hasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!hasValidPassword)
                return null;

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<bool> UserExistsByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user != null;
        }

        public async Task<bool> UserExistsByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<bool> EmailConfirmedAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.IsEmailConfirmedAsync(user);
        }
    }
}