using Blog.Application.DTO;
using Blog.Application.Mapper.Interface;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Mapper
{
    public class BlogPostMapper : IBlogPostMapper
    {
        public BlogPost ToDomain(BlogPostDTO blogPostDTO)
        {
            var blogPost = new BlogPost(blogPostDTO.BlogId, blogPostDTO.Title, blogPostDTO.Content, new List<Comment>());
            foreach (var commentDTO in blogPostDTO.Comments)
            {
                var comment = new Comment(commentDTO.CommentId, commentDTO.Comment, blogPost.Id);
                blogPost.AddComment(comment);
            }
            return blogPost;
        }

        public List<BlogPost> ToDomain(List<BlogPostDTO> blogPostlist)
        {
            var domainList = new List<BlogPost>();
            foreach (var blogPostDTO in blogPostlist)
            {
                domainList.Add(ToDomain(blogPostDTO));
            }
            return domainList;
        }

        public BlogPostDTO ToDTO(BlogPost blogPost)
        {
            var blogPostDTO = new BlogPostDTO
            {
                BlogId = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                Comments = blogPost.Comments.Select(c => new CommentDTO
                {
                    CommentId = c.Id,
                    Comment = c.Content,
                    BlogId = c.BlogPostId
                }).ToList()
            };
            return blogPostDTO;
        }

        public List<BlogPostDTO> ToDTO(List<BlogPost> blogPostlist)
        {
            var dtoList = new List<BlogPostDTO>();
            foreach (var blogPost in blogPostlist)
            {
                dtoList.Add(ToDTO(blogPost));
            }
            return dtoList;
        }
    }
}
