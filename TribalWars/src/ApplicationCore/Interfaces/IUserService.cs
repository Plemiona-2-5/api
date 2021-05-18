using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResult> ConfirmUserEmailAsync(string email, string confirmationToken);
        Task<(ServiceResult, string)> CreateUserAsync(UserDto userDto, string password);
        Task<UserDto> GetUserDtoByCredentialsAsync(string email, string password);
        Task<bool> UserExistsByUserNameAsync(string userName);
        Task<bool> UserExistsByEmailAsync(string email);
        Task<bool> EmailConfirmedAsync(string email);
    }
}