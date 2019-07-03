using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Models.Dto.AccountModelDtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }
        public string Email { get; set; }
        public  string PhoneNumber { get; set; }

        public string Message { get; set; }
    }
}
