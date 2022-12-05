using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sdsds.Dtos.Character;
using sdsds.Services.CharaterServices;

namespace sdsds.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharaterServices _charaterServices;

        public CharacterController (ICharaterServices charaterServices)
        {
            _charaterServices = charaterServices;

        }

        [HttpGet ("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDtos>>>> Get()
        {
            return Ok(await _charaterServices.GetCharacters());
        }
        
         [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDtos>>> GetSingle(int id)
        {
            return Ok(await _charaterServices.GetCharacterID(id));
        }

        [HttpDelete("{id}")]
         public async Task<ActionResult<ServiceResponse<List<GetCharacterDtos>>>> Delete(int id)
         {
              var response = await _charaterServices.DeleteCharter(id);

                 if (response.Data == null)
                {
                    return NotFound(response);
                 }
                 return Ok (response);
         }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDtos>>>> AddCharacter(AddCharacterDtos newCharactor) => Ok(await _charaterServices.AddCharacter(newCharactor));



         [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDtos>>> UpdateCharacter(UpdateCharacterDtos updateCharacter){

                var response = await _charaterServices.UpdateCharacter(updateCharacter);

                if (response.Data == null)
                {
                    return NotFound(response);
                 }
                 return Ok (response);

         }
    }
}