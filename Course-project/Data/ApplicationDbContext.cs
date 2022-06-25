using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Course_project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "sasha",
                    UserName = "sasha",
                    Email ="sirlolka@gmail.com"
                });
            base.OnModelCreating(builder);

        }
    }
}
