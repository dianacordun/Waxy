using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities
{
    public class Candle
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public string Scent { get; set; }

        public int ContainerId { get; set; }
        public Container Container { get; set; } //navigation property

        public ICollection <CandleIngredient> CandleIngredients{ get; set; }

    }
}
