using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace RoomQuery.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            ApplicationDbContext Context = ApplicationDbContext.Create();

            string currentEmail = userIdentity.GetUserName().ToString();

            if (Context.Professors.Where(x => x.Email.Equals(currentEmail)).FirstOrDefault() != null)
            {
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, "Professor"));
            }
            else
            {
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            }

            return userIdentity;
        }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        { 
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<OfficeHour> OfficeHours { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<SRCTimestamp> Timestamps { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}