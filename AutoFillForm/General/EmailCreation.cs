using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AutoFillForm.General
{
     
   public class EmailCreation
    {
       public static string createmail(string carid, string state)
       {
           string Email = string.Empty;
           int CarId = Convert.ToInt32(carid);
           DataSet ds = new DataSet();
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("select SN.NAme  from Tbl_UsedCarsForSale as UCFS inner join Tbl_SellersInfo as SI on UCFS.sellerid=SI.sellerid inner join Tbl_SellerUNames as SN on SN.uid=UCFS.uid where UCFS.carid=" + CarId, con);
           con.Open();
           //cmd.Parameters.Add(new SqlParameter("@CarID", carid));
           cmd.CommandType = CommandType.Text;
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
          //string str = "select SN.NAme,si.state  from Tbl_UsedCarsForSale as UCFS inner join Tbl_SellersInfo as SI on UCFS.sellerid=SI.sellerid inner join Tbl_SellerUNames as SN on SN.uid=UCFS.uid where UCFS.carid=10";
           if (ds.Tables.Count > 0)
           {
               if (ds.Tables[0].Rows.Count > 0)
               {
                   string name = ds.Tables[0].Rows[0]["NAme"].ToString();
                   string statename = state.ToString();
                   string charectr = name[0].ToString();
                   Email = charectr + statename + carid + "@americantravelexpert.com";
                   //Email = charectr + statename + carid + "@globaltpv.com";
               }
               else
               {
                   string statename = state.ToString();
                   Email = statename + carid + "@americantravelexpert.com";
               }
           }
           return Email;
       }
    }
}
