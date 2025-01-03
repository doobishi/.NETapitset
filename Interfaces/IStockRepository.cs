using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Stock;
using api.Helper;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetALLAsync( QueryObject query ) ;

        Task<Stock?> GetByIdAsync( int id ) ;

        Task<Stock> CreateAsync( Stock stockModel ) ;
        
        Task<Stock?> UpdateAsync( int id, UpdateStockRequestDto stockDto ) ;

        Task<Stock?> DeleteAsync( int id ) ;

        Task<bool> StockExists(int id) ;

    }
}