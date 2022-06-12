using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly IDbService _dbService;

        public MusiciansController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveMusician(int id)
        {
            var result = await _dbService.RemoveMusician(id);
            if (result)
            {
                return Ok("Removed Musician");
            } else
            {
                return BadRequest();
            }
        }

    }
}
