using Microsoft.AspNetCore.Mvc;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;
using MitraNepAdven.Services;
using System;

namespace MitraNepAdven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gallery>>> GetAllGallery()
        {
            return await _galleryService.GetAllGalleryAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddGallery(Gallery gallery)
        {
            try
            {
                var addedGallery = await _galleryService.AddGalleryAsync(gallery);
                return CreatedAtAction(nameof(GetGalleryById), new { id = addedGallery.Id }, addedGallery);
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
        public async Task<IActionResult> UpdateGallery(int id, Gallery gallery)
        {
            try
            {
                var success = await _galleryService.UpdateGalleryAsync(id, gallery);
                if (!success)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "Gallery not found"
                    });
                return NoContent();
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallery(int id)
        {
            try
            {
                var success = await _galleryService.DeleteGalleryAsync(id);
                if (!success)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "Gallery not found"
                    });
                return NoContent();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGalleryById(int id)
        {
            try
            {
                var gallery = await _galleryService.GetGalleryByIdAsync(id);
                if (gallery == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "Gallery not found"
                    });
                }
                return Ok(gallery);
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
    }
}
