using Application.Common.Dto.Comment;
using Application.Common.Dto.Page;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Comments
{
    public interface ICommentService
    {
        Task<List<ViewCommentDTO>> GetAll(PageDto page);

        Task Create(CreateCommentDTO createCommentDTO);
    }
}
