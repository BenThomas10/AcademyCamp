using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace AcademyCamp.Models
{

    // Profile data added for the user by adding more properties to the ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //added Unit and Submitter name properties 

        public string Unit { get; set; }
        public string SubmitterName { get; set; }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<AcademyCamp.Models.Registrant> Registrants { get; set; }

        public System.Data.Entity.DbSet<AcademyCamp.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<AcademyCamp.Models.Unit> Units { get; set; }

        public System.Data.Entity.DbSet<AcademyCamp.Models.Workshop> Workshops { get; set; }
    }
}