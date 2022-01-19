using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Entities;
using Waxy.Models.Entities;
using Waxy.Repositories.GenericRepository;

namespace Waxy.Repositories.CandleRepository
{
    public class CandleRepository : GenericRepository<Candle>, ICandleRepository
    {
        public CandleRepository(WaxyContext context) : base(context) { }

        public async Task<List<Candle>> GetAllCandlesAsync()
        {
            return await _context.Candles.ToListAsync();
        }

        public async Task<List<Candle>> GetCandlesOrderedByPrice()
        {
            var orderedCandles = _context.Candles
                .Where(c => c.CandleIngredients.Count > 0) //care au mai mult de un ingredient
                .OrderBy(c => c.Price)
                .ToListAsync();

            return await orderedCandles;
        }
       
        /* aceeasi problema ca la join, fiind acel select orderedCandles este un obiect de tip anonim si nu se potrivesc tipurile
        * public async Task<List<(int,int)>> GetCandlesWithNrOfIngredients()
        {
            var orderdedCandles = _context.CandleIngredients.GroupBy(x => x.CandleId).Select(x => new
            {
                Key = x.Key,
                IngredientsCount = x.Count()
            }).ToListAsync();

            return await orderdedCandles;
        }*/
    }
}
