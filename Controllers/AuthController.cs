using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sdsds.Data;
using sdsds.Services.CharaterServices;
using sdsds.User;

namespace sdsds.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _authRepo;


        public AuthController(IAuthRepository autRepo){

            _authRepo = autRepo;
        }

        [HttpPost("register")] 
        public async Task<ActionResult<ServiceResponse<int>>> Register (UserRegisterDto request)
        {
            var response = await _authRepo.Register(new Users {UserName = request.UserName }, request.Password); 

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok (response);
            
        }
        
        [HttpPost("login")] 
        public async Task<ActionResult<ServiceResponse<string>>> Logins (UserLoginDto loginDto)
        {
            var response = await _authRepo.Login(loginDto.UserName, loginDto.Password); 

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok (response);
            
        }
    }
}