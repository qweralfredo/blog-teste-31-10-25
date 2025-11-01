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
    public class CommentMapper : ICommentMapper
    {
        public Comment MapToDomain(Comment commentDTO)
        {
            return new Comment(commentDTO.Id, commentDTO.Content, commentDTO.BlogPostId);
        }

        public CommentDTO MapToDTO(Comment comment)
        {
            return new CommentDTO
            {
                CommentId = comment.Id,
                Comment = comment.Content,
                BlogId = comment.BlogPostId
            };
        }
    }
}
