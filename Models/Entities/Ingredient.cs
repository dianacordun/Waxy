using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Waxy.Models.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        [MaxLength(30), Required]
        public string Name { get; set; }

        public ICollection<CandleIngredient> CandleIngredients { get; set; }
    }
}
