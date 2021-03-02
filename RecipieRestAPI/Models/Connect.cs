using System;
using System.Collections.Generic;

namespace RecipieRestAPI.Models
{
    public partial class Connect
    {
        public long Id { get; set; }
        public long? DictId { get; set; }
        public long? IngridientId { get; set; }
    }
}
