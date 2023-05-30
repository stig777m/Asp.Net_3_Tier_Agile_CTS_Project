using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace project_demo_1.DAL.Models.Authentication
{

    public enum Gender
    {
        MALE = 1,
        FEMALE = 2,
        OTHERS = 3,
    }

    public class MyUser : IdentityUser
    {
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EnumDataType(typeof(Gender))]
        [Required]
        public Gender Gender { get; set; }

        [EnumDataType(typeof(Roles))]
        public string RoleAlloted { get; set; }
    }
}
