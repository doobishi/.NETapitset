using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Stocks")]
    public class Stock
    {
        public int Id  { get ; set ;}

        public string symbol { get; set; } = string.Empty ;

        public string companyName { get; set ; } = string.Empty ;
        [ Column( TypeName = "decimal(18,2)")]

        public decimal  purchase { get ; set; }
        [ Column( TypeName = "decimal(18,2)")]

        public decimal lastDev { get; set ;}

        public string industry{ get ; set ;} = string.Empty ;

        public long marketCap { get ; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>() ;
        // public List<Portfolio> Portfolio {get; set; } = new List<Portfolio>() ;
    }
}