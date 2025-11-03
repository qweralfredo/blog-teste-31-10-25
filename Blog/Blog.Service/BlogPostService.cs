using Blog.Domain;
using Blog.Repository.Interface;
using Blog.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICommentRepository commentRepository;
        public BlogPostService(IBlogPostRepository blogPostRepository, ICommentRepository commentRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.commentRepository = commentRepository;
        }

        public Task CreateComment(int blogPostId, Comment comment)
        {
            comment.SetBlogPostId(blogPostId);
            return commentRepository.CreateCommentAsync(comment);
        }

        public async Task CreatePost(BlogPost blogPost)
        {
            await blogPostRepository.CreateBlogPostAsync(blogPost);
        }

        public async Task<List<BlogPost>> GetAllPosts()
        {
            return await blogPostRepository.GetAllBlogPostsAsync();
        }

        public Task<List<Comment>> GetComments(int idBlogPostId)
        {
            return commentRepository.GetCommentsByBlogPostIdAsync(idBlogPostId);
        }

        public async Task<BlogPost> GetPostById(int id)
        {
            var post = await blogPostRepository.GetBlogPostByIdAsync(id); 
            return post;
        }
    }
}
