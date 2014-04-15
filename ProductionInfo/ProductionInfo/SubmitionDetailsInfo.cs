using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductionInfo
{
   public class SubmitionDetailsInfo
    {
       private string _Webname;

       public string Webname
        {
            get { return _Webname; }
            set { _Webname = value; }
        }

       private string _SubmittedBy;

       public string SubmittedBy
        {
            get { return _SubmittedBy; }
            set { _SubmittedBy = value; }
        }

       private string _CarId;

       public string CarId
        {
            get { return _CarId; }
            set { _CarId = value; }
        }

    }
}
