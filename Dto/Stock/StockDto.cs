using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comment;

namespace api.Dto.Stock
{
    public class StockDto
    {

        public int Id  { get ; set ;}

        public string symbol { get; set; } = string.Empty ;

        public string companyName { get; set ; } = string.Empty ;

        public decimal  purchase { get ; set; }


        public decimal lastDev { get; set ;}

        public string industry{ get ; set ;} = string.Empty ;

        public long marketCap { get ; set; }

        public List<CommentDto> Comments { get; set ;}

    }
}