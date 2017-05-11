using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BulBiziWebServis
{
    /// <summary>
    /// Summary description for Servis
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Servis : System.Web.Services.WebService
    {

        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            return conString;
        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


         [WebMethod]
        public String Ekle(String email, String sifre, int il_id, int ilce_id, String magaza_adi, String sahibi, String web_sitesi, Int64 telefon, String icerik, String resim, double x, double y)
        {
            SqlConnection con = new SqlConnection(ConnectionState());
            try
            {
                SqlCommand cmd = new SqlCommand("Insert Into magaza (email,sifre,il_id,ilce_id,magaza_adi,sahibi,web_sitesi,telefon,icerik,resim,x,y)"+
                    " Values ('" + email + "','" + sifre + "'," + il_id + "," + ilce_id + ",'" + magaza_adi + "','" + sahibi + "','" + web_sitesi + "'," + telefon + ",'" + icerik + "','" + resim + "'," + x + "," + y + ")", con);  
                con.Open();
                cmd.ExecuteNonQuery();
                return "basarili";
            }
            catch (Exception ex)
            {
                return "hata="+ex;
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return "hata";


        }


        [WebMethod]
        public DataTable Deneme()
        {
            SqlConnection con = new SqlConnection(ConnectionState());
            SqlCommand cmd = new SqlCommand("Select * from magaza   ", con); 
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable("magaza");
            dt.Load(dr);
            con.Close();
            return dt;

        }

        [WebMethod]
        public DataTable Kullanici_Girisi(string email, string sifre)
        {
            SqlConnection con = new SqlConnection(ConnectionState());
            SqlCommand cmd = new SqlCommand("Select adsoyad,email,sifre,id  from kullanici  where email=@email and sifre=@sifre", con);
            cmd.Parameters.AddWithValue("@email", email.Trim());
            cmd.Parameters.AddWithValue("@sifre", sifre.Trim());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable("magaza");
            dt.Load(dr);
            con.Close();
            return dt;

        }

    }
}
