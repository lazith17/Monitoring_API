using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Monitoring_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new Exception("Something bad in Get");
            //return new string[] { "User 1", "User 2" };
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
/*             if (id < 0 || id > 100)
            {
                _logger.LogWarning("The given ID of {id} was invalid", id);
                return BadRequest("The Index was out of range");
            }
            _logger.LogInformation("The api\\Users\\{id} was called", id);
            return Ok($"Value {id}"); */

            try
            {
                if (id < 0 || id > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }
                _logger.LogInformation("The api\\Users\\{id} was called", id);
                return Ok($"Value {id}");

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "The given ID of {id} was invalid", id);
                return BadRequest("The Index was out of range");
            }
        }
    }
}