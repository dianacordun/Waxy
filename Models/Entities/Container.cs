using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities
{
    public class Container
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public int Material { get; set; }

        public ICollection<Candle> Candles { get; set; }
        public Label Label { get; set; }
    }
}
