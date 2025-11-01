using Blog.Repository.Interface;
using Blog.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        [HttpDelete]
        [Route("api/blogpost/blog-post")]
        public async Task<IActionResult> GetAllBlogPost()
        {
            return Ok( await blogPostService.GetAllPosts());
        }


    }
}
