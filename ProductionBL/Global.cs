using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Configuration;


namespace ProductionBL
{
   public  class Global
    {
       

       public static string INSTANCE_NAME;

       public static string GetGlobal()
       {
           com.unitedcarexchange.WSProduction obj = new com.unitedcarexchange.WSProduction();

          // INSTANCE_NAME = Convert.ToString(obj.GetCarsTestConnectionString());
            INSTANCE_NAME = Convert.ToString(obj.GetCarsConnectionString());
           return INSTANCE_NAME;
       }


       

       
       
       

  
    }
}
