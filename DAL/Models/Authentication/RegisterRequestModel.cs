﻿using System.ComponentModel.DataAnnotations;

namespace project_demo_1.DAL.Models.Authentication
{
    public class RegisterRequestModel
    {
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }

        [EnumDataType(typeof(Gender))]
        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, MinimumLength = 3)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [EnumDataType(typeof(Roles))]
        public string RoleAlloted { get; set; }

    }
}