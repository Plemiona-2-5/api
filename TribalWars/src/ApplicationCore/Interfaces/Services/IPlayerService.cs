using System;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<ServiceResult> CreatePlayerAsync(Guid userId, string nickname);
        Task<bool> PlayerExistsByNicknameAsync(string nickname);
        Task<PlayerDto> GetPlayerDtoByUserId(Guid userId);
        Task<Guid> GetPlayerId(Guid userId);
    }
}
