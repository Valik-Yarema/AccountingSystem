﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingSystem.Models.Dto.AccountModelDtos
{
    public class RegisterModelDto
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

      
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\+[0-9]{11,12}$", ErrorMessage = "Wrong phone number")]
        public string PhoneNumber { get; set; }
     
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }

    }
}
