using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Site.admin
{
    public partial class Default : System.Web.UI.Page
    {

        DB db = new DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            String sorgu = "select *from admin where kulAdi = '" + txtAdii.Text.Trim() + "' and sifre = '" + db.MD5Sifrele(txtSifree.Text.Trim()) + "'";
            SqlCommand cm = new SqlCommand(sorgu,db.baglan());
            SqlDataReader rd = cm.ExecuteReader();


            if (rd.Read()) { 
                
                // session olayları
                Session["id"] = rd["id"].ToString();
                Session["adi"] = rd["adi"].ToString();
                Session["soyadi"] = rd["soyadi"].ToString();

                // sayfa yönlendirliyor
                Response.Redirect("home.aspx",true);
            }
        }
    }
}