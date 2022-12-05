using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using sdsds.Dtos.Character;
using sdsds.Services.CharaterServices;

namespace sdsds
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<Character, GetCharacterDtos>();
            CreateMap<AddCharacterDtos, Character>();
            CreateMap<UpdateCharacterDtos, Character>();
            
        }

       
    }
}