using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data.Entity
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string Content { get; set; } = string.Empty;
        public BlogPostEntity BlogPost { get; set; } = null!;
    }
}
