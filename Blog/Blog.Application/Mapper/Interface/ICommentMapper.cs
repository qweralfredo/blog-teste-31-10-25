using Blog.Application.DTO;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Mapper.Interface
{
    public interface ICommentMapper
    {
        public Comment ToDomain(CommentDTO comment);

        public CommentDTO ToDTO(Comment comment);


        public List<Comment> ToDomain(List<CommentDTO> comment);

        public List<CommentDTO> ToDTO(List<Comment> comments);
    }
}
