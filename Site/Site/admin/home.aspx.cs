using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site.admin
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // session kontrol yapılıyor
            if (Session["id"] == null) {
                Response.Redirect("Default.aspx", true);
            }
        }
    }
}