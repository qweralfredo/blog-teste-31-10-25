using Blog.Application.DTO;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Mapper.Interface
{
    public interface IBlogPostMapper
    {
        public BlogPost ToDomain(BlogPostDTO blogPostDTO);
        public BlogPostDTO ToDTO(BlogPost blogPost);
    }
}
