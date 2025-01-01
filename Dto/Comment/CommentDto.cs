using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        
        public string title { get ; set; } = string.Empty;

        public string content { get; set ;} = string.Empty;

        public DateTime createOn { get; set;} = DateTime.Now ;


        public int?  stockId { get; set ;}
    }
}