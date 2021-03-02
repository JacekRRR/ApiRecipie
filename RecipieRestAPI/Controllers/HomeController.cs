using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RecipieRestAPI.Data;
using RecipieRestAPI.DTO;
using RecipieRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace RecipieRestAPI.Controllers
{
    [Route("api/recipies")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRecipieRepository _repository;
        private readonly IMapper _mapper;

        public HomeController(IRecipieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("/{KitchenType}")]
        public ActionResult<IEnumerable<Dishes>> GetAllDishes(string? KitchenType)
        {
            var AllDishes = _repository.GetAllDishes(KitchenType); ;
            if (AllDishes != null && KitchenType != "time" && KitchenType != "bping") 
            {
                foreach (var item in AllDishes)
                {
                    var ii = _repository.GetIngridients(item.Id);
                    item.Ingridients = ii;
                }
                return Ok(AllDishes);
            }
            else if (KitchenType == "time"||KitchenType== "bping")
            {
                return Ok(AllDishes);
            }

            return NotFound();
        }

        [HttpGet("[action]")]

        public ActionResult<Ingridients> GetIngridientList()
        {
            List<Ingridients> allIngridients = new List<Ingridients>();
            allIngridients = _repository.GetAllIngridients().ToList();
          
            return Ok(allIngridients);
        }



        [HttpGet("[action]/{name}")]
        public ActionResult<Dishes> GetDishByName(string name)
        {
            var dd = _repository.GetDishByName(name);
            if (dd != null)
            {
                var ii = _repository.GetIngridients(dd.Id);
                dd.Ingridients = ii;
                return Ok(_mapper.Map<Dishes>(dd));
            }
            return Ok(dd);
        }

        [HttpPost]
        public ActionResult<DishReadDTO> Create(DishCreateDTO createdDish)
        {
            var createItem = _mapper.Map<Dishes>(createdDish);
            _repository.CreateDish(createItem);
            _repository.SaveChanges();

            var dishReadDTO = _mapper.Map<DishReadDTO>(createItem);

            return CreatedAtRoute(nameof(GetDishByName), new { name = dishReadDTO.Name }, dishReadDTO);

        }


        [HttpPut("[action]/{log}")]
        public ActionResult AddLog([FromBody] Logs log)
        {
            try
            {
                _repository.CreateLog(log);

                _repository.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPut("[action]/{dishUpdateDTO}")]
        public ActionResult UpdateDish(Dishes dishUpdateDTO)
        {
           
            _repository.UpdateDish(dishUpdateDTO);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{name}")]
        public ActionResult PartialUpdadeDish(string name, JsonPatchDocument<DishUpdateDTO> patchDoc)
        {
            var dishModelFromRepo = _repository.GetDishByName(name);

            if (dishModelFromRepo == null)
            {
                return NotFound();
            }
            var dishToPatch = _mapper.Map<DishUpdateDTO>(dishModelFromRepo);
            patchDoc.ApplyTo(dishToPatch, ModelState);

            if (!TryValidateModel(dishToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(dishToPatch, dishModelFromRepo);
            _repository.UpdateDish(dishModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{name}")]

        public ActionResult DeleteDish(string name)
        {
            var dishModelFromRepo = _repository.GetDishByName(name);

            if (dishModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteDish(dishModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }
    }
}
