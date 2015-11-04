using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;


namespace Site
{
    public partial class sifremiUnuttum : System.Web.UI.Page
    {

        DB db = new DB();
        string dogumTarihi;
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        public string SifreOlustur()

       {
             char[] karakter = "0123456789abcdefghijklmnoprstuvyz".ToCharArray(); 
             string sonuc = "";
             Random rnd = new Random();
           for (int i = 0; i < 6; i++) 
           {
               sonuc += karakter[rnd.Next(0, karakter.Length - 1)].ToString();
           }
           return sonuc;
       }

        protected void Button1_Click(object sender, EventArgs e)
        {
                SqlCommand sorgu = new SqlCommand("select *from kullanici where mail = '"+TextBox1.Text+"' and                           dogumTarihi = '"+dogumTarihi+"'",db.baglan());
                SqlDataReader dr = sorgu.ExecuteReader();
                string yenisifre = SifreOlustur();
            if(dr.Read()){
                MailMessage mesaj = new MailMessage();
                mesaj.To.Add(new MailAddress(TextBox1.Text));
                mesaj.From = new MailAddress("erentatlisu@gmail.com", "Üyelik Sistemi", System.Text.Encoding.UTF8);
                mesaj.Subject = "Yeni Şifreniz";
                mesaj.Body = "Merhaba " + dr["adi"].ToString() + " " + dr["soyadi"].ToString() + "\n" + "\n" + "E-Mail: "                + dr["mail"].ToString() + "\n" + "Kullanıcı Adı: " + dr["kullaniciAdi"].ToString() + "\n" + "Yeni                        Şifreniz: " + yenisifre + "\n";
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.Credentials = new NetworkCredential("gönderenin mail adresi", "gönderen sifresi");
                client.EnableSsl = true;
                try
                {
                    client.Send(mesaj);
                    Label2.Text = "Şifreniz e-mail adresinize gönderilmiştir.";
                }
                catch
                {
                    Label2.Text = "Mesaj gönderilirken bir hata oluştu.";
                }
                }
              else
                {
                    Label2.Text="E-mail adresi bulunamadı."; 
                }
                    dr.Close();

                    SqlCommand SifreGuncelle = new SqlCommand("UPDATE kullanici SET sifre='" + db.MD5Sifrele(yenisifre) +                    "' WHERE mail   ='" + TextBox1.Text + "'", db.baglan());
                    SifreGuncelle.ExecuteNonQuery();
                    db.kapat();
                    TextBox1.Text = "";
                    System.Threading.Thread.Sleep(2000);
                }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
                     dogumTarihi = Calendar1.SelectedDate.ToString();

        }
             
        }
            
        }
    
