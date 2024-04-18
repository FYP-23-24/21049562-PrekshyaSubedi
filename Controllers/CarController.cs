
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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAllCars()
        {
            return await _carService.GetAllCarsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return car;
        }

        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {
            try
            {
                var addedCar = await _carService.AddCarAsync(car);
                return CreatedAtAction(nameof(GetCarById), new { id = addedCar.Id }, addedCar);
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
        public async Task<IActionResult> UpdateCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            var success = await _carService.UpdateCarAsync(id, car);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var success = await _carService.DeleteCarAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
