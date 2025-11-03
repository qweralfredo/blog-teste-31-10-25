using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public record Comment
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public int BlogPostId { get; private set; }
        public Comment(int id, string content, int blogPostId)
        {
            Id = id;
            Content = content;
            BlogPostId = blogPostId;
        }

        public void SetBlogPostId(int blogPostId)
        {
            BlogPostId = blogPostId;
        }
    }
}
