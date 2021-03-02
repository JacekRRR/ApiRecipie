using System;
using System.Collections.Generic;

namespace RecipieRestAPI.Models
{
    public partial class Ingridients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DishesId { get; set; }
    }
}
