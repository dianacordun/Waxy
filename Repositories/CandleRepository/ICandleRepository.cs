using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities;

namespace Waxy.Repositories.CandleRepository
{
    public interface ICandleRepository : IGenericRepository<Candle>
    {
        Task<List<Candle>> GetAllCandlesAsync();
        Task<List<Candle>> GetCandlesOrderedByPrice();
        //Task<List<Candle>> GetCandlesWithNrOfIngredients();
    }
}
