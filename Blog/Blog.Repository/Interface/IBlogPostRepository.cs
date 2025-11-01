using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Interface
{
    public interface IBlogPostRepository
    {
        public Task  CreateBlogPostAsync(BlogPost blogPost);
        public Task<BlogPost?> GetBlogPostByIdAsync(int id);
        public Task<List<BlogPost>> GetAllBlogPostsAsync();

    }
}
