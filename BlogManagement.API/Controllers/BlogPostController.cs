using BlogManagement.Application.IService;
using BlogManagement.Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = _blogPostService.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _blogPostService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BlogPostModel post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _blogPostService.Add(post);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BlogPostModel post)
        {
            if (id != post.Id)
            {
                return BadRequest("Id not matched between route parameter and body.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _blogPostService.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = _blogPostService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            _blogPostService.Delete(id);
            return NoContent();
        }
    }
}
