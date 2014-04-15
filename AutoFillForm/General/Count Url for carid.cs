using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace AutoFillForm.General
{
   public static class Count_Url_for_carid
    {
       public static int GetcountofCarid(int carid, int Id )
       {
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            string Date = DateTime.Now.ToString("yyyy-MM-dd");
                Date = Date.Replace("-", "/");
              //  dt = dt + "/"+dateoftoday;

            string str = "select count(carid) from Tbl_MultiStatusbySite where postedBy="+Id+"and convert(varchar(10),urlpostdate,111) ='"+Date+"'and carid="+carid;
            
            cmd.CommandText = str;
            int count =Convert.ToInt32( cmd.ExecuteScalar());
            return count;
       }
    }
}
