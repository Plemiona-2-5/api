using System;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Resources;
using ApplicationCore.Results;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace ApplicationCore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResource> _localizer;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper,
            IStringLocalizer<MessageResource> localizer)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<ServiceResult> CreatePlayerAsync(Guid userId, string nickname)
        {
            var player = new Player {UserId = userId, Nickname = nickname, CreatedAt = DateTime.Now};

            return await _playerRepository.AddAsync(player)
                ? ServiceResult.Success()
                : ServiceResult.Failure(_localizer["SomethingWentWrong"]);
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
        
        public async Task<Guid> GetPlayerId(Guid userId)
        {
            var player = await _playerRepository.GetPlayerByUserId(userId);
            return player.Id;
        }
    }
}