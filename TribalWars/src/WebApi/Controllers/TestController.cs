using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("api/v1/tests")]
        public IActionResult GetTests()
        {
            return Ok(new List<object>{new {Id = 1, Message = "works fine"}, new {Id = 2, Message = "works good"}});
        }
        
        [HttpGet("api/v1/tests/{testId}")]
        public IActionResult GetTestById([FromRoute] int testId)
        {
            return Ok(new {Id = testId, Message = "works fine"});
        }

        [HttpPost("api/v1/tests")]
        public IActionResult Post([FromBody] CreateMessageRequest request)
        {
            return NoContent();
        }
    }

    public class CreateMessageRequest
    {
        public string Message { get; set; }
    }
}