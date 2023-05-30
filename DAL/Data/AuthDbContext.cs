using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project_demo_1.DAL.Models.Authentication;

namespace project_demo_1.DAL.Data
{
    public class AuthDbContext : IdentityDbContext<MyUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}
