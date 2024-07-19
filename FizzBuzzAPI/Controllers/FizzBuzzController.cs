using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FizzBuzzAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string[] values)
        {
            if (values == null || values.Length == 0)
            {
                return BadRequest("Input array is empty or null.");
            }

            var results = values.Select(v => _fizzBuzzService.ProcessValue(v)).ToList();
            return Ok(results);
        }
    }
}
