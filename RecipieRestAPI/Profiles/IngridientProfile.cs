using AutoMapper;
using RecipieRestAPI.DTO;
using RecipieRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieRestAPI.Profiles
{
    public class IngridientProfile:Profile
    {
        public IngridientProfile()
        {
            CreateMap<Ingridients, IngridientReadDTO>();
        }
        
    }
}
