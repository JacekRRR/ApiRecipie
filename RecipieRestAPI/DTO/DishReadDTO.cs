using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieRestAPI.DTO
{
    public class DishReadDTO
    {
   
       
 
        public string Name { get; set; }

        public int Id { get; set; }
      
        public string Description { get; set; }

        public string Directions { get; set; }
        public int TimeForPrepare { get; set; }
    
        public int Calories { get; set; }
        public string KitchenFrom { get; set; }

        public List<IngridientReadDTO> ingridients { get; set; }
    }
}
