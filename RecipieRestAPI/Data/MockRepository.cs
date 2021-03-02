using RecipieRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RecipieRestAPI.Data
{
    public class MockRepository : IRecipieRepository

    {
        public void CreateDish(Dishes dis)
        {
            throw new NotImplementedException();
        }

        public void CreateLog(Logs log)
        {
            throw new NotImplementedException();
        }

        public void DeleteDish(Dishes dish)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dishes> GetAllDishes()
        {
            List<Ingridients> skladniki = new List<Ingridients>();
            var salata = new Ingridients();
            var cebula = new Ingridients();
            skladniki.Add(salata);
            skladniki.Add(cebula);
            var dania = new List<Dishes>
            {
                new Dishes{Id=0,Name="salatka",Calories=100,Ingridients=skladniki},
                new Dishes{Id=1,Name="salatka2",Calories=1200,Ingridients=skladniki},
                new Dishes{Id=2,Name="salatka3",Calories=1100,Ingridients=skladniki}
            };
            return dania;

        }

        public IEnumerable<Dishes> GetAllDishes(string KitchenType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingridients> GetAllIngridients()
        {
            throw new NotImplementedException();
        }

        public Dishes GetDishByName(string name)
        {
            var danie = GetAllDishes().Where(p => p.Name == name).FirstOrDefault();
            return danie;
        }

        public List<Ingridients> GetIngridients(int dishID)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateDish(Dishes dis)
        {
            throw new NotImplementedException();
        }

        List<Ingridients> IRecipieRepository.GetIngridients(int dishID)
        {
            throw new NotImplementedException();
        }
    }
}
