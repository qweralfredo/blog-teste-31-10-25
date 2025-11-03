using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Interface
{
    public interface IBlogPostService
    {
        public Task CreatePost(BlogPost blogPost);
        public Task<List<BlogPost>> GetAllPosts();

        public Task<BlogPost> GetPostById(int id);

        public Task<List<Comment>> GetComments(int idBlogPostId);

        public Task CreateComment(int blogPostId, Comment comment);

    }
}
