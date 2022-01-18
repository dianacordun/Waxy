using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities.DTOs
{
    public class CreatorDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public CreatorDTO(Creator creator)
        {
            this.Id = creator.Id;
            this.FirstName = creator.FirstName;
            this.LastName = creator.LastName;
            this.Email = creator.Email;
        }
    }
}
