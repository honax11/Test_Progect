using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sdsds.Dtos.Character;
using sdsds.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace sdsds.Services.CharaterServices
{
    public class CharacterServices : ICharaterServices
    {


        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character { Id = 1, Name = "Sem"}
            
        };
        
        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;

        

    
        public CharacterServices (DataContext dbcontext, IMapper mapper ){

            _dbcontext = dbcontext;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetCharacterDtos>>> AddCharacter(AddCharacterDtos newCharacter)
        {
            var serviceReponse = new ServiceResponse<List<GetCharacterDtos>>();
            Character character = _mapper.Map<Character>(newCharacter);
            _dbcontext.Characters.Add(character);
            await _dbcontext.SaveChangesAsync();
            serviceReponse.Data = await _dbcontext.Characters
                .Select(c => _mapper.Map<GetCharacterDtos>(c))
                .ToListAsync();
            return serviceReponse;


        }

        public async Task<ServiceResponse<GetCharacterDtos>> GetCharacterID(int id)
        {
            var serviceReponse = new ServiceResponse<GetCharacterDtos>();
            var dbcharacter = await _dbcontext.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceReponse.Data = _mapper.Map<GetCharacterDtos>(dbcharacter);
            return serviceReponse;
        }

        public async  Task<ServiceResponse<List<GetCharacterDtos>>> GetCharacters()
        {
        var response = new ServiceResponse<List<GetCharacterDtos>>();
           var dbcharacters = await _dbcontext.Characters.ToListAsync();
           response.Data = characters.Select(c => _mapper.Map<GetCharacterDtos>(c)).ToList();
           return response;
          
           
        }


        public async Task<ServiceResponse<GetCharacterDtos>> UpdateCharacter(UpdateCharacterDtos updatedCharacter)
        {
            ServiceResponse<GetCharacterDtos> response = new  ServiceResponse<GetCharacterDtos> ();

            try
            {
                var character = await _dbcontext.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);


                character.Name = updatedCharacter.Name;
                character.HitPoinst = updatedCharacter.HitPoinst;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                await _dbcontext.SaveChangesAsync();


                response.Data = _mapper.Map<GetCharacterDtos>(character);

            }

        catch(Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;

        }


        public async Task<ServiceResponse<List<GetCharacterDtos>>> DeleteCharter(int id)
        {

             ServiceResponse<List<GetCharacterDtos>>response = new  ServiceResponse<List<GetCharacterDtos>>();

             try
             {
                Character character = await _dbcontext.Characters.FirstAsync(c => c.Id == id);
                _dbcontext.Characters.Remove(character);
                await _dbcontext.SaveChangesAsync();


                response.Data = _dbcontext.Characters.Select(c => _mapper.Map<GetCharacterDtos>(c)).ToList();

             }
             catch(Exception ex)
             {
                response.Success = false;
                response.Message = ex.Message;
             }

             return response;

        }

    
    }
}