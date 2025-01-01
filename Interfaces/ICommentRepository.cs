using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comment;
using api.Models ;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetALLAsync() ;
        Task<Comment?> GetByIdAsync( int id) ;

        Task<Comment?> CreateAsync( Comment commentModel ) ;
        Task<Comment?> UpdataAsync( int id, UpdateCommentRequestDto commentModel ) ;
        Task<Comment?> DeleteAsync( int id ) ;


    }
}
