Academy Camp Example Application

This application was developed by Benjamin Thomas for git testing and code example purposes. 
It is not currently a complete application.  This version of Acedemy Camp is a simple ASP.NET MVC 5 event registration web application
demonstrating use of Entity Framework, Code First, Identity, C#, Unobtrusive Javascript, LINQ, Json, Razor, Bootstrap, and CSS. 
Webforms are used for thier built-in rdlc ReportViewer tool.

Before testing the application, make sure your App_Data folder has at least authenticated user read/write NTSF 
permissions. Using Visual Studio 2015 or above, enable migrations in the VS Package Manager Console and run update-database 
to build the AcademyCampDB to a local SQL instance and seed test data. The migration creates Admin and User roles 
and populates one Administrator and two Standard User accounts. It also populates test Dropdownlist data and adds registrant data 
that is linked to two different standard user accounts.

Adjust the DefaultConnection connectionString in Web.config to change SQL connection settings.

	To use Acedemy Camp as an administrator log in with the following credentials:

	Admin User: "admin@admin.com"
	Admin User Password: "Administr8tor"
	Administrators have a global view of user data and can create Units (locations), Events, and Event Workshops.

	To use Academy Camp as a standard user:

	Standard User: "user@user.com"
    Standard User Password: "St@ndard1"

    Standard User2: "user2@user2.com"
    Standard User2 Password: "St@ndard2"
	Users can create registration data and view only the registration data they have created.


Benjamin Thomas : benthomas10.email@gmail.com

