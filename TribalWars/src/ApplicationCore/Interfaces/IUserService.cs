using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<(ServiceResult, string)> CreateUserAsync(UserDto userDto, string password);
        Task<ServiceResult> ConfirmUserEmailAsync(string email, string confirmationToken);
        Task<bool> UserExistsByUserNameAsync(string userName);
        Task<bool> UserExistsByEmailAsync(string email);
        Task<bool> EmailConfirmedAsync(string email);
    }
}