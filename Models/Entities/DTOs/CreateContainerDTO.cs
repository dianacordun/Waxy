using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities.DTOs
{
    public class CreateContainerDTO
    {
        public string Color { get; set; }
        public string Material { get; set; }

        //public Label Label { get; set; } //nu merge pt ca n am creatori si un label are NEAPARAT NEVOIE de creatori, deci pot sa si sterg asta

    }
}
