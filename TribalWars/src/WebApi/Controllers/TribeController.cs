﻿using ApplicationCore.Dtos;
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
        private readonly IStringLocalizer<MessageResource> _localizer;

        public TribeController(IMapper mapper, ITribeService tribeService, IStringLocalizer<MessageResource> localizer)
        {
            _mapper = mapper;
            _tribeService = tribeService;
            _localizer = localizer;
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
    }
}