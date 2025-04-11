using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TomeOfHolding.Models.DTO;
namespace TomeOfHolding.Models
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {
            CreateMap<CharacterSheet, CharSheetCreateDTO>().ReverseMap();
        }
    }
}
