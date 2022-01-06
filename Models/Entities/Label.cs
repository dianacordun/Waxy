using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities
{
    public class Label
    {
        public int Id { get; set; }
        public string Quote { get; set; }
        public int ContainerId { get; set; }
        public Container Container { get; set; }
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
    }
    
}
