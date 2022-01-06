using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities
{
    public class CandleIngredient
    {
        public int CandleId { get; set; }
        public Candle Candle { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
