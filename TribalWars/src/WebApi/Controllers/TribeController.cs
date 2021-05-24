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
        private readonly ITribeMemberService _tribeMemberService;

        public TribeController(IMapper mapper,
                               ITribeService tribeService,
                               IStringLocalizer<MessageResource> localizer,
                               ITribeMemberService tribeMemberService)
        {
            _mapper = mapper;
            _tribeService = tribeService;
            _tribeMemberService = tribeMemberService;
            _localizer = localizer;
            _tribeMemberService = tribeMemberService;
        }

        [HttpPost("/create-tribe")]
        public async Task<IActionResult> CreateTribe([FromBody] TribeDto dto)
        {
            var playerId = new Guid();  //TODO: Read playerId from session
            var tribe = _mapper.Map<Tribe>(dto);

            var result = await _tribeService.CreateTribe(tribe, playerId);
            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["AddTribeSuccess"]))
                : BadRequest(new ErrorsResponse(result.Errors));
        }

        [HttpGet("/tribe-details")]
        public async Task<ActionResult<TribeDetailsVM>> TribeDetails()
        {
            var playerId = new Guid();  //TODO: Read playerId from session

            var result = await _tribeService.TribeDetails(playerId);
            return result.Succeeded
                ? Ok(result.Content)
                : BadRequest(new ErrorsResponse(result.Errors));
        }

        [HttpPut("/edit-tribe-description")]
        public async Task<ActionResult<TribeDescriptionDto>> EditTribeDescription([FromHeader] int tribeId, [FromBody] TribeDescriptionDto dto)
        {
            var playerId = new Guid();//new Guid();  //TODO: Read playerId from session
            var result = await _tribeService.EditTribeDescription(playerId, dto, tribeId);

            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["EditTribeDescriptionSuccess"]))
                : BadRequest(new ErrorsResponse(result.Errors));
        }

        [HttpPost("/invite-tribe-member")]
        public async Task<ActionResult> AddTribeMember([FromBody] InviteTribeMemberDto dto)
        {
            var playerId = new Guid();  //TODO: Read playerId from session
            var result = await _tribeMemberService.InviteNewMember(playerId, dto.InvitedPlayerId);
            return result.Succeeded
                ? Ok(new SuccessResponse(_localizer["AddTribeMemberSuccess"]))

        [HttpGet("/tribe-members")]
        public async Task<ActionResult> TribeMembers([FromHeader] int tribeId)
        {
            var result = await _tribeMemberService.GetTribeUsersByTribeId(tribeId);
            return result.Succeeded
                ? Ok(_mapper.Map<List<TribeMemberVM>>(result.Content))
                : BadRequest(new ErrorsResponse(result.Errors));
        }
    }
}
