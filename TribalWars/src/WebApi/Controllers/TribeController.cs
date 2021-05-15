using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
            Guid userId = new Guid();

            var tribe = _mapper.Map<Tribe>(dto);
            _tribeService.CreateTribe(tribe, userId);
            return Ok();
        }
    }
}
