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
    }
}
