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
    public class LogInBL
    {
        //public DataSet PerformLogin1(LogInIfno objLogInIfno)
        //{
        //    string spNameString = string.Empty;
        //    DataSet dsLogInfo = new DataSet();


        //  //  DbConnection dbConn;
            
        //    Database dbDatabase = DatabaseFactory.CreateDatabase() ;


        //    //dbDatabase.= Global.GetGlobal();
              

            
        //    spNameString = "USP_GetMultiUserDetails";
        //    DbCommand dbCommand = null;
           
            
        //        dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
        //       // dbDatabase.AddInParameter(dbCommand, "@LogId", System.Data.DbType.Int32, objLogInIfno.LogId);
        //        dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objLogInIfno.UserName);
        //        dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, objLogInIfno.Password);
        //        dbDatabase.AddInParameter(dbCommand, "@TypeOfUser", System.Data.DbType.String, objLogInIfno.TypeOfUser);
        //         dsLogInfo = dbDatabase.ExecuteDataSet(dbCommand);

        //        //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
        //        return dsLogInfo;







        //}
        public DataSet PerformLogin(string UserName, String Password)
        {
           // SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
          //  SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
            SqlCommand cmd = new SqlCommand("GetMultiSiteCredentials", con);
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@USername", UserName));
            cmd.Parameters.Add(new SqlParameter("@Password", Password));



            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;

        }
        public DataSet GetIpAddressList(string ipadd)
        {
            //SqlConnection con = new SqlConnection(Global.INSTANCE_NAME);
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
            SqlCommand cmd = new SqlCommand("USP_GetIpAddressList", con);
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@IpAddress", ipadd));
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;

        }



       

    }
}
