using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductionInfo;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace ProductionBL
{
   public class RegisterBL
    {
       public void SaveRegUserDetails(RegisterInfo objreginfo)
       {
           //SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
           //SqlCommand cmd = new SqlCommand("USP_MultiSaveRegUser", con);
           //con.Open();
           //cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
           //cmd.Parameters.Add(new SqlParameter("@Pwd", Pwd));
           //cmd.Parameters.Add(new SqlParameter("@FirstName", FName));
           //cmd.Parameters.Add(new SqlParameter("@LastName", Lname));
           //cmd.Parameters.Add(new SqlParameter("@TypeOfUser", TypUser));

           //cmd.CommandType = CommandType.StoredProcedure;
           //cmd.ExecuteNonQuery();
           //con.Close();

           string spNameString = string.Empty;
           // DataSet dsLogInfo = new DataSet();
           Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
           spNameString = "USP_MultiSaveRegUser";
           DbCommand dbCommand = null;


           dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

           dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objreginfo.Uname);
           dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, objreginfo.passwrd);
           dbDatabase.AddInParameter(dbCommand, "@FirstName", System.Data.DbType.String, objreginfo.FName);
           dbDatabase.AddInParameter(dbCommand, "@LastName", System.Data.DbType.String, objreginfo.LName);
           dbDatabase.AddInParameter(dbCommand, "@TypeOfUser", System.Data.DbType.String, objreginfo.Typuser);
           dbDatabase.ExecuteDataSet(dbCommand);

       }
    }
}
