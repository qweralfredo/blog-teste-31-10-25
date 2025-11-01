using Blog.Domain;
using Blog.Infra.Data;
using Blog.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Context _context;
        public CommentRepository(Context context)
        {
            _context = context;
        }

        public async Task  CreateCommentAsync(Comment comment)
        {
           await  _context.Comments.AddAsync(new Infra.Data.Entity.CommentEntity
            {
                BlogPostId = comment.BlogPostId,
                Content = comment.Content
            });
        }

        public async Task<List<Comment>> GetCommentsByBlogPostIdAsync(int blogPostId)
        {
            var comments = await _context.Comments
                .Where(c => c.BlogPostId == blogPostId)
                .Select(c => new Comment(
                    c.Id,
                    c.Content,
                    c.BlogPostId
                )).ToListAsync();

            return comments;
        }
    }
}
