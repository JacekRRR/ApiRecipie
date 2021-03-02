using Microsoft.EntityFrameworkCore;
using RecipieRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieRestAPI.Data
{
    public class RecipieContext:DbContext
    {
        public RecipieContext(DbContextOptions<RecipieContext> options):base(options)
        {

        }

        public   DbSet<Dishes> dishes { get; set; }

        public DbSet<Ingridients> ingridients { get; set; }
        
        public DbSet<Connect> connect { get; set; }

        public DbSet<Logs> logs { get; set; }
    }
}
