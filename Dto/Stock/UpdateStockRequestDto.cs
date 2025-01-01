using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10,ErrorMessage ="symbol cannot be over 10 char")]
        public string symbol { get; set; } = string.Empty ;
        [Required]
        [MaxLength(10,ErrorMessage ="company cannot be over 10 char")]
        public string companyName { get; set ; } = string.Empty ;
        [Required]
        [Range(1,100000000)]
        public decimal  purchase { get ; set; }
        [Required]
        [Range(0.01,100)]
        public decimal lastDev { get; set ;}
        [Required]
        [MaxLength(10,ErrorMessage ="industry cannot be over 10 char")]
        public string industry{ get ; set ;} = string.Empty ;
        [Required]
        [Range(1,100000000)]
        public long marketCap { get ; set; }
    }
}