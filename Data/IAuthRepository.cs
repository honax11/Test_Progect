using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sdsds.Services.CharaterServices;

namespace sdsds.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register (Users user, string password);
        Task<ServiceResponse<string>> Login (string userName, string password);
        Task<bool> UserExists(string userName);
        
    }
}