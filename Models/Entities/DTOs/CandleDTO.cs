using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities.DTOs
{
    public class CandleDTO
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public string Scent { get; set; }

        public int ContainerId { get; set; }

        public Container Container { get; set; }

        public List<CandleIngredient> CandleIngredients { get; set; }
        public CandleDTO(Candle candle)
        {
            this.Id = candle.Id;
            this.Price = candle.Price;
            this.Scent = candle.Scent;
            this.CandleIngredients = new List<CandleIngredient>();
            this.ContainerId = candle.ContainerId;
            this.Container = new Container();
        }
    }
}
