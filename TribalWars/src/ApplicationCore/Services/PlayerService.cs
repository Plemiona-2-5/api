using System;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Results;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
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

        public async Task<PlayerDto> GetPlayerDtoByUserId(Guid userId)
        {
            var player = await _playerRepository.GetByUserId(userId);

            if (player == null)
                return null;

            return _mapper.Map<PlayerDto>(player);
        }
    }
}