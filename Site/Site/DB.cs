using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

using System.Web;


// client kütüphanesi ekleniyor
using System.Data.SqlClient;
using System.Data;

// şifreleme kütüphanesi
using System.Security.Cryptography; 


public class DB
    {
        // default vt adı
        String dbName = "forum";

        // sql connection sınıfı
        public SqlConnection baglanti;

        public DB() { 
            // boş kurucu method
        }

        public DB(String dbName) { 
            // vt adı olan kurucu method
            this.dbName = dbName;
        }


        // bağlan fonksiyonu oluşturuluyor
        public SqlConnection baglan() {
            try
            {
                baglanti = new SqlConnection("Data Source=.; Initial Catalog=" + dbName + "; Integrated Security = true");
                // bağlantı kontrolü
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
            }
            catch (Exception ex)
            {
                // bağlantı varsa burada hatayı yaz
                //MessageBox.Show("Bağlantı Hatası " + ex);
            }
            return baglanti;
        }


        // kapat fonksiyonu
        public void kapat() {
            if (baglanti.State == ConnectionState.Open) {
                baglanti.Close();
            }
        }


        // data getirme fonksiyonu
        SqlDataReader rd;
        public SqlDataReader dataGetir(String sorgu) {
            SqlCommand cm = new SqlCommand(sorgu, baglan());
            rd = cm.ExecuteReader();
            return rd;
        }




        public string MD5Sifrele(string metin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

    }

