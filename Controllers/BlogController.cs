using Microsoft.AspNetCore.Mvc;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;
using MitraNepAdven.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MitraNepAdven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogPostService)
        {
            _blogService = blogPostService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blog>>> GetAllBlog()
        {
            return await _blogService.GetAllBlogAsync();
        }
        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog)
        {
            try
            {
                var addedBlog = await _blogService.AddBlogAsync(blog);
                return CreatedAtAction(nameof(GetBlogById), new { id = addedBlog.Id }, addedBlog);
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
        public async Task<IActionResult> UpdateBlog(int id, Blog blog)
        {
            try
            {
                var success = await _blogService.UpdateBlogAsync(id, blog);
                if (!success)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "Blog not found"
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
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var success = await _blogService.DeleteBlogAsync(id);
                if (!success)
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "Blog not found"
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
        public async Task<IActionResult> GetBlogById(int id)
        {
            try
            {
                var blog = await _blogService.GetBlogByIdAsync(id);
                if (blog == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "Blog not found"
                    });
                }
                return Ok(blog);
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
      