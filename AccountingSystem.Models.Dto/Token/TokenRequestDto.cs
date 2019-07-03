using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingSystem.Models.Dto.Token
{
   public class TokenRequestDto
    {
       // [Required]
      //  [JsonProperty("username")]
        public string UserName { get; set; }


     //   [Required]
     //   [JsonProperty("password")]
        public string Password { get; set; }
    }
}
