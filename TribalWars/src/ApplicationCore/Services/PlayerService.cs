using System;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Results;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<ServiceResult> CreatePlayerAsync(Guid userId, string nickname)
        {
            var player = new Player {UserId = userId, Nickname = nickname, CreatedAt = DateTime.Now};
            
            return await _playerRepository.AddAsync(player)
                ? ServiceResult.Success()
                : ServiceResult.Failure("Something went wrong");
        }

        public async Task<bool> PlayerExistsByNicknameAsync(string nickname) =>
            await _playerRepository.GetByNicknameAsync(nickname) != null;
    }
}