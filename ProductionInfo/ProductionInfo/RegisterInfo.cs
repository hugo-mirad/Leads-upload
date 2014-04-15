using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductionInfo
{
   public class RegisterInfo
    {
       private string _Uname;

        public string Uname
        {
            get { return _Uname; }
            set { _Uname = value; }
        }

        private string _passwrd;

        public string passwrd
        {
            get { return _passwrd; }
            set { _passwrd = value; }
        }
        private string _LName;

        public string LName
        {
            get { return _LName; }
            set { _LName = value; }
        }
        private string _FName;

        public string FName
        {
            get { return _FName; }
            set { _FName = value; }
        }
        private string _Typuser;

        public string Typuser
        {
            get { return _Typuser; }
            set { _Typuser = value; }
        }
    }
}
