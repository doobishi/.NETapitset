using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Comment
{
    public class UpdateCommentRequestDto
    {   [Required]
        [MinLength( 5, ErrorMessage = "title must be 5 char")]
        [MaxLength( 200, ErrorMessage = "title must not over 200 char")]
        public string title { get ; set; } = string.Empty;
        [Required]
        [MinLength( 5, ErrorMessage = "content must be 5 char")]
        [MaxLength( 200, ErrorMessage = "content must not over 200 char")]
        public string content { get; set ;} = string.Empty;



    }
}