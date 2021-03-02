using System;
using System.Collections.Generic;

namespace RecipieRestAPI.Models
{
    public partial class Logs
    {
        public int Id { get; set; }
        public string TypeOdError { get; set; }
        public string UserId { get; set; }
        public DateTime? LogDate { get; set; }
    }
}
