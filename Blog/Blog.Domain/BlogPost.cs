using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain
{
    public class BlogPost
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public List<Comment> Comments { get; private set; } = new List<Comment>();
        public BlogPost(int id, string title, string content, List<Comment> comments)
        {
            Id = id;
            Title = title;
            Content = content;
            Comments = comments;
        }


        public void AddComment(Comment comment)
        {
            if (Comments == null)
            {
                Comments = new List<Comment>();
            }
            Comments.Add(comment);
        }
    }
}
