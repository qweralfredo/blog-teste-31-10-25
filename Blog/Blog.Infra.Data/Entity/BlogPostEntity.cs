using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data.Entity
{
    public class BlogPostEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
    }
}
