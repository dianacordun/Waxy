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
                .Where(c => c.Price > 70) //au pretul mai mare de 70
                .OrderBy(c => c.Price)
                .ToListAsync();

            return await orderedCandles;
        }

    }
}
