using Blog.Domain;
using Blog.Infra.Data;
using Blog.Infra.Data.Entity;
using Blog.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly Context context;
        public BlogPostRepository(Context context)
        {
            this.context = context;
        }
        public async Task CreateBlogPostAsync(BlogPost blogPost)
        {
            await context.BlogPosts.AddAsync(new BlogPostEntity
            {
                Title = blogPost.Title,
                Content = blogPost.Content
            });
            await context.SaveChangesAsync();
        }

        public async Task<List<BlogPost>> GetAllBlogPostsAsync()
        {
            var blogPosts = await context.BlogPosts.Select(bp => new BlogPost(bp.Id, bp.Title, bp.Content)).ToListAsync();
            return blogPosts;
        }

        public Task<BlogPost?> GetBlogPostByIdAsync(int id)
        {
            return context.BlogPosts
                .Where(bp => bp.Id == id)
                .Select(bp => new BlogPost(bp.Id, bp.Title, bp.Content))
                .FirstOrDefaultAsync();
        }
    }
}
