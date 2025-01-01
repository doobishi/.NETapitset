using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Comments")]
    public class Comment
    {

        public int Id { get; set; }
        
        public string title { get ; set; } = string.Empty;

        public string content { get; set ;} = string.Empty;

        public DateTime createOn { get; set;} = DateTime.Now ;


        public int?  stockId { get; set ;}

        public Stock? stock{ get; set; }
    }
}