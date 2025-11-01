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
        public Comment MapToDomain(Comment comment);

        public CommentDTO MapToDTO(Comment comment);
    }
}
