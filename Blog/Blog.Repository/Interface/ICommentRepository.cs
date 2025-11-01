using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Interface
{
    public interface ICommentRepository
    {
        public Task  CreateCommentAsync(Comment comment);
        public Task<List<Comment>> GetCommentsByBlogPostIdAsync(int blogPostId);
    }
}
