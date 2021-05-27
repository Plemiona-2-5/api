using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ApplicationCore.Responses;
using Microsoft.Extensions.Localization;
using ApplicationCore.Resources;
using ApplicationCore.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/tribe")]
    public class TribeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITribeService _tribeService;
        private readonly ITribeMemberService _tribeMemberService;
        private readonly IStringLocalizer<MessageResource> _localizer;
        private readonly IPlayerService _playerService;

        public TribeController(IMapper mapper,
                               ITribeService tribeService,
                               IStringLocalizer<MessageResource> localizer,
                               ITribeMemberService tribeMemberService,
                               IPlayerService playerService)
        {
            _mapper = mapper;
            _tribeService = tribeService;
            _tribeMemberService = tribeMemberService;
            _localizer = localizer;
            _tribeMemberService = tribeMemberService;
            _playerService = playerService;
        }

        [Authorize]
        [HttpPost("/create-tribe")]
        public async Task<IActionResult> CreateTribe([FromBody] TribeDto dto)
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var playerId = await _playerService.GetPlayerId(Guid.Parse(user));
            var tribe = _mapper.Map<Tribe>(dto);

            var result = await _tribeService.CreateTribe(tribe, playerId);
            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["AddTribeSuccess"]))
                : BadRequest(new ErrorsResponse(result.Errors));
        }

        [Authorize]
        [HttpGet("/tribe-details")]
        public async Task<ActionResult<TribeDetailsVM>> TribeDetails()
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var playerId = await _playerService.GetPlayerId(Guid.Parse(user));

            var result = await _tribeService.TribeDetails(playerId);
            return result.Succeeded
                ? Ok(result)
                : BadRequest(result);
        }

        [Authorize]
        [HttpPut("/edit-tribe-description")]
        public async Task<ActionResult<TribeDescriptionDto>> EditTribeDescription([FromHeader] int tribeId, [FromBody] TribeDescriptionDto dto)
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var playerId = await _playerService.GetPlayerId(Guid.Parse(user));
            var result = await _tribeService.EditTribeDescription(playerId, dto, tribeId);

            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["EditTribeDescriptionSuccess"]))
                : BadRequest(new ErrorsResponse(result.Errors));
        }

        [Authorize]
        [HttpPost("/invite-tribe-member")]
        public async Task<ActionResult> AddTribeMember([FromBody] InviteTribeMemberDto dto)
        {
            var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var playerId = await _playerService.GetPlayerId(Guid.Parse(user));
            var result = await _tribeMemberService.InviteNewMember(playerId, dto.InvitedPlayerId);
            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["AddTribeMemberSuccess"]))
                : BadRequest(new ErrorsResponse(_localizer["TribeDetailsError"]));
        }

        [Authorize]
        [HttpGet("/tribe-members")]
        public async Task<ActionResult> TribeMembers([FromHeader] int tribeId)
        {
            var result = await _tribeMemberService.GetTribeUsersByTribeId(tribeId);
            return result.Succeeded
                ? Ok(result)
                : BadRequest(result);
        }

        [Authorize]
        [HttpDelete("/leave-tribe")]
        public async Task<ActionResult> LeaveTheTribe([FromHeader] Guid playerId)
        {
            var result = await _tribeMemberService.LeaveTribe(playerId);
            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["LeaveTribeSuccess"]))
                : BadRequest(result.Errors);
        }

        [Authorize]
        [HttpDelete("/remove-member")]
        public async Task<ActionResult> RemoveMember([FromBody] RemoveTribeMemberDto dto)
        {
            var result = await _tribeMemberService.RemoveTribeMember(dto.OwnerId, dto.MemberId);
            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["RemoveTribeMemberSuccess"]))
                : BadRequest(result.Errors);
        }

        [Authorize]
        [HttpDelete("/disband-tribe")]
        public async Task<ActionResult> DisbandTribe([FromBody] DisbandTribeDto dto)
        {
            var result = await _tribeService.DisbandTribe(dto);
            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["DisbandTribeSuccess"]))
                : BadRequest(new ErrorsResponse(result.Errors));
        }
    }
}
