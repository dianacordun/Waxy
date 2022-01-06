using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities
{
    public class Creator
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InstagramUsername { get; set; }
        public string Email { get; set; }
        public ICollection<Label> Labels { get; set; }

    }
}
