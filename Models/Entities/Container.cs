using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities
{
    public class Container
    {
        public int Id { get; set; }

        [MaxLength(25), Required]
        public string Color { get; set; }

        [MaxLength(20)]
        public string Material { get; set; }

        public ICollection<Candle> Candles { get; set; }
        public Label Label { get; set; }
    }
}
