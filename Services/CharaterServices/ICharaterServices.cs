using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sdsds.Dtos.Character;

namespace sdsds.Services.CharaterServices
{
    public interface ICharaterServices
    {

        Task<ServiceResponse<List<GetCharacterDtos>> GetCharacter();
        Task<ServiceResponse<GetCharacterDtos>> GetCharacters(int id);
        Task<ServiceResponse<List<GetCharacterDtos>>> AddCharacter(AddCharacterDtos newCharacter);
        Task<object?> GetCharacters();
    }

    internal record struct NewStruct(object Item1, object Item2)
    {
        public static implicit operator (object, object)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((object, object) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}