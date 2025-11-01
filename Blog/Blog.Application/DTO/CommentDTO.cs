using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.DTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string Comment { get; set; } = String.Empty;
        public int BlogId { get; set; }
    }
}
