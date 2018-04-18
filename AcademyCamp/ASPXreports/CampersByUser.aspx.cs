using Microsoft.AspNet.Identity;
using System;

namespace AcademyCamp.Reports
{
    public partial class CampersByUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserId.Text = User.Identity.GetUserId();
        }
    }
}