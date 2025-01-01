using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContent _context ;
        public CommentRepository( ApplicationDBContent context )
        {
            _context = context ;
        }
        public async Task<List<Comment>> GetALLAsync()
        {
            return await _context.Comments.ToListAsync() ;
        }


        public async Task<Comment?> GetByIdAsync( int id ) {
            return await _context.Comments.FindAsync(id) ;
        }

        public async Task<Comment?> CreateAsync( Comment commentModel ) {
            await _context.Comments.AddAsync( commentModel ) ;
            await _context.SaveChangesAsync() ;
            return commentModel ;
        }

        public async Task<Comment?> UpdataAsync(int id, UpdateCommentRequestDto commentDto)
        {
            var existingComment =  await _context.Comments.FindAsync( id ) ;
            if ( existingComment == null ) {
                return null ;
            }

            existingComment.title =  commentDto.title ;
            existingComment.content = commentDto.content ;
            await _context.SaveChangesAsync() ;
            return existingComment ;

        }

        public async Task<Comment?> DeleteAsync( int id ) {
            var commentModel = await _context.Comments.FirstOrDefaultAsync( x => x.Id == id ) ;
            if ( commentModel == null ) {
                return null ;
            }
            _context.Comments.Remove( commentModel ) ;
            await _context.SaveChangesAsync() ;
            return commentModel ;
        }
    }
}