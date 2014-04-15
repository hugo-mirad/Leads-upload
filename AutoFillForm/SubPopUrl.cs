using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductionBL;
using System.Text.RegularExpressions;

namespace AutoFillForm
{
    public partial class SubPopUrl : Form
    {
        SubmitionDetailsBL objSubmitionDetailsBL = new SubmitionDetailsBL();
        public SubPopUrl()
        {
            InitializeComponent();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txturl.Text == "")
            {
                MessageBox.Show("URL Required");

            }
            
            else
            {

              
          


           
                //        string cell =
                //dtgvRecent.Rows[e.RowIndex].Cells[e.ColumnIndex].ToString();
                int urlid = GlobalUrlid.Urlid;
                string sitename = GlobalSite.Site;

                if (txturl.Text.Contains(sitename))
                {
                    // string Regex = " /(ftp|http|https):\\/\\/(\\w+:{0,1}\\w*@)?(\\S+)(:[0-9]+)?(\\/|\\/([\\w#!:.?+=&%@!-\\/]))?/;";
                    //if (Regex.(txtpndg.Text))
                    //{ 
                    //}

                    Regex urlCheck = new Regex(@"((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)");
                    if (urlCheck.IsMatch(txturl.Text))
                    {
                        objSubmitionDetailsBL.UpdatePendingDetails(urlid, GlobalLogId.globallogidVar, "Completed", txturl.Text);
                        //string QcStaus = "Pending";
                        //string SubStatus = "completed";

                      //objSubmitionDetailsBL.GetSubmitionDetails();
                        //objSubmitionDetailsBL.MultiSaveSubmitionDetails( GlobalCARId.globcarid, txturl.Text, websiteId, subby, SubStatus, QcStaus);
                       
                        MessageBox.Show("Url Updated Successfully");
                        txturl.Text = "";

                       


                    
                        ////PendingDetails objpend = new PendingDetails();
                        ////objpend.Show();
                        ////objpend.Text = "Submit Pending URL";
                        this.Hide();
                        Main objpen = new Main();
                       objpen.Getpending();

                     objpen. tabControl1.SelectedIndex = 1;


                    }
                    else
                    {
                        MessageBox.Show("Submit Correct URL");
                        txturl.Text = "";

                    }


                }
                else
                {
                    MessageBox.Show("Enter Correct URL");
                    txturl.Text = "";
                }
            }

        }

        private void SubPopUrl_Load(object sender, EventArgs e)
        {
           
            label5.Text = GlobalSite.Site; ;
            label3.Text = GlobalUserName.UserName;
            label4.Text = GlobalNoteCarId.notecarid;
            SubPopUrl objsuburl = new SubPopUrl();
            objsuburl.MdiParent = this.MdiParent;

        
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
