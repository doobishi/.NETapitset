using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto( this Comment commentModel ) {
            return new CommentDto {
                Id = commentModel.Id,
                title = commentModel.title,
                content = commentModel.content,
                createOn = commentModel.createOn,
                stockId = commentModel.stockId
            } ;
        }

        public static Comment ToCommentFormCreate( this CreateCommentDto commentDto, int stockId ) {
            return new Comment {
                title = commentDto.title,
                content = commentDto.content,
                stockId = stockId
            } ;
        }

        public static Comment ToCommentDtoFromUpdata( this UpdateCommentRequestDto commentDto ) {
            return new Comment {
                title = commentDto.title,
                content = commentDto.content

            } ;
        }
    }
}