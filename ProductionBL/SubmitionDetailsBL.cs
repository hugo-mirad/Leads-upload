using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductionInfo;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace ProductionBL
{
   public class SubmitionDetailsBL
    {
       //public void SaveSubmitionDetails(SubmitionDetailsInfo objsubdetailsinfo)
       //{


       //    string spNameString = string.Empty;
       //   // DataSet dsLogInfo = new DataSet();
       //    Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
       //    spNameString = "USP_MultiSubDetails";
       //    DbCommand dbCommand = null;


       //    dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

       //    dbDatabase.AddInParameter(dbCommand, "@Web_Name", System.Data.DbType.String, objsubdetailsinfo.Webname );
       //    dbDatabase.AddInParameter(dbCommand, "@SubmitedBy", System.Data.DbType.String, objsubdetailsinfo.SubmittedBy);
       //    dbDatabase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.String, objsubdetailsinfo.CarId);
       //     dbDatabase.ExecuteDataSet(dbCommand);

       //    //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
       // }

        //carid, linkItem, websiteId, subby

        //@CarID int,@URL varchar(500),@SiteID int,@PostedBy int

       public void SaveSubmitionDetails(int carid, String linkItem, int websiteId, int subby)
       {
           //SqlConnection con = new SqlConnection(Global.GetGlobal());
           //SqlCommand cmd = new SqlCommand("USP_SaveMultiSiteSubDetails", con);
           //con.Open();
           //cmd.Parameters.Add(new SqlParameter("@CarID", carid));
           //cmd.Parameters.Add(new SqlParameter("@URL", linkItem));
           //cmd.Parameters.Add(new SqlParameter("@SiteID", websiteId));
           //cmd.Parameters.Add(new SqlParameter("@PostedBy", subby));



           //cmd.CommandType = CommandType.StoredProcedure;
           //DataSet ds = new DataSet();
           //SqlDataAdapter da = new SqlDataAdapter(cmd);
           //da.Fill(ds);
           //return ds;

       }

       //public DataSet GetSubmitionDetails(SubmitionDetailsInfo objsubdetailsinfo)
       //{



       //    string spNameString = string.Empty;
       //    DataSet dsLogInfo = new DataSet();
       //    Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
       //    spNameString = "USP_GetSubDetails";
       //    DbCommand dbCommand = null;


       //    dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

       //    dbDatabase.AddInParameter(dbCommand, "@Web_Name", System.Data.DbType.String, objsubdetailsinfo.Webname);

       //    dsLogInfo = dbDatabase.ExecuteDataSet(dbCommand);

       //    //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
       //    return dsLogInfo;


       //}
       //public DataSet GetSubmitionDetailsByCarId(SubmitionDetailsInfo objsubdetailsinfo)
       //{



       //    string spNameString = string.Empty;
       //    DataSet dsLogInfo = new DataSet();
       //    Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
       //    spNameString = "USP_GetSubDetailsByCarId";
       //    DbCommand dbCommand = null;


       //    dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

       //    dbDatabase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.String, objsubdetailsinfo.CarId);

       //    dsLogInfo = dbDatabase.ExecuteDataSet(dbCommand);

       //    //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
       //    return dsLogInfo;


       //}

       public DataSet GetSubmitionDetailsByCarId(int carid)
       {

          // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
          // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_GetSubDetailsByCarId", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid));
           
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet GetRecentPostdata()
       {

          // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
         //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiSiteGetRecentPostData", con);
           con.Open();
          
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet GetpostedURL(int carid,string dt,int postedid )
       {
           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("dbo.USP_MultiGetPostedURL", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid));
          cmd.Parameters.Add(new SqlParameter("@date", dt));
          cmd.Parameters.Add(new SqlParameter("@postedBy", postedid));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;
       }

       public DataSet GetCarIdCount(int carid, string dt, int postedid)
       {
           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("dbo.USP_GetCarIDCount", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid));
           cmd.Parameters.Add(new SqlParameter("@date", dt));
           cmd.Parameters.Add(new SqlParameter("@postedBy", postedid));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;
       }

       public DataSet MultiGetCountBySites()
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("MultiGetCountBySites", con);
           con.Open();

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet MultiGetTotPending()
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetTotPending", con);
           con.Open();

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet MultiGetOpenTktsCountByCarId()
           {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetOpenTktsCountByCarId", con);
           con.Open();
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


           }
           
       public DataSet MultiGetPendingCount1()
            {

                // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
                //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
                SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
                SqlCommand cmd = new SqlCommand("USP_MultiGetPendingCount1", con);
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;


            }

       public DataSet MultiGetPendingCount()
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetPendingCount", con);
           con.Open();

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet MultiGetSiteList()
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetSiteList", con);
           con.Open();

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet MultiSiteGetRecentPostDataByCarId(string carid1)
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiSiteGetRecentPostDataByCarId", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid1));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet MultisiteGetCarFeatures(int carid1)
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultisiteGetCarFeatures", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid1));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet MultiGetpendbySiteid(int SiteId)
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetpendbySiteid", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@SiteId", SiteId));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet MultiGetPostingStatus(int SiteId)
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetPostingStatus", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@SiteId", SiteId));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet MultiGetQCbySiteid(int SiteId)
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetQCbySiteid", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@SiteId", SiteId));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }





       public DataSet MultiGetTicketCountByCarId(string carid1)
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetTicketCountByCarId", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid1));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }


       public DataSet MultiGetSiteNameTransation(int carid1)
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetSiteNameTransation", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@Carid", carid1));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }




       public DataSet GetEmailData()
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("usp_Multigetemails", con);
           con.Open();

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;

       }


       public DataSet MultiGetEmailByCarid(string Carid)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetEmailByCarid", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarId", Carid));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;

       }

       public DataSet MultiAssignEmailidByCarId(string Carid)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiAssignEmailidByCarId", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarId", Carid));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;

       }


       public DataSet MultiGetPwdByEmail(string EmailId)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetPwdByEmail", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@EmailId", EmailId));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;

       }

        public DataSet MultiGetSiteId(string SiteName)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiGetSiteId", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@SiteName", SiteName));
           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;

       }

       



       public DataSet GetMultiNote(int carid1)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_GetMultiNote", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid1));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;

       }

       public DataSet MultiSaveNotes(int carid, string Note,int AddedBy)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiSaveNotes", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid));
           cmd.Parameters.Add(new SqlParameter("@Note", Note));
           cmd.Parameters.Add(new SqlParameter("@AddedBy", AddedBy));
        

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;

       }

       public void MultiSaveSubmitionDetails(int carid, String linkItem, int websiteId, int subby, string SubStatus, string QcStaus,string Email,string Password)
       {
           try
           {

               // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
               // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
               SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
               SqlCommand cmd = new SqlCommand("USP_SaveQCMultiSiteSubDetails", con);
               con.Open();
               DateTime date = System.DateTime.Now;
               cmd.Parameters.Add(new SqlParameter("@CarID", carid));
               cmd.Parameters.Add(new SqlParameter("@URL", linkItem));
               cmd.Parameters.Add(new SqlParameter("@SiteID", websiteId));
               cmd.Parameters.Add(new SqlParameter("@PostedBy", subby));
               cmd.Parameters.Add(new SqlParameter("@SubStatus", SubStatus));
               cmd.Parameters.Add(new SqlParameter("@date", date));
               cmd.Parameters.Add(new SqlParameter("@QcStaus", QcStaus));
               cmd.Parameters.Add(new SqlParameter("@Email", Email));
               cmd.Parameters.Add(new SqlParameter("@Password", Password));



               cmd.CommandType = CommandType.StoredProcedure;
               cmd.ExecuteNonQuery();
               con.Close();
           }
           catch
           {
           }

     
           //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
       }



       public void MultiSiteTransation(String sitename, int siteid, int carid)
       {
           try
           {

               // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
               // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
               SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
               SqlCommand cmd = new SqlCommand("USP_MultiSaveSiteTransation", con);
               con.Open();
               cmd.Parameters.Add(new SqlParameter("@SiteName", sitename));
               cmd.Parameters.Add(new SqlParameter("@SiteId", siteid));
               cmd.Parameters.Add(new SqlParameter("@CarId", carid));




               cmd.CommandType = CommandType.StoredProcedure;
               cmd.ExecuteNonQuery();
               con.Close();
           }
           catch
           {
           }
       }


       public void MultiSaveEmail(string Email, string Password,string Carid)
       {
           try
           {
               // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
               // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
               SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
               SqlCommand cmd = new SqlCommand("USP_MultiSaveEmail", con);
               con.Open();
               cmd.Parameters.Add(new SqlParameter("@EmailId", Email));
               cmd.Parameters.Add(new SqlParameter("@Password", Password));
               cmd.Parameters.Add(new SqlParameter("@Carid", Carid));
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.ExecuteNonQuery();
               con.Close();
           }
           catch
           {
           }
           //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
       }

       public void multiupdateMultiSiteSubDetails(int Urlsid,  string QcStaus)
       {
           try
           {

               // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
               // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
               SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
               SqlCommand cmd = new SqlCommand("USP_multiupdateMultiSiteSubDetails", con);
               con.Open();

               cmd.Parameters.Add(new SqlParameter("@StId", Urlsid));

               cmd.Parameters.Add(new SqlParameter("@QcStaus", QcStaus));
             ;



               cmd.CommandType = CommandType.StoredProcedure;
               cmd.ExecuteNonQuery();
               con.Close();
           }
           catch
           {
           }
       }




       public void MultiSaveSmartzSubmitionDetails(int carid, String linkItem, int websiteId, int subby, string SubStatus, string UrlPostdate, int URLSID)
       {


           //SqlConnection con = new SqlConnection(Global.GetGlobal());
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_SaveMultiSiteSubDetails", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid));
           cmd.Parameters.Add(new SqlParameter("@URL", linkItem));
           cmd.Parameters.Add(new SqlParameter("@SiteID", websiteId));
           cmd.Parameters.Add(new SqlParameter("@PostedBy", subby));
           cmd.Parameters.Add(new SqlParameter("@SubStatus", SubStatus));
           cmd.Parameters.Add(new SqlParameter("@UrlPostdate", UrlPostdate));
           cmd.Parameters.Add(new SqlParameter("@URLSID", URLSID));



           cmd.CommandType = CommandType.StoredProcedure;
           cmd.ExecuteNonQuery();
           con.Close();


           //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
       }




       public void UpdatePendingDetails(int URLID, int PostedBy, string SubStatus, string URL)
       {

          // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
         //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultiUpdatePending", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@URLID", URLID));
           cmd.Parameters.Add(new SqlParameter("@PostedBy", PostedBy));

           cmd.Parameters.Add(new SqlParameter("@SubStatus", SubStatus));
           cmd.Parameters.Add(new SqlParameter("@URL", URL));


           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           cmd.ExecuteNonQuery();
           con.Close();



       }

       public DataSet GetSubmitionDetails()
       {

          // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
          // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_MultigetSubDetails", con);
           con.Open();
           //cmd.Parameters.Add(new SqlParameter("@CarID", carid));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }
       public DataSet MultiGetsiteName()
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("Usp_MultiGetSiteNameById", con);
           con.Open();
           //cmd.Parameters.Add(new SqlParameter("@CarID", carid));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

             public DataSet multibySiteid( int siteid)
       {

           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
           // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           SqlCommand cmd = new SqlCommand("USP_multibySiteid", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@siteid", siteid));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet GetQcChechDetails()
       {

         //SqlConnection con = new SqlConnection(Global1.INSTANCE_NAME1);
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           //SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlCommand cmd = new SqlCommand("USP_MultigetQcSubDetail", con);
           con.Open();
           //cmd.Parameters.Add(new SqlParameter("@CarID", carid));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;


       }

       public DataSet MultigetpostedSites(string carid1)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           //SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlCommand cmd = new SqlCommand("USP_MultigetpostedSites", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid1));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;
       }


       public DataSet MultigetPendingSites(string carid1)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           //SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlCommand cmd = new SqlCommand("USP_MultigetPendingSites", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid1));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;
       }

       public DataSet MultigetPendingSites1(string carid1)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           //SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlCommand cmd = new SqlCommand("USP_MultigetPendingSites1", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid1));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;
       }



       public DataSet MultigetViewpendingsite(string carid1)
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           //SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlCommand cmd = new SqlCommand("USp_MultigetViewpendingsite", con);
           con.Open();
           cmd.Parameters.Add(new SqlParameter("@CarID", carid1));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;
       }

            public DataSet MultiGetPendgCount()
       {
           SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           //SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
           SqlCommand cmd = new SqlCommand("USP_MultiGetPendgCount", con);
           con.Open();
          // cmd.Parameters.Add(new SqlParameter("@CarID", carid1));

           cmd.CommandType = CommandType.StoredProcedure;
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);
           return ds;
       }
            public DataSet MultiGetTicketCount()
            {
                SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
                //SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
                SqlCommand cmd = new SqlCommand("USP_MultiGetTicketCount", con);
                con.Open();
                // cmd.Parameters.Add(new SqlParameter("@CarID", carid1));

                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }







    }
}
