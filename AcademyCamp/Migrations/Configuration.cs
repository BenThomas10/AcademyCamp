namespace AcademyCamp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AcademyCamp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AcademyCamp.Models.ApplicationDbContext";
        }

        protected override void Seed(AcademyCamp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            //  initialize.addTestData(context) Seeds Admin and User roles and creates One Administrator and two Standard User accounts
            //  Also Seeds Dropdownlist tables and adds registrant test data linked to two different standard user submissions
            //
            //      Admin User Name: "admin@admin.com"
            //      Admin Password: "Administr8tor"
            //      User1 Name: "user@user.com"
            //      User1 Password: "St@ndard1"
            //      User2 Name: "user2@user2.com"
            //      User2 Password: "St@ndard2"

            InitializeTestData initialize = new InitializeTestData();
            initialize.addTestData(context);
        }
    }
}
