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
        public List<Comments> Comments { get; private set; }
        public BlogPost(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        public void AddComment(Comments comment)
        {
            if (Comments == null)
            {
                Comments = new List<Comments>();
            }
            Comments.Add(comment);
        }
    }
}
