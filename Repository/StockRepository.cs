using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Stock;
using api.Helper;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContent _context ;
        public StockRepository( ApplicationDBContent context )
        {
            _context = context ;
        }
        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync( stockModel ) ;
            await _context.SaveChangesAsync() ;
            return stockModel ;
        }


        public async Task<Stock?> DeleteAsync( int id ) 
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync( x => x.Id == id ) ;
            if ( stockModel == null ) {
                return null ;
            }
            _context.Stocks.Remove( stockModel ) ;
            await _context.SaveChangesAsync() ;
            return stockModel ;
        }

    
        public async Task<List<Stock>> GetALLAsync( QueryObject query  )
        {
            var stocks = _context.Stocks.Include( c => c.Comments ).AsQueryable() ;
            if ( !string.IsNullOrWhiteSpace( query.CompanyName) ) {
                stocks = stocks.Where( s => s.companyName.Contains(query.CompanyName ) ) ;
            }
            if (!string.IsNullOrWhiteSpace( query.Symbol)) {
                stocks = stocks.Where( s => s.symbol.Contains( query.Symbol ));
            }
            if ( !string.IsNullOrWhiteSpace(query.SortBy)) {
                if ( query.SortBy.Equals( "Symbol", StringComparison.OrdinalIgnoreCase) ) {
                    stocks = query.IsDecsending ? stocks.OrderByDescending( s => s.symbol ) : stocks.OrderBy( s => s.symbol ) ;
                }
            }
            
            return await stocks.ToListAsync() ;
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include( c => c.Comments ).FirstOrDefaultAsync( i => i.Id == id ) ;
        }


        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync( x => x.Id == id ) ;
            if (  existingStock == null ) {
                return null ;
            }

            existingStock.symbol = stockDto.symbol ;
            existingStock.companyName = stockDto.companyName ;
            existingStock.purchase = stockDto.purchase ;
            existingStock.lastDev = stockDto.lastDev ;
            existingStock.industry = stockDto.industry ;
            existingStock.marketCap = stockDto.marketCap ;
            
            await _context.SaveChangesAsync() ;

            return existingStock ;
        }

        public async Task<bool> StockExists( int id ) {
            return await _context.Stocks.AnyAsync( s => s.Id == id ) ;
        }

    }
}