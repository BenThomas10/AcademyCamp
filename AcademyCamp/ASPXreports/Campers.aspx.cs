using System;
using Microsoft.AspNet.Identity;

namespace AcademyCamp.Reports
{
        public partial class Campers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                Response.Redirect("CampersByUser.aspx", true);
            }
        }
    }
}