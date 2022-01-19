using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities.DTOs
{
    public class CreateCandleDTO
    {
        public double Price { get; set; }

        public string Scent { get; set; }

        public int ContainerId { get; set; }

    }
}
