using System;
using System.Threading.Tasks;
using ApplicationCore.Contract.Responses;
using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IVillageService _villageService;
        private readonly IPlayerService _playerService;
        private readonly ICurrentUserService _currentUserService;

        public MapController(IVillageService villageService, IPlayerService playerService,
            ICurrentUserService currentUserService)
        {
            _villageService = villageService;
            _playerService = playerService;
            _currentUserService = currentUserService;
        }

        [Authorize]
        [HttpGet("api/maps/villages")]
        public async Task<IActionResult> GetAllVillagesOnMap()
        {
            var playerDto = await _playerService.GetPlayerDtoByUserIdAsync(Guid.Parse(_currentUserService.UserId));
            var userVillage = await _villageService.GetVillageDtoByPlayerId(playerDto.Id);
            var (villagesDto, mapDto) = await _villageService.GetVillagesDtoExceptPlayerAsync(playerDto.Id);

            var response = new GetAllVillagesResponse
            {
                UserVillage = userVillage,
                OtherVillages = villagesDto,
                MapInformation = mapDto
            };
            
            return Ok(response);
        }
    }
}