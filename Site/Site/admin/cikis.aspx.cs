using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site.admin
{
    public partial class cikis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // çıkış işlemi sağlanıyor
            Session.Clear();
            Session.Abandon();
            // sayfa yönlendirmesi yapılıyor
            Response.Redirect("Default.aspx",true);
        }
    }
}