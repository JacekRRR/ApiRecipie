using Microsoft.EntityFrameworkCore;
using RecipieRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RecipieRestAPI.Data
{
    public class SQLRecipieRepo : IRecipieRepository
    {
        private readonly RecipieContext _context;

        public SQLRecipieRepo(RecipieContext context)
        {
            _context=context;
        }

        public void CreateDish(Dishes dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.dishes.Add(dis);

        }

        public void CreateLog(Logs log)
        {
            _context.logs.Add(log);
        }

        public void DeleteDish(Dishes dish)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dishes> GetAllDishes(string KitchenType)
        {
            if (KitchenType == "time" || KitchenType == "Ing" || KitchenType == "bping")
            {
                return _context.dishes.ToList();
            }
            
            return _context.dishes.ToList().Where(x=>x.KitchenFrom==KitchenType);
        }

        public IEnumerable<Ingridients> GetAllIngridients()
        {
            return _context.ingridients.ToList();
        }

        public Dishes GetDishByName(string name)
        {   
            return _context.dishes.FirstOrDefault(p=>p.Name==name);
        }

        public List<Ingridients> GetIngridients(int dishId)
        {
            List<Ingridients> listIngridients = new List<Ingridients>();
            var setter=_context.connect.Where(x => x.DictId ==dishId).ToList();
            foreach (var item in setter)
            { 
                var ingridients = _context.ingridients.Where(x => x.Id == item.IngridientId).FirstOrDefault();
                listIngridients.Add(new Ingridients()
                {
                    Name = ingridients.Name,
                    Id = ingridients.Id
                });
            }
            return listIngridients;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges())>=0;
        }

        public void UpdateDish(Dishes dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            var returnValue = _context.Database
           .ExecuteSqlCommand("dbo.addingFullDish {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", dis.Name,dis.Description,
           dis.Directions1,dis.Directions2,dis.Directions3,dis.Directions4,dis.PictUrl,dis.TimeForPrepare,
           dis.Calories,dis.IngridientsList,dis.KitchenFrom,dis.Video);
        }
    }
}
