using RecipieRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieRestAPI.Data
{
    public interface IRecipieRepository
    {
        bool SaveChanges();
        IEnumerable<Dishes> GetAllDishes(string KitchenType);
        IEnumerable<Ingridients> GetAllIngridients();

        Dishes GetDishByName(string name);

        List<Ingridients> GetIngridients(int dishID);

        void CreateDish(Dishes dis);

        void UpdateDish(Dishes dis);

        void DeleteDish(Dishes dish);

        void CreateLog(Logs log);

    }
}
