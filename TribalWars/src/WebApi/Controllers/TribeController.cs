using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ApplicationCore.Response;

namespace WebApi.Controllers
{
    [ApiController]
    public class TribeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITribeService _tribeService;

        public TribeController(IMapper mapper, ITribeService tribeService)
        {
            _mapper = mapper;
            _tribeService = tribeService;
        }

        [HttpPost("api/v1/Tribe/CreateTribe")]
        public async Task<IActionResult> CreateTribe([FromBody] TribeDto dto)
        {
            //TODO: Read userId from session
            Guid userId = new Guid(); 
            var tribe = _mapper.Map<Tribe>(dto);

            return Ok(new Response(await _tribeService.CreateTribe(tribe, userId)));
        }
    }
}
