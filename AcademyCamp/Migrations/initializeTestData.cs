using AcademyCamp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations;

namespace AcademyCamp.Migrations
{
    public class InitializeTestData
    {
        public void addTestData(AcademyCamp.Models.ApplicationDbContext context)
        {
            context.Events.AddOrUpdate(
             e => e.EventId,
            new Event { Name = "The Time Is Now", Address = "9999 Today St., Orlando FL 55555", StartDate = "2018-08-01", EndDate = "2018-08-02" },
            new Event { Name = "Gotta Cropbook", Address = "9999 Cropbook St., Sarasota FL 55555", StartDate = "2018-08-01", EndDate = "2018-08-02" },
            new Event { Name = "River Camp Kindess", Address = "9999 River St., Tampa FL 55555", StartDate = "2018-08-01", EndDate = "2018-08-02" }
            );

            context.Workshops.AddOrUpdate(
             w => w.EventId,
            new Workshop { EventId = 1, WorkshopName = "Communication" },
            new Workshop { EventId = 1, WorkshopName = "Material Things" },
            new Workshop { EventId = 1, WorkshopName = "Before You Act" },
            new Workshop { EventId = 2, WorkshopName = "Cropping Shopping" },
            new Workshop { EventId = 2, WorkshopName = "Cropping Toppings" },
            new Workshop { EventId = 3, WorkshopName = "So Sorry, Safari!" },
            new Workshop { EventId = 3, WorkshopName = "Lazy on the River" }
            );


            context.Units.AddOrUpdate(
             u => u.UnitId,
            new Unit { UnitName = "Bradenton" },
            new Unit { UnitName = "Brandon" },
            new Unit { UnitName = "Clearwater" },
            new Unit { UnitName = "Sarasota" },
            new Unit { UnitName = "St. Petersburg" },
            new Unit { UnitName = "Tampa" },
            new Unit { UnitName = "Winterhaven" }
            );

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Create first admin role and default admin user
            // Admins have unlimited rights and rights to role management  
            if (!roleManager.RoleExists("Admin"))
            {
                var admin = new ApplicationUser();
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                admin.UserName = "admin@admin.com";
                admin.Email = "admin@admin.com";
                string adminPWD = "Administr8tor";
                var chkAdmin = userManager.Create(admin, adminPWD);

                //Add default Admin to Role Admin   
                if (chkAdmin.Succeeded)
                {
                    userManager.AddToRole(admin.Id, "Admin");
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

            //Create deafult standard user 1
            var user = new ApplicationUser();
            user.UserName = "user@user.com";
            user.Email = "user@user.com";
            string userPWD = "St@ndard1";
            var chkUser = userManager.Create(user, userPWD);
            string UserId = user.Id.ToString();

            //Create deafult standard user 2
            var user2 = new ApplicationUser();
            user2.UserName = "user2@user2.com";
            user2.Email = "user2@user2.com";
            string userPWD2 = "St@ndard2";
            var chkUser2 = userManager.Create(user2, userPWD2);
            string UserId2 = user2.Id.ToString();


            string submitDate = DateTime.Now.ToString();

            context.Registrants.AddOrUpdate(
             r => r.Id,
            new Registrant { Event = "River Camp Kindness", FirstName = "Brian", LastName = "Thompson", Email = "brian@email.com", Age = 25, Gender = "M", Tsize = "M", Workshop = "So Sorry, Safari!", SubmitDate = submitDate, SubmitterId = UserId },
            new Registrant { Event = "River Camp Kindness", FirstName = "Ben", LastName = "Thompson", Email = "ben@email.com", Age = 20, Gender = "M", Tsize = "M", Workshop = "So Sorry, Safari!", SubmitDate = submitDate, SubmitterId = UserId },
            new Registrant { Event = "River Camp Kindness", FirstName = "Lisa", LastName = "Thompson", Email = "lisa@email.com", Age = 18, Gender = "F", Tsize = "L", Workshop = "Lazy on the River", SubmitDate = submitDate, SubmitterId = UserId },
            new Registrant { Event = "Gotta Cropbook", FirstName = "Linda", LastName = "Willson", Email = "linda@email.com", Age = 32, Gender = "F", Tsize = "S", Workshop = "Cropping Shopping", SubmitDate = submitDate, SubmitterId = UserId },
            new Registrant { Event = "The Time Is Now", FirstName = "Jessica", LastName = "Henry", Email = "henry@email.com", Age = 30, Gender = "F", Tsize = "XL", Workshop = "Communication", SubmitDate = submitDate, SubmitterId = UserId },
            new Registrant { Event = "The Time Is Now", FirstName = "David", LastName = "Reed", Email = "david@email.com", Age = 29, Gender = "M", Tsize = "L", Workshop = "Before You Act", SubmitDate = submitDate, SubmitterId = UserId },
            new Registrant { Event = "The Time Is Now", FirstName = "Gilbert", LastName = "Melendez", Email = "gilbert@eamil.com", Age = 25, Gender = "M", Tsize = "M", Workshop = "Communication", SubmitDate = submitDate, SubmitterId = UserId2 },
            new Registrant { Event = "The Time Is Now", FirstName = "Tina", LastName = "Herrera", Email = "tina@email.com", Age = 24, Gender = "F", Tsize = "S", Workshop = "Communication", SubmitDate = submitDate, SubmitterId = UserId2 }
            );
        }
    }
}