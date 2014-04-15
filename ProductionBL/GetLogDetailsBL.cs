using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductionInfo;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace ProductionBL
{
   public class GetLogDetailsBL
    {

       public DataSet GetLogDetails()
       {
           DataSet dsLogInfo = new DataSet();
           try
           {
               string spNameString = string.Empty;

               Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
               spNameString = "USP_MultiGetLogDetails";
               DbCommand dbCommand = null;
               dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
               dsLogInfo = dbDatabase.ExecuteDataSet(dbCommand);
               //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");

           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
             return dsLogInfo;
           
       }
    }
}
