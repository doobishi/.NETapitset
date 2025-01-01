using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dto.Stock ;
using api.Models ;

namespace api.Mappers
{
    public static class StockMappers
    {
        /*
        public int Id  { get ; set ;}
        public string symbol { get; set; } = string.Empty ;
        public string companyName { get; set ; } = string.Empty ;
        public decimal  purchase { get ; set; }
        public decimal lastDev { get; set ;}
        public string industry{ get ; set ;} = string.Empty ;
        public long marketCap { get ; set; }
        */
        public static StockDto ToStockDto( this Stock stockModel ){
            return new StockDto {
                Id = stockModel.Id,
                symbol = stockModel.symbol,
                companyName = stockModel.companyName,
                purchase = stockModel.purchase,
                lastDev = stockModel.lastDev,
                industry = stockModel.industry,
                marketCap = stockModel.marketCap,
                Comments = stockModel.Comments.Select( c => c.ToCommentDto() ).ToList() 

            } ;
        }

        public static Stock ToStockFromCreateDTO( this CreateStockRequestDto stockDto ){
            return new Stock {
                symbol = stockDto.symbol,
                companyName = stockDto.companyName,
                purchase = stockDto.purchase,
                lastDev = stockDto.lastDev,
                industry = stockDto.industry,
                marketCap = stockDto.marketCap

            } ;
        }
    }
}