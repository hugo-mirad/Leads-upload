using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductionInfo
{
   public class ChangePasswordInfo
    {
       private string _UName;

        public string UName
        {
            get { return _UName; }
            set { _UName = value; }
        }

        private string _OldPwd;

        public string OldPwd
        {
            get { return _OldPwd; }
            set { _OldPwd = value; }
        }

        private string _Npwd;

        public string Npwd
        {
            get { return _Npwd; }
            set { _Npwd = value; }
        }

        private string _Cnfrmpwd;

        public string Cnfrmpwd
        {
            get { return _Cnfrmpwd; }
            set { _Cnfrmpwd = value; }
        }
    }
}
