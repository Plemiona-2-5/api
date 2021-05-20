using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ApplicationCore.Responses;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/tribe")]
    public class TribeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITribeService _tribeService;

        public TribeController(IMapper mapper, ITribeService tribeService)
        {
            _mapper = mapper;
            _tribeService = tribeService;
        }

        [HttpPost("/create-tribe")]
        public async Task<IActionResult> CreateTribe([FromBody] TribeDto dto)
        {
            var userId = new Guid();  //TODO: Read userId from session
            var tribe = _mapper.Map<Tribe>(dto);

            return Ok(new Response(await _tribeService.CreateTribe(tribe, userId)));
        }
    }
}
