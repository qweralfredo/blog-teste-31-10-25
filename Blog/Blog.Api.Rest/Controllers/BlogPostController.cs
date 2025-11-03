using Blog.Application.DTO;
using Blog.Application.Mapper.Interface;
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
        private readonly IBlogPostMapper blogPostMapper;
        private readonly ICommentMapper commentMapper;

        public BlogPostController(IBlogPostService blogPostService, IBlogPostMapper blogPostMapper, ICommentMapper commentMapper)
        {
            this.blogPostService = blogPostService;
            this.blogPostMapper = blogPostMapper;
            this.commentMapper = commentMapper;
        }

        [HttpGet]
        [Route("api/posts")]
        public async Task<IActionResult> GetAllBlogPost()
        {
            var blogPosts = await blogPostService.GetAllPosts();
            return Ok(blogPostMapper.ToDTO(blogPosts));
        }

        [HttpGet]
        [Route("api/posts/{blogPostId}")]
        public async Task<IActionResult> GetBlogPostById(int blogPostId)
        {
            var blogPost = await blogPostService.GetPostById(blogPostId);
            if (blogPost == null)
            {
                return NotFound("Post não encontrado");
            }
            return Ok(blogPostMapper.ToDTO(blogPost));
        }

        [HttpPost]
        [Route("api/posts")]
        public async Task<IActionResult> CreatePost([FromBody] BlogPostDTO blogPostDTO)
        {
            await blogPostService.CreatePost(blogPostMapper.ToDomain(blogPostDTO));            
            return Ok("Criado com sucesso");
        }

        [HttpPost]
        [Route("api/posts/{blogPostId}/comments")]
        public async Task<IActionResult> CreateComment([FromBody] CommentDTO comment, int blogPostId)
        {
            await blogPostService.CreateComment(blogPostId, commentMapper.ToDomain(comment));
            return Ok("Criado com sucesso");
        }


    }
}
