using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Account
{
    
    public class NewUserDto
    {

        public string UserName{ get ; set; }
        public string Email { get; set; }
        public string Token { get; set; } 
        public NewUserDto(string userName, string email, string token)
        {
            UserName = userName;
            Email = email;
            Token = token;
        }
        
    }
    
}