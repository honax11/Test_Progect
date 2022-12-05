using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sdsds.Dtos.Character;

namespace sdsds.Services.CharaterServices
{
    public interface ICharaterServices
    {

        Task<ServiceResponse<GetCharacterDtos>> GetCharacterID(int id);
        Task<ServiceResponse<List<GetCharacterDtos>>> GetCharacters();
        Task<ServiceResponse<List<GetCharacterDtos>>> AddCharacter(AddCharacterDtos newCharacter);
        Task<ServiceResponse<GetCharacterDtos>> UpdateCharacter(UpdateCharacterDtos updatedCharacter);
        Task<ServiceResponse<List<GetCharacterDtos>>> DeleteCharter(int id);
        
    }

    
}