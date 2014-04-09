using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AutoFillForm
{
   public class HomeStatictics
    {
       public DataTable Statictics()
       {
         

           //Adding//

           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand();
           cmd.Connection = con;
           con.Open();

           //taemp1
           cmd.CommandText = "delete Tempt1";
           cmd.ExecuteNonQuery();

           string str = " insert into Tempt1 (Smname,Thisweek ) " +
               "select SU.SmartzUname,count(SMS.PostedBy) 'This wk#'  from Tbl_MultiStatusbySite  " +
               " as SMS inner join Tbl_SmartzUsers as SU on Su.SmartzUID=SMS.PostedBy where  " +
                " SMS.UrlPostDate>= DATEADD(dd, -7, getdate()) group by SMS.postedBy,SU.SmartzUname";
           cmd.CommandText = str;
           cmd.ExecuteNonQuery();


           cmd.CommandText = "delete tempt2";
           cmd.ExecuteNonQuery();
           //temp2
           string str1 = " insert into tempt2 (smartnam,lifetime ) " +
           "select SU.SmartzUname,count(SMS.PostedBy) 'Life time#'from Tbl_MultiStatusbySite as SMS inner join " +
           " Tbl_SmartzUsers as SU on Su.SmartzUID=SMS.PostedBy  group by SMS.postedBy,SU.SmartzUname ";
           cmd.CommandText = str1;
           cmd.ExecuteNonQuery();



           cmd.CommandText = "delete Temp3";
           cmd.ExecuteNonQuery();
           //Main Table
           string str2 = " insert into Temp3 (Sname,LifeTime,ThisWeek  ) " +
           "select a.smartnam,a.lifetime,b.Thisweek from tempt2 as a left join Tempt1 as b on a.smartnam=b.Smname ";
           cmd.CommandText = str2;
           cmd.ExecuteNonQuery();

           cmd.CommandText = "delete Tempt1";
           cmd.ExecuteNonQuery();
           cmd.CommandText = "delete tempt2";
           cmd.ExecuteNonQuery();
           //urlPening
           string str4 = " insert into Tempt1 (Smname,Thisweek)  " +
               "select SU.SmartzUname, count(MSS.PostedBy) as 'Pending' from Tbl_MultiStatusbySite as MSS  " +
            "inner join Tbl_SmartzUsers as SU on MSS.PostedBy=SU.SmartzUID where SubStatus='Pending' group by  " +
            " MSS.PostedBy,SU.SmartzUname ";
           cmd.CommandText = str4;
           cmd.ExecuteNonQuery();

           //Main Table with url pending
           string str7 = " insert into Temp3 (Sname,LifeTime,ThisWeek ) " +
           "select a.smartnam,a.lifetime,b.Thisweek from tempt2 as a left join Tempt1 as b on a.smartnam=b.Smname ";
           cmd.CommandText = str7;
           cmd.ExecuteNonQuery();

           //QcPening in t2
           //Main Table with url pending
           string str6 = " insert into tempt2 (smartnam,lifetime ) " +
           "select SU.SmartzUname, count(MSS.PostedBy) as 'Pending' from Tbl_MultiStatusbySite as MSS inner join Tbl_SmartzUsers as SU on  " +
           " MSS.PostedBy=SU.SmartzUID where QcStatus='Pending'and SubStatus='Completed' group by MSS.PostedBy,SU.SmartzUname ";
           cmd.CommandText = str6;
           cmd.ExecuteNonQuery();


           int value = 0; int value1; int value2 = 0;
           //GridBinding
           string S1 = "select isnull(a.Sname,'0')as 'Users',isnull(a.ThisWeek,'0')as 'ThisWeek#',isnull(a.lastWeek,'0')as 'LastWeek#',isnull(a.LifeTime,'0')as 'LifeTime#',isnull(b.Thisweek,'0') as UrlPending, " +
               " isnull(c.lifetime,'0') as [QC Pending] from Temp3 as a ";
           try
           {
               SqlDataReader dr;
               string str11 = " select count(lifetime)  as Va from tempt2";
               cmd.CommandText = str11;
               dr = cmd.ExecuteReader();
               if (dr.Read())
               {
                   value2 = Convert.ToInt32(dr["Va"].ToString());
               }
               dr.Close();



           }
           catch { value = 0; }
           //try
           //{
           //    string str111 = " select count(lifetime) from tempt2";
           //    cmd.CommandText = str111;
           //    value1 = cmd.ExecuteNonQuery();

           //}
           //catch { value = 0; }
           if (value2 == 0)
               //S1 += " left join Tempt1 as b on a.Sname=B.Smname left join tempt2 as c on B.Smname=c.smartnam ";
               S1 += " FULL OUTER JOIN Tempt1 as b on a.Sname=B.Smname FULL OUTER JOIN tempt2 as c on B.Smname=c.smartnam ";
           else
               //S1 += " left join tempt2 as c on a.Sname=c.smartnam left join Tempt1 as B on c.smartnam=B.Smname ";
               S1 += " FULL OUTER JOIN tempt2 as c on a.Sname=c.smartnam FULL OUTER JOIN Tempt1 as B on c.smartnam=B.Smname ";

           
           SqlDataAdapter dap = new SqlDataAdapter(S1, con);
           DataTable dt = new DataTable();
           dap.Fill(dt);
           Main objmn = new Main();
          objmn.dataGridView2.DataSource = dt;
           return dt;




       }
    }
}
