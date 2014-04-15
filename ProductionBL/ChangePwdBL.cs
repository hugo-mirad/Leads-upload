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
  public class ChangePwdBL
    {
      public void ResetPwd(ChangePasswordInfo objchngpwd)
      {
          //SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
          //SqlCommand cmd = new SqlCommand("USP_MultiUpdatePwd", con);
          //con.Open();
          //cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
          //cmd.Parameters.Add(new SqlParameter("@Pwd", Pwd));
          //cmd.Parameters.Add(new SqlParameter("@Newpwd", Newpwd));


          //cmd.CommandType = CommandType.StoredProcedure;
          //cmd.ExecuteNonQuery();
          //con.Close();

          string spNameString = string.Empty;
          // DataSet dsLogInfo = new DataSet();
          Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
          spNameString = "USP_MultiUpdatePwd";
          DbCommand dbCommand = null;


          dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

          dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objchngpwd.UName);
          dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, objchngpwd.OldPwd);
          dbDatabase.AddInParameter(dbCommand, "@Newpwd", System.Data.DbType.String, objchngpwd.Npwd);
        //  dbDatabase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.String, objchngpwd.Cnfrmpwd);
         //dbDatabase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.String, objchngpwd.Typuser);
          dbDatabase.ExecuteDataSet(dbCommand);


      }
    }
}
