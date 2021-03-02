using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieRestAPI.DTO
{
    public class DishUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Directions { get; set; }
        [Required]
        public int TimeForPrepare { get; set; }
        [Required]
        public int Calories { get; set; }
        [Required]
        public List<IngridientReadDTO> ingridients { get; set; }

    }
}
