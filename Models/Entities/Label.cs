using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities
{
    public class Label
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Quote { get; set; }
        public int ContainerId { get; set; }
        public Container Container { get; set; }
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
    }
    
}
