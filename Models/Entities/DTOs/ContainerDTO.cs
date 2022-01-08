using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities.DTOs
{
    public class ContainerDTO
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public int Material { get; set; }

        public List<Candle> Candles { get; set; }
        public Label Label { get; set; }
        //mapam doar proprietatile simple, pe restul doar le instantiem
        public ContainerDTO(Container container)
        {
            this.Id = container.Id;
            this.Color = container.Color;
            this.Material = container.Material;
            this.Candles = new List<Candle>();
            this.Label = new Label();
        }
    }
}
