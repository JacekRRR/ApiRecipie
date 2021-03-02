using AutoMapper;
using RecipieRestAPI.DTO;
using RecipieRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieRestAPI.Profiles
{
    public class DishProfile:Profile
    {
        public DishProfile()
        {
            CreateMap<Dishes, DishReadDTO>();
            CreateMap<DishCreateDTO, Dishes>();
            CreateMap<DishUpdateDTO, Dishes>();
            CreateMap<Dishes, DishUpdateDTO>();
        }
    }
}
