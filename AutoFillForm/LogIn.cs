using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductionBL;
using ProductionInfo;
using System.Net;
using System.Text.RegularExpressions;

namespace AutoFillForm
{
     
    public partial class LogIn : Form
    {
        LogInBL objLogBL = new LogInBL();
        LogInIfno objLogInIfno = new LogInIfno();
     
        //UserBL objuserBL = new UserBL();
        //UserLogBL objUserLogBL = new UserLogBL();
        //UserInfo objUserInfo = new UserInfo();
        public LogIn()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
           //panel1.Focus();

          // this.txtUname.Focus();
            this.AcceptButton = btnLogin;
          
            
        }
        //public void msgme()
        //{
        //    MessageBox.Show("Parent Function Called");
        //}
      

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
                try
                {

                    if ((txtUname.Text == "") || (txtPwd.Text == ""))
                    {

                        MessageBox.Show("Please enter UserName and Password", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtUname.Focus();
                        txtUname.Text = "";
                        txtPwd.Text = "";


                    }
                    else
                    {
                      Cursor.Current = Cursors.WaitCursor;
                        //circularProgressControl1.Start();
                        String strHostName = System.Net.Dns.GetHostName();
                        // string strIp1 = System.Net.Dns.GetHostAddresses(strHostName).GetValue(1).ToString();

                        IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                        IPAddress[] addr = ipEntry.AddressList;
                       // for (int iip = 0; iip < addr.Length; iip++)
                       // {
                           
                          //  string ipp = addr[iip].ToString();


                            Regex ip = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                            ////if (ip.IsMatch(ipp))
                            ////{
                                //string[] result = ip.;

                               // string strIp1 = addr[iip].ToString();
                               


                                string strIP2 = string.Empty;
                                string strIP3 = string.Empty;

                                DataSet dsIP = new DataSet();
                               // dsIP = objLogBL.GetIpAddressList(strIp1);
                                //if (dsIP.Tables.Count > 0)
                                //{
                                //    if (dsIP.Tables[0].Rows.Count > 0)
                                //    {
                                   


                                            if (txtUname.Text != "" || txtPwd.Text != "")
                                            {
                                                DataSet PerformLogin = new DataSet();
                                                objLogInIfno.UserName = txtUname.Text;
                                                objLogInIfno.Password = txtPwd.Text;



                                                PerformLogin = objLogBL.PerformLogin(txtUname.Text, txtPwd.Text);


                                                // String strHostName = "hugo56";

                                                if (PerformLogin.Tables.Count > 0)
                                                {
                                                    if (PerformLogin.Tables[0].Rows.Count > 0)
                                                    {

                                                        object o = PerformLogin.Tables[0].Rows[0]["MultiUID"];
                                                        GlobalLogId.globallogidVar = Convert.ToInt32(o);

                                                        // Form1 newForm1 = new Form1(txtUname.Text, objLogInIfno.TypeOfUser);
                                                        // newForm1.Show();
                                                        GlobalUserName.UserName = txtUname.Text;

                                                      //  Main newForm = new Main(txtUname.Text, objLogInIfno.TypeOfUser);

                                                        Main newForm = new Main();
                                                        //Form1 objform = new Form1(txtUname.Text, objLogInIfno.TypeOfUser);
                                                        //  newForm.Closed += (sender1, args) => this.Close();
                                                        //



                                                        newForm.Show();
                                                        this.Hide();
                                                        //objform.Show();




                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Invalid UserName & Password", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                                        txtUname.Text = "";
                                                        txtPwd.Text = "";
                                                        txtUname.Focus();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please Provide Credentials", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                                txtUname.Text = "";
                                                txtPwd.Text = "";
                                                txtUname.Focus();
                                            }

                                       // }
                                       // else
                                       // {

                                      //  }
                                  //  }
                                   // }

                               // }

                                Cursor.Current = Cursors.Default;
                           // }
                       // }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    //MessageBox.Show("I am Sorry we cannot provide you the service .Please contact Our Administrator");

                }
                // circularProgressControl1.Stop();

                Cursor.Current = Cursors.WaitCursor;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUname;
            
         txtUname.Focus();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void circularProgressControl1_Load(object sender, EventArgs e)
        {

        }
       
    
    }
    public static class GlobalLogId
    {
        public static int _globallogidVar = 0;

        public static int globallogidVar
        {
            get { return _globallogidVar; }
            set { _globallogidVar = value; }
        }
    }


    public static class GlobalUserName
    {
        public static string _UserName = "";

        public static string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
    }
}
