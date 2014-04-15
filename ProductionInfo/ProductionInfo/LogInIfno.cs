using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductionInfo
{
    public class LogInIfno
    {
        private int _LogId;

        public int LogId
        {
            get { return _LogId; }
            set { _LogId = value; }
        }

        private string  _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }


        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }


        private string _TypeOfUser;

        public string TypeOfUser
        {
            get { return _TypeOfUser; }
            set { _TypeOfUser = value; }
        }


    }
}
