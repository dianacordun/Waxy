using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities
{
    public class Creator
    {
        public int Id { get; set; }

        [MaxLength(25), Required]
        public string FirstName { get; set; }

        [MaxLength(25), Required]
        public string LastName { get; set; }

        [MaxLength(320)]
        public string Email { get; set; }
        public ICollection<Label> Labels { get; set; }

    }
}
