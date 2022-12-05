using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdsds.Models
{
    public class Users
    {
        public int Id {get; set;}
        public string UserName {get; set;} 
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public List<Character>? Characters {get; set;}
    }
}