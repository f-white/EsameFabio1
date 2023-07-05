using EsameFabio1.DB;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EsameFabio1.DB.Entities;
using EsameFabio1.Commons;

namespace EsameFabio1.Models
{
    public class UserModel
    {
       
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(ConstantValues.PasswordMinLenght, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

     
    }
}