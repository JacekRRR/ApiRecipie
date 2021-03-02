using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RecipieRestAPI.Models
{
    public  class RecipieContext : DbContext
    {


        public RecipieContext(DbContextOptions<RecipieContext>options):base (options)
        {

        }

        public  DbSet<Connect> Connect { get; set; }
        public  DbSet<Dishes> Dishes { get; set; }
        public  DbSet<Ingridients> Ingridients { get; set; }
        public  DbSet<Logs> Logs { get; set; }
    }
}

      