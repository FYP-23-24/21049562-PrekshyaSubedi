using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MitraNepAdven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearController : ControllerBase
    {
        private readonly IGearService _gearService;

        public GearController(IGearService gearService)
        {
            _gearService = gearService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gear>>> GetAllGears()
        {
            return await _gearService.GetAllGearsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gear>> GetGearById(int id)
        {
            var gear = await _gearService.GetGearByIdAsync(id);
            if (gear == null)
            {
                return NotFound();
            }
            return gear;
        }

        [HttpPost]
        public async Task<ActionResult<Gear>> AddGear(Gear gear)
        {
            try
            {
                var addedGear = await _gearService.AddGearAsync(gear);
                return CreatedAtAction(nameof(GetGearById), new { id = addedGear.Id }, addedGear);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGear(int id, Gear gear)
        {
            if (id != gear.Id)
            {
                return BadRequest();
            }

            var success = await _gearService.UpdateGearAsync(id, gear);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGear(int id)
        {
            var success = await _gearService.DeleteGearAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
