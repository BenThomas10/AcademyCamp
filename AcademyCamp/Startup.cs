using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AcademyCamp.Models;

[assembly: OwinStartupAttribute(typeof(AcademyCamp.Startup))]
namespace AcademyCamp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandAdmin();
        }

        // Create default roles and administrative user if no admin exists
        private void CreateRolesandAdmin()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Create admin role and default admin user if no admin exists
            // Admins have unlimited data rights and rights to role management  
            if (!roleManager.RoleExists("Admin"))
            { 
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
     
                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                string userPWD = "Administr8tor";
                var chkUser = userManager.Create(user, userPWD);

                //Add default Admin to Role Admin   
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            //Create Manager role (for future build)
            //Managers have limited but expanded rights and no rights to role management     
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            //Create Power role (for future build)
            //Powers have an even more limited rights-set but have more rights than a base authenticated user  
            if (!roleManager.RoleExists("Power"))
            {
                var role = new IdentityRole();
                role.Name = "Power";
                roleManager.Create(role);

            }
        }
    }
}

