using Microsoft.AspNetCore.Mvc;
using MitraNepAdven.Models;
using MitraNepAdven.Services;

namespace MitraNepAdven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly PackageService _packageService;

        public PackageController(PackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Package>>> GetAllPackages()
        {
            return await _packageService.GetAllPackagesAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddPackage(Package package)
        {
            try
            {
                var addedPackage = await _packageService.AddPackageAsync(package);
                return CreatedAtAction(nameof(GetPackageById), new { id = addedPackage.Id }, addedPackage);
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
        public async Task<IActionResult> UpdatePackage(int id, Package package)
        {
            try
            {
                var success = await _packageService.UpdatePackageAsync(id, package);
                if (!success)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "Package not found"
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
        public async Task<IActionResult> DeletePackage(int id)
        {
            try
            {
                var success = await _packageService.DeletePackageAsync(id);
                if (!success)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "Package not found"
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
        public async Task<IActionResult> GetPackageById(int id)
        {
            try
            {
                var package = await _packageService.GetPackageByIdAsync(id);
                if (package == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "Package not found"
                    });
                }
                return Ok(package);
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
