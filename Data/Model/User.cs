﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name!")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter your username!")]
        public string Username { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
