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
        public Comment ToDomain(CommentDTO commentDTO)
        {
            return new Comment(commentDTO.CommentId, commentDTO.Comment, commentDTO.BlogId);
        }

        public List<Comment> ToDomain(List<CommentDTO> comment)
        {
            var listComments = new List<Comment>();
            foreach (var commentDTO in comment)
            {
                listComments.Add(ToDomain(commentDTO));
            }
            return listComments;
        }

        public CommentDTO ToDTO(Comment comment)
        {
            return new CommentDTO
            {
                CommentId = comment.Id,
                Comment = comment.Content,
                BlogId = comment.BlogPostId
            };
        }

        public List<CommentDTO> ToDTO(List<Comment> comments)
        {
            var listCommentsDTO = new List<CommentDTO>();
            foreach (var comment in comments)
            {
                listCommentsDTO.Add(ToDTO(comment));
            }
            return listCommentsDTO;
        }
    }
}
