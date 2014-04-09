using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductionBL;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;


using System.Data.SqlClient;

using System.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace AutoFillForm
{
    public interface IWebSites
    {
        void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo, bool a);

    }
    public partial class Main : Form
    {
        SubmitionDetailsBL objSubmitionDetailsBL = new SubmitionDetailsBL();
        HomeStatictics objHomeStatictics = new HomeStatictics();
        SqlCommand cmd = new SqlCommand();
        #region variables
        int imgcount = 0;                   bool a = true;
        string carid = string.Empty;        string cnt = string.Empty;          string frmcarid = string.Empty;
        string Website = string.Empty;      string linkItem = string.Empty;     string Status = string.Empty;
        Form LiveFormUrl = new Form();      string data5 = string.Empty;        string url = string.Empty;
        string SubStatus = string.Empty;    string date = string.Empty;         string stNamemoto = string.Empty;
        string stName1moto = string.Empty;  string stcdemoto = string.Empty;    string statenamemoto = string.Empty;
        string date1 = string.Empty;        string Tickets = string.Empty;      string urlprndg = string.Empty;
        string cityno = string.Empty; string dateoftoday = string.Empty; int hgcl = 0; int eccount = 0;

        string Comfort = string.Empty;      string Seats = string.Empty;        string Safety = string.Empty;
        string soundsystem = string.Empty;  string powerWindows = string.Empty; string New = string.Empty;
        string Other = string.Empty;        string Specials = string.Empty;     string sname = "";
        TextBox LiveTextBoxUrl = new TextBox();    Button LiveButtonUrl = new Button();     Button LiveButtonLater = new Button();
        Button LiveButtonMinimize = new Button();  TextBox EmailTextBox = new TextBox();    TextBox passwordTextBox = new TextBox();
        Button ButtonSubmit = new Button();        Button ButtonLater = new Button();       Label lblpassword = new Label();
        Form EmailForm = new Form();        string pmake = string.Empty;        string pmodel = string.Empty;

        Button EmailButtonMinimize = new Button(); int repeat = 0; int ucount = 0; int ucount1 = 0;

        int carnum = 0;     int urlsid = 0;     int siteid = 0;     int postedby = 0;
        int adsty = 0;      int adccnt = 0;     int edi = 0;        int btnltr = 0;
        int cthy = 0;       int clsf = 0;       int epg = 0;        int epg1 = 0;
        int subepg = 0;     int epglst = 0;     int Kug = 0;        int jnga = 0;
        int clsfd = 0;      int msg = 0;        int vlly = 0;       int moto = 0;
        int clz = 0;        int clz1 = 0;       int websiteId = 0;  int f = 0;
        int ic = 0;         int subby = 0;      int count = 0;      int btncnt = 0;
        int cmbcnt = 0;     int pi = 0;         int purl = 0;       int asad = 0;
        int ik = 0;         int motosl = 0;     int cls4me = 0;     int c4mcty = 0;
        int pfc = 0;        int myads = 0;      int ano = 0;        int cads = 0;
        int anupic = 0;     int cvy = 0;        int pnt = 0;        int ht9 = 0;
        int HLepg1 = 0;     int HLepg = 0;      int HLsubepg = 0;   int HLepglst = 0;
        int adp = 0;        int cff = 0;        int cfreeimg = 0;   int fread = 0;
        int epagei = 0;     int epagej = 0;
        int c4cy = 0;
        bool canMove = false;
        #endregion
        //modify epage
        #region events
        protected void LiveButtonMinimize_click(object sender, EventArgs e) 
        {
            //LiveFormUrl.MinimizeBox = true;
            //this.LiveFormUrl = FormWindowState.Minimized;
            LiveFormUrl.WindowState = FormWindowState.Minimized;
        }
        protected void LiveButtonUrl_click(object sender, EventArgs e)      
        {
            if (string.IsNullOrEmpty(LiveTextBoxUrl.Text))
            {
                errorProvider1.SetError(LiveTextBoxUrl, "URL required!");
            }
            else
            {
                int carid = Convert.ToInt32(textBox3.Text);
                if (LiveTextBoxUrl.Text != "")
                {
                    Regex urlCheck = new Regex(@"((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)");
                    if (urlCheck.IsMatch(LiveTextBoxUrl.Text))
                    {
                        string SubStatus = "Completed";
                        string QcStatus = "Pending";
                        //objSubmitionDetailsBL.MultiSaveSubmitionDetails(objsubdetailsinfo, carid, LiveTextBoxUrl.Text, websiteId, subby);
                        objSubmitionDetailsBL.MultiSaveSubmitionDetails(carid, LiveTextBoxUrl.Text, websiteId, subby, SubStatus, QcStatus, Globaltxtemail.txtemail, Globalpwd.pwd);
                        MessageBox.Show("Uploaded to Live successfully    ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LiveTextBoxUrl.Text = "";
                        btnuploadtolive.Enabled = false;
                        LiveFormUrl.Hide();
                        carid = Convert.ToInt32(textBox3.Text);
                        //DataSet dss = new DataSet();
                        //dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);
                        //btnuploadtolive.Enabled = false;
                        comboBox1.Enabled = true;
                        button3.Enabled = true;
                        tabControl1.Enabled = true;
                        comboBox3.Visible = true;
                        button11.Visible = true;
                        label53.Visible = true;
                        DataSet dss = new DataSet();
                        dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);
                        dgvpostforpostedcarid.DataSource = dss.Tables[0];
                        DataGridViewColumn column1 = dgvpostforpostedcarid.Columns[0];
                        column1.Width = 40;
                        if (dss.Tables[0].Rows.Count == 0)
                        {
                            //  dgvpostforpostedcarid.Visible = false;
                            label48.Text = "Zero Posts For this Carid";
                            label48.Visible = true;
                        }
                        else
                        {
                            label48.Visible = false;
                        }
                        //if (dss.Tables[0].Rows.Count == 0)
                        //{
                        //    // dtgridSubDet.Visible = false;
                        //    //lblsubdetails.Visible = false;
                        //}
                        //else
                        //{
                        //    //  dtgridSubDet.Visible = true;
                        //    // dtgridSubDet.AutoGenerateColumns = true;
                        //    //  dtgridSubDet.DataSource = dss.Tables[0];
                        //    //lblsubdetails.Text = "Car Id " + txtCarID.Text + " Submitted Details :";
                        //}
                        // }
                    }
                }
            }
        }
        protected void LiveButtonLater_click(object sender, EventArgs e)    
        {
            if (btnltr == 0)
            {
                btnltr++;
                int carid = Convert.ToInt32(label10.Text);
                string SubStatus = "Pending";
                string QcStatus = "Pending";
                objSubmitionDetailsBL.MultiSaveSubmitionDetails(carid, linkItem, websiteId, subby, SubStatus, QcStatus, Globaltxtemail.txtemail, Globalpwd.pwd);
                LiveFormUrl.Hide();
                int rctcarid = Convert.ToInt32(label10.Text);
                DataSet dssSubDet = new DataSet();
                dssSubDet = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(rctcarid);
                dgvpostforpostedcarid.DataSource = dssSubDet.Tables[0];
                DataGridViewColumn column1 = dgvpostforpostedcarid.Columns[0];
                column1.Width = 40;
                btnuploadtolive.Enabled = false;
                comboBox1.Enabled = true;
                button3.Enabled = true;
                tabControl1.Enabled = true;
                comboBox3.Visible = true;
                button11.Visible = true;
                label53.Visible = true;
            }
        }
        protected void ButtonSubmit_click(object sender, EventArgs e)       
        {
            if ((EmailTextBox.Text.Trim() != "") && (passwordTextBox.Text.Trim() != ""))
            {
                objSubmitionDetailsBL.MultiSaveEmail(EmailTextBox.Text.Trim(), passwordTextBox.Text.Trim(), label10.Text);

                MessageBox.Show("Data inserted successfully");
                tabControl1.Enabled = true;

                DataSet dsemail = new DataSet();
                dsemail = objSubmitionDetailsBL.MultiGetEmailByCarid(label10.Text);
                if (dsemail.Tables.Count > 0)
                {
                    if (dsemail.Tables[0].Rows.Count > 0)
                    {
                        comboBox2.DataSource = dsemail.Tables[0];
                        comboBox2.DisplayMember = dsemail.Tables[0].Columns["EmailId"].ToString();
                        textBox2.Text = dsemail.Tables[0].Rows[0]["Password"].ToString();
                        EmailForm.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter Email and Password");
                EmailTextBox.Text = "";
                passwordTextBox.Text = "";
                passwordTextBox.Focus();

            }


        }
        protected void ButtonLater_click(object sender, EventArgs e)        
        {
            EmailForm.Hide();
            tabControl1.Enabled = true;

        }
        protected void EmailButtonMinimize_click(object sender, EventArgs e)
        {
            EmailForm.WindowState = FormWindowState.Minimized;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            label2.Text = "User: " + GlobalUserName.UserName;
            label47.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            label48.Visible = false;
            circularProgressControl2.Visible = false;
            panel2.Visible = false;
            groupBox1.Focus();
            tabControl1.SelectedIndex = 4;
            panel1.Visible = true;
            #region old
            //dataGridView6.RowTemplate.Resizable = DataGridViewTriState.False;
            //dataGridView6.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView5.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView2.ColumnHeadersHeight = 30;
            //dataGridView5.ColumnHeadersHeight = 30;
            //dataGridView6.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            //dataGridView6.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            //dataGridView6.BackgroundColor = Color.White;
            ////////vcl/
            //   DataTable dt = objHomeStatictics.Statictics();
            //   dataGridView2.DataSource = dt;
            //   dataGridView2.AllowUserToAddRows = false;         
            //   //Thisweek
            //   int sum = 0;
            //   for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            //   {
            //       try
            //       {
            //           sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);
            //       }
            //       catch { }
            //   }

            //   //lastweek sum
            //   int sum1 = 0;
            //   for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            //   {
            //       try
            //       {
            //           sum1 += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);
            //       }
            //       catch { }
            //   }
            //   //life time
            //   int sum2 = 0;
            //   for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            //   {
            //       try
            //       {
            //           sum2 += Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value);
            //       }
            //       catch { }
            //   }
            //   //pending
            //   int sum3 = 0;
            //   for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            //   {
            //       try
            //       {
            //           sum3 += Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value);
            //       }
            //       catch { }
            //   }
            //   //qcpending
            //   int sum4 = 0;
            //   for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            //   {
            //       try
            //       {
            //           sum4 += Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
            //       }
            //       catch { }
            //   }
            //   dt.Rows.Add("TOTAL", sum, sum1, sum2, sum3, sum4);
            ////   dataGridView2.Rows[4].Cells[0].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
            //// System.Drawing.FontStyle.Bold);
            ////   dataGridView2.Rows[4].Cells[1].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
            ////System.Drawing.FontStyle.Bold);
            ////   dataGridView2.Rows[4].Cells[2].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
            ////System.Drawing.FontStyle.Bold);
            ////   dataGridView2.Rows[4].Cells[3].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
            ////System.Drawing.FontStyle.Bold);
            ////   dataGridView2.Rows[4].Cells[4].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
            ////System.Drawing.FontStyle.Bold);
            ////   dataGridView2.Rows[4].Cells[5].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
            ////System.Drawing.FontStyle.Bold);
            //   //closing///
            //   //starting//
            //   DataSet cntsites = new DataSet();
            //   cntsites = objSubmitionDetailsBL.MultiGetCountBySites();
            //   int k0 = Convert.ToInt32(cntsites.Tables[0].Rows[0]["Nopst"]);
            //   int k1 = Convert.ToInt32(cntsites.Tables[1].Rows[0]["LE5"]);
            //   int k2 = Convert.ToInt32(cntsites.Tables[2].Rows[0]["B6to10"]);
            //   int k3 = Convert.ToInt32(cntsites.Tables[3].Rows[0]["B11to15"]);
            //   int k4 = Convert.ToInt32(cntsites.Tables[4].Rows[0]["GT15"]);
            //   DataTable dc1 = new DataTable();
            //   dc1.Columns.Add("Posting Stats for published cars from last 90 days  ", typeof(string));
            //   dc1.Columns.Add("Total", typeof(int));
            //   dc1.Rows.Add("# of Published Cars with no posts ", k0);
            //   dc1.Rows.Add("#Published Cars with 1-5 posts ", k1);
            //   dc1.Rows.Add("#Published Cars with 6-10 posts ", k2);
            //   dc1.Rows.Add("#Published Cars with 11-15 posts", k3);
            //   dc1.Rows.Add("#Published Cars with 15+ posts", k4);
            //   dataGridView5.DataSource = dc1;
            //   dataGridView5.AllowUserToAddRows = false;
            //   //closing//
            //   //starting//
            //   DataSet OpnTkts = new DataSet();
            //   OpnTkts = objSubmitionDetailsBL.MultiGetOpenTktsCountByCarId();
            //   dataGridView6.DataSource = OpnTkts.Tables[0];
            //   dataGridView6.AllowUserToAddRows = false;
            //   //closing//
            //  progressBar1.Visible = false;
            #endregion
            label41.Visible = false;
            label40.Visible = false;
            label40.AutoSize = false;
            button4.Visible = false;
            button6.Visible = false;
            label40.Height = 1;
            label40.Width = 660;
            label40.BorderStyle = BorderStyle.FixedSingle;
            label39.Visible = false;
            label38.Visible = false;
            //label43.Visible = false;
            //Label42.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            btnGetAllPics.Visible = false;
            btnback.Visible = false;
            lblimages.Visible = false;
            btnforward.Visible = false;
            btnback.Visible = false;
            //  panel1.Visible = false;
            label16.Visible = false;
            label16.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox7.Focus();
            DataSet website = objSubmitionDetailsBL.MultiGetSiteId(comboBox1.Text);
            if (website.Tables[0].Rows.Count > 0)
            {
                string MultiGetSiteId = website.Tables[0].Rows[0]["SmrtzSiteId"].ToString();
                websiteId = Convert.ToInt32(MultiGetSiteId);
            }
            linkItem = "";
            if (Website == "CarPosts")
            {
                // websiteId = 1;
            }
            else if (Website == "myadmonster")
            {
                // websiteId = 16;
            }
            else if (Website == "JustgoodCars")
            {
                // websiteId = 4;
            }
            else if (Website == "Usadsciti")
            {
                //  websiteId = 48;
            }
            else if (Website == "UsNetads")
            {
                //  websiteId = 7;
            }
            if (Website == "CarPosts")
            {
                int i = 0;
                foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                {
                    i++;
                    if (i == 5)
                    {
                        string tabItem = htmlElement.InnerText;
                        linkItem = htmlElement.GetAttribute("HREF").ToString();
                        label32.Font = new System.Drawing.Font("Verdana", 8.0f,
                        System.Drawing.FontStyle.Bold);
                        label32.ForeColor = System.Drawing.Color.Red;
                        btnuploadtolive.Enabled = false;
                    }
                }
            }
            if (Website == "www.autoii.com")
            {
                int i = 0;
                foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                {
                    i++;
                    if (i == 5)
                    {
                        //  websiteId = 2;
                        string tabItem = htmlElement.InnerText;
                        linkItem = htmlElement.GetAttribute("HREF").ToString();
                        label32.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                        label32.ForeColor = System.Drawing.Color.Red;
                        btnuploadtolive.Enabled = false;
                    }
                }
            }
            if (Website == "clazorg")
            {
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label31.ForeColor = System.Drawing.Color.Red;
                btnuploadtolive.Enabled = false;
            }
            if (Website == "JustgoodCars")
            {
                int i = 0;
                GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "View / Edit");
                foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                {
                    i++;
                    if (i == 8)
                    {
                        string tabItem = htmlElement.InnerText;
                        linkItem = htmlElement.GetAttribute("HREF").ToString();
                        webBrowser1.Navigate("http://www.justgoodcars.com/members/members_index.php");
                        btnuploadtolive.Enabled = false;
                        label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                        label31.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            if (Website == "Usadsciti")
            {
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label31.ForeColor = System.Drawing.Color.Red;
                linkItem = webBrowser1.Url.ToString();
                btnuploadtolive.Enabled = false;
            }
            if (Website == "www.adsciti.com")
            {
                //  websiteId = 50;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label31.ForeColor = System.Drawing.Color.Red;
                linkItem = webBrowser1.Url.ToString();
                btnuploadtolive.Enabled = false;
            }
            if (Website == "UsNetads")
            {
                int i = 0;
                foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                {
                    i++;
                    if (i == 7)
                    {
                        string tabItem = htmlElement.InnerText;
                        linkItem = htmlElement.GetAttribute("HREF").ToString();
                        btnuploadtolive.Enabled = false;
                        label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                        label31.ForeColor = System.Drawing.Color.Red;
                    }
                }
                // linkItem = webBrowser1.Url.ToString();
            }
            if (Website == "jeanza")
            {
                //  websiteId = 80;
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label31.ForeColor = System.Drawing.Color.Red;
            }
            if (Website == "americanclassifieds")
            {
                // websiteId = 29;
                linkItem = webBrowser1.Url.ToString();
                btnuploadtolive.Enabled = false;
                label32.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label32.ForeColor = System.Drawing.Color.Red;
            }
            if (Website == "classifiedsciti")
            {
                // websiteId = 49;
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                linkItem = webBrowser1.Url.ToString();
            }
            if (Website == "classifiedsforfree")
            {
                // websiteId = 39;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                btnuploadtolive.Enabled = false;
                //   linkItem = "";
                foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("div"))
                {
                    string gda = el.OuterText;
                    if (el.GetAttribute("className") == "spacing10")
                    {
                        if (gda != null)
                        {
                            if (gda.Contains("classifiedsforfree"))
                            {
                                linkItem = el.InnerText;
                                int index = linkItem.IndexOf("URL:");
                                int Endindex = linkItem.Length;
                                linkItem = linkItem.ToString().Substring(index, Endindex - index);
                                linkItem = linkItem.Replace("URL:", "");
                            }
                        }
                    }
                }
                #region old
                //string cls = "spacing10";
                //HtmlDocument doc = webBrowser1.Document;
                //HtmlElementCollection col = doc.GetElementsByTagName("div");
                //foreach (HtmlElement element in col)
                //{
                //    if (element.GetAttribute("classname").Trim() == cls)
                //    {
                //        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagNameLinks)
                //        {

                //            linkItem = htmlElement.GetAttribute("div").ToString();

                //            // element.InnerHtml = "<P align=center>" + ControlInnerHtml + "<BR></P>";


                //        }
                //    }
                //}
                #endregion
            }
            if (Website == "epage")
            {
                ik = 0;
                #region old
                //  websiteId = 37;

                //   btnuploadtolive.Enabled = false;
                // linkItem = "";

                ////foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                ////{
                //   ik++;
                //  if (ik == 7)
                //  {

                //       string tabItem = htmlElement.InnerText;

                //       linkItem = htmlElement.GetAttribute("HREF").ToString();
                //       btnuploadtolive.Enabled = false;

                //       label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.FontStyle.Bold);
                //   }
                #endregion
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                linkItem = webBrowser1.Url.ToString();
                GeneralFunction.LinkInvoke(webBrowser1, "Account");
                //}
            }
            if (Website == "highlandclassifieds")
            {
                ik = 0;
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                linkItem = webBrowser1.Url.ToString();
                //webBrowser1.Navigate("http://ww1.highlandclassifieds.com/js/account/c45757");
                //GeneralFunction.ImgeButtonimageInvoke(webBrowser1, "/tmpl/0/member.gif");
                GeneralFunction.LinkInvoke(webBrowser1, "Member Account");
            }
            if (Website == "classifiededition")
            {
                //  websiteId = 91;
                btnuploadtolive.Enabled = false;
                label32.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                linkItem = "";
                label32.ForeColor = System.Drawing.Color.Red;
            }
            if (Website == "classifiedsvalley")
            {
                // websiteId = 84;
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                linkItem = "";
                label31.ForeColor = System.Drawing.Color.Red;
            }
            if (Website == "www.postfreeadshere.com")
            {
                // websiteId = 51;
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                linkItem = "";
            }
            if (Website == "www.motoseller.com")
            {
                // websiteId = 54;
                btnuploadtolive.Enabled = false;
                label29.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                linkItem = "";
            }
            if (Website == "www.cathaylist.comm")
            {
                //websiteId = 83;
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                linkItem = "";
            }
            if (Website == "www.freeadlists.com")
            {
                //  websiteId = 13;
            }
            if (Website == "adsriver")
            {
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                // websiteId = 92;
                linkItem = "";
            }
            if (Website == "anunico")
            {
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                // websiteId = 82;
                linkItem = "";
                label31.ForeColor = System.Drawing.Color.Red;
            }
            if (Website == "classifieds4me")
            {
                label32.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                // websiteId = 77;
                linkItem = "";
                label32.ForeColor = System.Drawing.Color.Red;
            }
            if (Website == "classifiedsciti")
            {
                label32.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label32.ForeColor = System.Drawing.Color.Red;
                linkItem = webBrowser1.Url.ToString();
            }
            if (Website == "myadmonster")
            {
                linkItem = "";
                btnuploadtolive.Enabled = false;
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label31.ForeColor = System.Drawing.Color.Red;

                //          label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.Color.Red;
            }
            if (Website == "75vn")
            {
                //      linkItem = webBrowser1.Url.ToString();
                //      int strtindex = linkItem.IndexOf("IDProduct=");
                //      int endindex = linkItem.Length;
                //      string purl = linkItem.ToString().Substring(strtindex, endindex - strtindex);
                //      purl = purl.Replace("IDProduct=", "");
                //linkItem = "http://www.75vn.com/auto/ad35id" + purl + "/";
                label32.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                //label32.ForeColor = System.Drawing.Color.Red;
                linkItem = "";

                GeneralFunction.LinkInvoke(webBrowser1, "Log Out");
            }
            if (Website == "classifiedads")
            {
                btnuploadtolive.Enabled = false;
                linkItem = webBrowser1.Url.ToString();
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label31.ForeColor = System.Drawing.Color.Red;
            }
            if (Website == "webcosmo")
            {
                btnuploadtolive.Enabled = false;
                linkItem = "";// webBrowser1.Url.ToString();
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label31.ForeColor = System.Drawing.Color.Red;
            }
            if (Website == "extraclassifieds")
            {
                btnuploadtolive.Enabled = false;
                linkItem = "";// webBrowser1.Url.ToString();
                label31.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                label31.ForeColor = System.Drawing.Color.Red;
            }
            textBox2.Focus();
            subby = GlobalLogId.globallogidVar;
            DialogResult dialogResult = MessageBox.Show("DO you Want to Proceed?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (linkItem != "")
                {
                    string SubStatus = "Completed";
                    string QcStaus = "Pending";
                    int carid1 = Convert.ToInt32(label10.Text);
                    //@CarID int,@URL varchar(500),@SiteID int,@PostedBy int
                    objSubmitionDetailsBL.MultiSaveSubmitionDetails(carid1, linkItem, websiteId, subby, SubStatus, QcStaus, Globaltxtemail.txtemail, Globalpwd.pwd);
                    MessageBox.Show("Uploaded to Live successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    linkItem = "";
                }
                //do something
                else if (linkItem == "")
                {
                    comboBox1.Enabled = false;
                    button3.Enabled = false;
                    tabControl1.Enabled = false;
                    LiveFormUrl.ControlBox = false;
                    //LiveFormUrl.MaximizeBox = true;
                    //LiveFormUrl.MaximizeBox = true;
                    try
                    {
                        LiveButtonUrl.Click += new System.EventHandler(LiveButtonUrl_click);
                        LiveButtonLater.Click += new System.EventHandler(LiveButtonLater_click);
                        LiveButtonMinimize.Click += new System.EventHandler(LiveButtonMinimize_click);
                        btnltr = 0;
                        LiveFormUrl.Text = "To Enter Live Url";
                        LiveFormUrl.Width = 300;
                        LiveFormUrl.Height = 300;
                        Label lblliveurl = new Label();
                        LiveFormUrl.Controls.Add(LiveTextBoxUrl);
                        LiveFormUrl.Controls.Add(LiveButtonUrl);
                        LiveFormUrl.Controls.Add(LiveButtonLater);
                        LiveFormUrl.Controls.Add(LiveButtonMinimize);
                        LiveFormUrl.Controls.Add(lblliveurl);
                        lblliveurl.Location = new System.Drawing.Point(10, 65);
                        LiveTextBoxUrl.Location = new System.Drawing.Point(105, 64);
                        LiveTextBoxUrl.Width = 130;
                        lblliveurl.Text = "Enter Live URL: ";
                        LiveButtonUrl.Location = new System.Drawing.Point(95, 94);
                        LiveButtonUrl.Width = 75;
                        LiveButtonUrl.Text = "Submit";
                        //  LiveFormUrl.Show();
                        LiveButtonLater.Location = new System.Drawing.Point(175, 94);
                        LiveButtonLater.Width = 75;
                        LiveButtonLater.Text = "TryLater";
                        LiveFormUrl.Show();
                        LiveButtonMinimize.Location = new System.Drawing.Point(215, 10);
                        LiveButtonMinimize.Width = 60;
                        LiveButtonMinimize.Text = "Minimize";
                        LiveButtonMinimize.ForeColor = Color.White;
                        LiveButtonMinimize.BackColor = Color.DarkBlue;
                    }
                    catch
                    {
                        #region old
                        //LiveFormUrl.Text = "To Enter Live Url";
                        //LiveFormUrl.Width = 300;
                        //LiveFormUrl.Height = 300;
                        //Label lblliveurl = new Label();
                        //LiveFormUrl.Controls.Add(LiveTextBoxUrl);
                        //LiveFormUrl.Controls.Add(LiveButtonUrl);
                        //LiveFormUrl.Controls.Add(LiveButtonLater);
                        //LiveFormUrl.Controls.Add(lblliveurl);
                        //lblliveurl.Location = new System.Drawing.Point(10, 65);
                        //LiveTextBoxUrl.Location = new System.Drawing.Point(105, 64);
                        //LiveTextBoxUrl.Width = 130;
                        //lblliveurl.Text = "Enter Live URL: ";




                        //LiveButtonUrl.Location = new System.Drawing.Point(95, 94);
                        //LiveButtonUrl.Width = 75;
                        //LiveButtonUrl.Text = "Submit";
                        ////  LiveFormUrl.Show();

                        //LiveButtonLater.Location = new System.Drawing.Point(175, 94);
                        //LiveButtonLater.Width = 75;
                        //LiveButtonLater.Text = "TryLater";
                        //LiveFormUrl.Show();
                        #endregion
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            { }
            int carid = Convert.ToInt32(label10.Text);
            DataSet dss = new DataSet();
            dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);
            dgvpostforpostedcarid.DataSource = dss.Tables[0];
            DataGridViewColumn column1 = dgvpostforpostedcarid.Columns[0];
            column1.Width = 40;
            // to get total of particular carid posting today
            int carno = Convert.ToInt32(label10.Text);
            int value = General.Count_Url_for_carid.GetcountofCarid(carno, subby);
            label37.Text = Convert.ToInt32(value).ToString();
            //End  to get total of particular carid posting today
            if (dss.Tables[0].Rows.Count == 0)
            {
                //  dgvpostforpostedcarid.Visible = false;
                label48.Text = "Zero Posts For this Carid";
                label48.Visible = true;
            }
            else
            {
                label48.Visible = false;
            }
            int rctcarid = Convert.ToInt32(label10.Text);
            DataSet dssSubDet = new DataSet();
            dssSubDet = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(rctcarid);
            dgvpostforpostedcarid.DataSource = dssSubDet.Tables[0];
            DataGridViewColumn column2 = dgvpostforpostedcarid.Columns[0];
            column2.Width = 40;
            // this.Refresh();
            textBox2.Focus();
        }
        private void btnGetAllPics_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //btnForward.Visible = true;
            // btnback.Visible = true;
            if (imgcount >= 3)
            {
                //btnforward.Visible = true;
                //btnback.Visible = true;
                //lblimages.Text = "Tot:" + imgcount.ToString();
            }
            try
            {
                com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                obUsedCarsInfo = objService.FindCarID(label10.Text);
                //List<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                //UsedCarsSearch obj = new UsedCarsSearch();
                //obUsedCarsInfo = (List<com.unitedcarexchange.UsedCarsInfo>)obj.FindCarID(txtCarID.Text);
                Cursor.Current = Cursors.WaitCursor;
                // lblpics.Visible = false;
                CreateImageURLPath(Pics.GetPic3(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-4", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic4(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-5", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic5(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-6", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic6(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-7", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic7(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-8", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic8(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-9", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic9(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-10", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic10(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-11", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic11(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-12", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic12(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-13", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic13(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-14", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic14(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-15", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic15(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-16", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic16(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-17", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic17(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-18", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic18(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-19", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic19(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-20", obUsedCarsInfo[0].Carid.ToString());
                // lblimgcount.Visible = true ;
                MessageBox.Show("All Images downloaded successfully");
                Cursor.Current = Cursors.Default;
                // ---------------------
                // int fileSize = (int)new System.IO.FileInfo(filePath).Length;
                // @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpg";
                for (int i = 4; i <= 20; i++)
                {
                    string filePath = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + i + "" + ".jpg";
                    if (File.Exists(filePath))
                    {
                        int fileSize = (int)new System.IO.FileInfo(filePath).Length;
                        if (fileSize != 0)
                        {
                            imgcount++;
                        }
                    }
                }
                //------------------
            }
            catch (Exception ex)
            {
            }
            btnGetAllPics.Enabled = false;
            lblimages.Visible = true;
            lblimages.Text = "Tot:" + imgcount.ToString();
            if (imgcount > 3)
            {
                btnback.Visible = true;
                btnforward.Visible = true;
            }
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
            obUsedCarsInfo = objService.FindCarID(label10.Text);
            #region old
            //if (Convert.ToInt32(cnt) > 2)
            //{
            //    btnback.Enabled = true;
            //    string ex = label19.Text;
            //    char[] sepem = { '-' };
            //    string[] msplit = ex.Split(sepem);
            //    cnt = msplit[1].ToString();
            //    cnt = cnt.Replace(".jpg", " ");
            //    cnt = cnt.Replace(".jpg", " ");
            //    int c = Convert.ToInt32(cnt) - 3;
            //    int d = Convert.ToInt32(cnt) - 2;
            //    int b = Convert.ToInt32(cnt) - 1;
            //    //List<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
            //    //UsedCarsSearch obj = new UsedCarsSearch();
            //    //obUsedCarsInfo = (List<com.unitedcarexchange.UsedCarsInfo>)obj.FindCarID(txtCarID.Text);
            //    if (cnt == "7 ")
            //    {
            //        btnForward.Enabled = true;
            //        //CreateImageURLPath(Pics.GetPic3(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + c + "", obUsedCarsInfo[0].Carid.ToString());
            //        //CreateImageURLPath(Pics.GetPic4(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + d + "", obUsedCarsInfo[0].Carid.ToString());
            //        //CreateImageURLPath(Pics.GetPic5(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + b + "", obUsedCarsInfo[0].Carid.ToString());
            //        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpg";
            //        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpg";
            //        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpg";
            //        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpg";
            //        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpg";
            //        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpg";
            //    }
            //    if (cnt == "4 ")
            //    {
            //        btnback.Enabled = false;
            //        btnForward.Enabled = true;
            //        //CreateImageURLPath(Pics.GetPic0(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + c + "", obUsedCarsInfo[0].Carid.ToString());
            //        //CreateImageURLPath(Pics.GetPic1(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + d + "", obUsedCarsInfo[0].Carid.ToString());
            //        //CreateImageURLPath(Pics.GetPic3(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + b + "", obUsedCarsInfo[0].Carid.ToString());
            //        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpg";
            //        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpg";
            //        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpg";
            //        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpg";
            //        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpg";
            //        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpg";
            //    }
            //}
            //----------------------
            #endregion
            string ex = label21.Text;
            char[] sepem = { '-' };
            string[] msplit = ex.Split(sepem);
            cnt = msplit[1].ToString();
            cnt = cnt.Replace(".jpg", "");
            cnt = cnt.Replace(".jpg", "");
            int cntt = Convert.ToInt32(cnt);

            switch (imgcount)
            {
                case 1:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = "";
                    label21.Text = "";
                    break;
                case 2:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = "";
                    break;
                case 3:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    break;
                case 4:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                    if (cnt == "4") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 5:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                    if (cnt == "5") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 6:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    if (cnt == "6")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 7:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                    if (cnt == "7") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 8:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                    if (cnt == "8") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 9:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    if (cnt == "9")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 10:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                    if (cnt == "10")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6")  //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 11:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                    //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg")
                    if (cnt == "11")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    if (cnt == "9")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    if (cnt == "6")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +3 + "" + ".jpg")
                    if (cnt == "3")
                    { }
                    break;
                case 12:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    if (cnt == "12") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 13:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                    if (cnt == "13")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "12")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    { }
                    break;
                case 14:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                    if (cnt == "14")// if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 15:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    if (cnt == "15") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 16:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                    if (cnt == "16") // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    }
                    if (cnt == "15")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    { }
                    break;
                case 17:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                    if (cnt == "17") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    }
                    if (cnt == "15")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {                    }
                    break;
                case 18:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                    if (cnt == "18") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    }
                    if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {                    }
                    break;
                case 19:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg";
                    if (cnt == "19") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                    }
                    if (cnt == "18") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18+ "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    }
                    if (cnt == "15")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {                    }
                    break;
                case 20:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpg";
                    if (cnt == "20") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                    }
                    if (cnt == "18") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                    }
                    if (cnt == "15")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9")  //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                    }
                    if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {                    }
                    break;
            }
           //-----------------------
        }
        private void btnforward_Click(object sender, EventArgs e)
        {
            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
            obUsedCarsInfo = objService.FindCarID(label10.Text);
            #region old
            //btnback.Enabled = true;
            //btnForward.Enabled = true;
            //string ex = label21.Text;

            //char[] sepem = { '-' };
            //string[] msplit = ex.Split(sepem);
            //cnt = msplit[1].ToString();
            //cnt = cnt.Replace(".jpg", " ");
            //cnt = cnt.Replace(".jpg", " ");
            //if (cnt == "6 ")
            //{
            //    btnForward.Enabled = false;
            //}

            //int c = Convert.ToInt32(cnt) + 1;
            //int d = Convert.ToInt32(cnt) + 2;
            //int b = Convert.ToInt32(cnt) + 3;


            //// string ex=i


            ////List<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
            ////UsedCarsSearch obj = new UsedCarsSearch();
            ////obUsedCarsInfo = (List<com.unitedcarexchange.UsedCarsInfo>)obj.FindCarID(txtCarID.Text);


            //if (cnt == "3 ")
            //{

            //    //CreateImageURLPath(Pics.GetPic3(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + c + "", obUsedCarsInfo[0].Carid.ToString());
            //    //CreateImageURLPath(Pics.GetPic4(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + d + "", obUsedCarsInfo[0].Carid.ToString());
            //    //CreateImageURLPath(Pics.GetPic5(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + b + "", obUsedCarsInfo[0].Carid.ToString());

            //    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpg";

            //    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpg";

            //    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpg";
            //    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpg";

            //    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpg";
            //    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpg";

            //}
            //if (cnt == "6 ")
            //{
            //    //CreateImageURLPath(Pics.GetPic6(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + c + "", obUsedCarsInfo[0].Carid.ToString());
            //    //CreateImageURLPath(Pics.GetPic7(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + d + "", obUsedCarsInfo[0].Carid.ToString());
            //    //CreateImageURLPath(Pics.GetPic8(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + b + "", obUsedCarsInfo[0].Carid.ToString());
            //    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpg";
            //    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpg";
            //    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpg";
            //    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpg";
            //    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpg";
            //    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpg";
            //}
            //   //int picshowcount = imgcount - 1;
            //   //if (picshowcount > 9)
            //   //{ 
            //   //}
            //   //    List<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
            //   //    UsedCarsSearch obj = new UsedCarsSearch();
            //   //    obUsedCarsInfo = (List<com.unitedcarexchange.UsedCarsInfo>)obj.FindCarID(txtCarID.Text);
            //   // //pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-4" + ".jpg";
            //   // //label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-4" + ".jpg";
            //   // //pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-5" + ".jpg";
            //   // //label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() +"-5"+ ".jpg";
            //   // //pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() +"-6"+ ".jpg";
            //   // //label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() +"-6"+ ".jpg";
            //   ----------------------
            #endregion
            string ex = label21.Text;
            char[] sepem = { '-' };
            string[] msplit = ex.Split(sepem);
            cnt = msplit[1].ToString();
            cnt = cnt.Replace(".jpg", "");
            cnt = cnt.Replace(".jpg", "");
           //int cntt = Convert.ToInt32(cnt);
            //if (cntt > 3) 
            //{
            //    btnback.Enabled = true;
            //   // btnForward.Enabled = false;
            //}
            //if (cntt < 9)
            //{
            //    btnback.Enabled = false;
            //}
            switch (imgcount)
            {
                case 1:
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = "";
                    label21.Text = "";
                    break;
                case 2:

                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = "";

                    break;
                case 3:

                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";



                    break;
                case 4:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    //   if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    if (cnt == "3")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";

                    }
                    //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg")
                    if (cnt == "4")
                    {

                    }




                    break;

                case 5:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    if (cnt == "3")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";

                    }
                    //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg")
                    if (cnt == "5")
                    {

                    }


                    break;
                case 6:



                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    if (cnt == "3")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    if (cnt == "6")
                    {

                    }
                    break;
                case 7:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                    }
                    if (cnt == "7")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg")
                    {

                    }


                    break;
                case 8:

                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                    }
                    if (cnt == "8") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg")
                    {

                    }



                    break;

                case 9:

                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {

                    }

                    break;
                case 10:

                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                    }
                    if (cnt == "10")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg")
                    {

                    }

                    break;
                case 11:

                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    if (cnt == "3")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        break;


                    }
                    //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    if (cnt == "6")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        break;
                    }
                    //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    if (cnt == "9")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";

                        break;
                    }
                    //   if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg")
                    if (cnt == "11")
                    {

                        break;
                    }
                    break;


                case 12:

                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        break;
                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        break;
                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        break;
                    }
                    if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        break;
                    }



                    break;

                case 13:

                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        break;

                    }
                    if (cnt == "6") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                        break;
                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        break;
                    }
                    if (cnt == "12") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        break;

                    }
                    if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        break;
                    }



                    break;
                case 14:

                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";



                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";
                        break;

                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";

                    }
                    if (cnt == "14") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg")
                    {

                    }

                    break;
                case 15:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                    }
                    if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {

                    }

                    break;
                case 16:



                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    if (cnt == "6") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                    }
                    if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";


                    }
                    if (cnt == "16") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg")
                    {

                    }

                    break;
                case 17:



                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                    }
                    if (cnt == "15") //   else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";


                    }
                    if (cnt == "17")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg")
                    {

                    }

                    break;
                case 18:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    if (cnt == "6") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                    }
                    if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";


                    }
                    if (cnt == "18") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg")
                    {

                    }

                    break;

                case 19:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";


                    }
                    if (cnt == "6") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                    }
                    if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";


                    }
                    if (cnt == "18")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg";


                    }
                    if (cnt == "19") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg")
                    {

                    }

                    break;
                case 20:



                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg";

                    }
                    if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg";
                    }
                    if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg";
                    }
                    if (cnt == "12")  //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg";

                    }
                    if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";


                    }
                    if (cnt == "18") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpg";


                    }
                    if (cnt == "20") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpg")
                    {

                    }
                    break;
            }

            //---------------------------

        }
        private void dgvviewpendingsites_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.ForeColor = Color.Red;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {

                dataGridView6.RowTemplate.Resizable = DataGridViewTriState.False;
                dataGridView6.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView5.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.ColumnHeadersHeight = 30;
                dataGridView5.ColumnHeadersHeight = 30;
                dataGridView6.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                dataGridView6.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                dataGridView6.BackgroundColor = Color.White;
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt = objHomeStatictics.Statictics();
                dataGridView2.DataSource = dt;
                dataGridView2.AllowUserToAddRows = false;
                //Thisweek
                int sum = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    try
                    {
                        sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);
                    }
                    catch { }
                }
                //lastweek sum
                int sum1 = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    try
                    {
                        sum1 += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);
                    }
                    catch { }
                }
                //life time
                int sum2 = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    try
                    {
                        sum2 += Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value);
                    }
                    catch { }
                }
                //pending
                int sum3 = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    try
                    {
                        sum3 += Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value);
                    }
                    catch { }
                }
                //qcpending
                int sum4 = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    try
                    {
                        sum4 += Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
                    }
                    catch { }
                }
                dt.Rows.Add("TOTAL", sum, sum1, sum2, sum3, sum4);

                #region old
                //   dataGridView2.Rows[5].Cells[0].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
                // System.Drawing.FontStyle.Bold);
                //   dataGridView2.Rows[5].Cells[1].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.FontStyle.Bold);
                //   dataGridView2.Rows[5].Cells[2].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.FontStyle.Bold);
                //   dataGridView2.Rows[5].Cells[3].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.FontStyle.Bold);

                //   dataGridView2.Rows[5].Cells[4].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.FontStyle.Bold);
                //   dataGridView2.Rows[5].Cells[5].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.FontStyle.Bold);


                //closing///




                //starting//
                #endregion
                DataSet cntsites = new DataSet();
                cntsites = objSubmitionDetailsBL.MultiGetCountBySites();

                int k0 = Convert.ToInt32(cntsites.Tables[0].Rows[0]["Nopst"]);
                int k1 = Convert.ToInt32(cntsites.Tables[1].Rows[0]["LE5"]);
                int k2 = Convert.ToInt32(cntsites.Tables[2].Rows[0]["B6to10"]);
                int k3 = Convert.ToInt32(cntsites.Tables[3].Rows[0]["B11to15"]);
                int k4 = Convert.ToInt32(cntsites.Tables[4].Rows[0]["GT15"]);

                DataTable dc1 = new DataTable();
                dc1.Columns.Add("Posting Stats for published cars from last 90 days  ", typeof(string));
                dc1.Columns.Add("Total", typeof(int));
                dc1.Rows.Add("# of Published Cars with no posts ", k0);
                dc1.Rows.Add("#Published Cars with 1-5 posts ", k1);
                dc1.Rows.Add("#Published Cars with 6-10 posts ", k2);
                dc1.Rows.Add("#Published Cars with 11-15 posts", k3);
                dc1.Rows.Add("#Published Cars with 15+ posts", k4);
                dataGridView5.DataSource = dc1;
                dataGridView5.AllowUserToAddRows = false;

                //closing//
                //starting//
                DataSet OpnTkts = new DataSet();
                OpnTkts = objSubmitionDetailsBL.MultiGetOpenTktsCountByCarId();
                dataGridView6.DataSource = OpnTkts.Tables[0];
                dataGridView6.AllowUserToAddRows = false;
                //closing//
                Cursor.Current = Cursors.Default;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                comboBox1.Visible = true;
                comboBox3.Visible = true;
                button11.Visible = true;
                label53.Visible = true;
                ///////start//////////
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                ds = objSubmitionDetailsBL.GetRecentPostdata();
                //  dataGridView1.DataSource = ds.Tables[0];
                DataSet ds2 = new DataSet();
                ds2 = objSubmitionDetailsBL.MultiGetPendgCount();
                DataSet ds3 = new DataSet();
                ds3 = objSubmitionDetailsBL.MultiGetTicketCount();
                //-----datatable start-------------
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("CarId", typeof(int));
                dt1.Columns.Add("PublishDt", typeof(string));
                dt1.Columns.Add("#Posts", typeof(int));
                dt1.Columns.Add("LastPostDt", typeof(string));
                dt1.Columns.Add("LastPostedBy", typeof(string));
                dt1.Columns.Add("Year/Make/Model/Price/Mileage", typeof(string));
                dt1.Columns.Add("CarStatus", typeof(string));
                dt1.Columns.Add("State", typeof(string));
                dt1.Columns.Add("Pend#", typeof(int));
                dt1.Columns.Add("RelTkts#", typeof(int));

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("CarId", typeof(int));
                dt2.Columns.Add("Pend#", typeof(string));

                DataTable dt3 = new DataTable();
                dt3.Columns.Add("CarId", typeof(int));
                dt3.Columns.Add("#tkts", typeof(int));

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dynamicRow1 = dt1.NewRow();
                    dt1.Rows.Add(dynamicRow1);
                    dt1.Rows[i]["CarId"] = Convert.ToInt32(ds.Tables[0].Rows[i]["CarId"]);
                    dt1.Rows[i]["PublishDt"] = ds.Tables[0].Rows[i]["PublishedDt"]; ;
                    dt1.Rows[i]["#Posts"] = ds.Tables[0].Rows[i]["#Posts"];
                    dt1.Rows[i]["LastPostDt"] = ds.Tables[0].Rows[i]["LastSubDt"];
                    dt1.Rows[i]["LastPostedBy"] = ds.Tables[0].Rows[i]["Lstpstby"];
                    dt1.Rows[i]["Year/Make/Model/Price/Mileage"] = ds.Tables[0].Rows[i]["year/make/model/price/Mileage"];
                    dt1.Rows[i]["CarStatus"] = ds.Tables[0].Rows[i]["status"];
                    dt1.Rows[i]["State"] = ds.Tables[0].Rows[i]["state"];
                    dt1.Rows[i]["Pend#"] = 0;
                    dt1.Rows[i]["RelTkts#"] = 0;
                }
                if (ds2.Tables[0].Rows.Count < ds.Tables[0].Rows.Count)
                {
                    int j = ds.Tables[0].Rows.Count - ds2.Tables[0].Rows.Count;
                    for (int k = 0; k < j; k++)
                    {
                        DataRow dynamicRow2 = dt2.NewRow();
                        dt2.Rows.Add(dynamicRow2);
                        dt2.Rows[k]["CarId"] = 0;
                        dt2.Rows[k]["Pend#"] = 0;
                    }
                }
                if (ds2.Tables[0].Rows.Count < ds.Tables[0].Rows.Count)
                {
                    int x = ds.Tables[0].Rows.Count - ds2.Tables[0].Rows.Count;
                    int m = x + ds2.Tables[0].Rows.Count;
                    int n = 0;
                    for (int l = x; l < m; l++)
                    {
                        DataRow dynamicRow2 = dt2.NewRow();
                        dt2.Rows.Add(dynamicRow2);
                        dt2.Rows[l]["CarId"] = Convert.ToInt32(ds2.Tables[0].Rows[n]["Carid"]);
                        dt2.Rows[l]["Pend#"] = ds2.Tables[0].Rows[n]["Pend#"];
                        n++;
                    }
                }
                for (int p = 0; p < dt1.Rows.Count; p++)
                {
                    for (int q = 0; q < dt2.Rows.Count; q++)
                    {
                        // Label1.Text = dt1.Rows[p]["Dosage2"].ToString();
                        //  Label2.Text = dt2.Rows[q]["Dos2"].ToString();
                        if (dt1.Rows[p]["Carid"].ToString() == dt2.Rows[q]["Carid"].ToString())
                        {
                            // Label3 .Text = dt1.Rows[p]["Dosage6"].ToString();
                            //  Label4 .Text  = dt2.Rows[q]["Dos2"].ToString();
                            //  dt1.Rows[p]["Carid"] = dt2.Rows[q]["Dos5"];
                            dt1.Rows[p]["Pend#"] = dt2.Rows[q]["Pend#"];
                            //  dt1.Rows[p]["Dosage7"] = dt2.Rows[q]["Dos7"];
                        }
                    }
                }
                //  ----------------
                if (ds3.Tables[0].Rows.Count < ds.Tables[0].Rows.Count)
                {
                    int j = ds.Tables[0].Rows.Count - ds3.Tables[0].Rows.Count;

                    for (int k = 0; k < j; k++)
                    {
                        DataRow dynamicRow3 = dt3.NewRow();
                        dt3.Rows.Add(dynamicRow3);
                        dt3.Rows[k]["CarId"] = 0;
                        dt3.Rows[k]["#tkts"] = 0;
                    }
                }
                if (ds3.Tables[0].Rows.Count < ds.Tables[0].Rows.Count)
                {
                    int x = ds.Tables[0].Rows.Count - ds3.Tables[0].Rows.Count;
                    int m = x + ds3.Tables[0].Rows.Count;
                    int n = 0;
                    for (int l = x; l < m; l++)
                    {
                        DataRow dynamicRow3 = dt3.NewRow();
                        dt3.Rows.Add(dynamicRow3);
                        dt3.Rows[l]["CarId"] = Convert.ToInt32(ds3.Tables[0].Rows[n]["Carid"]);
                        dt3.Rows[l]["#tkts"] = ds3.Tables[0].Rows[n]["#tkts"];
                        n++;
                    }
                }
                for (int p = 0; p < dt1.Rows.Count; p++)
                {
                    for (int q = 0; q < dt3.Rows.Count; q++)
                    {
                        // Label1.Text = dt1.Rows[p]["Dosage2"].ToString();
                        //  Label2.Text = dt2.Rows[q]["Dos2"].ToString();
                        if (dt1.Rows[p]["Carid"].ToString() == dt3.Rows[q]["Carid"].ToString())
                        {
                            // Label3 .Text = dt1.Rows[p]["Dosage6"].ToString();
                            //  Label4 .Text  = dt2.Rows[q]["Dos2"].ToString();
                            //  dt1.Rows[p]["Carid"] = dt2.Rows[q]["Dos5"];
                            dt1.Rows[p]["RelTkts#"] = dt3.Rows[q]["#tkts"];
                            //  dt1.Rows[p]["Dosage7"] = dt2.Rows[q]["Dos7"];
                        }
                    }
                }
                //------------------
                dataGridView1.DataSource = dt1;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[0].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                dataGridView1.DataSource = dt1;
                this.dataGridView1.Columns[2].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                DataGridViewColumn column0 = dataGridView1.Columns[0];
                column0.Width = 65;
                DataGridViewColumn column1 = dataGridView1.Columns[1];
                column1.Width = 85;
                DataGridViewColumn column2 = dataGridView1.Columns[2];
                column2.Width = 65;
                DataGridViewColumn column3 = dataGridView1.Columns[3];
                column3.Width = 85;
                DataGridViewColumn column6 = dataGridView1.Columns[6];
                column6.Width = 85;
                DataGridViewColumn column5 = dataGridView1.Columns[5];
                column5.Width = 220;
                DataGridViewColumn column7 = dataGridView1.Columns[7];
                column7.Width = 65;
                DataGridViewColumn column8 = dataGridView1.Columns[8];
                column8.Width = 65;
                DataGridViewColumn column9 = dataGridView1.Columns[9];
                column9.Width = 85;
                /////end/////////
                //-----------------------start-----------------
                string dgvcarid = dataGridView1.Rows[0].Cells[0].Value.ToString();
                DataSet viewqpend = new DataSet();
                viewqpend = objSubmitionDetailsBL.MultigetViewpendingsite(dgvcarid);
                dgvviewpendingsites.DataSource = viewqpend.Tables[0];
                dgvviewpendingsites.ClearSelection();
                DataSet viewpost = new DataSet();
                viewpost = objSubmitionDetailsBL.MultigetpostedSites(dgvcarid);
                dgvviewpostedsite.DataSource = viewpost.Tables[0];
                DataGridViewColumn columnview0 = dgvviewpostedsite.Columns[0];
                columnview0.Width = 155;
                DataGridViewColumn columnpend0 = dgvviewpendingsites.Columns[0];
                columnpend0.Width = 155;
                dgvviewpendingsites.DefaultCellStyle.ForeColor = Color.Red;
                label18.Text = "CarId: " + dgvcarid.ToString();
                label22.Text = "CarId: " + dgvcarid.ToString();
                Cursor.Current = Cursors.Default;
                //--------------------end=========================
                // this.Opacity = 100;
                //-------datattable end--------------
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                this.AcceptButton = button1;
                // this.Opacity = .5;
                Getpending();
                #region old
                //Cursor.Current = Cursors.WaitCursor;
                //DataSet dsp1 = new DataSet();
                //DataSet dsp2=new DataSet();
                //DataSet dsp3 = new DataSet();
                //DataSet dsp4 = new DataSet();
                //dsp1 = objSubmitionDetailsBL.MultiGetTotPending();
                //dsp2 = objSubmitionDetailsBL.MultiGetPendingCount();
                //dsp3 = objSubmitionDetailsBL.MultiGetTicketCount();
                //dsp4 = objSubmitionDetailsBL.MultiGetPendingCount1();
                //DataTable dtp1 = new DataTable();
                //dtp1.Columns.Add("CarId", typeof(int));
                //dtp1.Columns.Add("PublishDt", typeof(string));
                //dtp1.Columns.Add("State", typeof(string));
                //dtp1.Columns.Add("LastPostDt", typeof(string));
                //dtp1.Columns.Add("#Posts", typeof(int));
                //dtp1.Columns.Add("Year/Make/Model/Price/Mileage", typeof(string));
                //dtp1.Columns.Add("CarStatus", typeof(string));
                //dtp1.Columns.Add("UrlPend#", typeof(int));
                //dtp1.Columns.Add("QcPend#", typeof(int));
                //dtp1.Columns.Add("RelTkts#", typeof(int));
                //DataTable dtp2 = new DataTable();
                //dtp2.Columns.Add("CarId", typeof(int));
                //dtp2.Columns.Add("UrlPend#", typeof(int));
                //DataTable dtp3 = new DataTable();
                //dtp3.Columns.Add("CarId", typeof(int));
                //dtp3.Columns.Add("#tkts", typeof(int));
                //DataTable dtp4 = new DataTable();
                //dtp4.Columns.Add("CarId", typeof(int));
                //dtp4.Columns.Add("QcPend#", typeof(int));
                //for (int i = 0; i < dsp1.Tables[0].Rows.Count; i++)
                //{
                //    DataRow dynamicRow1 = dtp1.NewRow();
                //    dtp1.Rows.Add(dynamicRow1);
                //    dtp1.Rows[i]["CarId"] = Convert.ToInt32(dsp1.Tables[0].Rows[i]["CarId"]);
                //    dtp1.Rows[i]["PublishDt"] = dsp1.Tables[0].Rows[i]["PublishedDt"]; ;
                //    dtp1.Rows[i]["#Posts"] = dsp1.Tables[0].Rows[i]["#Posts"];
                //    dtp1.Rows[i]["LastPostDt"] = dsp1.Tables[0].Rows[i]["LastSubDt"];
                //    dtp1.Rows[i]["Year/Make/Model/Price/Mileage"] = dsp1.Tables[0].Rows[i]["year/make/model/price/Mileage"];
                //    dtp1.Rows[i]["CarStatus"] = dsp1.Tables[0].Rows[i]["status"];
                //    dtp1.Rows[i]["State"] = dsp1.Tables[0].Rows[i]["state"];
                //    dtp1.Rows[i]["UrlPend#"] = 0;
                //    dtp1.Rows[i]["QcPend#"] = 0;
                //    dtp1.Rows[i]["RelTkts#"] = 0;
                //}
                //if (dsp2.Tables[0].Rows.Count < dsp1.Tables[0].Rows.Count)
                //{
                //    int j = dsp1.Tables[0].Rows.Count - dsp2.Tables[0].Rows.Count;
                //    for (int k = 0; k < j; k++)
                //    {
                //        DataRow dynamicRow2 = dtp2.NewRow();
                //        dtp2.Rows.Add(dynamicRow2);
                //        dtp2.Rows[k]["CarId"] = 0;
                //        dtp2.Rows[k]["UrlPend#"] = 0;
                //    }
                //}
                //if (dsp2.Tables[0].Rows.Count < dsp1.Tables[0].Rows.Count)
                //{
                //    int j = dsp1.Tables[0].Rows.Count - dsp2.Tables[0].Rows.Count;
                //    for (int k = 0; k < j; k++)
                //    {
                //        DataRow dynamicRow2 = dtp4.NewRow();
                //        dtp4.Rows.Add(dynamicRow2);
                //        dtp4.Rows[k]["CarId"] = 0;
                //        dtp4.Rows[k]["QcPend#"] = 0;
                //    }
                //}
                //if (dsp2.Tables[0].Rows.Count <= dsp1.Tables[0].Rows.Count)
                //{
                //    int x = dsp1.Tables[0].Rows.Count - dsp2.Tables[0].Rows.Count;
                //    int m = x + dsp2.Tables[0].Rows.Count;
                //    int n = 0;
                //    for (int l = x; l < m; l++)
                //    {
                //        DataRow dynamicRow2 = dtp2.NewRow();
                //        dtp2.Rows.Add(dynamicRow2);
                //        dtp2.Rows[l]["CarId"] = Convert.ToInt32(dsp2.Tables[0].Rows[n]["Carid"]);
                //        dtp2.Rows[l]["UrlPend#"] = dsp2.Tables[0].Rows[n]["UrlPend"];
                //        n++;
                //    }
                //}
                //if (dsp4.Tables[0].Rows.Count <= dsp1.Tables[0].Rows.Count)
                //{
                //    int x = dsp1.Tables[0].Rows.Count - dsp4.Tables[0].Rows.Count;
                //    int m = x + dsp4.Tables[0].Rows.Count;
                //    int n = 0;
                //    for (int l = x; l < m; l++)
                //    {
                //        DataRow dynamicRow2 = dtp4.NewRow();
                //        dtp4.Rows.Add(dynamicRow2);
                //        dtp4.Rows[l]["CarId"] = Convert.ToInt32(dsp4.Tables[0].Rows[n]["Carid"]);
                //        dtp4.Rows[l]["QcPend#"] = dsp4.Tables[0].Rows[n]["QcPend"];
                //        n++;
                //    }
                //}
                //for (int p = 0; p < dtp1.Rows.Count; p++)
                //{
                //    for (int q = 0; q < dtp2.Rows.Count; q++)
                //    {
                //        if (dtp1.Rows[p]["Carid"].ToString() == dtp2.Rows[q]["Carid"].ToString() )
                //        {
                //            dtp1.Rows[p]["UrlPend#"] = dtp2.Rows[q]["UrlPend#"];
                //        }
                //    }
                //}
                //for (int p = 0; p < dtp1.Rows.Count; p++)
                //{
                //    for (int q = 0; q < dtp4.Rows.Count; q++)
                //    {
                //        if (dtp1.Rows[p]["Carid"].ToString() == dtp4.Rows[q]["Carid"].ToString())
                //        {
                //            dtp1.Rows[p]["QcPend#"] = dtp4.Rows[q]["QcPend#"];
                //        }
                //    }
                //}
                ////  ----------------
                //if (dsp3.Tables[0].Rows.Count <= dsp1.Tables[0].Rows.Count)
                //{
                //    int j = dsp1.Tables[0].Rows.Count - dsp3.Tables[0].Rows.Count;
                //    for (int k = 0; k < j; k++)
                //    {
                //        DataRow dynamicRow3 = dtp3.NewRow();
                //        dtp3.Rows.Add(dynamicRow3);
                //        dtp3.Rows[k]["CarId"] = 0;
                //        dtp3.Rows[k]["#tkts"] = 0;
                //    }
                //}
                //if (dsp3.Tables[0].Rows.Count < dsp1.Tables[0].Rows.Count)
                //{
                //    int x = dsp1.Tables[0].Rows.Count - dsp3.Tables[0].Rows.Count;
                //    int m = x + dsp3.Tables[0].Rows.Count;
                //    int n = 0;
                //    for (int l = x; l < m; l++)
                //    {
                //        DataRow dynamicRow3 = dtp3.NewRow();
                //        dtp3.Rows.Add(dynamicRow3);
                //        dtp3.Rows[l]["CarId"] = Convert.ToInt32(dsp3.Tables[0].Rows[n]["Carid"]);
                //        dtp3.Rows[l]["#tkts"] = dsp3.Tables[0].Rows[n]["#tkts"];
                //        n++;
                //    }
                //}
                //for (int p = 0; p < dtp1.Rows.Count; p++)
                //{
                //    for (int q = 0; q < dtp3.Rows.Count; q++)
                //    {
                //        if (dtp1.Rows[p]["Carid"].ToString() == dtp3.Rows[q]["Carid"].ToString())
                //        {
                //            dtp1.Rows[p]["RelTkts#"] = dtp3.Rows[q]["#tkts"];
                //        }
                //    }
                //}
                //dataGridView3.DataSource = dtp1;
                //dataGridView3.Columns[4].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                //dataGridView3.Columns[7].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                //dataGridView3.Columns[8].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                //dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //int t = dataGridView3.Rows.Count;
                //for (int i = t; i <= 28; i++)
                //{
                //    dtp1.Rows.Add();
                //}
                //DataGridViewColumn columnp0 = dataGridView3.Columns[0];
                //columnp0.Width = 65;
                //DataGridViewColumn columnp1 = dataGridView3.Columns[1];
                //columnp1.Width = 85;
                //DataGridViewColumn columnp2 = dataGridView3.Columns[2];
                //columnp2.Width = 67;
                //DataGridViewColumn columnp3 = dataGridView3.Columns[3];
                //columnp3.Width = 85;
                //DataGridViewColumn columnp6 = dataGridView3.Columns[6];
                //columnp6.Width = 85;
                //DataGridViewColumn columnp5 = dataGridView3.Columns[5];
                //columnp5.Width = 220;
                //DataGridViewColumn columnp7 = dataGridView3.Columns[7];
                //columnp7.Width = 75;
                //DataGridViewColumn columnp8 = dataGridView3.Columns[8];
                //columnp8.Width = 79;
                //string fcarid = dataGridView3.Rows[0].Cells[0].Value.ToString();
                //DataSet dsfcarid = new DataSet();
                //dsfcarid = objSubmitionDetailsBL.MultigetPendingSites(fcarid);
                //label43.Text = "CarId: " + fcarid.ToString();
                //dataGridView4.DataSource = dsfcarid.Tables[0];
                //DataGridViewColumn cldtg1 = dataGridView4.Columns[0];
                //cldtg1.Width = 145;
                //DataGridViewColumn cldtg2 = dataGridView4.Columns[1];
                //cldtg2.Width = 125;
                //dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dataGridView4.ClearSelection();
                //dataGridView4.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
                //dataGridView4.Columns[1].DefaultCellStyle.ForeColor = Color.Red;
                //dataGridView4.Columns[2].DefaultCellStyle.ForeColor = Color.Red;
                //this.dataGridView4.Columns[1].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                //this.dataGridView4.Columns[2].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                //this.dataGridView4.Columns["UrlId"].Visible = false;
                //this.dataGridView4.Columns["CarId"].Visible = false;
                //this.dataGridView4.Columns["URL"].Visible = false;
                //this.dataGridView4.Columns["URLSID"].Visible = false;
                //this.dataGridView4.Columns["Siteid"].Visible = false;
                //this.dataGridView4.Columns["UrlPostDate"].Visible = false;
                //Cursor.Current = Cursors.Default;
                // this.Opacity =100;
                #endregion
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                //DataGridViewColumn cldtg1 = dataGridView4.Columns[0];
                //cldtg1.Width = 145;
                //DataGridViewColumn cldtg2 = dataGridView4.Columns[1];
                //cldtg2.Width = 125;
                //DataGridViewColumn cldtg3 = dataGridView4.Columns[2];
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                this.ActiveControl = textBox3;
                textBox3.Focus();
            }
            else if (tabControl1.SelectedIndex == 5)
            {
            }
            panel1.Visible = false;
            if (carid == "")
            {
                if (label10.Text == "label10")
                {
                    if (tabControl1.SelectedIndex == 4)
                    {
                        //PromtCarId Pobj = new PromtCarId();
                        //textBox4.Text = Pobj.ShowCarDialog("Enter CarId", "Enter CarId");
                        Cursor.Current = Cursors.WaitCursor;
                        lblimages.Visible = false;
                        panel1.Visible = true;
                        textBox3.Focus();
                        //  pnlpostentercarid.Visible = true;
                        pnlpostcardata.Visible = false;
                        pnlpostnotes.Visible = false;
                        pnlposttkt.Visible = false;
                        dgvpostforpostedcarid.Visible = false;
                        pnlpoststeps.Visible = false;
                        pnlpostbuttons.Visible = false;
                        pnlpostbrowser.Visible = false;
                        // pnlpostpics.Visible = false;
                        if (frmcarid != "")
                        {
                            pnlpostcardata.Visible = true;
                            pnlpostnotes.Visible = true;
                            pnlposttkt.Visible = true;
                            dgvpostforpostedcarid.Visible = false;
                            pnlpoststeps.Visible = true;
                            pnlpostbuttons.Visible = true;
                            pnlpostbrowser.Visible = true;
                            // pnlpostpics.Visible = true;
                        }
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {                }
            }
            else
            {
                pnlpostcardata.Visible = true;
                pnlpostnotes.Visible = true;
                pnlposttkt.Visible = true;
                dgvpostforpostedcarid.Visible = true;
                pnlpoststeps.Visible = true;
                pnlpostbuttons.Visible = true;
                pnlpostbrowser.Visible = true;
                // pnlpostpics.Visible = true;
            }
        }        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globaltxtemail.txtemail = comboBox2.Text;
            Globalpwd.pwd = textBox2.Text;

            if (comboBox1.Text != "System.Data.DataRowView")
            {
                if (comboBox1.Text != "")
                {
                    #region old
                    //DataSet website = objSubmitionDetailsBL.MultiGetSiteId(comboBox1.Text);
                    //if (website.Tables[0].Rows.Count > 0)
                    //{
                    //    string MultiGetSiteId = website.Tables[0].Rows[0]["SmrtzSiteId"].ToString();
                    //    websiteId = Convert.ToInt32(MultiGetSiteId);
                    //}
                    //  int carid=Convert.ToInt32(label10.Text);

                    //  objSubmitionDetailsBL.MultiSiteTransation(comboBox1.Text, websiteId, carid);
                    #endregion
                    for (int Loop = 100; Loop >= 88; Loop -= 5)
                    {
                        // pnlpostcardata.Visible = false;
                        circularProgressControl2.Start();
                        panel2.Visible = true;
                        // this.Opacity = Loop / 95.0;
                        // this.pnlpostcardata = Loop / 95.0;
                        circularProgressControl2.Visible = true;
                        circularProgressControl2.BringToFront();
                        this.Refresh();
                    }
                }
            }
            Cursor.Current = Cursors.WaitCursor;
            // Main objm = new Main();
            // objm.Opacity = .5;

            DataSet dssemail = new DataSet();
            dssemail = objSubmitionDetailsBL.MultiGetEmailByCarid(label10.Text);
            if (dssemail.Tables.Count > 0)
            {
                if (dssemail.Tables[0].Rows.Count > 0)
                {
                    comboBox2.DataSource = dssemail.Tables[0];
                    comboBox2.DisplayMember = dssemail.Tables[0].Columns["EmailId"].ToString();
                    textBox2.Text = dssemail.Tables[0].Rows[0]["Password"].ToString();
                }
            }
            //label19.Visible = true;
            //label20.Visible = true;
            //label21.Visible = true;
            webBrowser1.Visible = true;
            pnlpoststeps.Visible = true;
            pnlpostnotes.Visible = true;
            pnlpostbuttons.Visible = true;
            button2.Visible = true;
            comboBox2.Visible = true;
            button5.Visible = true;
            button7.Visible = true;
            button2.Visible = true;
            btnpostsubmit.Visible = false;
            btnpostupload.Visible = false;
            btnuploadtolive.Visible = false;
            button2.Enabled = true;
            // comboBox2.Visible = true;
            textBox2.Visible = true;
            lblemail.Visible = true;
            label25.Visible = true;
            label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Regular);
            label28.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Regular);
            label29.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Regular);
            label31.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Regular);
            label32.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Regular);
            label27.ForeColor = System.Drawing.Color.Black;
            label28.ForeColor = System.Drawing.Color.Black;
            label29.ForeColor = System.Drawing.Color.Black;
            label30.ForeColor = System.Drawing.Color.Black;
            label31.ForeColor = System.Drawing.Color.Black;
            label32.ForeColor = System.Drawing.Color.Black;
            label27.Text = "";
            label28.Text = "";
            label29.Text = "";
            label31.Text = "";
           label32.Text = "";
            if (label10.Text != "label10")
            {
                if (comboBox1.Text != "System.Data.DataRowView")
                {
                    if (comboBox1.Text == "CarPosts")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        label28.Text = "Note : Click browse button manually and select pic";
                        label29.Text = "Note : After selecting the pic click Upload and done button";
                        label31.Text = "2.Click submit (To Submit in the site)";
                        label32.Text = "3.Click Upload to Live Button(To upload in liveDB)";
                        webBrowser1.Navigate("http://www.carposts.com/");
                        Website = "CarPosts";
                        //int siteid = 16;
                        //DataSet sitelist=new DataSet();
                        //sitelist = objSubmitionDetailsBL.multibySiteid(siteid);
                    }
                    // }
                    else if (comboBox1.Text == "Clazorg")
                    {
                        clz = 0;
                        clz++;

                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to Upload car details) ";
                        label28.Text = "Note:Need to UPload Image Manually";
                        label29.Text = "2.Click Submit (to post Ad)";
                        label31.Text = "3.Click Upload to Live Button (to upload in live)";
                        webBrowser1.Navigate("http://claz.org/classifieds/post");
                        Website = "clazorg";
                    }
                    else if (comboBox1.Text == "JustgoodCars")
                    {
                        circularProgressControl2.Stop();
                        panel2.Visible = false;
                        circularProgressControl2.Visible = false;
                        MessageBox.Show("This Site under maintance.Please select another Site.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #region old
                        //label30.Visible = true;
                        //label27.Visible = true;
                        //label28.Visible = true;
                        //label29.Visible = true;
                        //label31.Visible = true;
                        //label30.Text = "Steps For " + comboBox1.Text;
                        //f = 0;
                        //ic = 0;

                        //label27.Text = "1.Click Start button (to upload the data)";
                        //label28.Text = "Note : Click Add more files button Manually.";
                        //label29.Text = "2.Click submit (To  submit the picture)";
                        //label31.Text = "3.Mark it as published (To upload in live DB)";

                        //webBrowser1.Navigate("http://www.justgoodcars.com/sign-in.php");

                        //Website = "JustgoodCars";
                        #endregion
                   }
                    else if (comboBox1.Text == "usadsciti")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to Upload car details) ";
                        // label28.Text = "Note:Need to Enter Description";
                        label28.Text = "Note:Enter Validation code manually";
                        label29.Text = "2.Click Submit (to post Ad)";
                        label31.Text = "3.Click Upload to Live Button (to upload in live)";
                        webBrowser1.Navigate("http://www.usadsciti.com/publish-a-new-ad.htm");
                        Website = "Usadsciti";
                    }
                    else if (comboBox1.Text == "UsNetads")
                    {
                        //circularProgressControl2.Stop();
                        //panel2.Visible = false;
                        //circularProgressControl2.Visible = false;
                        //MessageBox.Show("This Site under maintance.Please select another Site.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        webBrowser1.Refresh();
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to Upload car details) ";
                        label28.Text = "Note:Need to give validation code";
                        label29.Text = "2.Click Submit (to post Ad)";
                        label31.Text = "3.Click Upload to Live Button (to upload to live)";
                        //  webBrowser1.Navigate("http://www.usnetads.com/");
                        webBrowser1.Navigate("http://www.usnetads.com");
                        Website = "UsNetads";
                    }
                    else if (comboBox1.Text == "kugli")
                    {
                        circularProgressControl2.Stop();
                        panel2.Visible = false;
                        circularProgressControl2.Visible = false;
                        MessageBox.Show("This Site under maintance.Please select another Site.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Website = " kugli";
                        //webBrowser1.Navigate("http://www.kugli.com/business/def/post-edit-classified-ad/catid/2/");
                    }
                    else if (comboBox1.Text == "jeanza")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button(to upload the data)";
                        label28.Text = "Note : Enter Verification code";
                        label29.Text = "2.Click submit (To Submit in the site)";
                        label31.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        Website = "jeanza";
                        webBrowser1.Navigate("http://www.jeanza.com/publish-a-new-ad.htm");
                    }
                    else if (comboBox1.Text == "classifiedsvalley")
                    {
                        cvy = 0;
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Chech For any errors in registration form and \n click submit";
                        label28.Text = "2.Paste Confirmation Link You got to email \n in searchbar and click Go Button";
                        //////label28.Text = "Note : Enter Security code Manually";
                        //////label29.Text = "2.Click submit (To Submit in the site)";
                        //////label31.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        //label32.Text = "3.Mark it as published (To upload in liveDB)";
                        Website = "classifiedsvalley";
                        webBrowser1.Navigate("http://www.classifiedsvalley.com/");

                    }

                    else if (comboBox1.Text == "classifiedsciti")
                    {
                        tabControl1.Enabled = false;
                        comboBox1.Enabled = true;
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        label28.Text = "Note :Enter Validation code Manually ";
                        label29.Text = "2.Click submit (To Submit in the site)";
                        label31.Text = "3.Click Upload to Live Button(To upload in liveDB)";
                        // label32.Text = "3.Mark it as published (To upload in liveDB)";
                        Website = "classifiedsciti";
                        webBrowser1.Navigate("http://www.classifiedsciti.com/publish-a-new-ad.htm");
                    }
                    else if (comboBox1.Text == "usa.motoseller.com")
                    {
                        circularProgressControl2.Stop();
                        panel2.Visible = false;
                        circularProgressControl2.Visible = false;
                        MessageBox.Show("This Site under maintance.Please select another Site.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //label30.Visible = true;
                        //label27.Visible = true;
                        //label28.Visible = true;
                        //label29.Visible = true;
                        ////label31.Visible = true;
                        ////label32.Visible = true;
                       //label30.Text = "Steps For " + comboBox1.Text;
                        //label27.Text = "1.Click Start button (to upload the data)";
                        //label28.Text = "2.Click submit (To Submit in the site)";
                        //label29.Text = "3.Mark it as published (To upload in liveDB)";
                        ////label31.Text = 
                        ////label32.Text = 
                        //Website = "usa.motoseller.com";
                        //webBrowser1.Navigate("http://usa.motoseller.com/c/sys.php?a=10&amp;c=a*is*1");
                    }
                    else if (comboBox1.Text == "American-classifieds.net")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;

                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        label28.Text = "Note : Select  City manually";
                        label29.Text = "Note : Enter Verification code manually";
                        label31.Text = "2.Click submit (To Submit in the site)";
                        label32.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        Website = "americanclassifieds";
                        webBrowser1.Navigate("http://www.american-classifieds.net/");

                    }
                    else if (comboBox1.Text == "Classifiedsforfree")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;


                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "Note: Click Register Button manually";
                        label28.Text = "Note :Click Post ad button manually ";
                        label29.Text = "2.Click submit (To Submit in the site)";
                        label31.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        Website = "classifiedsforfree";
                        webBrowser1.Navigate("http://www.classifiedsforfree.com/");
                        cff = 0;
                        cfreeimg = 0;
                    }
                    else if (comboBox1.Text == "Epage" || comboBox1.Text == "www.epage.com")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        // label28.Text = "Note : Need to enter price manually";
                        label28.Text = "2.Click submit (To Submit in the site)";
                        label29.Text = "Note:Click link before clicking upload button.";
                        label31.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        // label32.Text = "";
                        Website = "epage";
                        // webBrowser1.Navigate("http://epage.com/js/post/c0/");
                       webBrowser1.Navigate("http://epage.com/js/post/c0/");
                        //epg1 = 0;
                        //epg = 0;
                        //subepg = 0;
                        //epglst = 0;
                       epagei = 0;
                       epagej = 0;
                    }
                    else if (comboBox1.Text == "highlandclassifieds")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        // label28.Text = "Note : Need to enter price manually";
                        label28.Text = "2.Click submit (To Submit in the site)";
                        label29.Text = "Note:Click link before clicking upload button.";
                        label31.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        // label32.Text = "";
                        Website = "highlandclassifieds";
                        webBrowser1.Navigate("http://ww1.highlandclassifieds.com/js/csp?csp=45757");
                        HLepg1 = 0;
                        HLepg = 0;
                        HLsubepg = 0;
                        HLepglst = 0;
                        hgcl = 0;
                    }
                    else if (comboBox1.Text == "classifiededition")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        clsfd = 0;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        label28.Text = "Note : Need to select location manually";
                        label29.Text = "Note : Need to enter verification code manually";
                        label31.Text = "2.Click submit (To Submit in the site)";
                        label32.Text = "3.Click Upload to Live Button(To upload in liveDB)";
                        Website = "classifiededition";
                        webBrowser1.Navigate("http://www.classifiededition.com/");
                        btnpostupload.Enabled = true;
                    }
                    else if (comboBox1.Text == "autoii")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;

                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        label28.Text = "Note : Click browse button manually and select pic";
                        label29.Text = "Note : After selecting the pic click Upload and done button";
                        label31.Text = "2.Click submit (To Submit in the site)";
                        label32.Text = "3.Click Upload to Live Button(To upload in liveDB)";
                        Website = "www.autoii.com";
                        //webBrowser1.Navigate("auto/AutoEdit.php?SaveAuto=AddNew&Type=For%20Sale");

                        webBrowser1.Navigate("http://www.autoii.com/auto/index2.html");
                    }

                    else if (comboBox1.Text == "www.postfreeadshere.com")
                    {

                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        Website = "www.postfreeadshere.com";
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start Button (to Upload car details) ";
                        label28.Text = "Note:Need to Enter Description";
                        label29.Text = "Note:Enter Validation code manually";
                        label31.Text = "2.Click Submit (to post Ad)";
                        label32.Text = "3.Click Upload to Live Button(to upload in live)";
                        webBrowser1.Navigate("http://www.postfreeadshere.com/publish-a-new-ad.htm");
                    }
                    else if (comboBox1.Text == "cathaylist")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        //label32.Visible = true;
                        Website = "www.cathaylist.comm";

                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Select City Manually ";
                        label28.Text = "Note : Enter verification code manually";
                        label29.Text = "2.Click submit (To Submit in the site)";
                        label31.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        //label32.Text = "3.Mark it as published (To upload in liveDB)";
                        webBrowser1.Navigate("http://www.cathaylist.com/?view=selectcity&targetview=post&cityid=0&lang=en");
                    }
                    else if (comboBox1.Text == "adsciti")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        //label32.Visible = true;

                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button(to Upload car details) ";
                        // label28.Text = "Note:Need to Enter Description";
                        label28.Text = "Note:Enter Validation code manually";
                        label29.Text = "2.Click Submit (to post Ad)";
                        label31.Text = "3.Click Upload to Live Button(to upload in live)";
                        webBrowser1.Navigate("http://www.adsciti.com/publish-a-new-ad.htm");
                        Website = "www.adsciti.com";
                    }
                    else if (comboBox1.Text == "adsriver")
                    {
                        Globaltxtemail.txtemail = comboBox2.Text;
                        Globalpwd.pwd = textBox2.Text;
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        //  label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "";// "1.Click Start button (to upload the data)";
                        //label28.Text = "Note : Click browse button manually and select pic";
                        label28.Text = "Note : Need to enter verification code manually";
                        label29.Text = "1.Click submit (To Submit in the site)";
                        label31.Text = "2.Click Upload to Live Button(To upload in liveDB)";
                        webBrowser1.Navigate("http://www.adsriver.com/");
                        Website = "adsriver";
                    }
                    else if (comboBox1.Text == "anunico")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        label28.Text = "Note : Need select location manually";
                        // label29.Text = "Note : Need to enter verification code manually";
                        label29.Text = "2.Click submit (To Submit in the site)";
                        label31.Text = "3.Click Upload to Live Button(To upload in liveDB)";
                        webBrowser1.Navigate("http://www.anunico.us/post_free_ads_in_united_states.html");
                        Website = "anunico";
                    }
                    else if (comboBox1.Text == "classifieds4me")
                    {
                        c4cy = 0;
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "Note :Select City and click Continue";
                        label28.Text = "1.Click Start button (to upload the data)";
                        label29.Text = "Note : Need to enter validation code before submit";
                        //label29.Text = "Note : After selecting the pic click Upload and done button";
                        label31.Text = "2.Click submit (To Submit in the site)";
                        label32.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        c4mcty = 0;
                        webBrowser1.Navigate("http://www.classifieds4me.com");
                        Website = "classifieds4me";
                    }
                    else if (comboBox1.Text == "myadmonster")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        // label28.Text = "Note:Click continue button";
                        label28.Text = "Note:Enter Capcha code before clicking Submit";
                        //label29.Text = "Note : After selecting the pic click Upload and done button";
                        label29.Text = "2.Click submit (To Submit in the site)";
                        label31.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        c4mcty = 0;
                        webBrowser1.Navigate("http://www.myadmonster.com/free-ads/postfreead.php");
                        Website = "myadmonster";
                    }

                    else if (comboBox1.Text == "99localsearch")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        // label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        // label28.Text = "Note:Click continue button";
                        label29.Text = "Note:Enter Capcha code before clicking Submit";
                        //label29.Text = "Note : After selecting the pic click Upload and done button";
                        label31.Text = "2.Click submit (To Submit in the site)";
                        label32.Text = "3.Click Upload to Live Button(To upload in liveDB)";
                        c4mcty = 0;
                        webBrowser1.Navigate("http://www.99localsearch.com/freeclassified.aspx");
                        Website = "99localsearch";

                    }
                    else if (comboBox1.Text == "freead1.net")
                    {
                        fread = 0;
                        webBrowser1.Navigate("http://freead1.net/");
                        Website = "freead1.net";
                    }
                    else if (comboBox1.Text == "classifiedads")
                    {
                        cads = 0;
                        Globaltxtemail.txtemail = comboBox2.Text;
                        Globalpwd.pwd = textBox2.Text;
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "Note:Select city before clicking submit button";
                        // label28.Text = "Note:Click continue button";
                        label28.Text = "Note:Enter validation code before clicking submit button";
                        label29.Text = "1.Click submit (To Submit in the site)";
                        label31.Text = "2.Click Upload to Live Button(To upload in liveDB)";
                        // label31.Text = "3.Click Upload to Live Button(To upload in liveDB)";
                        webBrowser1.Navigate("http://www.classifiedads.com/");
                        Website = "classifiedads";
                    }
                    else if (comboBox1.Text == "facebook")
                    {
                        webBrowser1.Navigate("https://www.facebook.com/login.php?next=https%3A%2F%2Fwww.facebook.com%2Fmessages%2F");
                        Website = "facebook";
                    }
                    else if (comboBox1.Text == "pinterest")
                    {
                        pnt = 0;
                        webBrowser1.Navigate("https://www.pinterest.com/");
                    }
                    else if (comboBox1.Text == "hot9ads")
                    {
                        webBrowser1.Navigate("www.hot9ads.com");
                        Website = "hot9ads";
                        ht9 = 0;
                    }
                    else if (comboBox1.Text == "75vn")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "Note : Click the button Go To Next Step..>>(to upload the data)";
                        label28.Text = "Note : Click browse button manually and select pic";
                        label29.Text = "Note : After selecting the picture click Upload";
                        label31.Text = "Note:Click the posted link";
                        label32.Text = "1.Click Upload to Live Button(To upload in liveDB)";
                        webBrowser1.Navigate("http://www.75vn.com/");
                        Website = "75vn";
                    }
                    else if (comboBox1.Text == "adpost us")
                    {
                        adp = 0;
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "Note : Click the button Go To Next Step..>>(to upload the data)";
                        label28.Text = "Note : Click browse button manually and select pic";
                        label29.Text = "Note : After selecting the picture click Upload";
                        label31.Text = "Note:Click the posted link";
                        label32.Text = "1.Click Upload to Live Button(To upload in liveDB)";
                        webBrowser1.Navigate("http://www.adpost.com/");
                        Website = "adpost us";
                    }
                    else if (comboBox1.Text == "webcosmo")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        label28.Text = "Note : Click Continue Manually"+System.Environment.NewLine+"Note : Click on Continue after uploading Image";

                        label29.Text = "Note : Enter Verification Code Manually before clicking Submit Button";
                        label32.Text = "Click Submit";
                        label31.Text = "3.Click Upload to Live Button(To upload in liveDB)";
                        //label32.Text = 
                        webBrowser1.Navigate("https://www.webcosmo.com/Post/Post.aspx");
                        Website = "webcosmo";
                    }
                    else if (comboBox1.Text == "tumblr")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        clsfd = 0;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Start button (to upload the data)";
                        label28.Text = "Note : Need to Upload Images Manually";
                        label29.Text = "Click Submit";
                        label31.Text = "";
                        label32.Text = "";
                        Website = "classifiededition";
                        webBrowser1.Navigate("http://www.tumblr.com/new/text");
                        btnpostupload.Enabled = true;
                    }
                    else if (comboBox1.Text == "cargurus")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true; 
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click Submit button (to submit data)";
                        label28.Text = "2.Click Upload To Live (To upload in liveDB) ";
                        label29.Text = "";
                        label31.Text = "";
                        label32.Text = "";
                        Website = "cargurus";
                        webBrowser1.Navigate("http://www.cargurus.com/");
                        
                    }
                    else if (comboBox1.Text == "soavo")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Enter Verification code and click Create";
                        label28.Text = "2.Paste the activation link in textbox provided and click go";
                        label28.Text = "3.Select Category and SubCategory Manually";
                        label29.Text = "4.Upload Images Manually \r\n Select City Manually";
                        label31.Text = "5.Click Submit To Post Ad";
                        label32.Text = "6.Click Upload to Live Button (To upload in liveDB)";
                        Website = "soavo";
                        webBrowser1.Navigate("http://www.soavo.com/user/register");
                    }
                    else if (comboBox1.Text == "web-free-ads" || comboBox1.Text == "webfreeads")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "CHANGE EMAIL ID TO OTHER THAN GLOBALTPV.COM \n LIKE REDIFF OR YAHOO MAIL";
                        label28.Text = "1.Enter Verification code and click Submit";
                        label29.Text = "2.Click Upload to Live Button (To upload in liveDB)";
                        label31.Text = "3.Check mail for activation link";
                        Website = "web-free-ads";
                        webBrowser1.Navigate("http://web-free-ads.com/index.php?view=post&cityid=1&lang=en");
                    }
                    else if (comboBox1.Text == "blackworld")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Enter Verification code and click Submit";
                        label28.Text = "";
                        label29.Text = "";
                        label31.Text = "2.Click Upload to Live Button (To upload in liveDB)";
                        Website = "web-free-ads";
                        webBrowser1.Navigate("http://classifieds.blackworld.com/");
                    }
                    else if (comboBox1.Text == "extraclassifieds")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Enter Captha and click on submit"+System.Environment.NewLine
                            +"Paste Activation Link in provided TextBox and Click On Go";
                        label28.Text = "Upload Images manually";
                        label29.Text = "Click on Submit To Post Data";
                        label31.Text = "2.Click Upload to Live Button (To upload in liveDB)";
                        Website = "extraclassifieds";
                        webBrowser1.Navigate("http://extraclassifieds.com/");
                    }
                    else if (comboBox1.Text == "meetpark")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        // label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Click On Post Ad manually in WebBrowser";
                        label28.Text = "2.Enter Verification code and click Submit";
                        label29.Text = "";
                        label31.Text = "3.Click Upload to Live Button (To upload in liveDB)";
                        Website = "meetpark";
                        webBrowser1.Navigate("http://www.meetpark.com/");
                    }
                    else if (comboBox1.Text == "webleeg")
                    {
                        label30.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;
                        label29.Visible = true;
                        label31.Visible = true;
                        label32.Visible = true;
                        label30.Text = "Steps For " + comboBox1.Text;
                        label27.Text = "1.Temporarily change email to rediff or yahoo you have created earlier with mailcreator app";
                        label28.Text = "2.Enter Verification code and click Create";
                        label28.Text = "3.Paste the activation link in textbox provided and click go";
                        label29.Text = "4.Upload Images Manually \r\n Select City Manually";
                        label31.Text = "5.Click Submit To Post Ad";
                        label32.Text = "6.Click Upload to Live Button (To upload in liveDB)";
                        Website = "soavo";
                        webBrowser1.Navigate("http://www.webleeg.com/register.php");
                    }
                }
                textBox2.Focus();
                Cursor.Current = Cursors.Default;
                // this.Opacity = 100;
            }
            //DataSet dssitename = new DataSet();
            //int tcarid = Convert.ToInt32(label10.Text);
            //dssitename = objSubmitionDetailsBL.MultiGetSiteNameTransation(tcarid);
            //comboBox1.DataSource = dssitename.Tables[0];
            //comboBox1.DisplayMember = dssitename.Tables[0].Columns["SiteName"].ToString();
            //comboBox1.ValueMember = dssitename.Tables[0].Columns["SmrtzSiteID"].ToString();
            textBox7.Focus();
        }
        private void btnpostupload_Click(object sender, EventArgs e)
        {
            textBox7.Focus();
            textBox2.Focus();
            if (comboBox2.Text != "")
            {
                try
                {
                   count = 0;
                    count++;
                    Cursor.Current = Cursors.WaitCursor;
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(label10.Text);
                    Globaltxtemail.txtemail = comboBox2.Text;
                    Globalpwd.pwd = textBox2.Text;
                    if (comboBox1.Text == "pinterest")
                    {
                        if (webBrowser1.Url.ToString() == "http://www.pinterest.com/vinayy5544/boards/" || webBrowser1.Url.ToString() == "http://www.pinterest.com/vinayy5544/boards/#")
                        {

                           
                                // GeneralFunction.LinkInvoke(webBrowser1, "Create a board");
                                // GeneralFunction.LinkInvokeCollectorCarsPic(webBrowser1);

                                //GeneralFunction.LinkInvokepintrest(webBrowser1, "BoardCreateRep Module");
                                

                                //com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                                //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                                //obUsedCarsInfo = objService.FindCarID(label10.Text);

                                IWebSites objClass = new Pintrest();

                                objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                                circularProgressControl2.Stop();
                                circularProgressControl2.Visible = false;
                                panel2.Visible = false;
                            //}

                        }
                    }
                    if (Website == "CarPosts")
                    {
                        IWebSites objClass = new CarPosts();
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        label27.ForeColor = System.Drawing.Color.Red;
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        Cursor.Current = Cursors.Default;
                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        btnpostupload.Enabled = false;
                    }
                    if (Website == "clazorg")
                    {
                        clz++;
                        clz1++;
                        Cursor.Current = Cursors.WaitCursor;
                        IWebSites objClass = new ClazOrg();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        Cursor.Current = Cursors.Default;
                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        btnpostupload.Enabled = false;
                    }
                    if (Website == "JustgoodCars")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        if (count == 1)
                        {
                            IWebSites objClass = new JustgoodCars();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            webBrowser1.Navigate("http://www.justgoodcars.com/members/advertise.php");
                        }
                        if (count == 1)
                        {
                            webBrowser1.Navigate("http://www.justgoodcars.com/members/advertise.php");
                            label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                            btnpostupload.Enabled = false;
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    if (Website == "Usadsciti")
                    {
                        // adsty++;
                        Cursor.Current = Cursors.WaitCursor;
                        IWebSites objClass = new Usadsciti();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        Cursor.Current = Cursors.Default;
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        label27.ForeColor = System.Drawing.Color.Red;
                        btnpostupload.Enabled = false;
                        btnpostsubmit.Enabled = true;
                        btnpostsubmit.Visible = true;
                    }
                    if (Website == "www.adsciti.com")
                    {
                        // adsty++;
                        Cursor.Current = Cursors.WaitCursor;
                        IWebSites objClass = new Usadsciti();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        Cursor.Current = Cursors.Default;
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        label27.ForeColor = System.Drawing.Color.Red;
                        btnpostupload.Enabled = false;
                        btnpostsubmit.Enabled = true;
                        btnpostsubmit.Visible = true;
                    }
                    else if (Website == "UsNetads")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        IWebSites objClass = new UsnetAds();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        Cursor.Current = Cursors.Default;
                        btnpostupload.Enabled = false;
                        btnpostsubmit.Enabled = true;
                       btnpostsubmit.Visible = true;
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        label27.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (Website == " kugli")
                    {
                        Kug = 0;
                        Kug++;
                        IWebSites objClass = new Kugli();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    }
                    else if (Website == "jeanza")
                    {
                        IWebSites objClass = new Jeanza();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        btnpostupload.Enabled = false;
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                    }
                    else if (Website == "classifiedsvalley")
                    {
                        circularProgressControl2.Start();
                        panel2.Visible = true;
                        circularProgressControl2.Visible = true;
                        IWebSites objClass = new classifiedsvalley();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        btnpostupload.Enabled = false;
                        label27.ForeColor = System.Drawing.Color.Red;
                    }
                   else if (Website == "classifiedsciti")
                    {
                        IWebSites objClass = new classifiedsciti();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        btnpostupload.Enabled = false;
                        btnpostsubmit.Enabled = true;
                        btnpostsubmit.Visible = true;
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        label27.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (Website == "usa.motoseller.com")
                    {
                        IWebSites objClass = new Motoseller();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        btnpostupload.Enabled = false;
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        motosl = 0;
                        circularProgressControl2.Start();
                        panel2.Visible = true;
                        circularProgressControl2.Visible = true;
                        label49.Visible = true;
                    }
                    else if (Website == "americanclassifieds")
                    {
                        IWebSites objClass = new AmericanClassifieds();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        btnpostupload.Enabled = false;
                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        label27.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (Website == "classifiedsforfree")
                    {
                        IWebSites objClass = new ClassifiedsForFree();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        btnpostupload.Enabled = false;
                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        label27.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (Website == "epage")
                    {
                        IWebSites objClass = new epage();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        btnpostupload.Enabled = false;
                        circularProgressControl2.Start();
                        circularProgressControl2.Visible = true;
                        panel2.Visible = true;
                    }
                    else if (Website == "highlandclassifieds")
                    {
                        //GeneralFunction.LinkInvoke(webBrowser1, "Cars and Trucks");
                        IWebSites objClass = new highlandclassifieds();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        btnpostupload.Enabled = false;
                        circularProgressControl2.Start();
                        circularProgressControl2.Visible = true;
                        panel2.Visible = true;
                    }
                    else if (Website == "classifiededition")
                    {
                        circularProgressControl2.Start();
                        panel2.Visible = true;
                        circularProgressControl2.Visible = true;
                        IWebSites objClass = new ClassifiedEditor();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        btnpostupload.Enabled = false;
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        label27.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (Website == "www.autoii.com")
                    {
                        IWebSites objClass = new Autoii();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        btnpostupload.Enabled = false;
                    }
                    else if (Website == "www.postfreeadshere.com")
                    {
                        IWebSites objClass = new PostFreeAdshere();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        btnpostupload.Enabled = false;
                        btnpostsubmit.Enabled = true;
                        btnpostsubmit.Visible = true;
                    }
                    else if (Website == " www.freeadlists.com")
                    {
                        IWebSites objClass = new FreeAddList();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                    }
                   else if (Website == "adsriver")
                    {
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        //GeneralFunction.LinkInvoke(webBrowser1, "Automotive");
                        Cursor.Current = Cursors.Default;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = true;
                        circularProgressControl2.Visible = true;
                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        btnpostupload.Enabled = false;
                    }
                    else if (Website == "anunico")
                    {
                        textBox7.Focus();
                        anupic = 0;
                        circularProgressControl2.Start();
                        panel2.Visible = true;
                        circularProgressControl2.Visible = true;
                        btnpostupload.Enabled = false;
                        IWebSites objClass = new anunico();
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        label27.ForeColor = System.Drawing.Color.Red;
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    }
                    else if (Website == "classifieds4me")
                    {
                        cls4me = 0;

                        //               circularProgressControl2.Start();
                        //               panel2.Visible = true;
                        //               circularProgressControl2.Visible = true;
                        //               IWebSites objClass = new classifieds4me();
                        //               label27.Font = new System.Drawing.Font("Verdana", 8.0f,
                        //System.Drawing.FontStyle.Bold);
                        //               objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);
                        string suburl = webBrowser1.Url.ToString();
                        if (suburl.Contains("-classified-ads-"))
                        {
                            string split = suburl.ToString();
                            int index1 = split.IndexOf(".com/");
                            int end1 = split.IndexOf("-classified");
                            string c4mCity = split.ToString().Substring(index1, end1 - index1);
                            c4mCity = c4mCity.Replace(".com/", "");
                            string split1 = suburl.ToString();
                            int index2 = split1.IndexOf("ads-");
                            int end2 = split.Length;
                            string c4mCityId = split.ToString().Substring(index2, end2 - index2);
                            c4mCityId = c4mCityId.Replace("/", "");
                            c4mCityId = c4mCityId.Replace("ads-", "");
                            if (webBrowser1.Url.ToString() == "http://www.classifieds4me.com/" + c4mCity + "-classified-ads-" + c4mCityId + "/")
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "Post a FREE Classified Ad");
                            }
                        }
                    }
                    else if (Website == "myadmonster")
                    {
                        myads = 0;
                        circularProgressControl2.Start();
                        circularProgressControl2.Visible = true;
                        panel2.Visible = true;
                        GeneralFunction.SetDropDownNameandValue(webBrowser1, "sel_action", "post_1");
                        GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, " Select And Continue ");
                    }
                    else if (Website == "99localsearch")
                    {
                        IWebSites objClass = new local99search();
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    }
                    else if (Website == "freead1.net")
                    {
                        IWebSites objClass = new freead1();
                        label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    }
                    else if (Website == "facebook")
                    {
                        GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Log In");
                    }
                    else if (Website == "adpost us")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "United States");
                    }
                    //           else if (Website == "classifiedads")
                    //           {
                    //               IWebSites objClass = new ClassifiedAdds();
                    //               label27.Font = new System.Drawing.Font("Verdana", 8.0f,
                    //System.Drawing.FontStyle.Bold);
                    //               objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);
                    //           }
                    else if (Website == "webcosmo")
                    {
                        // adsty++;
                        IWebSites objClass = new WebCosmo();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        GeneralFunction.ButtonClickInvoke(webBrowser1, "ctl00$cphContent$ibContinue");
                        Cursor.Current = Cursors.WaitCursor;
                        Cursor.Current = Cursors.Default;
                        //label27.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                        //label27.ForeColor = System.Drawing.Color.Red;
                        //btnpostupload.Enabled = false;
                        //btnpostsubmit.Enabled = true;
                        //btnpostsubmit.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Temporarly Server is not Connecting .Please try after some times", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Email text is empty;");
            }
            textBox7.Focus();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //btnuploadtolive.Visible = true;
            //btnuploadtolive.Enabled = true;
            Cursor.Current = Cursors.WaitCursor;
            int u = 0;
            if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            // if ((this.webBrowser1.ReadyState == WebBrowserReadyState.Complete) || (this.webBrowser1.ReadyState == WebBrowserReadyState.Interactive))
            {
                // for (int Loop = 100; Loop >= 5; Loop -= 10)
                //  {
                //  }
                int cscnt = 0;
                if (comboBox1.Text == "usadsciti")
                {
                    cscnt++;
                }
                if (comboBox1.Text == "www.adsciti.com")
                {
                    adccnt++;
                }
                
                if (comboBox1.Text == "CarPosts")
                {
                    #region CarPosts
                    if (webBrowser1.Url.ToString() == "http://www.carposts.com/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post Free Ad");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.carposts.com/AutoEdit.php?SaveAuto=AddNew&Type=For Sale")
                    {
                        int cpst = 0;
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            string InnerTxt = "If you are misusing our site than know that you have been logged.";
                            if (element.OuterText == InnerTxt)
                            {
                                cpst++;
                                this.Opacity = 100;
                                circularProgressControl2.Stop();
                                circularProgressControl2.Visible = false;
                                panel2.Visible = false;
                                this.Refresh();
                                MessageBox.Show("This Site is not allowing to post ad with your ip address.");
                            }
                        }
                        if (cpst == 0)
                        {
                            btnpostupload.Enabled = true;
                            btnpostupload.Visible = true;
                            this.Opacity = 100;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            this.Refresh();
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://www.carposts.com/AutoEdit.php")
                    {
                        if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {
                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                string InnerTxt = "Use Agreement / Terms Conditions";
                                if (element.OuterText == InnerTxt)
                                {
                                    btnpostsubmit.Enabled = false;
                                    label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                                    System.Drawing.FontStyle.Bold);
                                    label31.ForeColor = System.Drawing.Color.Red;
                                    btnuploadtolive.Enabled = true;
                                    btnuploadtolive.Visible = true;
                                }
                            }
                        }
                    }
                    #endregion
                }
                
                if (comboBox1.Text == "autoii")
                {
                    #region autoii
                    if (webBrowser1.Url.ToString() == "http://www.autoii.com/auto/index2.html")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.autoii.com/auto/AutoEdit.php?SaveAuto=AddNew&Type=For Sale")
                    {
                        int auti = 0;
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            string InnerTxt = "If you are misusing our site than know that you have been logged.";
                            if (element.OuterText == InnerTxt)
                            {
                                auti++;

                                this.Opacity = 100;

                                circularProgressControl2.Stop();
                                circularProgressControl2.Visible = false;
                                panel2.Visible = false;
                                this.Refresh();
                                MessageBox.Show("This Site is not allowing to post ad with your ip address.");
                            }
                        }

                        if (auti == 0)
                        {

                            btnpostupload.Enabled = true;
                            btnpostupload.Visible = true;

                            this.Opacity = 100;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            this.Refresh();
                        }

                    }
                    if (webBrowser1.Url.ToString() == "http://www.autoii.com/auto/AutoEdit.php")
                    {
                        if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {

                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                string InnerTxt = "Use Agreement / Terms Conditions";
                                if (element.OuterText == InnerTxt)
                                {
                                    btnpostsubmit.Enabled = false;
                                    label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                                    System.Drawing.FontStyle.Bold);
                                    btnuploadtolive.Enabled = true;
                                    btnuploadtolive.Visible = true;
                                }
                            }
                        }

                    }
                    #endregion
                }
                
                if (comboBox1.Text == "Clazorg")
                {
                    #region Claz
                    if (webBrowser1.Url.ToString() == "http://claz.org/classifieds/post")
                    {

                        if (clz == 1)
                        {
                            btnpostupload.Enabled = true;
                            btnpostupload.Visible = true;

                            this.Opacity = 100;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            this.Refresh();

                        }
                    }
                    string check = string.Empty;
                    if ((webBrowser1.Url.ToString() != "http://claz.org/classifieds/post") )
                    {
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            string InnerTxt = "Back";
                            if (element.OuterText == InnerTxt)
                            {
                                label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                                System.Drawing.FontStyle.Bold);
                                btnpostsubmit.Enabled = false;
                                btnuploadtolive.Visible = true;
                                btnuploadtolive.Enabled = true;
                                check = webBrowser1.Url.ToString();
                            }
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://claz.org/classifieds/save")
                    {
                        //if (webBrowser1.Url.ToString() == check)
                        //  {
                        btnuploadtolive.Enabled = false;
                        // }
                    }
                    #endregion
                }
                
                if (comboBox1.Text == "usadsciti")
                {
                    #region usadsciti
                    //circularProgressControl2.Start();
                    //pnlpostcardata.Visible = true;
                    //circularProgressControl2.Visible = true;
                    panel2.Visible = true;
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (webBrowser1.Url.ToString() == "http://www.usadsciti.com/publish-a-new-ad.htm")
                        {
                            if (cscnt == 1)
                            {
                                // if (adsty == 0)
                                // {
                                // {
                                foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                                {
                                    string InnerTxt = "TERMS OF SERVICE";
                                    if (element.OuterText == InnerTxt)
                                    {
                                        btnpostupload.Enabled = true;
                                        btnpostupload.Visible = true;
                                        this.Opacity = 100;
                                        circularProgressControl2.Stop();
                                        pnlpostcardata.Visible = true;
                                        circularProgressControl2.Visible = false;
                                        panel2.Visible = false;
                                        this.Refresh();
                                        cscnt++;
                                    }
                                }
                                //cscnt++;
                                // }

                            }
                        }

                        if (cscnt == 1)
                        {
                            //  string nk = webBrowser1.Url.ToString();
                            if (webBrowser1.Url.ToString() == "http://www.usadsciti.com/publish-a-new-ad.htm")
                            {



                                btnpostsubmit.Enabled = true;

                            }
                        }

                        if (webBrowser1.Url.ToString() != "http://www.usadsciti.com/publish-a-new-ad.htm")
                        {
                            int adc = 0;
                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                string InnerTxt = "TERMS OF SERVICE";
                                if (element.OuterText == InnerTxt)
                                {
                                    adc++;
                                }
                            }
                            if (adc >= 1)
                            { }
                            else
                            {
                                label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                         System.Drawing.FontStyle.Bold);
                                label29.ForeColor = System.Drawing.Color.Red;
                                btnpostsubmit.Enabled = false;
                                btnuploadtolive.Visible = true;
                                btnuploadtolive.Enabled = true;

                                circularProgressControl2.Stop();
                                pnlpostcardata.Visible = true;
                                label49.Visible = false;
                                panel2.Visible = false;
                                circularProgressControl2.Visible = false;

                                //}
                            }
                        }
                        #region old
                        //if (webBrowser1.Url.ToString() == "http://www.usadsciti.com/publish-a-new-ad.htm")
                        //{
                        //    if (asad == 1)
                        //    {

                        //        asad++;
                        //        circularProgressControl2.Start();
                        //        panel2.Visible = true;
                        //        circularProgressControl2.Visible = true;
                        //    }
                        //}

                        //if (webBrowser1.Url.ToString() != "http://www.usadsciti.com/publish-a-new-ad.htm")
                        //{
                        //    foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        //    {
                        //        string InnerTxt = "Report bad use or Spam";
                        //        if (element.OuterText == InnerTxt)
                        //        {
                        //            btnuploadtolive.Enabled = true;
                        //            btnuploadtolive.Visible = true;
                        //        }
                        //    }
                        //}
                        #endregion
                    }
                    #endregion
                }
               
                if (comboBox1.Text == "adsciti")
                {
                    #region adsciti
                    if (webBrowser1.Url.ToString() == "http://www.adsciti.com/publish-a-new-ad.htm")
                    {
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            string InnerTxt = "TERMS OF SERVICE";
                            if (element.OuterText == InnerTxt)
                            {
                                btnpostupload.Enabled = true;
                                btnpostupload.Visible = true;

                                this.Opacity = 100;
                                circularProgressControl2.Stop();
                                circularProgressControl2.Visible = false;
                                panel2.Visible = false;
                                this.Refresh();
                            }
                        }

                    }

                    if (webBrowser1.Url.ToString() != "http://www.adsciti.com/publish-a-new-ad.htm")
                    {
                        int adc = 0;
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            string InnerTxt = "TERMS OF SERVICE";
                            if (element.OuterText == InnerTxt)
                            {
                                adc++;
                            }
                        }
                        if (adc >= 1)
                        {
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            btnpostsubmit.Enabled = true;
                        }
                        else
                        {
                            label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                    System.Drawing.FontStyle.Bold);
                            label31.ForeColor = System.Drawing.Color.Red;
                            btnpostsubmit.Enabled = false;
                            btnuploadtolive.Visible = true;
                            btnuploadtolive.Enabled = true;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                        }
                    }
                    #endregion
                }
              
                if (comboBox1.Text == "UsNetads")
                {
                    #region usnetads
                    if (webBrowser1.Url.ToString() == "http://www.usnetads.com/")
                    {
                        this.Opacity = 100;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        this.Refresh();
                        GeneralFunction.LinkInvoke(webBrowser1, "Click Here to Post Ads");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.usnetads.com/post/post-free-ads.php")
                    {

                        btnpostupload.Enabled = true;
                        btnpostupload.Visible = true;
                        //btnpostupload.Enabled = true;
                        //btnpostupload.Visible = true;
                        //this.Opacity = 100;
                        //circularProgressControl2.Stop();
                        //circularProgressControl2.Visible = false;
                        //panel2.Visible = false;
                        //this.Refresh();
                    }
                    if (webBrowser1.Url.ToString() == "http://www.usnetads.com/post/post-free-ads-op.php")
                    {
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("p"))
                        {
                            string InnerTxt = "Congratulations! You have posted the advertisement successfully.";
                            if (element.OuterText.Contains(InnerTxt))
                            {

                                //GeneralFunction.LinkInvoke(webBrowser1, InnerTxt8);
                                label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                        System.Drawing.FontStyle.Bold);
                                btnpostsubmit.Enabled = false;
                                btnuploadtolive.Enabled = true;
                                btnuploadtolive.Visible = true;

                                //com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                                //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                                //obUsedCarsInfo = objService.FindCarID(label10.Text);

                                //string InnerTxt8 = obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString();
                                //foreach (HtmlElement element1 in webBrowser1.Document.GetElementsByTagName("a"))
                                //{
                                //    if (element1.InnerText.Contains(InnerTxt8))
                                //   {


                                //   }

                                //}


                            }
                            else
                            {

                                //MessageBox.Show("Entered invalid data.Please check the data again");
                                //webBrowser1.Navigate("http://www.usnetads.com/post/post-free-ads.php");
                                // btnpostupload.Enabled = true;
                                // btnpostupload.Visible = true;
                            }
                        }


                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("div"))
                        {

                            string InnerTxt = "Failed to post your advertisement because of following error:";
                            string outer = element.OuterText;
                            //if (outer.Contains(InnerTxt))
                            if (outer.Contains(InnerTxt))
                            {
                                if (msg == 0)
                                {
                                    msg++;
                                    MessageBox.Show("Invalid Data Entered.Please Click start button Again and check the data.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);


                                    webBrowser1.Navigate("http://www.usnetads.com/post/post-free-ads.php");
                                    btnpostupload.Enabled = true;
                                    btnpostupload.Visible = true;
                                    btnpostsubmit.Enabled = false;

                                }

                            }
                        }
                    }

                    //if (webBrowser1.Url.ToString() == "http://www.usnetads.com/post/post-free-ads-op.php")
                    //{
                    //  //  foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName(""))
                    //   // {


                    //         //if (element.OuterText.Contains(InnerTxt))
                    //         //{
                    //         //}
                    //   // }
                    //}
                    #endregion
                }

                else if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/sign-in.php")
                {
                    btnpostupload.Enabled = true;
                    btnpostupload.Visible = true;
                    this.Opacity = 100;
                    circularProgressControl2.Stop();
                    circularProgressControl2.Visible = false;
                    panel2.Visible = false;
                    this.Refresh();
                }
                else if (webBrowser1.Url.ToString() == data5)
                {
                    button4.Visible = true;
                    button4.Enabled = true;
                    button6.Visible = true;
                    button6.Enabled = true;
                }
                //---------------justgoodcars Start-------------
                if (comboBox1.Text == "JustgoodCars")
                {
                    #region justgoodcars
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(label10.Text);
                    if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/members_index.php")
                    {
                        if (comboBox1.Text == "JustgoodCars")
                        {
                            if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/members_index.php")
                            {
                                //     foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                                //   {
                                //         linkItem = htmlElement.GetAttribute("HREF").ToString();
                                //    }
                                //// }
                                // }
                                //   else
                                //    {
                                GeneralFunction.HfClickInvoke(webBrowser1, "/images/btn-logout.gif");
                                webBrowser1.Navigate("http://www.justgoodcars.com/sign-in.php");
                                comboBox1.Text = "";
                                webBrowser1.Navigate("");
                            }
                            //}
                        }
                    }
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {

                        //for make and model
                        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise.php")
                        {
                            IWebSites objClass = new JustgoodCars();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        }
                    }
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {

                        //for car details
                        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise1.php")
                        {
                            IWebSites objClass = new JustgoodCars();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                            GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");

                        }
                    }
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        //to click image upload button
                        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise_preview.php")
                        {
                            if (ic == 0)
                            {
                                IWebSites objClass = new JustgoodCars();
                                objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            }

                        }
                    }
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise_preview.php")
                        {
                            //to click free button
                            if (ic == 2)
                            { }
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/adverts_edit_image-upload.php")
                    {
                        //to click try upload button  
                        if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Try this Simple Upload Tool");
                        }
                    }
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        //to click browsebutton  image 
                        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/adverts_edit_image.php")
                        {
                            ic++;
                            if (ic == 1)
                            {
                                GeneralFunction.FileUploadInvoke(webBrowser1, "userfile");
                                btnpostsubmit.Enabled = true;
                                btnpostsubmit.Visible = true;
                            }
                            //to click back button after uploading image
                            if (ic == 2)
                            {
                                label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                                System.Drawing.FontStyle.Bold);
                                btnpostsubmit.Enabled = false;
                            }
                            if (ic == 2)
                            {
                                if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/adverts_edit_image.php")
                                {
                                    GeneralFunction.ButtonClickInvokeValue(webBrowser1, "< Back");
                                }
                            }
                        }
                    }
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise_preview.php")
                        {
                            if (ic == 2)
                            {
                                f++;
                                if (f == 1)
                                {
                                    GeneralFunction.ButtonClickInvokeValue(webBrowser1, "FREE >");//SubmitButton for GoLive justgoodcars
                                    webBrowser1.Navigate("http://www.justgoodcars.com/members/members_index.php");
                                    webBrowser1.Navigate("http://www.justgoodcars.com/members/adverts.php");
                                }
                            }
                        }
                    }

                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/adverts.php")
                        {

                            GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "View / Edit");
                            btnuploadtolive.Enabled = true;
                            btnuploadtolive.Visible = true;
                        }
                    }
                    if (webBrowser1.Url.ToString() == data5)
                    {
                    }
                    #region old
                    //if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    //{
                    //    if (ic == 3)
                    //    {
                    //        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise_preview.php")
                    //        {
                    //            btnlive.Enabled = true;
                    //            int i = 0;
                    //            GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "View / Edit");
                    //            foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                    //            {
                    //                i++;
                    //                if (i == 8)
                    //                {

                    //                    string tabItem = htmlElement.InnerText;
                    //                    linkItem = htmlElement.GetAttribute("HREF").ToString();
                    //                    label26.Font = new System.Drawing.Font("Verdana", 8.0f,
                    //         System.Drawing.FontStyle.Bold);

                    //                    webBrowser1.Navigate("http://www.justgoodcars.com/members/members_index.php");

                    //                    //webBrowser1.Navigate("http://www.justgoodcars.com/");

                    //                }
                    //                btnSubmit.Enabled = true;
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion
                    #endregion
                }
                //--------------justgoodcars End----------------

                //-----------------kugli start-------------------------
                if (comboBox1.Text == "kugli")
                {
                    #region kugli
                    if (webBrowser1.Url.ToString() == "http://www.kugli.com/business/def/post-edit-classified-ad/catid/2/")
                    {
                        if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {
                            btnpostupload.Enabled = true;
                            btnpostupload.Visible = true;

                            this.Opacity = 100;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            this.Refresh();
                        }
                    }

                    if (Kug == 1)
                    {
                        if (webBrowser1.Url.ToString() == "http://www.kugli.com/business/def/post-edit-classified-ad/catid/2/")
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);


                            IWebSites objClass = new Kugli();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                        }
                    }
                    #endregion
                }
                //-----------------kugli end-------------------------

                //-----------------Jeanza start-------------------------
                if (comboBox1.Text == "jeanza")
                {
                    #region jeanza
                    if (webBrowser1.Url.ToString() == "http://www.jeanza.com/publish-a-new-ad.htm")
                    {
                        if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {
                            if (jnga == 0)
                            {
                                btnpostupload.Enabled = true;
                                btnpostupload.Visible = true;

                                this.Opacity = 100;
                                circularProgressControl2.Stop();
                                circularProgressControl2.Visible = false;
                                panel2.Visible = false;
                            }
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://www.jeanza.com/publish-a-new-ad.htm")
                    {
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                            {
                                string InnerTxt = "Click here for Free Classified Ads Website.";
                                if (element.OuterText == InnerTxt)
                                {
                                    label29.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                                    btnpostsubmit.Enabled = false;
                                    btnuploadtolive.Visible = true;
                                    btnuploadtolive.Enabled = true;
                                }
                            }
                        }
                    }
                    if (jnga == 1)
                    {
                        // btnuploadtolive.Visible = true;
                        //  btnuploadtolive.Enabled = true;
                    }
                    #endregion
                }
                //-----------------Jeanza end-------------------------

                //-----------------Classifiedvally start-------------------------
                if (comboBox1.Text == "classifiedsvalley")//done
                {
                    #region classifiedsvalley old
                    //if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/")
                    //{
                    //    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    //    {
                    //        btnpostupload.Enabled = true;
                    //        btnpostupload.Visible = true;

                    //        this.Opacity = 100;
                    //        circularProgressControl2.Stop();
                    //        circularProgressControl2.Visible = false;
                    //        panel2.Visible = false;
                    //        this.Refresh();
                    //    }
                    //}
                    ////
                    //if (Globalstname.stname == "oregon")
                    //    Globalstname.stname = "oklahoma";
                    ////
                    //if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/")
                    //{
                    //    //com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    //    //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //    //obUsedCarsInfo = objService.FindCarID(label10.Text);
                    //    //IWebSites objClass = new classifiedsvalley();
                    //    //objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);
                    //    GeneralFunction.LinkInvoke(webBrowser1, "Change City");
                    //    circularProgressControl2.Stop();
                    //    panel2.Visible = false;
                    //    circularProgressControl2.Visible = false;
                    //    MessageBox.Show("Please Select City Manually");
                    //}
                    ////
                    //if (Globalstname.stname == "oklahoma")
                    //    Globalstname.stname = "oregon";
                    ////
                    //if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/choose-classified-ad-location.php")
                    //{ }
                    //string valyurl = webBrowser1.Url.ToString();
                    //if (Globalstname.stname != "california")
                    //{
                    //    if (valyurl.Contains("_"))
                    //    {
                    //        // http://www.classifiedsvalley.com/alaska/10_Homer/
                    //        int index1 = valyurl.IndexOf(".com/");
                    //        int end1 = valyurl.Length;
                    //        valyurl = valyurl.ToString().Substring(index1, end1 - index1);
                    //        valyurl = valyurl.Replace(".com/", "");
                    //        int index2 = valyurl.IndexOf("/");
                    //        int end2 = valyurl.Length;
                    //        valyurl = valyurl.ToString().Substring(index2, end2 - index2);
                    //        valyurl = valyurl.Replace("/", "");
                    //        int index3 = 0;
                    //        int end3 = valyurl.IndexOf("_");
                    //        cityno = valyurl.ToString().Substring(index3, end3 - index3);
                    //        cityno = cityno.Replace("_", "");
                    //    }
                    //}

                    //if (Globalstname.stname == "california")
                    //{
                    //    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/")
                    //    {
                    //        btnpostupload.Enabled = true;
                    //        btnpostupload.Visible = true;

                    //        this.Opacity = 100;
                    //        circularProgressControl2.Stop();
                    //        circularProgressControl2.Visible = false;
                    //        panel2.Visible = false;
                    //        this.Refresh();


                    //        GeneralFunction.LinkInvoke(webBrowser1, "Change City");
                    //    }


                    //    if (valyurl.Contains("_"))
                    //    {

                    //        // http://www.classifiedsvalley.com/alaska/10_Homer/
                    //        int index1 = valyurl.IndexOf(".com/");
                    //        int end1 = valyurl.Length;
                    //        valyurl = valyurl.ToString().Substring(index1, end1 - index1);
                    //        valyurl = valyurl.Replace(".com/", "");
                    //        int index2 = 0;
                    //        int end2 = valyurl.Length;
                    //        valyurl = valyurl.ToString().Substring(index2, end2 - index2);
                    //        valyurl = valyurl.Replace("/", "");


                    //        int index3 = 0;
                    //        int end3 = valyurl.IndexOf("_");
                    //        cityno = valyurl.ToString().Substring(index3, end3 - index3);
                    //        cityno = cityno.Replace("_", "");


                    //    }

                    //    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/choose-classified-ad-location.php")
                    //    {

                    //        MessageBox.Show("Please Select City Manually");
                    //    }

                    //    //  http://www.classifiedsvalley.com/372_San_Francisco/
                    //    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + valyurl + "/")
                    //    {
                    //        GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");
                    //    }

                    //    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + "index.php?view=post&cityid=" + cityno + "&lang=en")
                    //    {
                    //        GeneralFunction.LinkInvokeClassifiedValley(webBrowser1, "Vehicles");
                    //    }
                    //    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4")
                    //    {

                    //        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    //        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //        obUsedCarsInfo = objService.FindCarID(label10.Text);

                    //        int year = Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString());
                    //        if (rb_Vans.Checked)
                    //        {
                    //            GeneralFunction.LinkInvoke(webBrowser1, "Vans");
                    //        }
                    //        else if (rb_Trucks.Checked)
                    //        {
                    //            GeneralFunction.LinkInvoke(webBrowser1, "Trucks");
                    //        }
                    //        else
                    //        {
                    //            if (year < 1991)
                    //            {
                    //                GeneralFunction.LinkInvoke(webBrowser1, "Classic Cars");
                    //            }
                    //            else
                    //                GeneralFunction.LinkInvoke(webBrowser1, "Cars");
                    //        }
                    //    }
                    //    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=65"
                    //     || webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=67"
                    //     || webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=69"
                    //     || webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=68")
                    //    {

                    //        if (cvy == 0)
                    //        {
                    //            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                    //            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //            obUsedCarsInfo = objService.FindCarID(label10.Text);

                    //            GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");


                    //            circularProgressControl2.Stop();
                    //            panel2.Visible = false;
                    //            circularProgressControl2.Visible = false;


                    //            IWebSites objClass = new classifiedsvalley();
                    //            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    //            btnpostsubmit.Visible = true;
                    //            btnpostsubmit.Enabled = true;

                    //            cvy++;
                    //        }
                    //    }



                    //    if ((webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=65&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&")
                    //     || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=65&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&")
                    //     || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=67&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&")
                    //     || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=67&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&")
                    //     || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=68&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&")
                    //     || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=68&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&")
                    //     || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=69&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&")
                    //     || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=69&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&"))
                    //    //if (webBrowser1.Url.ToString() != "http://www.classifiedsvalley.com/" + Globalstname.stname );
                    //    {
                    //        int clsfd = 0;
                    //        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                    //        {
                    //            string InnerTxt = "Back to Home";
                    //            if (element.OuterText == InnerTxt)
                    //            {
                    //                clsfd++;
                    //                label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                    //                System.Drawing.FontStyle.Bold);

                    //                label29.ForeColor = System.Drawing.Color.Red;


                    //                btnpostsubmit.Enabled = false;
                    //                btnuploadtolive.Visible = true;
                    //                btnuploadtolive.Enabled = true;
                    //            }
                    //        }
                    //        if (clsfd == 0)
                    //        {
                    //            if (vlly == 0)
                    //            {
                    //                vlly++;

                    //                MessageBox.Show("Enter Security Code and Check All the fields ", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);


                    //                GeneralFunction.CheckedInvoke(webBrowser1, "agree");

                    //                btnpostsubmit.Enabled = true;

                    //                GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
                    //            }
                    //        }


                    //    }
                    //}
                    //if (valyurl.Contains("_"))
                    //{

                    //}
                    //if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + valyurl + "/")
                    //{

                    //    circularProgressControl2.Start();
                    //    panel2.Visible = true;
                    //    circularProgressControl2.Visible = true;

                    //    GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");


                    //}

                    //string test = "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "index.php?view=post&cityid=" + cityno + "&lang=en";
                    //if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "index.php?view=post&cityid=" + cityno + "&lang=en")
                    //{
                    //    //com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                    //    //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //    //obUsedCarsInfo = objService.FindCarID(label10.Text);

                    //    // http://www.classifiedsvalley.com/kentucky/index.php?view=post&cityid=1&lang=en
                    //    //IWebSites objClass = new classifiedsvalley();
                    //    //objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);

                    //    GeneralFunction.LinkInvokeClassifiedValley(webBrowser1, "Vehicles");
                    //}

                    //if ((webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4") || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "?view=post&cityid=" + cityno + "&lang=en&catid=2"))
                    //{
                    //    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    //    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //    obUsedCarsInfo = objService.FindCarID(label10.Text);

                    //    int yearnw = Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString());
                    //    if (rb_Vans.Checked)
                    //    {
                    //        GeneralFunction.LinkInvoke(webBrowser1, "Vans");
                    //    }
                    //    else if (rb_Trucks.Checked)
                    //    {
                    //        GeneralFunction.LinkInvoke(webBrowser1, "Trucks");
                    //    }
                    //    else
                    //    {
                    //        if (yearnw < 1991)
                    //        {
                    //            GeneralFunction.LinkInvoke(webBrowser1, "Classic Cars");
                    //        }
                    //        else
                    //        {
                    //            //if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4")
                    //            //{
                    //            //    GeneralFunction.LinkInvoke(webBrowser1, "Cars");
                    //            //}
                    //            //com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    //            //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //            //obUsedCarsInfo = objService.FindCarID(label10.Text);
                    //            ////http://www.classifiedsvalley.com/kentucky/?view=post&cityid=1&lang=en&catid=4
                    //            //IWebSites objClass = new classifiedsvalley();
                    //            //objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);
                    //            GeneralFunction.LinkInvoke(webBrowser1, "Cars");
                    //        }
                    //    }
                    //}
                    //if ((webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=65")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=69")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "?view=post&cityid=" + cityno + "&lang=en&catid=2&subcatid=17")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "?view=post&cityid=" + cityno + "&lang=en&catid=2&subcatid=21")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=67")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/" + "?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=68"))
                    //{
                    //    // http://www.classifiedsvalley.com/kentucky/?view=post&cityid=1&lang=en&catid=4&subcatid=65
                    //    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    //    {
                    //        if (cvy == 0)
                    //        {

                    //            cvy++;
                    //            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                    //            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //            obUsedCarsInfo = objService.FindCarID(label10.Text);


                    //            circularProgressControl2.Stop();
                    //            panel2.Visible = false;
                    //            circularProgressControl2.Visible = false;

                    //            GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
                    //            IWebSites objClass = new classifiedsvalley();
                    //            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    //            btnpostsubmit.Visible = true;
                    //            btnpostsubmit.Enabled = true;
                    //        }


                    //    }
                    //}

                    ////  http://www.classifiedsvalley.com/alabama/index.php?view=post&cityid=1&lang=en&catid=2&subcatid=17&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&
                    //string sfsd = "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=1&lang=en&catid=4&subcatid=65&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&";
                    //string sfsd1 = "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=65&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&";
                    //string sfsd2 = "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=65&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&";

                    //if ((webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=65&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=65&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=69&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=69&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=67&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=67&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=68&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=4&subcatid=68&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=2&subcatid=17&adid=0&imgid=0&countryid=0&areaid=0&pos=0&picid=0&page=0&foptid=0&eoptid=0&pricemin=0&pricemax=0&")
                    // || (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/" + Globalstname.stname + "/index.php?view=post&cityid=" + cityno + "&lang=en&catid=2&subcatid=21&adid=&imgid=&countryid=&areaid=&pos=&picid=&page=&foptid=&eoptid=&pricemin=&pricemax=&"))
                    ////if (webBrowser1.Url.ToString() != "http://www.classifiedsvalley.com/" + Globalstname.stname );
                    //{
                    //    int clsfd = 0;
                    //    foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                    //    {
                    //        string InnerTxt = "Back to Home";
                    //        if (element.OuterText == InnerTxt)
                    //        {
                    //            clsfd++;
                    //            label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                    //            System.Drawing.FontStyle.Bold);

                    //            label29.ForeColor = System.Drawing.Color.Red;


                    //            btnpostsubmit.Enabled = false;
                    //            btnuploadtolive.Visible = true;
                    //            btnuploadtolive.Enabled = true;
                    //        }
                    //    }
                    //    if (clsfd == 0)
                    //    {
                    //        if (vlly == 0)
                    //        {
                    //            vlly++;

                    //            MessageBox.Show("Enter Security Code and Check All the fields ", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);


                    //            GeneralFunction.CheckedInvoke(webBrowser1, "agree");

                    //            btnpostsubmit.Enabled = true;

                    //            GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
                    //        }
                    //    }


                    //}
                    #endregion
                    #region classifiedsvalley
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(label10.Text);
                    string username = comboBox2.Text;
                    Char[] seprt = { '@' };
                    string[] splitemail = username.Split(seprt);

                    username = splitemail[0].ToString();
                    string statename1 = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Register");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/register.php")
                    {
                        GeneralFunction.SetTextValue(webBrowser1, "c[firstname]", "uce");
                        GeneralFunction.SetTextValue(webBrowser1, "c[lastname]", "urve");
                        GeneralFunction.SetTextValue(webBrowser1, "c[address]", obUsedCarsInfo[0].City.ToString() + " " + obUsedCarsInfo[0].State.ToString() + " " + obUsedCarsInfo[0].Zip.ToString());
                        GeneralFunction.SetTextValue(webBrowser1, "c[city]", obUsedCarsInfo[0].City.ToString());
                        GeneralFunction.SetTextValue(webBrowser1, "c[zip]", obUsedCarsInfo[0].Zip.ToString());
                        SelectOption(webBrowser1, statename1, "c[state]");
                        GeneralFunction.SetTextValue(webBrowser1, "c[email]", comboBox2.Text);
                        GeneralFunction.SetTextValue(webBrowser1, "c[email_verifier]", comboBox2.Text);
                        GeneralFunction.SetTextValue(webBrowser1, "c[username]", username);
                        GeneralFunction.SetTextValue(webBrowser1, "c[password]", textBox2.Text);
                        GeneralFunction.SetTextValue(webBrowser1, "c[password_confirm]", textBox2.Text);
                        GeneralFunction.RadioSetValue(webBrowser1, "c[business_type]", "1");
                        GeneralFunction.RadioSetValue(webBrowser1, "c[agreement]", "yes");
                        GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/register.php?b=1")
                    {
                        //foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("h1"))
                        //{
                        //    if (webBrowser1.Document.GetElementById("h1").InnerText == "Confirm Your Registration")
                        //        webBrowser1.Navigate("http://www.gmail.com");
                        //    else
                        //        webBrowser1.Refresh();
                        //}
                            //Txt_Url.Text = "http://www.gmail.com";
                        Txt_Url.Visible = true;
                        Navigate_btn.Visible = true;
                    }
                    //if (webBrowser1.Url.ToString() == "https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=http://mail.google.com/mail/&scc=1&ltmpl=default&ltmplcache=2&emr=1")
                    //{
                    //    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    //    {
                    //        GeneralFunction.SetTextValue(webBrowser1, "Email", "carsales@globaltpv.com");
                    //        GeneralFunction.SetTextValue(webBrowser1, "Passwd", "carsales*123*");
                    //        GeneralFunction.ButtonClickInvoke(webBrowser1, "signIn");
                    //        Txt_Url.Visible = true;
                    //        Navigate_btn.Visible = true;
                    //    }
                    //}
                    if (webBrowser1.Url.ToString().Contains("b=3"))
                    //webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart"
                    //|| webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=4"
                    //||
                    {
                        Txt_Url.Visible = false;
                        Navigate_btn.Visible = false;
                        GeneralFunction.LinkInvoke(webBrowser1, "CLICK HERE");
                        //GeneralFunction.LinkInvoke(webBrowser1, "Post an ad (free)");
                        //GeneralFunction.LinkInvoke(webBrowser1, "New Classified");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post an ad (free)");
                        GeneralFunction.LinkInvoke(webBrowser1, "New Classified");
                    }
                    if(webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "New Classified");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&action=new&main_type=classified")
                    {
                        GeneralFunction.spanLinkInvoke1(webBrowser1, "Vehicles");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&main_type=classified&step=classified:category&b=15&action=process")
                    {
                        if (rb_Trucks.Checked)
                        {
                            GeneralFunction.spanLinkInvoke1(webBrowser1, "Trucks");
                        }
                        else if (rb_Vans.Checked)
                        {
                            GeneralFunction.spanLinkInvoke1(webBrowser1, "Minivans");
                        }
                        else
                        GeneralFunction.spanLinkInvoke1(webBrowser1, "Cars");
                        //spanLinkInvoke1(webBrowser1, "Trucks");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&main_type=classified&step=classified:category&b=212&action=process")
                    {
                        webBrowser1.Navigate("http://www.classifiedsvalley.com/index.php?a=cart&main_type=classified&step=classified:category&b=212&c=terminal&action=process");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&main_type=classified&step=classified:category&b=196&action=process"
                     || webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&main_type=classified&step=classified:category&b=305&action=process"
                     || webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&main_type=classified&step=classified:category&b=212&c=terminal&action=process")
                    {
                        IWebSites ob = new classifiedsvalley1();
                        GeneralFunction.SetDropDownNameandValue(webBrowser1, "b[classified_length]", "62");
                        ob.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        //GeneralFunction.SetTextValue(webBrowser1, "b[classified_title]", obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString());
                        //GeneralFunction.SetMultiTextValue(webBrowser1, "b[description]", "Make: Ford\r\nModel: F250\r\nyear: 1995\r\nPrice: $7000\r\nMileage: 95000.00\r\n\n\nDescription: Runs and drives w ell 95,000 original miles 7.3 Turbo diesel have canopy for it as w ell 4253816458..!! If intrested\r\nContact : 4253816458..!!!For More Details: http://UnitedCarExchange.com/a1/1995-Ford-F250-271755505317");
                        //GeneralFunction.SetTextValue(webBrowser1, "b[question_value][92]", "jagadeesh");
                        //GeneralFunction.SetTextValue(webBrowser1, "b[question_value][93]", "jagadeesh");
                        //GeneralFunction.SetTextValue(webBrowser1, "b[price]", "jagadeesh");
                        //GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");
                        //GeneralFunction.SetTextValue(webBrowser1, "b[classified_title]", "jagadeesh");

                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&action=process&main_type=classified&step=classified:details")
                    {
                        //spanLinkInvoke2(webBrowser1, "normalUploaderShowLink");
                        GeneralFunction.spanLinkInvoke1(webBrowser1, "click here");
                        GeneralFunction.FileUploadInvoke(webBrowser1, "d[1]");
                        GeneralFunction.FileUploadInvoke(webBrowser1, "d[2]");
                        GeneralFunction.FileUploadInvoke(webBrowser1, "d[3]");
                        GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&action=process&main_type=classified&step=images:upload_images"
                     || webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&action=process&main_type=classified&step=images:upload_images&useLegacyUploader=1&no_ssl_force=1")
                    {
                        GeneralFunction.ButtonClickInvoke(webBrowser1, "c[no_images]");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&action=process&main_type=classified&step=images:upload_images&useLegacyUploader=1&no_ssl_force=1")
                    {
                        GeneralFunction.ButtonClickBody2(webBrowser1, "Process Queue");
                        btnuploadtolive.Enabled = true;
                        btnuploadtolive.Visible = true;
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsvalley.com/index.php?a=cart&action=process&main_type=cart&step=cart")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Logout");
                    }
                    //GeneralFunction.LinkInvoke(webBrowser1, statename);
                    #endregion
                }
                //-----------------Classifiedvally end-------------------------

                //-----------------Classifiedciti start-------------------------
                if (comboBox1.Text == "classifiedsciti")
                {
                    #region classifiedsciti
                    circularProgressControl2.Start();
                    circularProgressControl2.Visible = true;
                    panel2.Visible = true;
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsciti.com/publish-a-new-ad.htm")
                    {
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            string InnerTxt = "TERMS OF SERVICE";
                            if (element.OuterText == InnerTxt)
                            {
                                tabControl1.Enabled = true;
                                btnpostupload.Enabled = true;
                                btnpostupload.Visible = true;
                                this.Opacity = 100;
                                pnlpostcardata.Visible = true;
                                circularProgressControl2.Stop();
                                circularProgressControl2.Visible = false;
                                panel2.Visible = false;
                                this.Refresh();
                            }
                        }

                    }
                    if (webBrowser1.Url.ToString() != "http://www.classifiedsciti.com/publish-a-new-ad.htm")
                    {
                        if (webBrowser1.Url.ToString() != "http://just98.justhost.com/suspended.page/disabled.cgi/classifiedsciti.com")
                        {

                            int clc = 0;
                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                string InnerTxt = "TERMS OF SERVICE";
                                if (element.OuterText == InnerTxt)
                                {
                                    clc++;
                                }
                            }
                            if (clc >= 1)
                            {
                            }
                            else
                            {
                                label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                                System.Drawing.FontStyle.Bold);
                                label29.ForeColor = System.Drawing.Color.Red;

                                btnpostsubmit.Enabled = false;
                                btnuploadtolive.Visible = true;
                                btnuploadtolive.Enabled = true;
                                circularProgressControl2.Stop();
                                panel2.Visible = false;
                                circularProgressControl2.Visible = false;
                                //}
                            }
                        }
                    }

                    if (webBrowser1.Url.ToString() == "http://just98.justhost.com/suspended.page/disabled.cgi/classifiedsciti.com")
                    {
                        circularProgressControl2.Stop();
                        panel2.Visible = false;
                        circularProgressControl2.Visible = false;
                        MessageBox.Show("This Site under maintance.Please select another Site.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    #endregion
                }

                //-----------------Classifiedciti end-------------------------

                //-----------------USA.Motoseller start-------------------------
                if (comboBox1.Text == "usa.motoseller.com")
                {
                    #region usa.motoseller.com
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);



                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=10&amp;c=a*is*1")
                        {
                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                string InnerTxt = "click here to log out";
                                if (element.OuterText == InnerTxt)
                                {
                                    moto++;
                                    GeneralFunction.LinkInvokeClassifiedValley(webBrowser1, "click here to log out");
                                }
                            }
                            if (moto == 0)
                            {

                                btnpostupload.Enabled = true;
                                btnpostupload.Visible = true;

                                this.Opacity = 100;
                                circularProgressControl2.Stop();
                                circularProgressControl2.Visible = false;
                                panel2.Visible = false;
                                this.Refresh();
                            }

                            //foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            //{

                            //    string fgf = webBrowser1.Url.ToString();
                            //    string InnerTxt = "click here to log out";
                            //    if (element.OuterText == InnerTxt)
                            //    {
                            //        GeneralFunction.LinkInvokeClassifiedValley(webBrowser1, "click here to log out");

                            //        webBrowser1.Navigate("");
                            //        comboBox1.Text = "";
                            //    }

                            //    else
                            //    {


                            //        btnpostupload.Enabled = true;
                            //        btnpostupload.Visible = true;
                            //    }


                            //}






                            // btnpostsubmit.Visible = true;
                            // btnpostsubmit.Enabled = true;
                        }

                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=10")
                        {
                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                string InnerTxt = "click here to log out";
                                if (element.OuterText == InnerTxt)
                                {
                                    moto++;
                                    GeneralFunction.LinkInvokeClassifiedValley(webBrowser1, "click here to log out");
                                }
                            }

                        }

                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=10")
                        {
                            if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                            {
                                IWebSites objClass = new Motoseller();
                                objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            }
                        }
                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php")
                        {

                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                string InnerTxt = "Post a FREE Ad!";
                                if (element.OuterText == InnerTxt)
                                {

                                    GeneralFunction.LinkInvokeClassifiedValley(webBrowser1, "Post a FREE Ad!");
                                    moto = 0;
                                    //if(int motosl==0)
                                    //{
                                    motosl++;
                                    MessageBox.Show("Please Click Start Button Again", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    label27.Font = new System.Drawing.Font("Verdana", 8.0f,
                                    System.Drawing.FontStyle.Regular);
                                    //}
                                }
                            }

                        }

                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=1")
                        {

                            IWebSites objClass = new Motoseller();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                        }

                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=1&b=302&set_cat=1")
                        {

                            IWebSites objClass = new Motoseller();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                        }

                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=1&b=307&c=category&set_cat=1")
                        {
                            statenamemoto = GetStatesMotoseller.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
                            if (statenamemoto != "")
                            {
                                char[] spldata = { ',' };
                                string[] msplit = statenamemoto.Split(spldata);

                                stNamemoto = msplit[0].ToString();
                                // stName1moto = stNamemoto + " ".ToString();
                                stcdemoto = msplit[1].ToString();
                                GeneralFunction.LinkInvokeMotoSellerStateName(webBrowser1, "category_links", stNamemoto);
                                //IWebSites objClass = new Motoseller();
                                //objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);
                            }

                        }
                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=1&b=" + stcdemoto + "&c=category&set_cat=1")
                        {

                            circularProgressControl2.Stop();
                            panel2.Visible = false;
                            circularProgressControl2.Visible = false;
                            label49.Visible = false;

                            IWebSites objClass = new Motoseller();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            btnpostsubmit.Visible = true;
                            btnpostsubmit.Enabled = true;

                        }

                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=1&set_details=1")
                        {
                            if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                            {
                                GeneralFunction.FileUploadInvoke(webBrowser1, "d[1]");

                                btnpostsubmit.Enabled = false;
                            }


                        }
                        if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {
                            if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=1&set_details=1")
                            {

                                GeneralFunction.ButtonClickInvoke(webBrowser1, "c[no_images]");
                            }
                        }


                        if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=1&set_images=1")
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Approve this ad");
                            btnuploadtolive.Visible = true;
                            btnuploadtolive.Enabled = true;
                            label28.Font = new System.Drawing.Font("Verdana", 8.0f,
                            System.Drawing.FontStyle.Bold);
                            // GeneralFunction.LinkInvokeClassifiedValley(webBrowser1, "Log Out");
                        }
                    }
                    #endregion
                }
                //-----------------USA.Motoseller End-------------------------

                //-----------------American start-------------------------
                if (comboBox1.Text == "American-classifieds.net")
                {
                    #region American-classifieds.net
                    if (webBrowser1.Url.ToString() == "http://www.american-classifieds.net/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post Ads");

                    }
                    if (webBrowser1.Url.ToString() == "http://www.american-classifieds.net/postad.php")
                    {
                        //if (webBrowser1.Document.GetElementById("title").InnerText != "")
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "POST REGULAR AD");
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://www.american-classifieds.net/postad.php?submittype=0&categ=")
                    {

                        if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {

                            btnpostupload.Enabled = true;
                            btnpostupload.Visible = true;
                            this.Opacity = 100;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            this.Refresh();
                        }

                    }

                    if (comboBox1.Text == "American-classifieds.net")
                    {
                        int amc = 0;
                        int amc1 = 0;

                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            if (webBrowser1.Url.ToString() != "http://www.american-classifieds.net/postad.php")
                            {
                                if (webBrowser1.Url.ToString() != "http://www.american-classifieds.net/")
                                {
                                    if (webBrowser1.Url.ToString() != "http://www.american-classifieds.net/postad.php")
                                    {
                                        if (webBrowser1.Url.ToString() != "http://www.american-classifieds.net/postad.php?submittype=0&categ=")
                                        {
                                            if (webBrowser1.Url.ToString() != "http://www.american-classifieds.net/")
                                            {
                                                if (amc1 == 0)
                                                {

                                                    circularProgressControl2.Start();
                                                    circularProgressControl2.Visible = true;
                                                    panel2.Visible = true;
                                                    btnpostsubmit.Enabled = false;
                                                    string fgf = webBrowser1.Url.ToString();
                                                    string InnerTxt = "Accent List";
                                                    if (element.OuterText == InnerTxt)
                                                    {
                                                        if (amc == 0)
                                                        {
                                                            amc1++;
                                                            label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                                                             System.Drawing.FontStyle.Bold);
                                                            circularProgressControl2.Stop();
                                                            circularProgressControl2.Visible = false;
                                                            panel2.Visible = false;
                                                            label31.ForeColor = System.Drawing.Color.Red;
                                                            btnpostsubmit.Enabled = false;
                                                            btnuploadtolive.Visible = true;
                                                            btnuploadtolive.Enabled = true;
                                                            amc++;
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (amc >= 1)
                        {
                        }
                        else
                        {
                            if (amc1 == 1)
                            {
                                circularProgressControl2.Stop();
                                circularProgressControl2.Visible = false;
                                panel2.Visible = false;
                                btnpostsubmit.Enabled = false;
                                btnpostupload.Enabled = true;

                                MessageBox.Show("Email has been used already.Please select the site again and change emailId.");

                            }

                        }


                        //string recorded = webBrowser1.Url.ToString();
                        //if (recorded.Contains("recorded"))
                        //{

                        //}

                        if (webBrowser1.Url.ToString() == "http://www.american-classifieds.net/postad.php")
                        {
                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("div"))
                            {
                                string InnerTxt = "An ad was posted from your IP address less than 5 minutes ago.";


                                if (element.OuterText == InnerTxt)
                                {
                                }
                                string fxb = element.OuterText;
                                //  if (element.InnerText.Contains(InnerTxt))
                                //  {

                                // }
                            }
                        }

                    }
                    #endregion

                }
                //-----------------American End-------------------------

                //-----------------classifiedsforfree start-------------------------
                if (comboBox1.Text == "Classifiedsforfree")
                {
                    #region Classifiedsforfree
                    Globaltxtemail.txtemail = comboBox2.Text;
                    Globalpwd.pwd = textBox2.Text;
                    int cfree = 0;

                    if (webBrowser1.Url.ToString() == "http://www.classifiedsforfree.com/")
                    {

                        //  webBrowser1.Navigate("http://www.classifiedsforfree.com/post-ad/State.htm");
                        GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);

                        IWebSites objClass = new ClassifiedsForFree();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                        GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Post Ad");


                    }

                    if (webBrowser1.Url.ToString() == "http://www.classifiedsforfree.com/Account/Login?ReturnUrl=/Post")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Register");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsforfree.com/Post")
                    {

                        if (cfreeimg == 0)
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);

                            IWebSites objClass = new ClassifiedsForFree();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                            cfreeimg++;
                        }
                    }

                    if (webBrowser1.Url.ToString() == "http://www.classifiedsforfree.com/Account/Register")
                    {

                        if (cff == 0)
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);
                            cff++;


                            IWebSites objClass = new ClassifiedsForFree();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                            btnpostsubmit.Visible = true;
                            btnpostsubmit.Enabled = true;
                        }
                        if (cff == 1)
                        {
                            //GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");
                        }
                        circularProgressControl2.Stop();
                        panel2.Visible = false;
                        circularProgressControl2.Visible = false;
                        label49.Visible = false;



                        // GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");

                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsforfree.com/#")
                    {
                        GeneralFunction.SpanInnerText(webBrowser1, "US States");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedsforfree.com/post-ad/State.htm")
                    {
                        btnpostupload.Enabled = true;
                        btnpostupload.Visible = true;


                        this.Opacity = 100;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        this.Refresh();
                    }



                    if (webBrowser1.Url.ToString() == "http://www.classifiedsforfree.com/submit-ad/State.htm")
                    {
                        if (webBrowser1.Url.ToString() != "http://www.classifiedsforfree.com/post-ad/State.htm")
                        {
                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                string InnerTxt = "YouTube.com";
                                if (element.OuterText == InnerTxt)
                                {
                                    cfree++;
                                    MessageBox.Show("Please check the fields again before clicking submit");
                                }
                            }
                            if (cfree == 0)
                            {
                                foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("div"))
                                {
                                    string fg = element.InnerHtml;

                                    btnpostsubmit.Enabled = false;
                                    btnuploadtolive.Visible = true;
                                    btnuploadtolive.Enabled = true;
                                    label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                                    System.Drawing.FontStyle.Bold);

                                    label29.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                    }
                    #endregion
                }
                //-----------------classifiedsforfree End-------------------------

                //-----------------epage End-------------------------
                if (comboBox1.Text == "Epage" || comboBox1.Text == "www.epage.com")
                {
                    #region epage old
                    //com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //obUsedCarsInfo = objService.FindCarID(label10.Text);
                    //if (webBrowser1.Url.ToString() == "http://epage.com/js/post/c0/" 
                    //|| (webBrowser1.Url.ToString().Contains("http://epage.com/js/post;") && webBrowser1.Url.ToString().Contains("jsessionid")))
                    //{
                    //    btnpostupload.Enabled = true;
                    //    btnpostupload.Visible = true;
                    //    this.Opacity = 100;
                    //    circularProgressControl2.Stop();
                    //    circularProgressControl2.Visible = false;
                    //    panel2.Visible = false;
                    //    this.Refresh();
                    //}
                    //if (webBrowser1.Url.ToString() != "http://epage.com/js/post")
                    //{
                    //    if (webBrowser1.Url.ToString() != "http://epage.com/js/post?c=0&b=0&process=2&cnum=1100300"
                    //     || webBrowser1.Url.ToString() != "http://epage.com/js/post?c=0&b=0&process=2&cnum=1102000")
                    //    {
                    //        if (webBrowser1.Url.ToString() != "http://epage.com/js/post/c0/")
                    //        {
                    //            if (webBrowser1.Url.ToString() != "http://epage.com/js/post?c=0")
                    //            {
                    //                if (epg == 0)
                    //                {
                    //                    IWebSites objClass = new epage();
                    //                    objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    //                    epg1++;
                    //                    epg++;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    //if (webBrowser1.Url.ToString() == "http://epage.com/js/post?c=0&b=0&process=2&cnum=1100300" || webBrowser1.Url.ToString() == "http://epage.com/js/post?c=0&b=0&process=2&cnum=1102000")
                    //{
                    //    IWebSites objClass = new epage();
                    //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    //    circularProgressControl2.Stop();
                    //    circularProgressControl2.Visible = false;
                    //    panel2.Visible = false;
                    //}

                    //if (webBrowser1.Url.ToString() == "http://epage.com/js/post")
                    //{
                    //    if (epg1 == 1)
                    //    {
                    //        IWebSites objClass = new epage();
                    //        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    //        btnpostsubmit.Enabled = true;
                    //        btnpostsubmit.Visible = true;
                    //    }
                    //}
                    //if (webBrowser1.Url.ToString() == "http://epage.com/js/post?c=0")
                    //{
                    //    if (subepg == 1)
                    //    {
                    //        GeneralFunction.ButtonClickByValue(webBrowser1, "Continue");
                    //        epglst++;
                    //        subepg++;
                    //        label29.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                    //        //IWebSites objClass = new epage();
                    //        //objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);
                    //    }
                    //}
                    //if (webBrowser1.Url.ToString() == "http://epage.com/js/post")
                    //{
                    //    GeneralFunction.Submit(webBrowser1, " Register ");
                    //}
                    //if (webBrowser1.Url.ToString() == "http://epage.com/js/post?c=0")
                    //{
                    //    if (epglst == 1)
                    //    {
                    //        GeneralFunction.ButtonClickByValue(webBrowser1, "Yes");
                    //        epg1++;
                    //        if (epg1 == 2)
                    //        {
                    //            circularProgressControl2.Stop();
                    //            panel2.Visible = false;
                    //            circularProgressControl2.Visible = false;
                    //        }
                    //    }
                    //}
                    //if (webBrowser1.Url.ToString() == "http://epage.com/js/post")
                    //{
                    //    if (epg1 == 3)
                    //    {
                    //        btnpostsubmit.Enabled = false;
                    //    }
                    //}
                    //string urlck = webBrowser1.Url.ToString();
                    //if (urlck.Contains("mi"))
                    //{
                    //    btnuploadtolive.Visible = true;
                    //    btnuploadtolive.Enabled = true;
                    //}
                    //if (webBrowser1.Url.ToString() == "http://epage.com/js/account/n0/")
                    //{
                    //    GeneralFunction.LinkInvoke(webBrowser1, "Logout");
                    //}
                    #endregion
                    #region epage new 
                    if (webBrowser1.Url.ToString() == "http://epage.com/js/post/c0/")
                    {
                        GeneralFunction.RadioSetValue(webBrowser1, "place", "pp1100000,0,1100000,Vehicles");
                        GeneralFunction.ButtonClickByValue(webBrowser1, "Continue");
                    }
                    else if (webBrowser1.Url.ToString() == "http://epage.com/js/post" || webBrowser1.Url.ToString().Contains("jsessionid"))
                    {
                        epagei++;
                    }
                    else if (webBrowser1.Url.ToString() == "http://epage.com/js/post?c=0&b=0&process=2&cnum=1100300")
                    {
                        GeneralFunction.ButtonClickByValue(webBrowser1, "Continue");
                    }
                    else if (webBrowser1.Url.ToString() == "http://epage.com/js/post?c=0")
                    {
                        epagej++;
                    }
                    else if (webBrowser1.Url.ToString() == "http://epage.com/js/account/n0/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Logout");
                    }
                    //else if (webBrowser1.Url.ToString() == "http://epage.com/js/account/n0/")
                    //{
                    //    GeneralFunction.LinkInvoke(webBrowser1, "Logout");
                    //}
                    else if (webBrowser1.Url.ToString().Contains("mi"))
                    {
                        btnuploadtolive.Visible = true;
                        btnuploadtolive.Enabled = true;
                    }
                    if (epagej == 1)
                    {
                        GeneralFunction.ButtonClickByValue(webBrowser1, "Continue");
                    }
                    else if (epagej > 1)
                    {
                        //GeneralFunction.ButtonClickByValue(webBrowser1, "Yes");
                    }
                    if (epagei == 1)
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        IWebSites objClass = new epage();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    }
                    else if (epagei == 2)
                    {
                        GeneralFunction.Submit(webBrowser1, " Register ");
                    }
                    else if (epagei == 3)
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        IWebSites objClass = new epage();

                        string username = comboBox2.Text;
                        Char[] seprt = { '@' };
                        string[] splitemail = username.Split(seprt);
                        username = splitemail[0].ToString();
                        GeneralFunction.SetTextValue(webBrowser1, "loginuserid", username);
                        GeneralFunction.SetTextValue(webBrowser1, "loginemail", comboBox2.Text);
                        GeneralFunction.SetTextValue(webBrowser1, "loginpasswd", textBox2.Text);
                        GeneralFunction.SetTextValue(webBrowser1, "loginfirstname", username);
                        GeneralFunction.SetTextValue(webBrowser1, "loginlastname", username);
                        GeneralFunction.SetDropDownNameandValue(webBrowser1, "logincountry", "151000");
                        GeneralFunction.SetTextValue(webBrowser1, "loginzip", obUsedCarsInfo[0].Zip.ToString());
                    }
                    else if (epagei > 3)
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        IWebSites objClass = new epage();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    }
                    #endregion
                }
                //-----------------epage End-------------------------

                //------------Highland start---------------------------
                if (comboBox1.Text == "highlandclassifieds")//done
                {
                    #region highlandclassifieds
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(label10.Text);
                    GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Yes");
                    if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/csp?csp=45757")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post a New Ad");
                        //if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post/c45757")
                        //{
                        // HLepglst++;
                        btnpostupload.Enabled = true;
                        btnpostupload.Visible = true;
                        this.Opacity = 100;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        this.Refresh();

                    }
                    // }

                    if (webBrowser1.Url.ToString() != "http://highlandclassifieds.com/js/post")
                    {
                        if (webBrowser1.Url.ToString() != "http://highlandclassifieds.com/js/post?c=0&b=0&process=2&cnum=1100300"
                         || webBrowser1.Url.ToString() != "http://highlandclassifieds.com/js/post?c=0&b=0&process=2&cnum=1102000")
                        {
                            if (webBrowser1.Url.ToString() != "http://highlandclassifieds.com/js/post/c0/")
                            {
                                if (webBrowser1.Url.ToString() != "http://ww1.highlandclassifieds.com/js/post")
                                {
                                    if (HLepg == 0)
                                    {
                                        IWebSites objClass = new highlandclassifieds();
                                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                                        HLepg1++;
                                        HLepg++;
                                    }
                                }
                            }
                        }
                    }
                    string urlck = webBrowser1.Url.ToString();
                    if (urlck.Contains("mi"))
                    {
                        btnuploadtolive.Visible = true;
                        btnuploadtolive.Enabled = true;

                    }

                    if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post?c=45757&b=45757&process=2&cnum=1100300"
                     || webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post?c=45757&b=45757&process=2&cnum=1102000")
                    {

                        IWebSites objClass = new highlandclassifieds();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                    }

                    if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post")
                    {
                        if ((HLepg1 == 1) || (HLepg1 == 2) || (HLepg1 == 3) || (HLepg1 == 4))
                        {
                            IWebSites objClass = new highlandclassifieds();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Continue");

                            if (HLepg1 == 3)
                            {
                                btnpostupload.Enabled = false;
                                btnpostsubmit.Enabled = true;
                                btnpostsubmit.Visible = true;
                            }
                            if (HLepg1 == 4)
                            {
                                label28.Font = new System.Drawing.Font("Verdana", 8.0f,
                         System.Drawing.FontStyle.Bold);
                                btnpostsubmit.Enabled = false;
                            }
                            HLepg1++;


                        }
                    }
                    //if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post?c=0")
                    //{
                    //    if (HLsubepg == 1)
                    //    {
                    //        GeneralFunction.ButtonClickByValue(webBrowser1, "Continue");
                    //        HLepglst++;
                    //        HLsubepg++;
                    //        label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                    //        System.Drawing.FontStyle.Bold);
                    //        //IWebSites objClass = new epage();
                    //        //objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);

                    //    }
                    //}
                    if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post")
                    {
                        GeneralFunction.Submit(webBrowser1, " Register ");
                    }
                    //if (webBrowser1.Url.ToString() == "{http://ww1.highlandclassifieds.com/js/post?c=45757")
                    //{

                    //        GeneralFunction.ButtonClickByValue(webBrowser1, "Yes");
                    //        HLepg1++;
                    //        if (HLepg1 == 2)
                    //        {
                    //            circularProgressControl2.Stop();
                    //            pnlpostcardata.Visible = false;
                    //            panel2.Visible = false;
                    //            circularProgressControl2.Visible = false;
                    //        }
                    //}
                    if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post?c=45757")
                    {
                        //if (hgcl == 0)
                        //{

                        hgcl++;

                        //if (hgcl == 1)
                        //{
                        //string price = obUsedCarsInfo[0].Price.ToString();
                        //price = "$" + price;
                        // GeneralFunction.SetTextValue(webBrowser1, "price", price);
                        GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Continue");
                        //}

                        this.Opacity = 100;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        this.Refresh();

                        //     GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Continue");

                        // btnpostsubmit.Enabled = false;
                        // }
                    }
                    if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/account/c45757")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Logout");
                    }

                    //if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post")
                    //{

                    //    if (HLepg1 == 3)
                    //    {
                    //        btnpostsubmit.Enabled = false;
                    //        btnuploadtolive.Visible = true;
                    //        btnuploadtolive.Enabled = true;
                    //    }
                    //}

                    #endregion
                }
                //------------Highland End----------------------------

                if (comboBox1.Text == "classifiededition")
                {
                    #region classifiededition
                    string stName = string.Empty;
                    string stName1 = string.Empty;
                    string stNam = string.Empty;
                    string stcde = string.Empty;
                    string statename = string.Empty;
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(label10.Text);
                    statename = GetEditionState.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
                    if (statename != "")
                    {
                        char[] spldata = { ',' };
                        string[] msplit = statename.Split(spldata);
                        stName = msplit[0].ToString();
                        stNam = msplit[0].ToString();
                        if (stName == "New York")
                        {
                            stName = stName.Replace(" ", "_");

                        }
                        stName1 = stNam + " ".ToString();
                        stcde = msplit[1].ToString();
                        if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {
                            if (webBrowser1.Url.ToString() == "http://www.classifiededition.com/")
                            {
                                btnpostupload.Visible = true;
                                btnpostupload.Enabled = true;

                                this.Opacity = 100;
                                circularProgressControl2.Stop();
                                circularProgressControl2.Visible = false;
                                panel2.Visible = false;
                                this.Refresh();
                            }
                            if (webBrowser1.Url.ToString() == "http://www.classifiededition.com/-2_United_States/")
                            {

                                //com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                                //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                                //obUsedCarsInfo = objService.FindCarID(label10.Text);


                                //statename = GetEditionState.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
                                //if (statename != "")
                                //{
                                //    char[] spldata = { ',' };
                                //    string[] msplit = statename.Split(spldata);

                                //     stName = msplit[0].ToString();

                                //    stName = stName + " ".ToString();

                                // stcde = msplit[1].ToString();


                                GeneralFunction.LinkInvoke(webBrowser1, stName1);

                                //  GeneralFunction.LinkInvokestate(webBrowser1, stName1);
                            }

                        }


                        if (stName.Contains(" "))
                        {
                            stName = stName.Replace(" ", "_");
                        }
                        //if (stName == "New Jersey")
                        //{
                        //    stName = "New_Jersey";
                        //}
                        //else if (stName == "West Virginia")
                        //{
                        //    stName = "West_Virginia";
                        //}
                        string gh = "http://www.classifiededition.com/" + stcde + "_" + stName + "/";
                        if (webBrowser1.Url.ToString() == "http://www.classifiededition.com/" + stcde + "_" + stName + "/")
                        {

                            // {http://www.classifiededition.com/108_Pennsylvania/
                            GeneralFunction.LinkInvoke(webBrowser1, "Unlimited Free Post");

                        }


                        if (webBrowser1.Url.ToString() == "http://www.classifiededition.com/index.php?view=post&cityid=" + stcde + "&lang=en&funcountry=" + stcde)
                        {


                            GeneralFunction.LinkInvoke(webBrowser1, "Vehicles");
                        }
                        if (webBrowser1.Url.ToString() == "http://www.classifiededition.com/?view=post&cityid=" + stcde + "&funcountry=" + stcde + "&lang=en&catid=3")
                        {

                            int year = Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString());
                            if (rb_Trucks.Checked)
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "Trucks");
                            }
                            else
                            {
                                if (year < 1991)
                                {
                                    GeneralFunction.LinkInvoke(webBrowser1, "Classic Cars");
                                }
                                else
                                {
                                    GeneralFunction.LinkInvoke(webBrowser1, "Cars");
                                }
                            }
                            circularProgressControl2.Stop();
                            panel2.Visible = false;
                            circularProgressControl2.Visible = false;
                        }
                        if ((webBrowser1.Url.ToString() == "http://www.classifiededition.com/?view=post&cityid=" + stcde + "&funcountry=" + stcde + "&lang=en&catid=3&subcatid=50")
                         || (webBrowser1.Url.ToString() == "http://www.classifiededition.com/?view=post&cityid=" + stcde + "&funcountry=" + stcde + "&lang=en&catid=3&subcatid=55")
                         || (webBrowser1.Url.ToString() == "http://www.classifiededition.com/?view=post&cityid=" + stcde + "&funcountry=" + stcde + "&lang=en&catid=3&subcatid=51"))
                        {
                            //if ((clsfd == 0) || (clsfd == 1))
                            //{

                            if ((clsfd == 0))
                            {
                                IWebSites objClass = new ClassifiedEditor();
                                objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                                clsfd++;
                                btnpostsubmit.Visible = true;
                                btnpostsubmit.Enabled = true;
                            }
                       }

                        if ((webBrowser1.Url.ToString() == "http://www.classifiededition.com/index.php?view=post&cityid=" + stcde + "&funcountry=" + stcde + "&lang=en&catid=3&subcatid=50&")
                         || (webBrowser1.Url.ToString() == "http://www.classifiededition.com/index.php?view=post&cityid=" + stcde + "&funcountry=" + stcde + "&lang=en&catid=3&subcatid=55&")
                         || (webBrowser1.Url.ToString() == "http://www.classifiededition.com/index.php?view=post&cityid=" + stcde + "&funcountry=" + stcde + "&lang=en&catid=3&subcatid=51&"))
                        {

                            foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                            {
                                string InnerTxt = "Back to Home";
                                if (htmlElement.InnerText == InnerTxt)
                                {
                                    if (edi == 0)
                                    {
                                        edi++;
                                        label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                                        System.Drawing.FontStyle.Bold);
                                        label31.ForeColor = System.Drawing.Color.Red;
                                        btnpostsubmit.Enabled = false;
                                        btnuploadtolive.Visible = true;
                                        btnuploadtolive.Enabled = true;
                                    }
                                }
                            }
                            if (edi == 0)
                            {
                                edi++;
                                MessageBox.Show("Enter Security Code and Check All the fields ", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                GeneralFunction.CheckedInvoke(webBrowser1, "agree");
                            }
                        }
                    }
                    #endregion
                }

                //postfreeadshere.com start-----------------------
                if (comboBox1.Text == "www.postfreeadshere.com")
                {
                    #region www.postfreeadshere.com
                    if (webBrowser1.Url.ToString() == "http://www.postfreeadshere.com/publish-a-new-ad.htm")
                    {
                        if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {
                            btnpostupload.Enabled = true;
                            btnpostupload.Visible = true;

                            this.Opacity = 100;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            this.Refresh();
                        }
                    }
                    if (webBrowser1.Url.ToString() != "http://www.postfreeadshere.com/publish-a-new-ad.htm")
                    {
                        foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                        {
                            string InnerTxt = "No Thanks! - I am ok with the FREE POSTING..";
                            if (htmlElement.InnerText == InnerTxt)
                            {
                                label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                                System.Drawing.FontStyle.Bold);
                                label29.ForeColor = System.Drawing.Color.Red;
                                btnpostsubmit.Enabled = false;
                                btnuploadtolive.Visible = true;
                                btnuploadtolive.Enabled = true;
                            }
                        }
                    }
                    #endregion
                }
                //postfreeadshere.com end-----------------------

                //cathaylist start-------------------------
                if (comboBox1.Text == "cathaylist")
                {
                    #region cathaylist
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (webBrowser1.Url.ToString() == "http://www.cathaylist.com/?view=selectcity&targetview=post&cityid=0&lang=en")
                        {
                            cthy = 0;
                            btnpostupload.Visible = true;
                            btnpostupload.Enabled = false;


                            this.Opacity = 100;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            this.Refresh();
                        }

                        if (webBrowser1.Url.ToString() != "http://www.cathaylist.com/?view=selectcity&targetview=post&cityid=0&lang=en")
                        {
                            if (cthy == 0)
                            {
                                url = webBrowser1.Url.ToString();
                                if (url.Contains("cityid="))
                                {

                                    int index1 = url.IndexOf("cityid=");
                                    int end1 = url.IndexOf("lang=");
                                    url = url.ToString().Substring(index1, end1 - index1);
                                    url = url.Replace("cityid=", "");
                                    url = url.Replace("&", "");
                                    label27.Font = new System.Drawing.Font("Verdana", 8.0f,
                                    System.Drawing.FontStyle.Bold);

                                    circularProgressControl2.Start();
                                    panel2.Visible = true;
                                    circularProgressControl2.Visible = true;
                                }
                                cthy++;
                            }
                        }
                        //  string fsg = "http://www.cathaylist.com/?view=post&postevent=&cityid=" + url + "&lang=en&catid=&subcatid=";

                        if (webBrowser1.Url.ToString() == "http://www.cathaylist.com/?view=post&postevent=&cityid=" + url + "&lang=en&catid=&subcatid=")
                        {
                            webBrowser1.Navigate("http://www.cathaylist.com/?view=post&cityid=" + url + "&lang=en&catid=2&subcatid=6&shortcutregion=");
                        }

                        if (webBrowser1.Url.ToString() == "http://www.cathaylist.com/?view=post&cityid=" + url + "&lang=en&catid=2&subcatid=6&shortcutregion=")
                        {
                            Globaltxtemail.txtemail = comboBox2.Text;
                            circularProgressControl2.Stop();
                            panel2.Visible = false;
                            circularProgressControl2.Visible = false;


                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);

                            IWebSites objClass = new cathaylist();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                            btnpostsubmit.Enabled = true;
                            btnpostsubmit.Visible = true;



                        }
                        string gfg = "http://www.cathaylist.com/index.php?view=post&cityid=" + url + "&lang=en&catid=2&subcatid=6&shortcutregion=&";
                        if (webBrowser1.Url.ToString() == "http://www.cathaylist.com/index.php?view=post&cityid=" + url + "&lang=en&catid=2&subcatid=6&shortcutregion=&")
                        {

                            foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                string InnerTxt = "Back to Home";
                                if (element.OuterText == InnerTxt)
                                {
                                    label29.Font = new System.Drawing.Font("Verdana", 8.0f,
               System.Drawing.FontStyle.Bold);
                                    btnpostsubmit.Enabled = false;
                                    btnuploadtolive.Visible = true;
                                    btnuploadtolive.Enabled = true;
                                }
                            }

                        }

                    }
                    #endregion
                }
                //cathaylist end-------------------------
                if (comboBox1.Text == "www.freeadlists.com")
                {
                    #region www.freeadlists.com
                    btnpostupload.Visible = true;
                    btnpostupload.Enabled = true;

                    this.Opacity = 100;
                    circularProgressControl2.Stop();
                    circularProgressControl2.Visible = false;
                    panel2.Visible = false;
                    this.Refresh();
                    #endregion
                }

                if (comboBox1.Text == "adsriver")
                {
                    #region adsriver
                    //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //int year=obUsedCarsInfo[0].YearOfMake;
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(label10.Text);
                    if (webBrowser1.Url.ToString() == "http://www.adsriver.com/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");
                        //btnpostupload.Visible = true;
                        //btnpostupload.Enabled = true;
                        
                    }
                    if (webBrowser1.Url.ToString() == "http://www.adsriver.com/?view=selectcity&targetview=post&cityid=0&lang=en")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "USA");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.adsriver.com/?view=post&postevent=&cityid=1&lang=en&catid=&subcatid=" || webBrowser1.Url.ToString() == "http://www.adsriver.com/index.php?view=post&cityid=1&lang=en")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Automotive");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.adsriver.com/?view=post&cityid=1&lang=en&catid=1&shortcutregion=")
                    {
                        if (rb_Trucks.Checked || rb_Vans.Checked)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Vans & Trucks ");
                        }
                        else
                        {
                            if (Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString()) > 1991)
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "Cars");
                            }
                            else
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "Other");
                            }
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://www.adsriver.com/?view=post&cityid=1&lang=en&catid=1&subcatid=13&shortcutregion="
                     || webBrowser1.Url.ToString() == "http://www.adsriver.com/?view=post&cityid=1&lang=en&catid=1&subcatid=6&shortcutregion="
                     || webBrowser1.Url.ToString() == "http://www.adsriver.com/?view=post&cityid=1&lang=en&catid=1&subcatid=16&shortcutregion=")
                    {

                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        IWebSites objClass = new Adsriver();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                    }
                    if (webBrowser1.Url.ToString() != "http://www.adsriver.com/?view=post&cityid=1&lang=en&catid=1&subcatid=13&shortcutregion="
                     || webBrowser1.Url.ToString() != "http://www.adsriver.com/?view=post&cityid=1&lang=en&catid=1&subcatid=16&shortcutregion="
                     || webBrowser1.Url.ToString() != "http://www.adsriver.com/?view=post&cityid=1&lang=en&catid=1&subcatid=6&shortcutregion=")
                    {
                        //btnpostsubmit.Enabled = false;
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            string InnerTxt = "Back to Home";
                            if (element.OuterText == InnerTxt)
                            {
                                label29.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                                btnpostsubmit.Visible = false;
                                btnpostsubmit.Enabled = false;
                                btnuploadtolive.Visible = true;
                                btnuploadtolive.Enabled = true;
                            }
                        }
                    }
                    #endregion
                }

                if (comboBox1.Text == "anunico")
                {
                    #region anunico
                    string anuurl = string.Empty;
                    // http://www.anunico.us/post_free_ads_buying_selling_cars_real_estate_jobs.html
                    if (webBrowser1.Url.ToString() == "http://www.anunico.us/post_free_ads_in_united_states.html")
                    {
                        btnpostupload.Visible = true;
                        btnpostupload.Enabled = true;

                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                    }

                    if (webBrowser1.Url.ToString() != "http://www.anunico.us/post_free_ads_in_united_states.html")
                    {
                        string url = webBrowser1.Url.ToString();

                        if (url.Contains("cityid="))
                        {

                            int index1 = url.IndexOf("cityid=");
                            int end1 = url.IndexOf("lang=");
                            anuurl = url.ToString().Substring(index1, end1 - index1);
                            anuurl = anuurl.Replace("cityid=", "");
                            anuurl = anuurl.Replace("&", "");
                        }
                    }
                    string nhh = "http://www.anunico.es/?view=post&cityid=" + anuurl + "&lang=en.us";
                    if (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Vehicles");
                    }

                    if (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8")
                    {

                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);


                        int yearnw = Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString());
                        if (rb_Vans.Checked)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Pickups - Vans");
                        }
                        else if (rb_Trucks.Checked)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Trucks");
                        }
                        else
                        {
                            if (yearnw < 1991)
                            {

                                GeneralFunction.LinkInvoke(webBrowser1, "Collectible - Classic Cars");

                            }
                            else
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "Cars");
                            }
                        }
                    }
                    if ((webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=36")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=37")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=42")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=40"))
                    {
                        btnpostsubmit.Visible = false;
                        btnpostsubmit.Enabled = false;

                        circularProgressControl2.Stop();
                        panel2.Visible = false;
                        circularProgressControl2.Visible = false;



                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);


                        IWebSites objClass = new anunico();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        if (anupic == 0)
                        {
                            anupic++;
                        }
                    }
                    if ((webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=36&adid=&page=&search=&cityname=&")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=36&adid=0&page=0&search=&cityname=&")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=37&adid=&page=&search=&cityname=&")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=37&adid=0&page=0&search=&cityname=&")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=42&adid=&page=&search=&cityname=&")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=42&adid=0&page=0&search=&cityname=&")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=40&adid=&page=&search=&cityname=&")
                     || (webBrowser1.Url.ToString() == "http://www.anunico.us/?view=post&cityid=" + anuurl + "&lang=en.us&catid=8&subcatid=40&adid=0&page=0&search=&cityname=&"))
                    {



                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                            {
                                string InnerTxt = "Back to Home";
                                if (element.OuterText == InnerTxt)
                                {
                                    label29.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                                    ano++;
                                    btnpostsubmit.Enabled = false;
                                    btnuploadtolive.Visible = true;
                                    btnuploadtolive.Enabled = true;

                                }
                                else
                                {


                                }
                            }
                        }


                        if (ano == 1)
                        {
                        }
                        else
                        {
                            if (ano == 0)
                            {
                                MessageBox.Show("Mandatory fields should not leave empty");
                                GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
                                btnpostsubmit.Enabled = true;
                                ano++;
                            }

                        }
                    }
                    #endregion
                }
                if (comboBox1.Text == "classifieds4me")
                {
                    #region classifieds4me
                    string clsurl = string.Empty;
                    if (webBrowser1.Url.ToString() != "http://www.classifieds4me.com/postad/category.aspx")
                    {
                        if (webBrowser1.Url.ToString() != "http://www.classifieds4me.com/select-city.aspx")
                        {
                            string url = webBrowser1.Url.ToString();
                            if (url.Contains("city="))
                            {
                            }
                            else
                            {
                                if (c4mcty == 0)
                                {


                                    circularProgressControl2.Stop();
                                    circularProgressControl2.Visible = false;
                                    panel2.Visible = false;
                                    GeneralFunction.LinkInvoke(webBrowser1, "Select City");



                                    c4mcty++;
                                }
                            }
                        }
                    }


                    if (webBrowser1.Url.ToString() == "http://www.classifieds4me.com/select-city.aspx")
                    {

                        //if (c4cy == 0)
                        //{
                        //    c4cy++;

                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);


                        GeneralFunction.SetDropDownNameandValue(webBrowser1, "ctl00$ContentPlaceHolder1$cboCountry", "124");
                        string state = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
                        GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ContentPlaceHolder1$cboState", state);

                        btnpostupload.Visible = true;
                        btnpostupload.Enabled = true;
                        // }

                    }

                    // http://www.classifieds4me.com/rochester-classified-ads-T12961/

                    //string suburl = webBrowser1.Url.ToString();
                    //if (suburl.Contains("-classified-ads-"))
                    //{
                    //    if (pfc != 0)
                    //    {

                    //        string split = suburl.ToString();
                    //        int index1 = split.IndexOf(".com/");
                    //        int end1 = split.IndexOf("-classified");
                    //        string c4mCity = split.ToString().Substring(index1, end1 - index1);
                    //        c4mCity = c4mCity.Replace(".com/", "");

                    //        string split1 = suburl.ToString();
                    //        int index2 = split1.IndexOf("ads-");
                    //        int end2 = split.Length;
                    //        string c4mCityId = split.ToString().Substring(index2, end2 - index2);
                    //        c4mCityId = c4mCityId.Replace("/", "");
                    //        c4mCityId = c4mCityId.Replace("ads-", "");

                    //        if (webBrowser1.Url.ToString() == "http://www.classifieds4me.com/" + c4mCity + "-classified-ads-" + c4mCityId + "/")
                    //        {
                    //            GeneralFunction.LinkInvoke(webBrowser1, "Post a FREE Classified Ad");

                    //        }



                    //    }

                    //}

                    string suburl = webBrowser1.Url.ToString();
                    if (suburl.Contains("-classified-ads-"))
                    {

                        //{http://www.classifieds4me.com/west-haven-classified-ads-T9336/}

                        //    int index1 = url.IndexOf(".com/");
                        //    int end1 = url.IndexOf("classified");
                        //   string clsurl1 = url.ToString().Substring(index1, end1 - index1);
                        //    clsurl1 = clsurl1.Replace(".com/", "");
                        //    clsurl1 = clsurl1.Replace("classified", "");


                        // int index2 = url.IndexOf("ads-");
                        //    int end2 = url.Length;;
                        //   string code = url.ToString().Substring(index2, end2 - index2);
                        //    code = code.Replace("ads-", "");
                        //    code = code.Replace("/", "");

                        //if(webBrowser1.Url.ToString()=="http://www.classifieds4me.com/"+clsurl1+"-classified-ads-"+code+"/")
                        //{
                        //}

                        //btnpostupload.Visible = true;
                        //btnpostupload.Enabled = true;

                        //GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ContentPlaceHolder1$cboCountry", "United States");

                        //GeneralFunction.SetDropDownNameandValue(webBrowser1, "ctl00$ContentPlaceHolder1$cboState", "525");
                    }

                    if (webBrowser1.Url.ToString() != "http://www.classifieds4me.com/postad/category.aspx")
                    {
                        string url = webBrowser1.Url.ToString();

                        if (url.Contains("city="))
                        {

                            int index1 = url.IndexOf("city=");
                            int end1 = url.IndexOf("&");
                            clsurl = url.ToString().Substring(index1, end1 - index1);
                            clsurl = clsurl.Replace("city=", "");
                            clsurl = clsurl.Replace("&", "");
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifieds4me.com/postad/category.aspx")
                    {
                        circularProgressControl2.Start();
                        circularProgressControl2.Visible = true;
                        panel2.Visible = true;

                        btnpostupload.Enabled = false;
                        GeneralFunction.LinkInvoke(webBrowser1, "Autos");
                    }

                    if (webBrowser1.Url.ToString() == "http://www.classifieds4me.com/postad/subcategory.aspx?city=" + clsurl + "&CatId=Autos")
                    {

                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);

                        int yr = Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString());
                        if (yr < 1991 || rb_Trucks.Checked)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Other: Autos For Sale");
                        }
                        else
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Cars & SUVs");
                        }
                        btnpostupload.Enabled = false;
                    }
                    if ((webBrowser1.Url.ToString() == "http://www.classifieds4me.com/postad/post-ad.aspx?city=" + clsurl + "&cat=Autos&subcat=Cars_SUV") || (webBrowser1.Url.ToString() == "http://www.classifieds4me.com/postad/post-ad.aspx?city=" + clsurl + "&cat=Autos&subcat=Other_Autos"))
                    {

                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        if (cls4me == 0)
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);

                            IWebSites objClass = new classifieds4me();


                            cls4me++;


                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            btnpostsubmit.Visible = true;
                            btnpostsubmit.Enabled = true;

                            label28.Font = new System.Drawing.Font("Verdana", 8.0f,
       System.Drawing.FontStyle.Bold);
                            label28.ForeColor = System.Drawing.Color.Red;
                        }

                    }
                    string url1 = webBrowser1.Url.ToString();
                    if (url1.ToString().Contains("post-ad-success"))
                    {
                        btnpostsubmit.Enabled = false;
                        btnuploadtolive.Visible = true;
                        btnuploadtolive.Enabled = true;
                        label31.Font = new System.Drawing.Font("Verdana", 8.0f,
       System.Drawing.FontStyle.Bold);

                        label31.ForeColor = System.Drawing.Color.Red;

                    }

                    else
                    {

                        //GeneralFunction.FileUploadInvoke(webBrowser1, "ctl00$ContentPlaceHolder1$FileUpload1");
                        //GeneralFunction.FileUploadInvoke(webBrowser1, "ctl00$ContentPlaceHolder1$FileUpload2");
                        //GeneralFunction.FileUploadInvoke(webBrowser1, "ctl00$ContentPlaceHolder1$FileUpload3");
                    }
                    // http://www.classifieds4me.com/postad/post-ad-success.aspx?id=967539
                    #endregion
                }

                if (comboBox1.Text == "myadmonster")
                {
                    #region myadmonster
                    if (webBrowser1.Url.ToString() == "http://www.myadmonster.com/free-ads/postfreead.php")
                    {

                        btnpostupload.Visible = true;
                        btnpostupload.Enabled = true;
                        GeneralFunction.ImgeButtonClickInvoke(webBrowser1, "Click Here To Post A Free Classified Ad");
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                    }
                    if (webBrowser1.Url.ToString() == "http://www.myadmonster.com/free-ads/post_b.php")
                    {

                        if (myads == 0)
                        {
                            GeneralFunction.SetDropDownNameandValue(webBrowser1, "sel_intl_country", "United States");


                            GeneralFunction.SetDropDownNameandValue(webBrowser1, "sel_cat", "Automotive");
                            GeneralFunction.SetDropDownNameandValue(webBrowser1, "sel_duration", "28");

                            GeneralFunction.ButtonClickInvokeValue(webBrowser1, " Continue ");

                            label27.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);

                            label27.ForeColor = System.Drawing.Color.Red;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;

                            btnpostupload.Enabled = false;

                            myads++;
                        }
                        // MessageBox.Show("Please select Continue button");


                    }

                    if (webBrowser1.Url.ToString() == "http://www.myadmonster.com/free-ads/post_c.php")
                    {

                        if (repeat == 0)
                        {
                            //repeat += 1;
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);
                            IWebSites objClass = new myadmonster();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                        }
                        btnpostsubmit.Enabled = true;
                        btnpostsubmit.Visible = true;
                        btnpostupload.Enabled = false;

                    }

                    if (webBrowser1.Url.ToString() != "http://www.myadmonster.com/free-ads/postfreead.php")
                    {
                        if (webBrowser1.Url.ToString() != "http://www.myadmonster.com/free-ads/post_b.php")
                        {
                            if (webBrowser1.Url.ToString() != "http://www.myadmonster.com/free-ads/post_c.php")
                            {
                                ////          foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                                ////{
                                // string InnerTxt = "Cars";
                                ////if (element.OuterHtml == "Click here to view your ad")
                                ////{
                                label29.Font = new System.Drawing.Font("Verdana", 8.0f,System.Drawing.FontStyle.Bold);
                                label29.ForeColor = System.Drawing.Color.Red;
                                btnpostsubmit.Enabled = false;
                                btnuploadtolive.Visible = true;
                                btnuploadtolive.Enabled = true;
                            }
                            // }
                            //  }
                        }
                    }
                    #endregion
                }

                if (comboBox1.Text == "freead1.net")
                {
                    #region freead1.net
                    if (webBrowser1.Url.ToString() == "http://freead1.net/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "POST FREE AD USA");
                    }
                    if (webBrowser1.Url.ToString() == "http://freead1.net/post-free-ad-to-USA-42")
                    {

                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;


                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                        if (fread == 0)
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);

                            IWebSites objClass = new freead1();

                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            fread++;
                        }
                    }

                    string url = webBrowser1.Url.ToString();
                    if (url.Contains("add-success"))
                    {
                        btnpostsubmit.Enabled = false;
                        btnuploadtolive.Visible = true;
                        btnuploadtolive.Enabled = true;
                    }
                    #endregion
                }
                #region old
                //if (comboBox1.Text == "classifiedads")
                //{
                //    if (webBrowser1.Url.ToString() == "http://www.classifiedads.com/post.php")
                //    {
                //        btnpostupload.Visible = true;
                //        btnpostupload.Enabled = true;
                //    }


                //    else if (webBrowser1.Url.ToString() == "http://www.classifiedads.com/post.php")
                //    {
                //        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                //        {
                //            string InnerTxt = "Cars";
                //            if (element.OuterText == InnerTxt)
                //            {
                //                //United States
                //               // GeneralFunction.LinkInvoke(webBrowser1, "Vehicles");
                //                GeneralFunction.LinkInvoke(webBrowser1, "Cars");
                //                //  GeneralFunction.LinkInvoke(webBrowser1, "United States");
                //            }
                //        }
                //    }


                //    else if (webBrowser1.Url.ToString() == "http://www.classifiedads.com/post.php")
                //    {
                //        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                //        {
                //            string InnerTxt = "United States";
                //            if (element.OuterText == InnerTxt)
                //            {
                //                //United States
                //                // GeneralFunction.LinkInvoke(webBrowser1, "Vehicles");
                //               // GeneralFunction.LinkInvoke(webBrowser1, "Cars");
                //                  GeneralFunction.LinkInvoke(webBrowser1, "United States");
                //            }
                //        }
                //    }

                //}
                #endregion
                if (comboBox1.Text == "99localsearch")
                {
                    #region 99localsearch
                    if (webBrowser1.Url.ToString() == "http://www.99localsearch.com/freeclassified.aspx")
                    {

                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        btnpostupload.Visible = true;
                        btnpostupload.Enabled = true;

                    }
                    #endregion
                }
                if (comboBox1.Text == "classifiedads")
                {
                    #region classifiedads
                    if (webBrowser1.Url.ToString() == "http://www.classifiedads.com/")
                    {

                        GeneralFunction.LinkInvokeClsads(webBrowser1, "Post an Ad (free)", "Post an ad (free)");

                    }
                    if (webBrowser1.Url.ToString() == "http://www.classifiedads.com/post.php")
                    {
                        if (cads == 0)
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            //btnpostupload.Visible = true;
                            //btnpostupload.Enabled = true;
                            //btnpostsubmit.Visible = true;
                            //btnpostsubmit.Enabled = true;
                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);
                            IWebSites objClass = new ClassifiedAdds();
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            cads++;
                        }
                        if (cads == 1)
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);

                            IWebSites objClass = new ClassifiedAdds();

                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            cads++;
                        }
                        if (cads == 2)
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);

                            IWebSites objClass = new ClassifiedAdds();

                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            cads++;
                        }
                        if (cads == 3)
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);

                            IWebSites objClass = new ClassifiedAdds();

                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);


                            GeneralFunction.FileUploadInvoke(webBrowser1, "uploadedfile");
                            //GeneralFunction.FileUploadInvoke(webBrowser1, "uploadedfile");
                            //GeneralFunction.FileUploadInvoke(webBrowser1, "uploadedfile");
                            cads++;

                            btnpostsubmit.Visible = true;
                            btnpostsubmit.Enabled = true;
                        }
                        //if (cads == 4)
                        //{
                        //    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                        //    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        //    obUsedCarsInfo = objService.FindCarID(label10.Text);

                        //    IWebSites objClass = new ClassifiedAdds();

                        //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);
                        //    cads++;
                        //}



                    }
                    if (webBrowser1.Url.ToString() != "http://www.classifiedads.com/post.php")
                    {
                        string urltst = webBrowser1.Url.ToString();

                        if (urltst.Contains(".htm"))
                        {
                            label29.Font = new System.Drawing.Font("Verdana", 8.0f, System.Drawing.FontStyle.Bold);
                            label29.ForeColor = System.Drawing.Color.Red;
                            btnuploadtolive.Enabled = true;
                            btnuploadtolive.Visible = true;
                            btnpostsubmit.Enabled = false;


                        }
                    }
                    #endregion
                }
                if (comboBox1.Text == "facebook")
                {
                    #region facebook
                    if (webBrowser1.Url.ToString() == "https://www.facebook.com/login.php?next=https://www.facebook.com/messages/")
                    {
                        btnpostupload.Enabled = true;
                        btnpostupload.Visible = true;

                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);

                        IWebSites objClass = new FaceBook();

                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    }
                    // if (webBrowser1.Url.ToString() == "https://www.facebook.com/messages/")
                    //{
                    //    GeneralFunction.LinkInvoke(webBrowser1, "Home");
                    // }
                    if (webBrowser1.Url.ToString() == "https://www.facebook.com/messages/")
                    {
                        GeneralFunction.LinkInvokeDiv(webBrowser1, "menuPulldown", "Account Settings");
                        GeneralFunction.LinkInvokeDiv(webBrowser1, "navSubmenuName ellipsis", "UCE - Test");
                    }
                    if (webBrowser1.Url.ToString() == "https://www.facebook.com/pages/UCE-Test/637729332928509?ref=hl")
                    {
                        //   GeneralFunction.ImgeButtonClickFB(webBrowser1);
                    }
                    //if (webBrowser1.Url.ToString() == "https://www.facebook.com/?ref=tn_tnmn")
                    //{
                    //    GeneralFunction.LinkInvokeDiv(webBrowser1, "linkWrap noCount", "United Car Exchange");
                    //}
                    if (webBrowser1.Url.ToString() == "https://www.facebook.com/pages/United-Car-Exchange/321065371264090")
                    {
                        GeneralFunction.LinkInvokeFB(webBrowser1, "uiIconText _51z7");
                    }
                    if (webBrowser1.Url.ToString() == "https://www.facebook.com/pages/United-Car-Exchange/321065371264090")
                    {
                        GeneralFunction.LinkInvokeFBInnerDiv(webBrowser1, "Create Photo Album");
                    }
                    if (webBrowser1.Url.ToString() == "https://www.facebook.com/pages/United-Car-Exchange/321065371264090#!/albums/create.php?id=321065371264090&error=3")
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        string title = obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString();
                        GeneralFunction.SetTextvaluebyName(webBrowser1, "name", title);
                        string location = obUsedCarsInfo[0].State.ToString() + " " + obUsedCarsInfo[0].City.ToString() + " " + obUsedCarsInfo[0].Zip.ToString();
                        GeneralFunction.SetTextvaluebyName(webBrowser1, "location", location);
                        GeneralFunction.ButtonClickBody(webBrowser1, "button");
                    }
                    if (webBrowser1.Url.ToString() == "https://www.facebook.com/pages/United-Car-Exchange/321065371264090?id=321065371264090&sk=photos_stream")
                    {

                        GeneralFunction.LinkInvokeFB(webBrowser1, "fbPhotosRedesignNavSubtitle");

                    }



                    //if (webBrowser1.Url.ToString() == "https://www.facebook.com/media/set/edit/a.581830711854220.1073743406.321065371264090/")
                    //{
                    //https://www.facebook.com/media/upload/photos/simple/?set=a.582546955115929.1073743487.321065371264090

                    string sburl = webBrowser1.Url.ToString();
                    if (sburl.Contains("set"))
                    {
                        // foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("input"))
                        //{
                        string InnerTxt = "Add Date";
                        //    if (element.OuterText == InnerTxt)
                        //  {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        //IWebSites objClass = new FaceBook();

                        //objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);

                        string title = obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString();
                        string dep = obUsedCarsInfo[0].Description.ToString();
                        GeneralFunction.SetDivValuebyInnerText(webBrowser1, "inputtext _5eln photoAlbumTitleInput DOMControl_placeholder", title);
                        string location = obUsedCarsInfo[0].State.ToString() + " " + obUsedCarsInfo[0].City.ToString() + " " + obUsedCarsInfo[0].Zip.ToString();
                        GeneralFunction.SetTextvaluebyName(webBrowser1, "location", location);


                        GeneralFunction.SetMultiTextName(webBrowser1, "desc_text", dep);

                        //GeneralFunction.ButtonClickBody(webBrowser1, "button");



                        // }
                        // }
                    }
                    #endregion
                }
                if (comboBox1.Text == "pinterest")
                {
                    #region pinterest
                    if (webBrowser1.Url.ToString() == "https://www.pinterest.com/")
                    {
                        foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("a"))
                        {
                            string InnerTxt = "Log in now";
                            if (element.OuterText == InnerTxt)
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "Log in now");
                            }
                        }
                    }
                    else if (webBrowser1.Url.ToString() == "https://www.pinterest.com/login/")
                    {

                        GeneralFunction.SetTextValue(webBrowser1, "username_or_email", "vinayy5544@gmail.com");
                        GeneralFunction.SetTextValue(webBrowser1, "password", "vinayy12345");

                        GeneralFunction.LinkInvokeFB(webBrowser1, "buttonText");//epage
                    }

                    else if (webBrowser1.Url.ToString() == "http://www.pinterest.com/")
                    {

                        GeneralFunction.LinkInvokeFB(webBrowser1, "profileName");//epage

                        //GeneralFunction.LinkInvoke(webBrowser1, "                                            Your Boards");

                        GeneralFunction.Linkhref(webBrowser1, "/vinayy5544/boards/");

                        // GeneralFunction.LinkInvokeCollectorCarsPic(webBrowser1);

                        webBrowser1.Navigate("http://www.pinterest.com/vinayy5544/boards/");
                    }
                    
                    ////
                    ////MODIFIED
                    ////

                    else if (webBrowser1.Url.ToString() == "http://www.pinterest.com/vinayy5544/boards/" || webBrowser1.Url.ToString() == "http://www.pinterest.com/vinayy5544/boards/#")
                    {

                        if (pnt == 0)
                        {
                            // GeneralFunction.LinkInvoke(webBrowser1, "Create a board");
                            // GeneralFunction.LinkInvokeCollectorCarsPic(webBrowser1);

                            GeneralFunction.LinkInvokepintrest(webBrowser1, "BoardCreateRep Module");
                            btnpostupload.Visible = true;
                            btnpostupload.Enabled = true;
                            circularProgressControl2.Stop();
                            circularProgressControl2.Visible = false;
                            panel2.Visible = false;
                            pnt++;
                        }
                    }
                    //        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    //        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //        obUsedCarsInfo = objService.FindCarID(label10.Text);

                    //        IWebSites objClass = new Pintrest();

                    //        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    //        circularProgressControl2.Stop();
                    //        circularProgressControl2.Visible = false;
                    //        panel2.Visible = false;
                    //    }

                    //}
                    
                    #endregion
                }
                if (comboBox1.Text == "hot9ads")
                {
                    #region hot9ads
                    if (webBrowser1.Url.ToString() == "http://www.hot9ads.com/")
                    {
                        this.Opacity = 100;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        this.Refresh();


                        GeneralFunction.LinkInvoke(webBrowser1, "Register for a free account");
                    }

                    if (webBrowser1.Url.ToString() == "http://www.hot9ads.com/user/register")
                    {
                        //webBrowser1.Navigate("http://www.hot9ads.com/");

                        GeneralFunction.SetTextValue(webBrowser1, "s_email", comboBox2.Text);
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);

                        IWebSites objClass = new Hot9Ads();

                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                        ht9++;

                    }

                    if (webBrowser1.Url.ToString() == "http://www.hot9ads.com/")
                    {
                        if (ht9 == 1)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Publish your ad for free");
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://www.hot9ads.com/item/new")
                    {

                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);

                        IWebSites objClass = new Hot9Ads();

                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);

                        btnpostsubmit.Visible = true;
                        btnpostsubmit.Enabled = true;
                    }

                    if (webBrowser1.Url.ToString() == "http://www.hot9ads.com/index.php")
                    {
                        //  GeneralFunction.LinkInvoke(webBrowser1, "Login");

                        MessageBox.Show("You have already registerd with this emailid.Change the emailid and post again");




                    }
                    //if (webBrowser1.Url.ToString() == "http://www.hot9ads.com/user/login")
                    //{
                    //    GeneralFunction.SetTextValue(webBrowser1, "s_email", comboBox2.Text);
                    //    GeneralFunction.SetTextValue(webBrowser1, "s_password", "UCEURV123");
                    //    GeneralFunction.ButtonClickBody(webBrowser1, "submit");
                    //}
                    #endregion
                }
                if (comboBox1.Text == "75vn")
                {
                    #region 75vn
                    if (webBrowser1.Url.ToString() == "http://www.75vn.com/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Login");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.75vn.com/member/login.php")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Create seller account (Free)");
                    }

                    if (webBrowser1.Url.ToString() == "http://www.75vn.com/member/create.php")
                    {
                        Globaltxtemail.txtemail = comboBox2.Text;
                        Globalpwd.pwd = textBox2.Text;

                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);

                        IWebSites objClass = new Vn75();

                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);


                        this.Opacity = 100;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        this.Refresh();
                    }

                    if (webBrowser1.Url.ToString() == "http://www.75vn.com/mod.php")
                    {


                        this.Opacity = 100;
                        circularProgressControl2.Start();
                        circularProgressControl2.Visible = true;
                        panel2.Visible = true;
                        this.Refresh();
                        GeneralFunction.LinkInvoke(webBrowser1, "Place an ad");


                    }
                    if (webBrowser1.Url.ToString() == "http://www.75vn.com/post.php")
                    {

                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);



                        int year = Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString());
                        if (rb_Trucks.Checked)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "SELL YOUR COMMERCIAL TRUCK - Click Here");
                        }
                        else
                        {
                            if (year < 1990)
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "SELL YOUR CLASSIC CAR - Click Here");
                            }
                            else
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "SELL YOUR CAR - Click Here");
                            }
                        }
                    }
                    if ((webBrowser1.Url.ToString() == "http://www.75vn.com/auto/place_ad.php?TypeItem=35") || (webBrowser1.Url.ToString() == "http://www.75vn.com/car/place_ad.php?TypeItem=32") || (webBrowser1.Url.ToString() == "http://www.75vn.com/truck/place_ad.php?TypeItem=31"))
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);

                        IWebSites objClass = new Vn75();

                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);



                        GeneralFunction.ButtonClickInvoke(webBrowser1, "btn_Add");


                    }


                    if (webBrowser1.Url.ToString().Contains("&IDProduct="))
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "UPLOAD PHOTOS");


                        this.Opacity = 100;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        this.Refresh();

                    }

                    if (webBrowser1.Url.ToString().Contains("http://www.75vn.com/auto/") || webBrowser1.Url.ToString().Contains("http://www.75vn.com/truck/") || webBrowser1.Url.ToString().Contains("http://www.75vn.com/car/"))
                    {
                        if (webBrowser1.Url.ToString().Contains("IDProduct="))
                        {

                            btnuploadtolive.Enabled = true;
                            btnuploadtolive.Visible = true;
                            //Log Out  http://www.75vn.com/car/display_ad.php?TypeItem=32&IDProduct=40649

                        }
                    }
                    #endregion
                }

                if (comboBox1.Text == "adpost us")
                {
                    #region adpost us
                    if (webBrowser1.Url.ToString() == "http://www.adpost.com/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "United States");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.adpost.com/us/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.adpost.com/us/?website=&language=&session_key=&place_front_page=on")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Vehicles");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.adpost.com/us/?db=us_vehicles&website=&language=&session_key=&add_item_button=on")
                    {
                        //GeneralFunction.LinkInvoke(webBrowser1, "Click here to Register now!");
                        GeneralFunction.SetTextValue(webBrowser1, "auth_user_name", "IL54545");
                        GeneralFunction.SetTextValue(webBrowser1, "auth_password1", Globalpwd.pwd);
                    }
                    if ((webBrowser1.Url.ToString() ==
                        "http://www.adpost.com/us/?&db=us_vehicles&session_key=&add_item_button=on&language=&website=&auth_register_screen_op=on&")
                     || (webBrowser1.Url.ToString() ==
                     "http://www.adpost.com/us/?&add_item_button=on&website=&db=us_vehicles&session_key=&language=&auth_register_screen_op=on&"))
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        IWebSites objClass = new adpost_us();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        this.Opacity = 100;
                        circularProgressControl2.Stop();
                        circularProgressControl2.Visible = false;
                        panel2.Visible = false;
                        this.Refresh();
                        btnpostupload.Enabled = true;
                        btnpostupload.Visible = true;
                        if (adp == 0)
                        {
                            adp++;
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://www.adpost.com/us/")
                    {
                        //if (adp == 1)
                        //{
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        IWebSites objClass = new adpost_us();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        //}
                    }
                    #endregion
                }
                if (comboBox1.Text == "webcosmo")
                {
                    #region webcosmo

                    GeneralFunction.SetDropDownNameandValue(webBrowser1, "ctl00$cphContent$ddlCountry", "1");
                    GeneralFunction.SetDropDownNameandValue(webBrowser1, "ctl00$cphContent$ddlGenre", "4");
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(label10.Text);
                    IWebSites objClass = new WebCosmo();
                    if (webBrowser1.Url.ToString().Contains("PostListing.aspx") && webBrowser1.Url.ToString().Contains("countryId=1&stateId="))
                    {
                        if (a)
                        {
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            a = false;
                            //GeneralFunction.ButtonClickInvoke(webBrowser1, "ctl00$cphContent$btnSubmit");

                        }
                        else if (webBrowser1.DocumentText.ToString().Contains("Duplicate posting"))
                        {
                            MessageBox.Show("Carid once posted in this site is not allowed to post again within 24 Hours");
                        }


                    }
                    else if (webBrowser1.Url.ToString().Contains("PostReview.aspx") && webBrowser1.Url.ToString().Contains("countryId=1&stateId=") || webBrowser1.Url.ToString().Contains("countryid=1&stateid="))
                    {
                        btnpostupload.Visible = false;
                        btnpostupload.Enabled = false;
                        btnpostsubmit.Enabled = true;
                        btnpostsubmit.Visible = true;
                    }
                    circularProgressControl2.Stop();
                    btnpostupload.Visible = true;
                    btnpostupload.Enabled = true;


                    #endregion
                }
                if (comboBox1.Text == "tumblr")
                {
                    #region tumblr

                    if (webBrowser1.Url.ToString() == "https://www.tumblr.com/login?redirect_to=%2Fnew%2Ftext")
                    {
                        GeneralFunction.ButtonClickInvoke(webBrowser1, "user[email]");
                        GeneralFunction.ButtonClickInvoke(webBrowser1, "user[password]");
                    }
                    else if (webBrowser1.Url.ToString() == "http://www.tumblr.com/dashboard")
                    {
                        GeneralFunction.LinkhrefForTumbler(webBrowser1, "new_post_label_text");

                    }
                    else if (webBrowser1.Url.ToString() == "http://www.tumblr.com/new/text?redirect_to=/dashboard"
                          || webBrowser1.Url.ToString() == "http://www.tumblr.com/new/text")
                    {

                        //Add car Details Title,Description
                        GeneralFunction.SetTextValue(webBrowser1, "post[one]", "Hello");
                        GeneralFunction.SetMultiTextValue(webBrowser1, "post[two]", "Hello Description");
                        //Should Add Images Manually
                        GeneralFunction.ButtonClick(webBrowser1, "submit");
                    }
                    #endregion
                }
                if (comboBox1.Text == "cargurus")
                {
                    #region cargurus
                    
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(label10.Text);
                    IWebSites objClass = new WebCosmo();
                    string username = comboBox2.Text; ;
                    Char[] seprt = { '@' };
                    string[] splitemail = username.Split(seprt);
                    username = splitemail[0].ToString();
                    if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (webBrowser1.Url.ToString() == "http://www.cargurus.com/")
                        {
                            ucount++;
                            GeneralFunction.spanLinkInvoke(webBrowser1, "Register");
                        }
                        if (webBrowser1.Url.ToString() == "http://www.cargurus.com/")
                        {
                            if (ucount > 1)
                            {
                                foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName("span"))
                                {
                                    if (element.InnerText.Trim() == "Sell Your Car")
                                    {
                                        GeneralFunction.spanLinkInvoke1(webBrowser1, "Sell Your Car");
                                        ucount--;
                                        return;
                                    }
                                }
                            }
                        }
                        if (webBrowser1.Url.ToString() == "https://www.cargurus.com/Cars/authentication/renderRegistrationForm.action?redirectUrl=/Cars/index.html&cgLocale=en")
                        {
                            GeneralFunction.SetTextValue(webBrowser1, "person.screenName", username);
                            GeneralFunction.SetTextValue(webBrowser1, "person.password", textBox2.Text);
                            GeneralFunction.SetTextValue(webBrowser1, "person.email", comboBox2.Text);
                            GeneralFunction.ButtonClickInvokeInnerText1(webBrowser1, "Register");
                        }
                        if (webBrowser1.Url.ToString() == "http://www.cargurus.com/Cars/sell-car/")
                        {
                            GeneralFunction.SetTextValue(webBrowser1, "zip", obUsedCarsInfo[0].Zip.ToString());
                            GeneralFunction.ButtonClickInvokeInnerText1(webBrowser1, "Get Started");
                        }
                        if (webBrowser1.Url.ToString() == "http://www.cargurus.com/Cars/sell-car/createAd.action?zip=" + obUsedCarsInfo[0].Zip.ToString())
                        {
                            SelectOption(webBrowser1, obUsedCarsInfo[0].Make.ToString(), "ign-makerId-selectedEntity");
                            SelectOption(webBrowser1, obUsedCarsInfo[0].Model.ToString(), "ign-modelId-selectedEntity");
                            //SelectOption(webBrowser1, obUsedCarsInfo[0].YearOfMake.ToString(), "ign-carId-selectedEntity");
                            //SelectOption(webBrowser1, obUsedCarsInfo[0].Transmission.ToString(), "selectedTransmission");
                            //GeneralFunction.SetTextValue(webBrowser1, "exteriorColor", obUsedCarsInfo[0].ExteriorColor.ToString());
                            //GeneralFunction.SetTextValue(webBrowser1, "interiorColor", obUsedCarsInfo[0].InteriorColor.ToString());
                            //GeneralFunction.SetTextValue(webBrowser1, "vin", obUsedCarsInfo[0].VIN.ToString());
                            IWebSites ob = new cargurus();
                            ob.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            
                        }
                        if (webBrowser1.Url.ToString().Contains("addPhotos.action") && webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {
                            ucount1++;
                        }
                        if (webBrowser1.Url.ToString().Contains("addPhotos.action") && webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                        {
                            if (ucount1 == 1)
                            {
                                //for (int i = 0; i < 3; i++)
                                //{
                                GeneralFunction.FileUploadInvoke(webBrowser1, "file");
                                GeneralFunction.FileUploadInvoke(webBrowser1, "file");
                                //GeneralFunction.FileUploadInvoke(webBrowser1, "file");
                                //}
                                ucount1++;
                                //GeneralFunction.ButtonClickByValue(webBrowser1, "Finish");
                                btnpostsubmit.Enabled = true;
                                btnpostsubmit.Visible = true;
                            }
                            
                        }
                        if (webBrowser1.Url.ToString().Contains("viewGarage.action"))
                        {
                            btnpostsubmit.Visible = false;
                            btnpostsubmit.Enabled = false;
                            btnuploadtolive.Enabled = true;
                            btnuploadtolive.Visible = true;
                            //GeneralFunction.LinkInvoke(webBrowser1, "Sign out");
                            //circularProgressControl2.Stop();
                            //btnpostupload.Visible = true;
                            //btnpostupload.Enabled = true;
                        }

                       
                    }
                    #endregion
                }
                if (comboBox1.Text == "soavo")
                {
                    #region soavo
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (webBrowser1.Url.ToString() == "http://www.soavo.com/user/register")
                        {
                            string username = comboBox2.Text;
                            string mail = comboBox2.Text;
                            Char[] seprt = { '@' };
                            string[] splitemail = username.Split(seprt);
                            username = splitemail[0].ToString();
                            GeneralFunction.SetTextValue(webBrowser1, "s_name", username);
                            GeneralFunction.SetTextValue(webBrowser1, "s_password", "UCEURV123");
                            GeneralFunction.SetTextValue(webBrowser1, "s_password2", "UCEURV123");
                            GeneralFunction.SetTextValue(webBrowser1, "s_email", mail);
                            Txt_Url.Visible = true;
                            Navigate_btn.Visible = true;
                        }
                        if (webBrowser1.Url.ToString() == "http://www.soavo.com/")
                        {
                            Txt_Url.Visible = false;
                            Navigate_btn.Visible = false;
                            GeneralFunction.LinkInvoke(webBrowser1, "Publish your ad for free");
                        }
                        if (webBrowser1.Url.ToString() == "http://www.soavo.com/item/new")
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);
                            IWebSites objClass = new soavo();
                            GeneralFunction.SetDropDownNameandValue(webBrowser1, "select_1", "100");
                            if (rb_Trucks.Checked || rb_Vans.Checked)
                            {
                                GeneralFunction.SetDropDownNameandValue(webBrowser1, "select_2", "143");
                            }
                            else if (Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString())<1991)
                            {
                                GeneralFunction.SetDropDownNameandValue(webBrowser1, "select_2", "144");
                            }
                            else
                            {
                                GeneralFunction.SetDropDownNameandValue(webBrowser1, "select_2", "140");
                            }
                            objClass.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
                            SelectOption(webBrowser1, statename, "regionId");
                            string city = obUsedCarsInfo[0].City.ToString();
                            SelectOption(webBrowser1, city, "cityId");
                            string cityarea = city + "," + obUsedCarsInfo[0].State.ToString() + obUsedCarsInfo[0].Zip.ToString();
                            GeneralFunction.SetTextValue(webBrowser1, "cityArea", cityarea);
                            GeneralFunction.SetTextValue(webBrowser1, "address", cityarea);
                            btnpostsubmit.Visible = true;
                            btnpostsubmit.Enabled = true;
                        }
                        if (webBrowser1.Url.ToString() == "http://www.soavo.com/vehicles/cars")
                        {
                            btnpostsubmit.Visible = false;
                            btnpostsubmit.Enabled = false;
                            btnuploadtolive.Enabled = true;
                            btnuploadtolive.Visible = true;
                            GeneralFunction.LinkInvoke(webBrowser1, "Logout");
                        }
                        
                    }
                    #endregion
                }
                if (comboBox1.Text == "web-free-ads" || comboBox1.Text == "webfreeads")
                {
                    #region webfreeads
                    
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (webBrowser1.Url.ToString() == "http://web-free-ads.com/index.php?view=post&cityid=1&lang=en")
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Change");
                        }
                        if (webBrowser1.Url.ToString() == "http://web-free-ads.com/?view=selectcity&targetview=post")
                        {
                            //string url = "";
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);
                            string state = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State, "1");
                            GeneralFunction.LinkInvoke(webBrowser1, state);
                            foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("a"))
                            {
                                if (el.InnerText == state)
                                {
                                    url = el.GetAttribute("href").ToString();
                                    url = url.Substring(url.IndexOf("cityid"));
                                    url = url.Replace("cityid=", "");
                                    url = url.Substring(0, url.IndexOf("&"));
                                }
                            }
                            
                        }
                        if (webBrowser1.Url.ToString() == "http://web-free-ads.com/?view=post&postevent=&cityid="+url+"&lang=en&catid=&subcatid=")
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Automotive");
                        }
                        if (webBrowser1.Url.ToString() == "http://web-free-ads.com/?view=post&cityid=" + url + "&lang=en&catid=8&shortcutregion=")
                        {
                            if(rb_Trucks.Checked || rb_Vans.Checked)
                                GeneralFunction.LinkInvoke(webBrowser1, "Vans & Commercial");
                            else
                                GeneralFunction.LinkInvoke(webBrowser1, "Cars");
                        }
                        if (webBrowser1.Url.ToString() == "http://web-free-ads.com/?view=post&cityid=" + url + "&lang=en&catid=8&subcatid=3&shortcutregion="
                         || webBrowser1.Url.ToString() == "http://web-free-ads.com/?view=post&cityid=" + url + "&lang=en&catid=8&subcatid=9&shortcutregion=")
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);
                            IWebSites obwebfreeads = new webfreeads();
                            obwebfreeads.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                            GeneralFunction.SetTextValue(webBrowser1, "email", comboBox2.Text);
                            GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
                            GeneralFunction.CheckedInvoke(webBrowser1, "agree");
                            //GeneralFunction.RadioSetValue(webBrowser1, "agree", "1");
                            btnpostsubmit.Visible = true;
                            btnpostsubmit.Enabled = true;
                        }
                        if (webBrowser1.Url.ToString() == "http://web-free-ads.com/index.php?view=post&cityid=" + url + "&lang=en&catid=8&subcatid=3&shortcutregion=&"
                         || webBrowser1.Url.ToString() == "http://web-free-ads.com/index.php?view=post&cityid=" + url + "&lang=en&catid=8&subcatid=9&shortcutregion=&")
                        {
                            btnpostsubmit.Visible = false;
                            btnpostsubmit.Enabled = false;
                            btnuploadtolive.Enabled = true;
                            btnuploadtolive.Visible = true;
                        }
                    }
                   
                    #endregion
                }
                if (comboBox1.Text == "blackworld")
                {
                    #region blackworld
                    if (webBrowser1.Url.ToString() == "http://classifieds.blackworld.com/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");
                    }
                    if (webBrowser1.Url.ToString() == "http://classifieds.blackworld.com/index.php?view=post&cityid=1&lang=en")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Auto Sales & Car Accessories");
                    }
                    if (webBrowser1.Url.ToString() == "http://classifieds.blackworld.com/?view=post&cityid=1&lang=en&catid=4")
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        if (rb_Trucks.Checked)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Trucks & Heavy Vehicles");
                        }
                        else if (obUsedCarsInfo[0].Price < 2000)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Autos under $2000");
                        }
                        else if (obUsedCarsInfo[0].Price > 2000 && obUsedCarsInfo[0].Price < 10000)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Autos $2000 to $10000");
                        }
                        else if (obUsedCarsInfo[0].Price > 10000)
                        {
                            GeneralFunction.LinkInvoke(webBrowser1, "Autos $10000 upwards");
                        }
                    }
                    if (webBrowser1.Url.ToString() == "http://classifieds.blackworld.com/?view=post&cityid=1&lang=en&catid=4&subcatid=29"
                        || webBrowser1.Url.ToString() == "http://classifieds.blackworld.com/?view=post&cityid=1&lang=en&catid=4&subcatid=28"
                        || webBrowser1.Url.ToString() == "http://classifieds.blackworld.com/?view=post&cityid=1&lang=en&catid=4&subcatid=30"
                        || webBrowser1.Url.ToString() == "http://classifieds.blackworld.com/?view=post&cityid=1&lang=en&catid=4&subcatid=31")
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        IWebSites obblackworld = new classifieds_blackworld();
                        obblackworld.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        GeneralFunction.SetTextValue(webBrowser1, "email", comboBox2.Text);
                        GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
                        GeneralFunction.RadioSetValue(webBrowser1, "agree", "1");
                    }
                    #endregion
                }
                if (comboBox1.Text == "extraclassifieds")
                {
                    #region extraclassifieds
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (webBrowser1.Url.ToString() == "http://extraclassifieds.com/")
                        {
                            eccount++;
                            if (eccount < 3)
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "Register a free account");
                                if (webBrowser1.DocumentText.Contains("<div id=\"flashmessage\" class=\"flashmessage flashmessage-ok\">"))
                                {
                                    Txt_Url.Visible = true;
                                    Navigate_btn.Visible = true;
                                }
                            }
                            if (eccount >= 3)
                            {
                                GeneralFunction.LinkInvoke(webBrowser1, "Publish your ad for free");
                            }
                        }
                        if (webBrowser1.Url.ToString() == "http://extraclassifieds.com/user/register")
                        {
                            string username = comboBox2.Text;
                            string mail = comboBox2.Text;
                            Char[] seprt = { '@' };
                            string[] splitemail = username.Split(seprt);
                            username = splitemail[0].ToString();
                            GeneralFunction.SetTextValue(webBrowser1, "s_name", username);
                            GeneralFunction.SetTextValue(webBrowser1, "s_password", "UCEURV123");
                            GeneralFunction.SetTextValue(webBrowser1, "s_password2", "UCEURV123");
                            GeneralFunction.SetTextValue(webBrowser1, "s_email", comboBox2.Text);
                        }
                        //Register a free account
                        #region old
                        
                        if (webBrowser1.Url.ToString() == "http://extraclassifieds.com/item/new")
                        {
                            //GeneralFunction.SetDropDownValue(webBrowser1, "catId", "  Cars");
                            if (rb_Trucks.Checked || rb_Vans.Checked)
                            {
                                SelectOption(webBrowser1, "  Vans, Trucks, Commercial Vehicles", "catId");
                            }
                            else
                            {
                                SelectOption(webBrowser1, "  Cars", "catId");
                            }
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(label10.Text);
                            IWebSites obextraclassifieds = new extraclassifieds();
                            obextraclassifieds.carpostfunc(webBrowser1, obUsedCarsInfo, true);

                            GeneralFunction.SetTextValue(webBrowser1, "contactEmail", comboBox2.Text);
                            GeneralFunction.SetTextValue(webBrowser1, "contactName", "UCEURVE");
                            SelectOption(webBrowser1, "United States", "countryId");
                            GeneralFunction.SetTextValue(webBrowser1, "city", obUsedCarsInfo[0].City);
                            GeneralFunction.SetTextValue(webBrowser1, "cityArea", obUsedCarsInfo[0].Phone);
                            //GeneralFunction.FileUploadInvoke(webBrowser1, "photos[]");
                            //GeneralFunction.FileUploadInvoke(webBrowser1, "photos[]");
                            btnpostsubmit.Enabled = true;
                            btnpostsubmit.Visible = true;
                        }
                        if (webBrowser1.Url.ToString() == "http://extraclassifieds.com/cars-vehicles/cars")
                        {
                            btnpostsubmit.Enabled = false;
                            btnpostsubmit.Visible = false;
                            btnuploadtolive.Enabled = true;
                            btnuploadtolive.Visible = true;
                        }
                        #endregion
                    }
                    #endregion
                }
                if (comboBox1.Text == "meetpark")
                {
                    #region meetpark
                    
                    string newurl = webBrowser1.Url.ToString();
                    if (newurl.Contains("cityid"))
                    {
                        newurl = newurl.Substring(newurl.IndexOf("cityid"));
                        newurl = newurl.Substring(newurl.IndexOf("="), newurl.IndexOf("&") - newurl.IndexOf("="));
                        newurl = newurl.Replace("=", "").Trim();
                    }
                    else if (newurl.Contains(sname))
                    {
                        newurl = Regex.Replace(newurl, @"[^0-9]", "");
                    }
                    #region new
                    if (webBrowser1.Url.ToString() == "http://www.meetpark.com/")
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        sname = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), label10.Text);
                        GeneralFunction.LinkInvoke(webBrowser1, sname);
                    }
                    if (webBrowser1.Url.ToString() == "http://www.meetpark.com/" + newurl + "-" + sname + "/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");
                    }
                    else if (webBrowser1.Url.ToString() == "http://www.meetpark.com/index.php?view=post&cityid=" + newurl + "&lang=en")
                    {
                        //GeneralFunction.LinkInvoke(webBrowser1, "Change");
                        GeneralFunction.LinkInvoke(webBrowser1, "For Sale");
                    }
                    else if (webBrowser1.Url.ToString() == "http://www.meetpark.com/?view=post&cityid=" + newurl + "&lang=en&catid=4&shortcutregion=")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "cars+trucks");
                    }
                    //else if (webBrowser1.Url.ToString() == "http://www.meetpark.com/?view=selectcity&targetview=post&cityid=0&lang=en"
                    //  || webBrowser1.Url.ToString() == "http://www.meetpark.com/?view=selectcity&targetview=post")
                    //{
                    //    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    //    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    //    obUsedCarsInfo = objService.FindCarID(label10.Text);
                    //    sname = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), label10.Text);
                    //    GeneralFunction.LinkInvoke(webBrowser1, sname);
                    //}
                    //else if (webBrowser1.Url.ToString() == "http://www.meetpark.com/?view=post&postevent=&cityid=" + newurl + "&lang=en&catid=&subcatid=")
                    //{
                    //    GeneralFunction.LinkInvoke(webBrowser1, "For Sale");
                    //}
                    
                    else if (webBrowser1.Url.ToString() == "http://www.meetpark.com/?view=post&cityid=" + newurl + "&lang=en&catid=4&subcatid=56&shortcutregion=")
                    {
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        IWebSites obmeetpark = new meetpark();
                        obmeetpark.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                        GeneralFunction.SetTextValue(webBrowser1, "email", comboBox2.Text);//obUsedCarsInfo[0].Email;
                        GeneralFunction.CheckedInvoke(webBrowser1, "agree");
                    }
                    #endregion
                    btnpostsubmit.Enabled = true;
                    btnpostsubmit.Visible = true;
                    #endregion
                }
                if (comboBox1.Text == "webleeg")
                {
                    #region webleeg
                    if (webBrowser1.Url.ToString() == "http://www.webleeg.com/register.php")
                    {
                        string username = comboBox2.Text;
                        string mail = comboBox2.Text;
                        Char[] seprt = { '@' };
                        string[] splitemail = username.Split(seprt);
                        username = splitemail[0].ToString();
                        GeneralFunction.SetTextValue(webBrowser1, "c[email]", mail);
                        GeneralFunction.SetTextValue(webBrowser1, "c[email_verifier]", mail);
                        GeneralFunction.SetTextValue(webBrowser1, "c[username]", username);
                        GeneralFunction.SetTextValue(webBrowser1, "c[password]", "UCEURV123");
                        GeneralFunction.SetTextValue(webBrowser1, "c[password_confirm]", "UCEURV123");
                        GeneralFunction.RadioSetValue(webBrowser1, "c[agreement]", "yes");
                        GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.webleeg.com/register.php?b=1")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "CLICK HERE");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.webleeg.com/")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "Post Ad");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.webleeg.com/index.php?a=4")
                    {
                        GeneralFunction.LinkInvoke(webBrowser1, "New Classified");
                    }
                    if (webBrowser1.Url.ToString() == "http://www.webleeg.com/index.php?a=cart&action=new&main_type=classified")
                    {
                        GeneralFunction.RadioSetValue(webBrowser1, "b[leveled][cat][1]", "304");
                        GeneralFunction.SetDropDownNameandValue(webBrowser1, "select", "360");
                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                        obUsedCarsInfo = objService.FindCarID(label10.Text);
                        IWebSites obwebleeg = new webleeg();
                        obwebleeg.carpostfunc(webBrowser1, obUsedCarsInfo, rb_Trucks.Checked);
                    }
                    #endregion
                }
                //    btnpostupload.Visible = false;
                //    btnpostupload.Enabled = false;
                //    btnpostsubmit.Enabled = true;
                //    btnpostsubmit.Visible = true;
                //}

            }

            Cursor.Current = Cursors.Default;
        }
        private void btnpostsubmit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Website == "CarPosts")
            {
                GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Save");//Carposts Submit
            }
            if (Website == "clazorg")
            {
                GeneralFunction.ButtonClickBody(webBrowser1, "submit");//epagephotos[]
                // objSubmitionDetailsBL.SaveSubmitionDetails(objsubdetailsinfo);
            }
            if (Website == "JustgoodCars")
            {
                GeneralFunction.Submit(webBrowser1, "Submit");
                btnpostsubmit.Enabled = false;
            }
            if (Website == "Usadsciti")
            {
                asad = 1;
                GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Post It For Free Now!");//usadciti
            }
            if (Website == "www.adsciti.com")
            {
                Cursor.Current = Cursors.WaitCursor;
                GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Post It For Free Now!");//usadciti
                label29.Font = new System.Drawing.Font("Verdana", 8.0f,
                System.Drawing.FontStyle.Bold);
                label29.ForeColor = System.Drawing.Color.Red;
                Cursor.Current = Cursors.Default;
                //circularProgressControl2.Stop();
                //circularProgressControl2.Visible = false;
                //panel2.Visible = false;
            }
            if (Website == "UsNetads")
            {
               msg = 0;
                if (webBrowser1.Url.ToString() == "http://www.usnetads.com/post/post-free-ads.php")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Submit");//usnetads
                   Cursor.Current = Cursors.Default;
                }
            }
            else if (Website == "jeanza")
            {
                jnga++;
                GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Post it!");
            }
            else if (Website == "classifiedsvalley")
            {
                vlly = 0;
                btnpostsubmit.Enabled = false;
                GeneralFunction.ButtonClickBody(webBrowser1, "submit");
            }
            if (Website == "classifiedsciti")
            {
                GeneralFunction.ButtonClickInvokeValue(webBrowser1, "POST IT FOR FREE NOW");//usadciti
            }
            if (comboBox1.Text == "usa.motoseller.com")
            {
                GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Enter Ad Details >>");
                //com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                //obUsedCarsInfo = objService.FindCarID(label10.Text);
                //IWebSites objClass = new Motoseller();
                //objClass.carpostfunc(webBrowser1, obUsedCarsInfo,rb_Trucks.Checked);
            }
            if (comboBox1.Text == "American-classifieds.net")
            {
                // if (webBrowser1.Url.ToString() == "http://www.american-classifieds.net/postad.php?submittype=0&categ=")
               //{
                GeneralFunction.ButtonClickInvoke(webBrowser1, "submitted");
                // }
            }
            if (comboBox1.Text == "classifiedsforfree")
            {
                GeneralFunction.ButtonClickBody1(webBrowser1, "submit");
            }
            if (comboBox1.Text == "Epage" || comboBox1.Text == "www.epage.com")
            {
                subepg = 0; epagei = 0; epagej = 0;
                GeneralFunction.ButtonClickByValue(webBrowser1, "Continue");
                subepg++;
                circularProgressControl2.Start();
                pnlpostcardata.Visible = true;
                panel2.Visible = true;
                circularProgressControl2.Visible = true;

            }
            if (comboBox1.Text == "highlandclassifieds")
            {
                subepg = 0;
                GeneralFunction.ButtonClickByValue(webBrowser1, "Sign Up");
                subepg++;
                circularProgressControl2.Start();
                pnlpostcardata.Visible = true;
                panel2.Visible = true;
                circularProgressControl2.Visible = true;
            }
            if (comboBox1.Text == "www.classifiededition.com")
            {
                edi = 0;
                GeneralFunction.ButtonClickBody(webBrowser1, "submit");
                //GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Post Now");
            }
            if (comboBox1.Text == "autoii")
            {
                GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Save");//autoii Submit
            }
            if (Website == "www.postfreeadshere.com")
            {
                GeneralFunction.ButtonClickInvokeValue(webBrowser1, "POST IT FOR FREE NOW");//usadciti
            }
            if (Website == "www.cathaylist.comm")
            {
                GeneralFunction.ButtonClickBody(webBrowser1, "submit");
            }
            if (Website == "www.freeadlists.com")
            {
                GeneralFunction.ButtonClickBody(webBrowser1, "submit");
            }
            if (Website == "adsriver")
            {
                GeneralFunction.ButtonClickBody(webBrowser1, "submit");
            }
            if (Website == "anunico")
            {
                ano = 0;
                btnpostsubmit.Enabled = false;
                GeneralFunction.ButtonClickBody(webBrowser1, "submit");//epage
                // objSubmitionDetailsBL.SaveSubmitionDetails(objsubdetailsinfo);
            }
            if (Website == "classifieds4me")
            {
                GeneralFunction.ButtonClickInvoke(webBrowser1, "ctl00$ContentPlaceHolder1$cmdAddNew");//epage
            }
            if (Website == "myadmonster")
            {
                GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, " Post Ad ");
            }
            if (Website == "classifiededition")
            {
                edi = 0;
                GeneralFunction.ButtonClickBody(webBrowser1, "submit");
           }
            if (Website == "classifiedsforfree")
            {
                GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Post the Above Ad");
            }
            if (Website == "classifiedads")
            {
                //GeneralFunction.ImgeButtonimageInvoke(webBrowser1, "http://static.classifiedads.com/_/button_post_this_ad.png");
                //   GeneralFunction.SetDivValuebyclass(webBrowser1, "losubmit");
                GeneralFunction.LinkInvokeClassifiedValley(webBrowser1, "Post this ad");
            }
            if (Website == "hot9ads")
            {
                GeneralFunction.ButtonClickBody(webBrowser1, "Publish");
            }
            if (Website == "freead1.net")
            {
                GeneralFunction.LinkInvoke(webBrowser1, "POST FREE AD");
            }
            if (Website == "webcosmo")
            {
                GeneralFunction.CheckedInvoke(webBrowser1, "ctl00$cphContent$chkAcceptTerms");
                GeneralFunction.CheckedInvoke(webBrowser1, "ctl00$cphContent$chkSubscribe");
                GeneralFunction.ButtonClickInvoke(webBrowser1, "ctl00$cphContent$btnSubmit");
                btnuploadtolive.Enabled = true;
                btnuploadtolive.Visible = true;
                btnpostsubmit.Enabled = false;
                btnpostsubmit.Visible = false;
            }
            if (Website == "cargurus")
            {
                GeneralFunction.ButtonClickByValue(webBrowser1, "Finish");
            }
            if (Website == "web-free-ads")
            {
                GeneralFunction.ButtonClickBody2(webBrowser1, "Post Now");
                btnuploadtolive.Enabled = true;
                btnuploadtolive.Visible = true;
                btnpostsubmit.Enabled = false;
                btnpostsubmit.Visible = false;
            }
            if (Website == "meetpark")
            {
                GeneralFunction.ButtonClickBody2(webBrowser1, "Post Now");
                btnuploadtolive.Enabled = true;
                btnuploadtolive.Visible = true;
                btnpostsubmit.Enabled = false;
                btnpostsubmit.Visible = false;
            }
            if (Website == "extraclassifieds")
            {
                GeneralFunction.ButtonClickBody2(webBrowser1, "Publish");
                eccount = 0;
            }
            if (Website == "soavo")
            {
                GeneralFunction.ButtonClickBody2(webBrowser1, "Publish");
            }
            Cursor.Current = Cursors.Default;
            textBox7.Focus();
            textBox2.Focus();
        }
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }
        private void Btnaddnote_Click(object sender, EventArgs e)
        {
            GlobalNoteCarId.notecarid = label10.Text;
            Prompt Pobj = new Prompt();
            textBox4.Text = Pobj.ShowDialog("Enter Notes", "Notes");
            textBox4.Focus();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string pstcrid = string.Empty;
            //  this.Opacity = .5;
            int Pmin = 0; int Pmax = 150;
            // progressBar1.Value = 0;
            label39.Text = "";
            //progressBar1.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            btnGetAllPics.Enabled = true;
            //  string hex ="ffffffff";
            //  long l = Convert.ToInt64(hex, 16);
            // And back to hex...
            // string hex2 = l.ToString("X");
            if ((e.ColumnIndex == 0) || (e.ColumnIndex == 2))
            {
                if (e.ColumnIndex == 0)
                {
                    if (e.RowIndex != -1)
                    {
                        label47.Visible = false;
                        // tabControl1.SelectedIndex = 4;
                        Cursor.Current = Cursors.WaitCursor;
                        comboBox1.Text = "";
                        btnuploadtolive.Visible = false;
                        btnpostsubmit.Visible = false;
                        btnpostupload.Visible = false;
                        comboBox2.Visible = false;
                        button5.Visible = false;
                        button7.Visible = false;
                        textBox2.Visible = false;
                        lblemail.Visible = false;
                        label25.Visible = false;
                        btnforward.Visible = false;
                        btnback.Visible = false;
                        lblimages.Visible = false;
                        textBox4.Text = "";
                        //btnGetAllPics.Visible = true;
                        dgvpostforpostedcarid.Visible = true;
                        label38.Visible = true;
                        label39.Visible = true;
                        label41.Visible = true;
                        label40.Visible = true;
                        //postingtab
                        int i = 0;
                        i = dataGridView1.SelectedCells[0].RowIndex;
                        carid = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        date = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        Tickets = dataGridView1.Rows[i].Cells[8].Value.ToString();
                        Status = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        //---------posttabdetails start-----------------
                        try
                        {
                            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                            obUsedCarsInfo = objService.FindCarID(carid);
                            FillCarDetails(obUsedCarsInfo);
                            tabControl1.SelectedIndex = 4;
                            comboBox1.Text = "";
                            if (tabControl1.SelectedIndex == 4)
                            {
                                circularProgressControl2.Visible = false;
                                webBrowser1.Visible = false;
                                pnlpoststeps.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        //---------posttabcardetails end--------------------

                        //----------For getting posted information basedon carid  start--------------------------------
                        DataSet dsSubDet = new DataSet();
                        int carid1 = Convert.ToInt32(carid);
                        dsSubDet = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid1);
                        if (dsSubDet.Tables[0].Rows.Count == 0)
                        {
                            dgvpostforpostedcarid.DataSource = dsSubDet.Tables[0];

                            // dgvpostforpostedcarid.Visible = false;
                            label48.Text = "Zero Posts For this Carid";
                            label48.Visible = true;
                        }
                        else
                        {
                            label48.Visible = false;
                            dgvpostforpostedcarid.DataSource = dsSubDet.Tables[0];
                            this.dgvpostforpostedcarid.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                            panel1.Visible = false;
                            DataGridViewColumn clmpostgrd0 = dgvpostforpostedcarid.Columns[0];
                            clmpostgrd0.Width = 80;
                            DataGridViewColumn clmpostgrd1 = dgvpostforpostedcarid.Columns[1];
                            clmpostgrd1.Width = 80;
                            DataGridViewColumn clmpostgrd2 = dgvpostforpostedcarid.Columns[2];
                            clmpostgrd2.Width = 75;
                        }
                        DataSet dsemail1 = new DataSet();
                        dsemail1 = objSubmitionDetailsBL.MultiGetEmailByCarid(label10.Text);
                        if (dsemail1.Tables.Count > 0)
                        {
                            if (dsemail1.Tables[0].Rows.Count > 0)
                            {
                                comboBox2.DataSource = dsemail1.Tables[0];
                                comboBox2.DisplayMember = dsemail1.Tables[0].Columns["EmailId"].ToString();
                                textBox2.Text = dsemail1.Tables[0].Rows[0]["Password"].ToString();
                            }
                        }

                        //  dgvpostforpostedcarid.CellBorderStyle = DataGridViewCellBorderStyle.None;

                        DataSet dsnote = new DataSet();
                        dsnote = objSubmitionDetailsBL.GetMultiNote(carid1);
                        if (dsnote.Tables.Count > 0)
                        {
                            if (dsnote.Tables[0].Rows.Count > 0)
                            {
                                textBox4.Text = dsnote.Tables[0].Rows[0]["Note"].ToString();
                            }
                        }
                        label34.Text = date;
                        // label37.Text = Tickets;
                        //if (Status == "Paid")
                        //{
                        //    label39.Text = "Published";
                        //}
                        //else
                        //{
                        //    label39.Text = "NotPublished";
                        //}
                        label39.ForeColor = Color.Green;
                        label38.ForeColor = Color.Green;
                        circularProgressControl2.Stop();
                        panel2.Visible = false;
                        circularProgressControl2.Visible = false;
                        Cursor.Current = Cursors.Default;
                        //----------For getting posted information basedon carid  end-------------------------------------------
                    }
                }
                //----------for geting postedsitelist start--------------
                if (e.ColumnIndex == 2)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    label16.Visible = true;
                    label17.Visible = true;
                    label18.Visible = true;
                    label22.Visible = true;
                    int i = dataGridView1.SelectedCells[0].RowIndex;
                    carid = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    DataSet dts1 = new DataSet();
                    dts1 = objSubmitionDetailsBL.MultigetpostedSites(carid);
                    dgvviewpostedsite.DataSource = dts1.Tables[0];
                    DataGridViewColumn column0 = dgvviewpostedsite.Columns[0];
                    column0.Width = 150;
                    DataGridViewColumn column1 = dgvviewpostedsite.Columns[1];
                    column1.Width = 150;
                    DataSet dts2 = new DataSet();
                    dts2 = objSubmitionDetailsBL.MultigetViewpendingsite(carid);
                    dgvviewpendingsites.DataSource = dts2.Tables[0];
                    dgvviewpendingsites.DefaultCellStyle.ForeColor = Color.Red;
                    DataGridViewColumn column2 = dgvviewpendingsites.Columns[0];
                    column2.Width = 150;
                    DataGridViewColumn column3 = dgvviewpendingsites.Columns[1];
                    column3.Width = 150;
                    label18.Text = "CarId: " + carid;
                    label22.Text = "CarId: " + carid;
                    Cursor.Current = Cursors.Default;
                }
                //   this.Opacity = 100;
                DataSet Eds = new DataSet();
                Eds = objSubmitionDetailsBL.GetEmailData();
                //DataSet dssitename = new DataSet;
                //dssitename = objSubmitionDetailsBL.MultiGetSiteList();
                //comboBox1.DataSource = dssitename.Tables[0];
                //comboBox1.DisplayMember = dssitename.Tables[0].Columns["SiteName"].ToString();
                //comboBox1.ValueMember = dssitename.Tables[0].Columns["SmrtzSiteID"].ToString();
                DataSet dssitename = new DataSet();
                int tcarid = Convert.ToInt32(carid);
                dssitename = objSubmitionDetailsBL.MultiGetSiteNameTransation(tcarid);
                comboBox1.DataSource = dssitename.Tables[0];
                comboBox1.DisplayMember = dssitename.Tables[0].Columns["SiteName"].ToString();
                comboBox1.ValueMember = dssitename.Tables[0].Columns["SmrtzSiteID"].ToString();
            }
            //----------for geting postedsitelist end--------------
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string carid = string.Empty;
            label43.Visible = true;
            Label42.Visible = true;
            label43.Text = "";
            pi = dataGridView3.SelectedCells[0].RowIndex;
            carid = dataGridView3.Rows[pi].Cells[0].Value.ToString();
            string stcarid = carid.ToString();
            if (stcarid != "")
            {
                if (e.ColumnIndex == 7)
                {
                    if (e.RowIndex != -1)
                    {
                        int val1 = Convert.ToInt32(dataGridView3.Rows[pi].Cells[7].Value.ToString());
                        if (val1 != 0)
                        {
                            label43.Text = "CarId: " + carid.ToString();
                            DataSet dtsp1 = new DataSet();
                            dtsp1 = objSubmitionDetailsBL.MultigetPendingSites(carid);
                            dataGridView4.DataSource = dtsp1.Tables[0];
                            dataGridView4.Columns["sitename"].ReadOnly = true;
                            //   dataGridView4.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridView4.Columns[1].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridView4.Columns[2].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridView4.Columns[2].DefaultCellStyle.Font = new Font(dataGridView4.DefaultCellStyle.Font, FontStyle.Underline);
                            // dataGridView4.Columns[2].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                            // DataGridViewColumn cldtg1 = dataGridView4.Columns[0];
                            // cldtg1.Width = 145;
                            DataGridViewColumn cldtg2 = dataGridView4.Columns[1];
                            cldtg2.Width = 145;
                            DataGridViewColumn cldtg3 = dataGridView4.Columns[2];
                            cldtg3.Width = 77;
                            this.dataGridView4.Columns["StId"].Visible = false;
                            this.dataGridView4.Columns["UrlId"].Visible = false;
                            this.dataGridView4.Columns["CarId"].Visible = false;
                            this.dataGridView4.Columns["URL"].Visible = false;
                            this.dataGridView4.Columns["URLSID"].Visible = false;
                            this.dataGridView4.Columns["Siteid"].Visible = false;
                            this.dataGridView4.Columns["UrlPostDate"].Visible = false;
                        }
                        else
                        {
                            dataGridView4.DataSource = null;
                            //dataGridView4.DataBind();
                            //  dataGridView4.Rows.Clear();
                        }
                    }
                }
                if (e.ColumnIndex == 8)
                {
                    if (e.RowIndex != -1)
                    {
                        int val = Convert.ToInt32(dataGridView3.Rows[pi].Cells[8].Value.ToString());
                        if (val != 0)
                        {
                            label43.Text = "CarId: " + carid.ToString();
                            DataSet dtsp2 = new DataSet();
                            dtsp2 = objSubmitionDetailsBL.MultigetPendingSites1(carid);
                            dataGridView4.DataSource = dtsp2.Tables[0];
                            dataGridView4.Columns["sitename"].ReadOnly = true;
                            dataGridView4.Columns[1].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridView4.Columns[2].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridView4.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
                            dataGridView4.Columns[2].DefaultCellStyle.Font = new Font(dataGridView4.DefaultCellStyle.Font, FontStyle.Underline);
                            // dataGridView4.Columns[2].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                            DataGridViewColumn cldtg1 = dataGridView4.Columns[1];
                            cldtg1.Width = 145;
                            DataGridViewColumn cldtg2 = dataGridView4.Columns[2];
                            cldtg2.Width = 125;
                            DataGridViewColumn cldtg3 = dataGridView4.Columns[3];
                            cldtg3.Width = 77;
                            this.dataGridView4.Columns["StId"].Visible = false;
                            this.dataGridView4.Columns["UrlId"].Visible = false;
                            this.dataGridView4.Columns["CarId"].Visible = false;
                            this.dataGridView4.Columns["URL"].Visible = false;
                            this.dataGridView4.Columns["URLSID"].Visible = false;
                            this.dataGridView4.Columns["Siteid"].Visible = false;
                            this.dataGridView4.Columns["UrlPostDate"].Visible = false;
                        }
                        else
                        {
                            // dataGridView4.Rows.Count;
                            // for (int i = 0; i < dataGridView4.Rows.Count; i++)
                            // {
                            dataGridView4.DataSource = null;
                            //dataGridView4.Columns.Clear();
                            // dataGridView4.Rows.RemoveAt(i);
                            //   }
                        }
                    }
                }
                else if (e.ColumnIndex == 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    General.ExcelFormat objExcelFormat = new General.ExcelFormat();
                    DataSet ds = new DataSet();
                    int carid1 = Convert.ToInt32(carid);
                    string dt = DateTime.Now.ToString();
                    ds = objSubmitionDetailsBL.GetpostedURL(carid1, dt, GlobalLogId.globallogidVar);
                    objExcelFormat.ProcessedSheetExcel(carid1, ds, comboBox3.Text);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Downloaded to ExcelSheet Sucessfully");
                }
            }
            if (e.ColumnIndex == 4)
            {
                DataSet dtsp1 = new DataSet();
                dtsp1 = objSubmitionDetailsBL.MultigetpostedSites(carid);
                dataGridView4.DataSource = dtsp1.Tables[0];
                dataGridView4.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
                dataGridView4.Columns[1].DefaultCellStyle.ForeColor = Color.Black;
                DataGridViewColumn postdlst1 = dataGridView4.Columns[0];
                postdlst1.Width = 150;
                DataGridViewColumn postdlst2 = dataGridView4.Columns[1];
                postdlst2.Width = 100;
                label43.Text = "CarId: " + carid.ToString();
            }
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string data2 = string.Empty;
            if (e.RowIndex != -1)
            {
                purl = dataGridView4.SelectedCells[0].RowIndex;
                string data0 = dataGridView4.Rows[purl].Cells[0].Value.ToString();
                string data1 = dataGridView4.Rows[purl].Cells[1].Value.ToString();
                if (data1 != "")
                {
                    Regex obj = new Regex("^([1-9]|0[1-9]|1[0-9]|2[0-9]|3[0-1])[- / .]([1-9]|0[1-9]|1[0-2])[- / .]([1-9]|0[1-9]|1[0-9])$");
                    if (obj.IsMatch(data1.ToString()))
                    {
                    }
                    else
                    {
                        data2 = dataGridView4.Rows[purl].Cells[2].Value.ToString();
                        if ((data2 == "UrlPend") || (data2 == "QcPend"))
                        {
                            string data5 = dataGridView4.Rows[purl].Cells[4].Value.ToString();
                            string data4 = dataGridView4.Rows[purl].Cells[3].Value.ToString();
                            if (e.ColumnIndex == 2)
                            {
                                if (data2 == "UrlPend")
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    GlobalNoteCarId.notecarid = data5;
                                    GlobalSite.Site = data1;
                                    GlobalUrlid.Urlid = Convert.ToInt32(data0);
                                    SubPopUrl objsuburl = new SubPopUrl();
                                    // objsuburl.MdiParent = this;
                                    objsuburl.ShowDialog();
                                    // objsuburl.BringToFront();
                                    Cursor.Current = Cursors.Default;
                                }
                            }
                            if (e.ColumnIndex == 2)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                data2 = dataGridView4.Rows[purl].Cells[2].Value.ToString();
                                if (data2 == "QcPend")
                                {
                                    ////button6.Enabled = true;
                                    ////button4.Enabled = true;
                                    button6.Visible = false;
                                    button4.Visible = false; ;
                                    data5 = dataGridView4.Rows[purl].Cells[4].Value.ToString();
                                    string data6 = dataGridView4.Rows[purl].Cells[5].Value.ToString();
                                    string data7 = dataGridView4.Rows[purl].Cells[7].Value.ToString();
                                    string data8 = dataGridView4.Rows[purl].Cells[8].Value.ToString();
                                    GlobalpendURL.pendURL = data6;
                                    GlobalUrlsid.Urlsid = Convert.ToInt32(data0);
                                    GlobalNoteCarId.notecarid = data5;
                                    Globalpenddate.penddate = data8;
                                    lblpostsite.Visible = false;
                                    comboBox1.Visible = false;
                                   //Main objfrm = new Main();
                                    //objfrm.Show();
                                   //------------------------------------------start-------------------------------------
                                    try
                                    {
                                        com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                                        IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                                        obUsedCarsInfo = objService.FindCarID(data5);
                                        // FillCarDetails(obUsedCarsInfo);
                                        QCCarDetails(obUsedCarsInfo);
                                        DataSet dsSubDet = new DataSet();
                                        int cid = Convert.ToInt32(GlobalNoteCarId.notecarid);
                                        dsSubDet = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(cid);
                                        dgvpostforpostedcarid.DataSource = dsSubDet.Tables[0];
                                        DataGridViewColumn clmpostmn0 = dgvpostforpostedcarid.Columns[0];
                                        clmpostmn0.Width = 80;
                                        DataGridViewColumn clmpostmn1 = dgvpostforpostedcarid.Columns[1];
                                        clmpostmn1.Width = 80;
                                        DataGridViewColumn clmpostmn2 = dgvpostforpostedcarid.Columns[2];
                                        clmpostmn2.Width = 75;
                                        tabControl1.SelectedIndex = 4;
                                        if (tabControl1.SelectedIndex == 4)
                                        {
                                            circularProgressControl2.Start();
                                            panel2.Visible = true;
                                            circularProgressControl2.Visible = true;

                                            webBrowser1.Navigate(data6);
                                            webBrowser1.Visible = true;
                                            pnlpoststeps.Visible = false;

                                            label34.Visible = false;
                                            label35.Visible = false;
                                            label36.Visible = false;
                                            label37.Visible = false;
                                            comboBox1.Text = "";
                                            label40.Visible = true;
                                            label41.Visible = true;
                                            // dgvpostforpostedcarid.Visible = false;
                                            comboBox2.Visible = false;
                                            button5.Visible = false;
                                            button7.Visible = false;

                                            textBox2.Visible = false;
                                            lblemail.Visible = false;
                                            label25.Visible = false;
                                            btnpostupload.Visible = false;
                                            btnpostsubmit.Visible = false;
                                            btnuploadtolive.Visible = false;


                                            circularProgressControl2.Stop();
                                            panel2.Visible = false;
                                            circularProgressControl2.Visible = false;

                                            //button4.Visible = true;
                                            //button6.Visible = true;
                                            //button4.Enabled = true;
                                            //button6.Enabled = true;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    //--------------end-----------------
                                   GlobalsiteId.siteId = Convert.ToInt32(data7);
                                    Cursor.Current = Cursors.Default;
                                    //QCFormcheck objqcformchech = new QCFormcheck();
                                    //objqcformchech.Show();
                                }
                            }
                        }
                    }
                }
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+") || (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\b"))))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            //try
            //{
            //    string str = textBox3.Text;
            //    double xx = Convert.ToDouble(str);
            //}
            //catch
            //{
            //    if (textBox3.Text.Length > 0)
            //    {
            //        MessageBox.Show("Enter Only Numbers", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //        textBox3.Text = " ";
            //    }
            //}
        }
        private void Main_Move(object sender, EventArgs e)
        {
            if (canMove)
            {
                this.Opacity = 0.25;
            }
        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataSet dsnewPwdByemail = new DataSet();
            dsnewPwdByemail = objSubmitionDetailsBL.MultiGetPwdByEmail(comboBox2.Text);
            if (dsnewPwdByemail.Tables.Count > 0)
            {
                if (dsnewPwdByemail.Tables[0].Rows.Count > 0)
                {
                    textBox2.Text = dsnewPwdByemail.Tables[0].Rows[0]["Password"].ToString();
                }
            }
        }
        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DataGridViewColumn newColumn = dataGridView3.Columns.GetColumnCount(
           DataGridViewElementStates.Selected) == 1 ? dataGridView3.SelectedColumns[0] : null;
                DataGridViewColumn oldColumn = dataGridView1.SortedColumn;
                ListSortDirection direction;
                if (oldColumn != null)
                {
                    if (oldColumn == newColumn &&
                        dataGridView3.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                if (newColumn == null)
                {
                }
                else
                {
                    dataGridView3.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("");
            this.Text = textBox3.Text;
            GetCarDetails(textBox3.Text);
            #region old
            //circularProgressControl2.Stop();



            ////try
            ////{
            ////    comboBox1.Text = "";
            ////    button2.Visible = false;
            ////    label30.Visible = false;
            ////    label27.Visible = false;
            ////    label28.Visible = false;
            ////    label29.Visible = false;
            ////    label31.Visible = false;
            ////    label32.Visible = false;



            ////    comboBox2.Visible = false;
            ////    button5.Visible = false;

            ////    pnlpoststeps.Visible = false;
            ////    pnlpostnotes.Visible = false;
            ////    webBrowser1.Visible = false;
            ////    pnlpostbuttons.Visible = false;


            ////    string txtcarid = textBox3.Text;

            ////    if (txtcarid != "")
            ////    {
            ////        string number = textBox3.Text;
            ////        Regex regex = new Regex(@"[\d]");
            ////        if (regex.IsMatch(number))
            ////        {


            ////            Cursor.Current = Cursors.WaitCursor;


            ////            try
            ////            {
            ////                com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


            ////                IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
            ////                obUsedCarsInfo = objService.FindCarID(txtcarid.ToString());


            ////                if (obUsedCarsInfo.Count > 0)
            ////                {

            ////                    FillCarDetails(obUsedCarsInfo);
            ////                    int rctcarid = Convert.ToInt32(txtcarid.ToString());

            ////                    DataSet dsSubDet = new DataSet();
            ////                    dsSubDet = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(rctcarid);

            ////                    dgvpostforpostedcarid.DataSource = dsSubDet.Tables[0];
            ////                    if (dsSubDet.Tables[0].Rows.Count == 0)
            ////                    {
            ////                        dgvpostforpostedcarid.Visible = true;
            ////                        label48.Text = "No Posts For this Carid";
            ////                        label48.Visible = true;
            ////                    }
            ////                    else
            ////                    {
            ////                        label48.Visible = false;
            ////                        dgvpostforpostedcarid.Visible = true;
            ////                    }



            ////                    panel1.Visible = false;

            ////                    label35.Visible=true;
            ////                        label36.Visible=true;

            ////                        label37.Visible=true;
            ////                        label38.Visible = true;
            ////                    label41.Visible = true;
            ////                    label40.Visible = true;
            ////                    //btnGetAllPics.Visible = true;
            ////                    label38.Visible = true;
            ////                    label39.Visible = true;
            ////                    comboBox1.Visible = true;
            ////                    comboBox1.Text="";
            ////                    lblpostsite.Visible = true;

            ////                    label39.ForeColor = Color.Green;
            ////                    label38.ForeColor = Color.Green;

            ////                    //  comboBox2.Visible = false;
            ////                    textBox2.Visible = false;
            ////                    lblemail.Visible = false;
            ////                    label25.Visible = false;
            ////                    button4.Visible = false;

            ////                    btnpostsubmit.Visible = false;
            ////                    btnpostupload.Visible = false;
            ////                    btnuploadtolive.Visible = false;
            ////                    //}
            ////                    //    else
            ////                    //    {
            ////                    //        MessageBox.Show("CarId not found .Please try with another Carid");

            ////                    //        comboBox1.Text = "";
            ////                    //        label38.Visible = false;
            ////                    //        label39.Visible = false;
            ////                    //        lblimages.Visible = false;
            ////                    //        btnGetAllPics.Visible = false;
            ////                    //        btnback.Visible = false;
            ////                    //        btnforward.Visible = false;
            ////                    //        pictureBox1.Visible = false;
            ////                    //        pictureBox2.Visible = false;
            ////                    //        pictureBox3.Visible = false;
            ////                    //        dgvpostforpostedcarid.Visible = false;
            ////                    //        pnlpostcardata.Visible = false;
            ////                    //        pnlpostnotes.Visible = false;
            ////                    //        pnlposttkt.Visible = false;
            ////                    //        pnlpostbuttons.Visible = false;
            ////                    //        pnlpoststeps.Visible = false;
            ////                    //        webBrowser1.Visible = false;
            ////                    //        label40.Visible = false;
            ////                    //        label41.Visible = false;
            ////                    //        panel1.Visible = true;
            ////                    //        textBox3.Text = "";
            ////                    //        textBox3.Focus();
            ////                    //    }

            ////                    //}
            ////                    //catch (Exception ex)
            ////                    //{
            ////                    //    comboBox1.Text = "";
            ////                    //    label38.Visible = false;
            ////                    //    label39.Visible = false;
            ////                    //    lblimages.Visible = false;
            ////                    //    btnGetAllPics.Visible = false;
            ////                    //    btnback.Visible = false;
            ////                    //    btnforward.Visible = false;
            ////                    //    pictureBox1.Visible = false;
            ////                    //    pictureBox2.Visible = false;
            ////                    //    pictureBox3.Visible = false;
            ////                    //    dgvpostforpostedcarid.Visible = false;
            ////                    //    pnlpostcardata.Visible = false;
            ////                    //    pnlpostnotes.Visible = false;
            ////                    //    pnlposttkt.Visible = false;
            ////                    //    pnlpostbuttons.Visible = false;
            ////                    //    pnlpoststeps.Visible = false;
            ////                    //    webBrowser1.Visible = false;
            ////                    //    label40.Visible = false;
            ////                    //    label41.Visible = false;
            ////                    //    panel1.Visible = true;
            ////                    //    textBox3.Text = "";
            ////                    //    textBox3.Focus();
            ////                    //}




            ////                    pnlpostcardata.Visible = true;
            ////                    pnlpostnotes.Visible = true;
            ////                    pnlposttkt.Visible = true;


            ////                    pnlpoststeps.Visible = true;
            ////                    pnlpostbuttons.Visible = true;
            ////                    pnlpostbrowser.Visible = true;
            ////                    // pnlpostpics.Visible = true;




            ////                    DataSet dsemail = new DataSet();
            ////                    dsemail = objSubmitionDetailsBL.MultiGetEmailByCarid(label10.Text);
            ////                    if (dsemail.Tables.Count > 0)
            ////                    {
            ////                        if (dsemail.Tables[0].Rows.Count > 0)
            ////                        {
            ////                            comboBox2.DataSource = dsemail.Tables[0];
            ////                            comboBox2.DisplayMember = dsemail.Tables[0].Columns["EmailId"].ToString();
            ////                            textBox2.Text = dsemail.Tables[0].Rows[0]["Password"].ToString();
            ////                        }
            ////                    }





            ////                    DataSet dsnotebtn = new DataSet();
            ////                    int btncarid = Convert.ToInt32(textBox3.Text);
            ////                    dsnotebtn = objSubmitionDetailsBL.GetMultiNote(btncarid);
            ////                    if (dsnotebtn.Tables.Count > 0)
            ////                    {

            ////                        if (dsnotebtn.Tables[0].Rows.Count > 0)
            ////                        {
            ////                            for (int i = 0; i < dsnotebtn.Tables[0].Rows.Count; i++)
            ////                            {
            ////                                textBox4.Text += dsnotebtn.Tables[0].Rows[i]["Note"].ToString() + "\r\n";

            ////                            }
            ////                        }
            ////                        else
            ////                        {
            ////                            textBox4.Text = "";
            ////                        }

            ////                    }

            ////                    DataSet pudds = new DataSet();
            ////                    pudds = objSubmitionDetailsBL.MultiSiteGetRecentPostDataByCarId(textBox3.Text);
            ////                    if (pudds.Tables.Count > 0)
            ////                    {
            ////                        if (pudds.Tables[0].Rows.Count > 0)
            ////                        {
            ////                            label34.Text = pudds.Tables[0].Rows[0]["Publisheddt"].ToString();
            ////                        }
            ////                        else
            ////                        {
            ////                            label34.Text = "Not Published";
            ////                        }
            ////                    }

            ////                    DataSet tktds = new DataSet();
            ////                    tktds = objSubmitionDetailsBL.MultiGetTicketCountByCarId(textBox3.Text);
            ////                    if (tktds.Tables.Count > 0)
            ////                    {
            ////                        if (tktds.Tables[0].Rows.Count > 0)
            ////                        {
            ////                            label37.Text = tktds.Tables[0].Rows[0]["#tkts"].ToString();
            ////                        }
            ////                        else
            ////                        {
            ////                            label37.Text = "0";
            ////                        }
            ////                    }
            ////                    else
            ////                    {
            ////                        label37.Text = "0";
            ////                    }



            // to get total of particular carid posting today
            #endregion
            if (label10.Text != "label10")
            {
                int carno = Convert.ToInt32(label10.Text);
                int value = General.Count_Url_for_carid.GetcountofCarid(carno, GlobalLogId.globallogidVar);
                label37.Text = Convert.ToInt32(value).ToString();
            }
            #region old
            //End  to get total of particular carid posting today
            ////                    if (pudds.Tables.Count > 0)
            ////                    {
            ////                        if (pudds.Tables[0].Rows.Count > 0)
            ////                        {
            ////                            string crstatus = pudds.Tables[0].Rows[0]["Status"].ToString();
            ////                            if (crstatus == "Active")
            ////                            {
            ////                                label39.Text = "Published";
            ////                            }
            ////                            else
            ////                            {
            ////                                label39.Text = "Not Published";
            ////                            }
            ////                        }
            ////                        else
            ////                        {
            ////                            label39.Text = "Not Published";
            ////                        }
            ////                    }
            ////                    else
            ////                    {
            ////                        label39.Text = "Not Published";
            ////                    }

            ////                    //-------------------------------------------------------------------
            ////                }
            ////                else
            ////                {
            ////                   // MessageBox.Show("CarId not found .Please try with another Carid");

            ////                    comboBox1.Text = "";
            ////                    label38.Visible = false;
            ////                    label39.Visible = false;
            ////                    lblimages.Visible = false;
            ////                    btnGetAllPics.Visible = false;
            ////                    btnback.Visible = false;
            ////                    btnforward.Visible = false;
            ////                    pictureBox1.Visible = false;
            ////                    pictureBox2.Visible = false;
            ////                    pictureBox3.Visible = false;
            ////                    dgvpostforpostedcarid.Visible = false;
            ////                    pnlpostcardata.Visible = false;
            ////                    pnlpostnotes.Visible = false;
            ////                    pnlposttkt.Visible = false;
            ////                    pnlpostbuttons.Visible = false;
            ////                    pnlpoststeps.Visible = false;
            ////                    webBrowser1.Visible = false;
            ////                    label40.Visible = false;
            ////                    label41.Visible = false;
            ////                    panel1.Visible = true;
            ////                    MessageBox.Show("CarId not found .Please try with another Carid");
            ////                   textBox3.Text = "";
            ////                   textBox3.Focus();
            ////                }

            ////            }
            ////            catch (Exception ex)
            ////            {

            ////                comboBox1.Text = "";
            ////                label38.Visible = false;
            ////                label39.Visible = false;
            ////                lblimages.Visible = false;
            ////                btnGetAllPics.Visible = false;
            ////                btnback.Visible = false;
            ////                btnforward.Visible = false;
            ////                pictureBox1.Visible = false;
            ////                pictureBox2.Visible = false;
            ////                pictureBox3.Visible = false;
            ////                dgvpostforpostedcarid.Visible = false;
            ////                pnlpostcardata.Visible = false;
            ////                pnlpostnotes.Visible = false;
            ////                pnlposttkt.Visible = false;
            ////                pnlpostbuttons.Visible = false;
            ////                pnlpoststeps.Visible = false;
            ////                webBrowser1.Visible = false;
            ////                label40.Visible = false;
            ////                label41.Visible = false;
            ////                panel1.Visible = true;
            ////                textBox3.Text = "";
            ////                textBox3.Focus();
            ////                MessageBox.Show("CarId not found.Please try another CarId");
            ////            }


            ////        }

            ////        else
            ////        {
            ////            MessageBox.Show(" Enter Carid                 ");
            ////            textBox3.Text = "";
            ////        }
            ////    }
            ////    else
            ////    {
            ////        MessageBox.Show("Please Enter Any carId           ");
            ////        textBox3.Text = "";
            ////    }

            ////    DataGridViewColumn clmpostgrdmn0 = dgvpostforpostedcarid.Columns[0];
            ////    clmpostgrdmn0.Width = 80;
            ////    DataGridViewColumn clmpostgrdmn1 = dgvpostforpostedcarid.Columns[1];
            ////    clmpostgrdmn1.Width = 80;

            ////    DataGridViewColumn clmpostgrdmn2 = dgvpostforpostedcarid.Columns[2];
            ////    clmpostgrdmn2.Width = 75;

            ////}
            ////catch (Exception ex)
            ////{
            ////   // MessageBox.Show("CarId not found.Please try another CarId");


            ////    comboBox1.Text = "";
            ////    label38.Visible = false;
            ////    label39.Visible = false;
            ////    lblimages.Visible = false;
            ////    btnGetAllPics.Visible = false;
            ////    btnback.Visible = false;
            ////    btnforward.Visible = false;
            ////    pictureBox1.Visible = false;
            ////    pictureBox2.Visible = false;
            ////    pictureBox3.Visible = false;
            ////    dgvpostforpostedcarid.Visible = false;
            ////    pnlpostcardata.Visible = false;
            ////    pnlpostnotes.Visible = false;
            ////    pnlposttkt.Visible = false;
            ////    pnlpostbuttons.Visible = false;
            ////    pnlpoststeps.Visible = false;
            ////    webBrowser1.Visible = false;
            ////    label40.Visible = false;
            ////    label41.Visible = false;
            ////    panel1.Visible = true;
            ////    textBox3.Text = "";
            ////    textBox3.Focus();
            ////}
            ////Cursor.Current = Cursors.Default;
            #endregion
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            comboBox1.Text = "";
            btnpostsubmit.Visible = false;
            btnpostupload.Visible = false;
            btnuploadtolive.Visible = false;
            button2.Enabled = false;
            webBrowser1.Visible = false;
            btnpostupload.Visible = false;
            circularProgressControl2.Stop();
            panel2.Visible = false;
            //   this.Opacity = Loop / 95.0;
            // this.pnlpostcardata = Loop / 95.0;
            circularProgressControl2.Visible = false;
            this.Refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label48.Visible = false;
            label47.Visible = false;
            textBox3.Text = "";
            comboBox1.Text = "";
            label38.Visible = false;
            label39.Visible = false;
            lblimages.Visible = false;
            btnGetAllPics.Visible = false;
            btnback.Visible = false;
            btnforward.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            dgvpostforpostedcarid.Visible = false;
            pnlpostcardata.Visible = false;
            pnlpostnotes.Visible = false;
            pnlposttkt.Visible = false;
            pnlpostbuttons.Visible = false;
            pnlpoststeps.Visible = false;
            webBrowser1.Visible = false;
            label40.Visible = false;
            label41.Visible = false;
            circularProgressControl2.Visible = false;
            panel2.Visible = false;
            this.Opacity = 100;
            panel1.Visible = true;
            textBox3.Focus();
            webBrowser1.Navigate("");
            //GlobalNoteCarId.notecarid = label10.Text;
            //PromtCarId Pobj = new PromtCarId();
            //Pobj.ShowCarDialog("Enter Notes", "Notes");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button6.Enabled = false;
            string carnum1 = GlobalNoteCarId.notecarid;
            carnum = Convert.ToInt32(carnum1);
            urlprndg = GlobalpendURL.pendURL;
            urlsid = GlobalUrlsid.Urlsid;
            siteid = GlobalsiteId.siteId;
            postedby = GlobalLogId.globallogidVar;
            date1 = Globalpenddate.penddate;
            SubStatus = "Completed";
            objSubmitionDetailsBL.MultiSaveSmartzSubmitionDetails(carnum, urlprndg, siteid, postedby, SubStatus, date1, urlsid);
            MessageBox.Show("Uploaded In Live DataBase Sucessfully");
            tabControl1.SelectedIndex = 2;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //USP_MultiAssignEmailidByCarId
            Cursor.Current = Cursors.WaitCursor;
            string state = textBox10.Text;
            char[] sep = { ',' };
            string[] split = state.Split(sep);
            state = split[1].ToString();

            General.EmailCreation.createmail(label10.Text, state);
            //DataSet dsnewemail = new DataSet();
            //dsnewemail = objSubmitionDetailsBL.MultiAssignEmailidByCarId(label10.Text);
            //if (dsnewemail.Tables.Count > 0)
            //{
            //    if (dsnewemail.Tables[0].Rows.Count > 0)
            //    {
            //        comboBox2.DataSource = dsnewemail.Tables[0];
            //        comboBox2.DisplayMember = dsnewemail.Tables[0].Columns["EmailId"].ToString();
            //        textBox2.Text = dsnewemail.Tables[0].Rows[0]["Password"].ToString();
            //    }
            //}
            Cursor.Current = Cursors.Default;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button4.Enabled = false;
            //button4.Enabled = false;
            string carnum1 = GlobalNoteCarId.notecarid;
            carnum = Convert.ToInt32(carnum1);
            urlprndg = GlobalpendURL.pendURL;
            urlsid = GlobalUrlsid.Urlsid;
            siteid = GlobalsiteId.siteId;
            postedby = GlobalLogId.globallogidVar;
            date1 = Globalpenddate.penddate;
            SubStatus = "Completed";
            string QcStatus = "Failed";
            objSubmitionDetailsBL.multiupdateMultiSiteSubDetails(urlsid, QcStatus);
            MessageBox.Show("Updated Sucessfully");
            tabControl1.SelectedIndex = 2;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            EmailTextBox.Text = "";
            passwordTextBox.Text = "";
            tabControl1.Enabled = false;
            EmailForm.ControlBox = false;

            ButtonSubmit.Click += new System.EventHandler(ButtonSubmit_click);
            ButtonLater.Click += new System.EventHandler(ButtonLater_click);
            EmailButtonMinimize.Click += new System.EventHandler(EmailButtonMinimize_click);

            EmailForm.Text = "To Add Email";
            EmailForm.Width = 300;
            EmailForm.Height = 250;
            Label lblliveurl = new Label();

            EmailForm.Controls.Add(EmailTextBox);
            EmailTextBox.Width = 130;
            EmailForm.Controls.Add(lblliveurl);
            lblliveurl.Text = "New Email: ";
            lblliveurl.Location = new System.Drawing.Point(20, 65);
            EmailTextBox.Location = new System.Drawing.Point(115, 64);
            EmailTextBox.FindForm();
            EmailForm.Controls.Add(passwordTextBox);
            passwordTextBox.Width = 130;
            EmailForm.Controls.Add(lblpassword);
            lblpassword.Text = " Password: ";
            lblpassword.Location = new System.Drawing.Point(20, 95);
            passwordTextBox.Location = new System.Drawing.Point(115, 94);

            EmailForm.Controls.Add(ButtonSubmit);
            ButtonSubmit.Location = new System.Drawing.Point(95, 120);
            ButtonSubmit.Width = 75;
            ButtonSubmit.Text = "Submit";

            EmailForm.Controls.Add(ButtonLater);
            ButtonLater.Location = new System.Drawing.Point(175, 120);
            ButtonLater.Width = 75;
            ButtonLater.Text = "TryLater";
            // EmailForm.BringToFront();

            EmailButtonMinimize.Location = new System.Drawing.Point(215, 10);
            EmailButtonMinimize.Width = 60;
            EmailButtonMinimize.Text = "Minimize";
            EmailForm.Controls.Add(EmailButtonMinimize);
            EmailButtonMinimize.ForeColor = Color.White;
            EmailButtonMinimize.BackColor = Color.DarkBlue;

            EmailForm.Show();
            #region old
            //if (button7.Text == "Add Email")
            //{
            //    button5.Enabled = false;
            //    btnpostupload.Enabled = false;
            //    comboBox2.Text = "";
            //    textBox2.Text = "";

            //    button7.Text = "Save";

            //}
            //else if (button7.Text == "Save")
            //{
            //    if (textBox2.Text == "" || comboBox2.Text == "")
            //    {
            //        MessageBox.Show("Please enter Email and Password");
            //    }
            //    else
            //    {

            //        button5.Enabled = true;
            //        btnpostupload.Enabled = true;
            //        objSubmitionDetailsBL.MultiSaveEmail(comboBox2.Text, textBox2.Text, label10.Text);

            //        MessageBox.Show("Data inserted successfully");


            //        DataSet dsemail = new DataSet();
            //        dsemail = objSubmitionDetailsBL.MultiGetEmailByCarid(label10.Text);
            //        if (dsemail.Tables.Count > 0)
            //        {
            //            if (dsemail.Tables[0].Rows.Count > 0)
            //            {
            //                comboBox2.DataSource = dsemail.Tables[0];
            //                comboBox2.DisplayMember = dsemail.Tables[0].Columns["EmailId"].ToString();
            //                textBox2.Text = dsemail.Tables[0].Rows[0]["Password"].ToString();
            //                button7.Text = "Add Email";
            //            }
            //        }
            //    }
            //}
            #endregion
        }
        private void button8_Click(object sender, EventArgs e)
        {
            //objSubmitionDetailsBL.MultiSaveEmail(textBox5.Text, textBox6.Text,label10.Text);
            MessageBox.Show("You cannot create Account.Please contact your administrator.");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Trim() != "")
            {
                button9.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                General.ExcelFormat objExcelFormat = new General.ExcelFormat();
                DataSet ds = new DataSet();
                int carid1 = Convert.ToInt32(textBox8.Text);
                string dt = DateTime.Now.ToString();
                ds = objSubmitionDetailsBL.GetpostedURL(carid1, dt, GlobalLogId.globallogidVar);
                objExcelFormat.ProcessedSheetExcel(carid1, ds, comboBox3.Text);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Downloaded to ExcelSheet Sucessfully");
                button9.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please Enter CarId");
                textBox8.Text = "";
                textBox8.Focus();
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            btnuploadtolive.Enabled = true;
            btnuploadtolive.Visible = true;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if ((comboBox3.Text.Trim() != "") || (textBox9.Text.Trim() != ""))
            {
                Cursor.Current = Cursors.WaitCursor;
                string dt = string.Empty;
                General.ExcelFormat objExcelFormat = new General.ExcelFormat();
                DataSet ds = new DataSet();
                int carid1 = 0;

                if (comboBox3.Text.Trim() != "")
                {
                    button9.Enabled = false;
                    string month = "";
                    //dt = DateTime.Now.ToString("yyyy-MM");
                    if (comboBox3.Text.Length != 2)
                        dateoftoday = 0 + comboBox3.Text;
                    else
                        dateoftoday = comboBox3.Text;
                    if (DateTime.Now.Month.ToString().Length != 2)
                        month = "0" + DateTime.Now.Month;
                    else month = DateTime.Now.Month.ToString();
                    dt = DateTime.Now.Year + "/" + month + "/" + dateoftoday;
                    dt = dt.Replace("-", "/");
                    //dt = dt + "/" + dateoftoday;
                    carid1 = 0;
                }
                else if (textBox9.Text.Trim() != "")
                {
                    dt = DateTime.Now.ToString("yyyy-MM-dd");
                    //dt = textBox9.Text+"/" + DateTime.Now.Month+"/" + DateTime.Now.Year;
                    dt = dt.Replace("-", "/");
                    carid1 = Convert.ToInt32(textBox9.Text);
                }
                //  DateTime t1 = DateTime.Now;
                //  t1 = Convert.ToDateTime(t1);
                // // t1 = DateTime.Parse(t1);
                // DateTime t2 = Convert.ToDateTime("00:01:00 AM");
                //int t= TimeSpan.Compare(t1.TimeOfDay, t2.TimeOfDay);
                //int i = DateTime.Compare(t1,t2);
                ////t2 = DateTime.Parse(t2);
                //if (i > 0)
                //{
                //}
                ds = objSubmitionDetailsBL.GetpostedURL(carid1, dt, GlobalLogId.globallogidVar);

                objExcelFormat.ProcessedSheetExcel(carid1, ds, comboBox3.Text);
                DataSet ds1 = objSubmitionDetailsBL.GetCarIdCount(carid1, dt, GlobalLogId.globallogidVar);
                if (ds1.Tables[0].Rows.Count > 0)
                    label15.Text = ds1.Tables[0].Rows[0][0].ToString();
                else
                    label15.Text = "No Postings Found";
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Downloaded to ExcelSheet Sucessfully");
                button9.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please Select Date or enter Date");
                comboBox3.Text = "";
                comboBox3.Focus();
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+") || (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\b"))))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void webBrowser1_NewWindow(object sender, WebBrowserNavigatingEventArgs e)
        {
            //e.Cancel = true;
            //if (webBrowser1.Document != null)
            //{
            //    HtmlElement currentElement = webBrowser1.Document.ActiveElement;
            //    if (currentElement != null)
            //    {
            string currentURl = e.Url.ToString();
            //        You can perform some logic here to determine if the targetPath conformsto your specification and if so...
            //        MainForm newWindow = new MainForm();
            //        newWindow.webBrowser1.Navigate(targetPath);
            //        newWindow.Show();
            //        Otherwise
            //        webBrowser1.Navigate(targetPath);

            //    }
            //}
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text = "";
            dateoftoday = comboBox3.SelectedItem.ToString();
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            comboBox3.Text = "";
        }       
        #endregion
        #region picturebox
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(174, 200);
            pictureBox1.Height = 50;
            pictureBox1.Width = 35;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(224, 200);
            pictureBox2.Height = 50;
            pictureBox2.Width = 35;
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Location = new Point(150, 150);
            pictureBox3.Height = 180;
            pictureBox3.Width = 180;
            pictureBox3.BringToFront();
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(150, 150);
            pictureBox1.Height = 180;
            pictureBox1.Width = 180;
            pictureBox1.BringToFront();
            // pictureBox1.SizeMode=
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(150, 150);
            pictureBox2.Height = 180;
            pictureBox2.Width = 180;
            pictureBox2.BringToFront();

        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Location = new Point(274, 200);
            pictureBox3.Height = 50;
            pictureBox3.Width = 35;



        }
        #endregion
        #region defined methods
        public Main()
        {
            InitializeComponent();
            int crid = 0;
            this.AcceptButton = button1;
            
        }
        public void Getpending()
        {

            Cursor.Current = Cursors.WaitCursor;

            DataSet dsp1 = new DataSet();
            DataSet dsp2 = new DataSet();
            DataSet dsp3 = new DataSet();
            DataSet dsp4 = new DataSet();

            dsp1 = objSubmitionDetailsBL.MultiGetTotPending();
            dsp2 = objSubmitionDetailsBL.MultiGetPendingCount();




            dsp3 = objSubmitionDetailsBL.MultiGetTicketCount();
            dsp4 = objSubmitionDetailsBL.MultiGetPendingCount1();
            DataTable dtp1 = new DataTable();
            dtp1.Columns.Add("CarId", typeof(int));
            dtp1.Columns.Add("PublishDt", typeof(string));
            dtp1.Columns.Add("State", typeof(string));
            dtp1.Columns.Add("LastPostDt", typeof(string));
            dtp1.Columns.Add("#Posts", typeof(int));
            dtp1.Columns.Add("Year/Make/Model/Price/Mileage", typeof(string));
            dtp1.Columns.Add("CarStatus", typeof(string));
            dtp1.Columns.Add("UrlPend#", typeof(int));
            dtp1.Columns.Add("QcPend#", typeof(int));

            dtp1.Columns.Add("RelTkts#", typeof(int));





            DataTable dtp2 = new DataTable();
            dtp2.Columns.Add("CarId", typeof(int));
            dtp2.Columns.Add("UrlPend#", typeof(int));

            DataTable dtp3 = new DataTable();
            dtp3.Columns.Add("CarId", typeof(int));
            dtp3.Columns.Add("#tkts", typeof(int));

            DataTable dtp4 = new DataTable();
            dtp4.Columns.Add("CarId", typeof(int));
            dtp4.Columns.Add("QcPend#", typeof(int));




            for (int i = 0; i < dsp1.Tables[0].Rows.Count; i++)
            {
                DataRow dynamicRow1 = dtp1.NewRow();
                dtp1.Rows.Add(dynamicRow1);


                dtp1.Rows[i]["CarId"] = Convert.ToInt32(dsp1.Tables[0].Rows[i]["CarId"]);
                dtp1.Rows[i]["PublishDt"] = dsp1.Tables[0].Rows[i]["PublishedDt"]; ;
                dtp1.Rows[i]["#Posts"] = dsp1.Tables[0].Rows[i]["#Posts"];
                dtp1.Rows[i]["LastPostDt"] = dsp1.Tables[0].Rows[i]["LastSubDt"];
                // dtp1.Rows[i]["LastPostedBy"] = dsp1.Tables[0].Rows[i]["Lstpstby"];
                dtp1.Rows[i]["Year/Make/Model/Price/Mileage"] = dsp1.Tables[0].Rows[i]["year/make/model/price/Mileage"];
                dtp1.Rows[i]["CarStatus"] = dsp1.Tables[0].Rows[i]["status"];
                dtp1.Rows[i]["State"] = dsp1.Tables[0].Rows[i]["state"];
                dtp1.Rows[i]["UrlPend#"] = 0;
                dtp1.Rows[i]["QcPend#"] = 0;
                dtp1.Rows[i]["RelTkts#"] = 0;


            }

            if (dsp2.Tables[0].Rows.Count < dsp1.Tables[0].Rows.Count)
            {
                int j = dsp1.Tables[0].Rows.Count - dsp2.Tables[0].Rows.Count;

                for (int k = 0; k < j; k++)
                {

                    DataRow dynamicRow2 = dtp2.NewRow();
                    dtp2.Rows.Add(dynamicRow2);

                    dtp2.Rows[k]["CarId"] = 0;
                    dtp2.Rows[k]["UrlPend#"] = 0;

                }

            }

            if (dsp2.Tables[0].Rows.Count < dsp1.Tables[0].Rows.Count)
            {
                int j = dsp1.Tables[0].Rows.Count - dsp2.Tables[0].Rows.Count;

                for (int k = 0; k < j; k++)
                {

                    DataRow dynamicRow2 = dtp4.NewRow();
                    dtp4.Rows.Add(dynamicRow2);

                    dtp4.Rows[k]["CarId"] = 0;
                    dtp4.Rows[k]["QcPend#"] = 0;

                }

            }

            if (dsp2.Tables[0].Rows.Count <= dsp1.Tables[0].Rows.Count)
            {
                int x = dsp1.Tables[0].Rows.Count - dsp2.Tables[0].Rows.Count;
                int m = x + dsp2.Tables[0].Rows.Count;
                int n = 0;

                for (int l = x; l < m; l++)
                {
                    DataRow dynamicRow2 = dtp2.NewRow();
                    dtp2.Rows.Add(dynamicRow2);

                    dtp2.Rows[l]["CarId"] = Convert.ToInt32(dsp2.Tables[0].Rows[n]["Carid"]);
                    dtp2.Rows[l]["UrlPend#"] = dsp2.Tables[0].Rows[n]["UrlPend"];


                    n++;
                }
            }
            if (dsp4.Tables[0].Rows.Count <= dsp1.Tables[0].Rows.Count)
            {
                int x = dsp1.Tables[0].Rows.Count - dsp4.Tables[0].Rows.Count;
                int m = x + dsp4.Tables[0].Rows.Count;
                int n = 0;

                for (int l = 0; l < dsp4.Tables[0].Rows.Count; l++)
                //  for (int l = 0; l <m; l++)
                {
                    DataRow dynamicRow2 = dtp4.NewRow();
                    dtp4.Rows.Add(dynamicRow2);

                    dtp4.Rows[l]["CarId"] = Convert.ToInt32(dsp4.Tables[0].Rows[n]["Carid"]);
                    dtp4.Rows[l]["QcPend#"] = dsp4.Tables[0].Rows[n]["QcPend"];


                    n++;
                }
            }


            for (int p = 0; p < dtp1.Rows.Count; p++)
            {

                for (int q = 0; q < dtp2.Rows.Count; q++)
                {
                    // Label1.Text = dt1.Rows[p]["Dosage2"].ToString();
                    //  Label2.Text = dt2.Rows[q]["Dos2"].ToString();

                    if (dtp1.Rows[p]["Carid"].ToString() == dtp2.Rows[q]["Carid"].ToString())
                    {

                        // Label3 .Text = dt1.Rows[p]["Dosage6"].ToString();
                        //  Label4 .Text  = dt2.Rows[q]["Dos2"].ToString();
                        //  dt1.Rows[p]["Carid"] = dt2.Rows[q]["Dos5"];
                        dtp1.Rows[p]["UrlPend#"] = dtp2.Rows[q]["UrlPend#"];
                        //  dt1.Rows[p]["Dosage7"] = dt2.Rows[q]["Dos7"];
                    }

                }

            }


            for (int p = 0; p < dtp1.Rows.Count; p++)
            {

                for (int q = 0; q < dtp4.Rows.Count; q++)
                {
                    // Label1.Text = dt1.Rows[p]["Dosage2"].ToString();
                    //  Label2.Text = dt2.Rows[q]["Dos2"].ToString();
                    string caris = dtp1.Rows[p]["Carid"].ToString();
                    string caris1 = dtp4.Rows[q]["carid"].ToString();

                    if (dtp1.Rows[p]["Carid"].ToString() == dtp4.Rows[q]["Carid"].ToString())
                    {

                        // Label3 .Text = dt1.Rows[p]["Dosage6"].ToString();
                        //  Label4 .Text  = dt2.Rows[q]["Dos2"].ToString();
                        //  dt1.Rows[p]["Carid"] = dt2.Rows[q]["Dos5"];
                        dtp1.Rows[p]["QcPend#"] = dtp4.Rows[q]["QcPend#"];
                        //  dt1.Rows[p]["Dosage7"] = dt2.Rows[q]["Dos7"];
                    }


                }



            }
            //  ----------------

            if (dsp3.Tables[0].Rows.Count <= dsp1.Tables[0].Rows.Count)
            {
                int j = dsp1.Tables[0].Rows.Count - dsp3.Tables[0].Rows.Count;

                for (int k = 0; k < j; k++)
                {

                    DataRow dynamicRow3 = dtp3.NewRow();
                    dtp3.Rows.Add(dynamicRow3);

                    dtp3.Rows[k]["CarId"] = 0;
                    dtp3.Rows[k]["#tkts"] = 0;


                }

            }

            if (dsp3.Tables[0].Rows.Count < dsp1.Tables[0].Rows.Count)
            {
                int x = dsp1.Tables[0].Rows.Count - dsp3.Tables[0].Rows.Count;
                int m = x + dsp3.Tables[0].Rows.Count;
                int n = 0;

                for (int l = x; l < m; l++)
                {
                    DataRow dynamicRow3 = dtp3.NewRow();
                    dtp3.Rows.Add(dynamicRow3);

                    dtp3.Rows[l]["CarId"] = Convert.ToInt32(dsp3.Tables[0].Rows[n]["Carid"]);
                    dtp3.Rows[l]["#tkts"] = dsp3.Tables[0].Rows[n]["#tkts"];


                    n++;
                }
            }


            for (int p = 0; p < dtp1.Rows.Count; p++)
            {

                for (int q = 0; q < dtp3.Rows.Count; q++)
                {
                    // Label1.Text = dt1.Rows[p]["Dosage2"].ToString();
                    //  Label2.Text = dt2.Rows[q]["Dos2"].ToString();

                    if (dtp1.Rows[p]["Carid"].ToString() == dtp3.Rows[q]["Carid"].ToString())
                    {

                        // Label3 .Text = dt1.Rows[p]["Dosage6"].ToString();
                        //  Label4 .Text  = dt2.Rows[q]["Dos2"].ToString();
                        //  dt1.Rows[p]["Carid"] = dt2.Rows[q]["Dos5"];
                        dtp1.Rows[p]["RelTkts#"] = dtp3.Rows[q]["#tkts"];
                        //  dt1.Rows[p]["Dosage7"] = dt2.Rows[q]["Dos7"];
                    }

                }



            }
            //  dataGridView3.Refresh();
            dataGridView3.DataSource = null;

            dataGridView3.DataSource = dtp1;
            dataGridView3.AllowUserToAddRows = false;

            dataGridView3.Columns[0].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
            dataGridView3.Columns[4].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
            dataGridView3.Columns[7].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
            dataGridView3.Columns[8].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int t = dataGridView3.Rows.Count;
            for (int i = t; i <= 28; i++)
            {
                // object[] obj = { null, "", "", "", null, "", "", null, null };
                dtp1.Rows.Add();

            }



            DataGridViewColumn columnp0 = dataGridView3.Columns[0];
            columnp0.Width = 65;

            DataGridViewColumn columnp1 = dataGridView3.Columns[1];
            columnp1.Width = 85;


            DataGridViewColumn columnp2 = dataGridView3.Columns[2];
            columnp2.Width = 67;
            DataGridViewColumn columnp3 = dataGridView3.Columns[3];
            columnp3.Width = 85;
            DataGridViewColumn columnp6 = dataGridView3.Columns[6];
            columnp6.Width = 85;


            DataGridViewColumn columnp5 = dataGridView3.Columns[5];
            columnp5.Width = 220;

            DataGridViewColumn columnp7 = dataGridView3.Columns[7];
            columnp7.Width = 75;
            DataGridViewColumn columnp8 = dataGridView3.Columns[8];
            columnp8.Width = 79;



            string fcarid = dataGridView3.Rows[0].Cells[0].Value.ToString();
            DataSet dsfcarid = new DataSet();
            dsfcarid = objSubmitionDetailsBL.MultigetPendingSites(fcarid);
            if (dsfcarid.Tables[0].Rows.Count == 0)
            {
                label43.Text = "CarId: " + carid.ToString();
                DataSet dtsp2 = new DataSet();
                dtsp2 = objSubmitionDetailsBL.MultigetPendingSites1(fcarid);
                dataGridView4.DataSource = dtsp2.Tables[0];
                dataGridView4.Columns["sitename"].ReadOnly = true;


                dataGridView4.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
                dataGridView4.Columns[1].DefaultCellStyle.ForeColor = Color.Red;
                dataGridView4.Columns[2].DefaultCellStyle.ForeColor = Color.Red;
                dataGridView4.Columns[1].DefaultCellStyle.Font = new Font(dataGridView4.DefaultCellStyle.Font, FontStyle.Underline);
                dataGridView4.Columns[2].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);


                DataGridViewColumn cldtg11 = dataGridView4.Columns[1];
                cldtg11.Width = 145;
                DataGridViewColumn cldtg21 = dataGridView4.Columns[2];
                cldtg21.Width = 125;
                DataGridViewColumn cldtg31 = dataGridView4.Columns[3];
                cldtg31.Width = 77;
                this.dataGridView4.Columns["StId"].Visible = false;
                this.dataGridView4.Columns["UrlId"].Visible = false;
                this.dataGridView4.Columns["CarId"].Visible = false;
                this.dataGridView4.Columns["URL"].Visible = false;
                this.dataGridView4.Columns["URLSID"].Visible = false;
                this.dataGridView4.Columns["Siteid"].Visible = false;
                this.dataGridView4.Columns["UrlPostDate"].Visible = false;
            }
            else
            {
                label43.Text = "CarId: " + fcarid.ToString();

                dataGridView4.DataSource = dsfcarid.Tables[0];
                DataGridViewColumn cldtg1 = dataGridView4.Columns[1];
                cldtg1.Width = 145;
                DataGridViewColumn cldtg2 = dataGridView4.Columns[2];
                cldtg2.Width = 125;
                dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridView4.ClearSelection();
                dataGridView4.Columns[1].DefaultCellStyle.ForeColor = Color.Red;
                dataGridView4.Columns[2].DefaultCellStyle.ForeColor = Color.Red;
                dataGridView4.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
                this.dataGridView4.Columns[2].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
                this.dataGridView4.Columns[3].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);

                this.dataGridView4.Columns["StId"].Visible = false;
                this.dataGridView4.Columns["UrlId"].Visible = false;
                this.dataGridView4.Columns["CarId"].Visible = false;
                this.dataGridView4.Columns["URL"].Visible = false;
                this.dataGridView4.Columns["URLSID"].Visible = false;
                this.dataGridView4.Columns["Siteid"].Visible = false;
                this.dataGridView4.Columns["UrlPostDate"].Visible = false;
            }


            Cursor.Current = Cursors.Default;

        }
        public Main(string strTextBox1)
        {
            InitializeComponent();

            frmcarid = strTextBox1;

        }
        public void GetCarDetails(string carid)
        {
            //  circularProgressControl1.Start();
            try
            {
                // pnlposttkt.Visible = true;
                comboBox1.Text = "";
                //pnlpostnotes.Visible = true;
                button2.Visible = false;
                label30.Visible = false;
                label27.Visible = false;
                label28.Visible = false;
                label29.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                comboBox2.Visible = false;
                button5.Visible = false;
                button7.Visible = false;
                pnlpoststeps.Visible = false;
                pnlpostnotes.Visible = false;
                webBrowser1.Visible = false;
                pnlpostbuttons.Visible = false;
                string txtcarid = textBox3.Text;
                //if (txtcarid != "")
                //{
                //string number = textBox.Text;
                //Regex regex = new Regex(@"[\d]");
                //if (regex.IsMatch(number))
                //{
                Cursor.Current = Cursors.WaitCursor;
                //circularProgressControl2.Visible = true;
                //circularProgressControl2.Start();
                //circularProgressControl2.BringToFront();
                try
                {
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(carid);
                    if (obUsedCarsInfo.Count > 0)
                    {
                        FillCarDetails(obUsedCarsInfo);
                        int rctcarid = Convert.ToInt32(carid.ToString());
                        DataSet dsSubDet = new DataSet();
                        dsSubDet = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(rctcarid);

                        dgvpostforpostedcarid.DataSource = dsSubDet.Tables[0];
                        DataGridViewColumn column1 = dgvpostforpostedcarid.Columns[0];
                        column1.Width = 20;
                        if (dsSubDet.Tables[0].Rows.Count == 0)
                        {
                            dgvpostforpostedcarid.Visible = true;
                            label48.Text = "Zero Posts For this Carid";
                            label48.Visible = true;
                        }
                        else
                        {
                            label48.Visible = false;
                            dgvpostforpostedcarid.Visible = true;
                        }


                        panel1.Visible = false;

                        label35.Visible = true;
                        label36.Visible = true;

                        label37.Visible = true;
                        label38.Visible = true;
                        label41.Visible = true;
                        label40.Visible = true;
                        //btnGetAllPics.Visible = true;
                        label38.Visible = true;
                        label39.Visible = true;
                        comboBox1.Visible = true;
                        comboBox1.Text = "";
                        lblpostsite.Visible = true;

                        label39.ForeColor = Color.Green;
                        label38.ForeColor = Color.Green;
                        //  comboBox2.Visible = false;
                        textBox2.Visible = false;
                        lblemail.Visible = false;
                        label25.Visible = false;
                        button4.Visible = false;
                        button6.Visible = false;

                        btnpostsubmit.Visible = false;
                        btnpostupload.Visible = false;
                        btnuploadtolive.Visible = false;
                        //}
                        //    else
                        //    {
                        //        MessageBox.Show("CarId not found .Please try with another Carid");

                        //        comboBox1.Text = "";
                        //        label38.Visible = false;
                        //        label39.Visible = false;
                        //        lblimages.Visible = false;
                        //        btnGetAllPics.Visible = false;
                        //        btnback.Visible = false;
                        //        btnforward.Visible = false;
                        //        pictureBox1.Visible = false;
                        //        pictureBox2.Visible = false;
                        //        pictureBox3.Visible = false;
                        //        dgvpostforpostedcarid.Visible = false;
                        //        pnlpostcardata.Visible = false;
                        //        pnlpostnotes.Visible = false;
                        //        pnlposttkt.Visible = false;
                        //        pnlpostbuttons.Visible = false;
                        //        pnlpoststeps.Visible = false;
                        //        webBrowser1.Visible = false;
                        //        label40.Visible = false;
                        //        label41.Visible = false;
                        //        panel1.Visible = true;
                        //        textBox3.Text = "";
                        //        textBox3.Focus();
                        //    }

                        //}
                        //catch (Exception ex)
                        //{
                        //    comboBox1.Text = "";
                        //    label38.Visible = false;
                        //    label39.Visible = false;
                        //    lblimages.Visible = false;
                        //    btnGetAllPics.Visible = false;
                        //    btnback.Visible = false;
                        //    btnforward.Visible = false;
                        //    pictureBox1.Visible = false;
                        //    pictureBox2.Visible = false;
                        //    pictureBox3.Visible = false;
                        //    dgvpostforpostedcarid.Visible = false;
                        //    pnlpostcardata.Visible = false;
                        //    pnlpostnotes.Visible = false;
                        //    pnlposttkt.Visible = false;
                        //    pnlpostbuttons.Visible = false;
                        //    pnlpoststeps.Visible = false;
                        //    webBrowser1.Visible = false;
                        //    label40.Visible = false;
                        //    label41.Visible = false;
                        //    panel1.Visible = true;
                        //    textBox3.Text = "";
                        //    textBox3.Focus();
                        //}




                        pnlpostcardata.Visible = true;
                        pnlpostnotes.Visible = true;
                        pnlposttkt.Visible = true;


                        pnlpoststeps.Visible = true;
                        pnlpostbuttons.Visible = true;
                        pnlpostbrowser.Visible = true;
                        // pnlpostpics.Visible = true;



                        int count = 0;
                        DataSet dsemail = new DataSet();
                        dsemail = objSubmitionDetailsBL.MultiGetEmailByCarid(carid);
                        if (dsemail.Tables.Count > 0)
                        {
                            if (dsemail.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in dsemail.Tables[0].Rows)
                                {
                                    if(dr["EmailId"].ToString().Contains("americantravelexpert"))
                                    {
                                        count++;
                                    }
                                }
                                if (count != 0)
                                {
                                    comboBox2.DataSource = dsemail.Tables[0];
                                    comboBox2.DisplayMember = dsemail.Tables[0].Columns["EmailId"].ToString();
                                    textBox2.Text = dsemail.Tables[0].Rows[0]["Password"].ToString();
                                }
                                else
                                {
                                    string state = obUsedCarsInfo[0].State.ToString().Trim();
                                    string NewEmail = General.EmailCreation.createmail(label10.Text, state);
                                    string password = "UCEURV123";
                                    objSubmitionDetailsBL.MultiSaveEmail(NewEmail.Trim(), password.Trim(), label10.Text);
                                    DataSet Newml = new DataSet();
                                    Newml = objSubmitionDetailsBL.MultiGetEmailByCarid(carid);
                                    if (Newml.Tables.Count > 0)
                                    {
                                        if (dsemail.Tables[0].Rows.Count > 0)
                                        {
                                            comboBox2.DataSource = Newml.Tables[0];
                                            comboBox2.DisplayMember = Newml.Tables[0].Columns["EmailId"].ToString();
                                            textBox2.Text = Newml.Tables[0].Rows[0]["Password"].ToString();
                                        }
                                    }
                                }
                            }

                            else
                            {
                                //create email start
                                string state = obUsedCarsInfo[0].State.ToString().Trim();

                                string NewEmail = General.EmailCreation.createmail(label10.Text, state);
                                string password = "UCEURV123";


                                objSubmitionDetailsBL.MultiSaveEmail(NewEmail.Trim(), password.Trim(), label10.Text);
                                //create email end

                                //getEmail start
                                DataSet Newml = new DataSet();
                                Newml = objSubmitionDetailsBL.MultiGetEmailByCarid(carid);
                                if (Newml.Tables.Count > 0)
                                {
                                    if (dsemail.Tables[0].Rows.Count > 0)
                                    {
                                        comboBox2.DataSource = Newml.Tables[0];
                                        comboBox2.DisplayMember = Newml.Tables[0].Columns["EmailId"].ToString();
                                        textBox2.Text = Newml.Tables[0].Rows[0]["Password"].ToString();
                                    }
                                }
                                //Getemailend
                            }
                        }
                        DataSet dsnotebtn = new DataSet();
                        int btncarid = Convert.ToInt32(carid);
                        dsnotebtn = objSubmitionDetailsBL.GetMultiNote(btncarid);
                        if (dsnotebtn.Tables.Count > 0)
                        {
                            if (dsnotebtn.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsnotebtn.Tables[0].Rows.Count; i++)
                                {
                                    textBox4.Text += dsnotebtn.Tables[0].Rows[i]["Note"].ToString() + "\r\n";
                                }
                            }
                            else
                            {
                                textBox4.Text = "";
                            }
                        }
                        DataSet pudds = new DataSet();
                        pudds = objSubmitionDetailsBL.MultiSiteGetRecentPostDataByCarId(carid);
                        if (pudds.Tables.Count > 0)
                        {
                            if (pudds.Tables[0].Rows.Count > 0)
                            {
                                label34.Text = pudds.Tables[0].Rows[0]["Publisheddt"].ToString();
                            }
                            else
                            {
                                label34.Text = "Not Published";
                            }
                        }
                       DataSet dssitename = new DataSet();

                        dssitename = objSubmitionDetailsBL.MultiGetSiteList();
                        comboBox1.DataSource = dssitename.Tables[0];
                        comboBox1.DisplayMember = dssitename.Tables[0].Columns["SiteName"].ToString();
                        comboBox1.ValueMember = dssitename.Tables[0].Columns["SmrtzSiteID"].ToString();

                        //int tcarid=Convert.ToInt32(textBox3.Text);
                        //dssitename = objSubmitionDetailsBL.MultiGetSiteNameTransation(tcarid);
                        //comboBox1.DataSource = dssitename.Tables[0];
                        //comboBox1.DisplayMember = dssitename.Tables[0].Columns["SiteName"].ToString();
                        //comboBox1.ValueMember = dssitename.Tables[0].Columns["SmrtzSiteID"].ToString();
                        //DataSet tktds = new DataSet();
                        //tktds = objSubmitionDetailsBL.MultiGetTicketCountByCarId(carid);
                        //if (tktds.Tables.Count > 0)
                        //{
                        //    if (tktds.Tables[0].Rows.Count > 0)
                        //    {
                        //        label37.Text = tktds.Tables[0].Rows[0]["#tkts"].ToString();
                        //    }
                        //    else
                        //    {
                        //        label37.Text = "0";
                        //    }
                        //}
                        //else
                        //{
                        //    label37.Text = "0";
                        //}
                        //if (pudds.Tables.Count > 0)
                        //{
                        //    if (pudds.Tables[0].Rows.Count > 0)
                        //    {
                        //        string crstatus = pudds.Tables[0].Rows[0]["Status"].ToString();
                        //        if (crstatus == "Paid")
                        //        {
                        //            label39.Text = "Published";
                        //        }
                        //        else
                        //        {
                        //            label39.Text = "Not Published";
                        //        }
                        //    }
                        //    else
                        //    {
                        //        label39.Text = "Not Published";
                        //    }
                        //}
                        //else
                        //{
                        //    label39.Text = "Not Published";
                        //}
                        comboBox2.Text = "";
                        textBox2.Text = "";
                        //-------------------------------------------------------------------
                    }
                    else
                    {
                        // MessageBox.Show("CarId not found .Please try with another Carid");

                        comboBox1.Text = "";
                        label38.Visible = false;
                        label39.Visible = false;
                        lblimages.Visible = false;
                        btnGetAllPics.Visible = false;
                        btnback.Visible = false;
                        btnforward.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = false;
                        dgvpostforpostedcarid.Visible = false;
                        pnlpostcardata.Visible = false;
                        pnlpostnotes.Visible = false;
                        pnlposttkt.Visible = false;
                        pnlpostbuttons.Visible = false;
                        pnlpoststeps.Visible = false;
                        webBrowser1.Visible = false;
                        label40.Visible = false;
                        label41.Visible = false;
                        panel1.Visible = true;
                        MessageBox.Show("CarId not found .Please try with another Carid", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox3.Text = "";
                        textBox3.Focus();
                    }

                }
                catch (Exception ex)
                {

                    comboBox1.Text = "";
                    label38.Visible = false;
                    label39.Visible = false;
                    lblimages.Visible = false;
                    btnGetAllPics.Visible = false;
                    btnback.Visible = false;
                    btnforward.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    dgvpostforpostedcarid.Visible = false;
                    pnlpostcardata.Visible = false;
                    pnlpostnotes.Visible = false;
                    pnlposttkt.Visible = false;
                    pnlpostbuttons.Visible = false;
                    pnlpoststeps.Visible = false;
                    webBrowser1.Visible = false;
                    label40.Visible = false;
                    label41.Visible = false;
                    panel1.Visible = true;
                    textBox3.Text = "";
                    textBox3.Focus();
                    MessageBox.Show("CarId not found.Please try another CarId", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                //}
                //    else
                //    {
                //        MessageBox.Show(" Enter Carid                 ");
                //        textBox3.Text = "";
                //    }
                ////}
                //else
                //{
                //    MessageBox.Show("Please Enter Any carId           ");
                //    textBox3.Text = "";
                //}

                DataGridViewColumn clmpostgrdmn0 = dgvpostforpostedcarid.Columns[0];
                clmpostgrdmn0.Width = 20;
                DataGridViewColumn clmpostgrdmn1 = dgvpostforpostedcarid.Columns[1];
                clmpostgrdmn1.Width = 80;

                DataGridViewColumn clmpostgrdmn2 = dgvpostforpostedcarid.Columns[2];
                clmpostgrdmn2.Width = 75;
                return;
                // pnlpostnotes.Visible = true;

            }
            catch (Exception ex)
            {
                // MessageBox.Show("CarId not found.Please try another CarId");


                comboBox1.Text = "";
                label38.Visible = false;
                label39.Visible = false;
                lblimages.Visible = false;
                btnGetAllPics.Visible = false;
                btnback.Visible = false;
                btnforward.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                dgvpostforpostedcarid.Visible = false;
                pnlpostcardata.Visible = false;
                pnlpostnotes.Visible = false;
                pnlposttkt.Visible = false;
                pnlpostbuttons.Visible = false;
                pnlpoststeps.Visible = false;
                webBrowser1.Visible = false;
                label40.Visible = false;
                label41.Visible = false;
                panel1.Visible = true;
                textBox3.Text = "";
                textBox3.Focus();
            }
            Cursor.Current = Cursors.Default;
            //circularProgressControl1.Stop();
        }
        public void FillCarDetails(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {
            //LabelBind Start//////
            Cursor.Current = Cursors.WaitCursor;
            label10.Text = obUsedCarsInfo[0].Carid.ToString();
            string mileage = obUsedCarsInfo[0].Mileage.ToString();

            if (mileage.Contains("."))
            {
                int index = 0;

                int Endindex = mileage.IndexOf(".");

                mileage = mileage.ToString().Substring(index, Endindex - index);
            }
            else
            {
                mileage = obUsedCarsInfo[0].Mileage.ToString();

            }

            double dsda = Convert.ToDouble(mileage);
            mileage = dsda.ToString("0,0", CultureInfo.InvariantCulture);

            string pricechng1 = obUsedCarsInfo[0].Price.ToString();
            if (pricechng1 == "0")
            {
                pricechng1 = "1";
            }

            double pricechng2 = Convert.ToDouble(pricechng1);
            string pricechng = pricechng2.ToString("0,0", CultureInfo.InvariantCulture);

            if (pricechng.Contains("."))
            {
                int index1 = 0;

                int Endindex1 = pricechng.IndexOf(".");

                pricechng = pricechng.ToString().Substring(index1, Endindex1 - index1);
                pricechng = "$" + pricechng;
            }
            else
            {
                pricechng = "$" + pricechng;
            }

            label39.Text = obUsedCarsInfo[0].AdStatus.ToString();

            label11.Text = obUsedCarsInfo[0].YearOfMake.ToString() + " / " + obUsedCarsInfo[0].Make.ToString() + " / " + obUsedCarsInfo[0].Model.ToString() + " / " + pricechng + " / " + mileage;
            string pmake = obUsedCarsInfo[0].Make.ToString();
            string pmodel = obUsedCarsInfo[0].Model.ToString();
            string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
            string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
            string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
            label12.Text = obUsedCarsInfo[0].Title.ToString();
            label13.Text = url;
            label14.Text = obUsedCarsInfo[0].Phone.ToString();
            textBox10.Text = obUsedCarsInfo[0].City.ToString().Trim() + "," + obUsedCarsInfo[0].State.ToString().Trim() + "," + obUsedCarsInfo[0].Zip.ToString().Trim();

            textBox10.Font = new Font(textBox10.Font.Name, 8, FontStyle.Bold);
            label24.Text = obUsedCarsInfo[0].Fueltype.ToString() + " / " + obUsedCarsInfo[0].Transmission.ToString() + " / " + obUsedCarsInfo[0].NumberOfSeats.ToString() + " / " + obUsedCarsInfo[0].NumberOfCylinder.ToString();
            ////string pmake = obUsedCarsInfo[0].Make.ToString();
            ////string pmodel = obUsedCarsInfo[0].Model.ToString();
            ////string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
            ////string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
            ////string url = "UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";

            string dep = obUsedCarsInfo[0].Description.ToString();
            int val = 1000;
            string pn = obUsedCarsInfo[0].Phone.ToString() + " ";
            string make = obUsedCarsInfo[0].Make.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Make.ToString() == "Unspecified" ? "" : "\r\nMake: " + obUsedCarsInfo[0].Make.ToString();

            string model = obUsedCarsInfo[0].Model.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Model.ToString() == "Unspecified" ? "" : "\r\nModel: " + obUsedCarsInfo[0].Model.ToString(); ;
            string year = obUsedCarsInfo[0].YearOfMake.ToString() == "Emp" ? "" : obUsedCarsInfo[0].YearOfMake.ToString() == "Unspecified" ? "" : "\r\nyear: " + obUsedCarsInfo[0].YearOfMake.ToString();
            string doors = obUsedCarsInfo[0].NumberOfDoors.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfDoors.ToString() == "Unspecified" ? "" : "\r\nDoors: " + obUsedCarsInfo[0].NumberOfDoors.ToString();
            string bodystyle = obUsedCarsInfo[0].Bodytype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Bodytype.ToString() == "Unspecified" ? "" : "\r\nBodytype: " + obUsedCarsInfo[0].Bodytype.ToString();

            string exteriorcolor = obUsedCarsInfo[0].ExteriorColor.ToString() == "Emp" ? "" : obUsedCarsInfo[0].ExteriorColor.ToString() == "Unspecified" ? "" : "\r\nExteriorColor: " + obUsedCarsInfo[0].ExteriorColor.ToString();
            string interior = obUsedCarsInfo[0].InteriorColor.ToString() == "Emp" ? "" : obUsedCarsInfo[0].InteriorColor.ToString() == "Unspecified" ? "" : "\r\nInteriorColor: " + obUsedCarsInfo[0].InteriorColor.ToString();
            string seats = obUsedCarsInfo[0].NumberOfSeats.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfSeats.ToString() == "Unspecified" ? "" : "\r\nSeats: " + obUsedCarsInfo[0].NumberOfSeats.ToString();
            string price = "Price: " + "$" + (obUsedCarsInfo[0].Price.ToString() == "0" ? "1" : obUsedCarsInfo[0].Price.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Price.ToString() == "Unspecified" ? "" : obUsedCarsInfo[0].Price.ToString());
            string fuel = obUsedCarsInfo[0].Fueltype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Fueltype.ToString() == "Unspecified" ? "" : "\r\nFuelType: " + obUsedCarsInfo[0].Fueltype.ToString();
            string transmission = obUsedCarsInfo[0].Transmission.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Transmission.ToString() == "Unspecified" ? "" : "\r\nTransmission: " + obUsedCarsInfo[0].Transmission.ToString();
            string drivetrain = obUsedCarsInfo[0].DriveTrain.ToString() == "Emp" ? "" : obUsedCarsInfo[0].DriveTrain.ToString() == "Unspecified" ? "" : "\r\nDriveTrain: " + obUsedCarsInfo[0].DriveTrain.ToString();
            mileage = obUsedCarsInfo[0].Mileage.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Mileage.ToString() == "Unspecified" ? "" : "\r\nMileage: " + obUsedCarsInfo[0].Mileage.ToString();
            //obUsedCarsInfo[0]..ToString();
            string Engine = obUsedCarsInfo[0].NumberOfCylinder.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfCylinder.ToString() == "Unspecified" ? "" : "\r\nEngine: " + obUsedCarsInfo[0].NumberOfCylinder.ToString();

            int carid = Convert.ToInt32(obUsedCarsInfo[0].Carid.ToString());


            DataSet dsfeatures = objSubmitionDetailsBL.MultisiteGetCarFeatures(carid);


            if (dsfeatures.Tables[0].Rows.Count > 0)
            {
                Comfort = "";
                Seats = "";
                Safety = "";
                soundsystem = "";
                powerWindows = "";
                Other = "";
                New = "";
                Specials = "";
                for (int k = 0; k < dsfeatures.Tables[0].Rows.Count; k++)
                {
                    if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "1")
                    {


                        Comfort += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";



                        //Comfort += Comfort + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                    }
                    if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "2")
                    {


                        Seats += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";



                        // Seats = Seats + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                    }
                    if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "3")
                    {


                        Safety += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";



                        //Safety = Safety + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                    }
                    if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "4")
                    {

                        soundsystem += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";


                        //  soundsystem = soundsystem + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                    }
                    if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "5")
                    {

                        powerWindows += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";


                        //  powerWindows = powerWindows + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                    }
                    if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "6")
                    {

                        Other += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";

                        //  Other = Other + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                    }
                    if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "7")
                    {

                        New += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";


                        //  New = New + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                    }
                    if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "8")
                    {

                        Specials += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";

                        // Specials = Specials + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                    }
                }

                if (Comfort != "")
                {
                    Comfort = Comfort.TrimEnd(',') + ".";
                }
                if (Seats != "")
                {
                    Seats = Seats.TrimEnd(',') + ".";
                }
                if (Safety != "")
                {
                    Safety = Safety.TrimEnd(',') + ".";
                }
                if (soundsystem != "")
                {
                    soundsystem = soundsystem.TrimEnd(',') + ".";
                }
                if (powerWindows != "")
                {
                    powerWindows = powerWindows.TrimEnd(',') + ".";
                }
                if (Other != "")
                {
                    Other = Other.TrimEnd(',') + ".";
                }
                if (New != "")
                {
                    New = New.TrimEnd(',') + ".";
                }
                if (Specials != "")
                {
                    Specials = Specials.TrimEnd(',') + ".";
                }
            }




            Comfort = Comfort == "" ? "" : Comfort == "Unspecified" ? "" : "\r\nComfort: " + Comfort;

            Seats = Seats == "" ? "" : Seats == "Unspecified" ? "" : "\r\nSeats: " + Seats;

            Safety = Safety == "" ? "" : Safety == "Unspecified" ? "" : "\r\nSafety: " + Safety;
            soundsystem = soundsystem == "" ? "" : soundsystem == "Unspecified" ? "" : "\r\nsoundsystem: " + soundsystem;
            powerWindows = powerWindows == "" ? "" : powerWindows == "Unspecified" ? "" : "\r\npowerWindows: " + powerWindows;
            Other = Other == "" ? "" : Other == "Unspecified" ? "" : "\r\nOther: " + Other;
            New = New == "" ? "" : New == "Unspecified" ? "" : "\r\nNew: " + New;
            Specials = Specials == "" ? "" : Specials == "Unspecified" ? "" : "\r\nSpecials: " + Specials;





            string details = (make.Trim() == "" ? "" : make.Trim()) + (model.Trim() == "" ? "" : "\r\n" + model.Trim()) + (year.Trim() == "" ? "" : "\r\n" + year.Trim()) + (doors.Trim() == "" ? "" : "\r\n" + doors.Trim()) + (bodystyle.Trim() == "" ? "" : "\r\n" + bodystyle.Trim()) + (exteriorcolor.Trim() == "" ? "" : "\r\n" + exteriorcolor.Trim()) + (interior.Trim() == "" ? "" : "\r\n" + interior.Trim()) + (seats.Trim() == "" ? "" : "\r\n" + seats.Trim()) + (price.Trim() == "" ? "" : "\r\n" + price.Trim()) + (transmission.Trim() == "" ? "" : "\r\n" + transmission.Trim()) + (mileage.Trim() == "" ? "" : "\r\n" + mileage.Trim()) + (fuel.Trim() == "" ? "" : "\r\n" + fuel.Trim()) + (drivetrain.Trim() == "" ? "" : "\r\n" + drivetrain.Trim()) + (Engine.Trim() == "" ? "" : "\r\n" + Engine.Trim()) + "\r\n" + (Comfort.Trim() == "" ? "" : "\r\n" + Comfort.Trim()) + (Seats.Trim() == "" ? "" : "\r\n" + Seats.Trim()) + (Safety.Trim() == "" ? "" : "\r\n" + Safety.Trim()) + (soundsystem.Trim() == "" ? "" : "\r\n" + soundsystem.Trim()) + (powerWindows.Trim() == "" ? "" : "\r\n" + powerWindows.Trim()) + (Other.Trim() == "" ? "" : "\r\n" + Other.Trim()) + (New.Trim() == "" ? "" : "\r\n" + New.Trim()) + (Specials.Trim() == "" ? "" : "\r\n" + Specials.Trim());
            if (dep.Contains("Emp"))
            {
                dep = dep.Replace("Emp", "");
            }

            dep = dep.Replace("\n", " ");


            string dd = obUsedCarsInfo[0].DateOfPosting.ToString();


            string URLDesp = WrapTextByMaxCharacters(details, dep, val, url, pn);
            textBox1.Text = URLDesp;
            // tabControl1.SelectedIndex = 4;
            //LabelBind End///////
            pictureBoxlogo.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            //for Image Download
            if (Pics.GetPic0(obUsedCarsInfo) == null)
            {
                CreateImageURLPath(Pics.GetPic1(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-2", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic2(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-3", obUsedCarsInfo[0].Carid.ToString());
            }
            else if (Pics.GetPic1(obUsedCarsInfo) == null)
            {
                CreateImageURLPath(Pics.GetPic0(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-1", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic2(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-3", obUsedCarsInfo[0].Carid.ToString());
            }
            else if (Pics.GetPic2(obUsedCarsInfo) == null)
            {
                CreateImageURLPath(Pics.GetPic0(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-1", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic1(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-2", obUsedCarsInfo[0].Carid.ToString());
            }
            else
            {

                imgcount = 0;
                CreateImageURLPath(Pics.GetPic0(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-1", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic1(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-2", obUsedCarsInfo[0].Carid.ToString());
                CreateImageURLPath(Pics.GetPic2(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-3", obUsedCarsInfo[0].Carid.ToString());

            }

            try
            {
                for (int i = 1; i <= 3; i++)
                {


                    string filePath = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + i + "" + ".jpg";
                    if (File.Exists(filePath))
                    {


                        int fileSize = (int)new System.IO.FileInfo(filePath).Length;
                        if (fileSize != 0)
                        {

                            imgcount++;
                            if (imgcount == 1)
                            {
                                pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-1" + ".jpg";

                                label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-1" + ".jpg";
                            }
                            if (imgcount == 2)
                            {
                                pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-2" + ".jpg";
                                label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-2" + ".jpg";
                            }
                            if (imgcount == 3)
                            {
                                pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-3" + ".jpg";
                                label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-3" + ".jpg";
                            }
                            if (imgcount == 3)
                            {
                                btnGetAllPics.Visible = true;
                                btnGetAllPics.Enabled = true;
                            }

                        }
                    }
                    else
                    {


                    }

                }

                //forending

                //for (int i = 1; i <= imgcount; i++)
                //{
                //    string filePath = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + i + "" + ".jpg";
                //    if (File.Exists(filePath))
                //    {
                //        int fileSize = (int)new System.IO.FileInfo(filePath).Length;
                //        if (fileSize != 0)
                //        {
                //            imgcount++;
                //        }

                //    }
                //}


                if (imgcount == 0)
                {
                    pictureBoxlogo.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    label19.Visible = false;

                    label20.Visible = false;

                    label21.Visible = false;
                    btnGetAllPics.Visible = true;
                    label47.Visible = true;
                }



                //label10.Text = obUsedCarsInfo[0].Carid.ToString();



                //string mileage = obUsedCarsInfo[0].Mileage.ToString();

                //if (mileage.Contains("."))
                //{
                //    int index = 0;

                //    int Endindex = mileage.IndexOf(".");

                //    mileage = mileage.ToString().Substring(index, Endindex - index);
                //}
                //else
                //{
                //    mileage = obUsedCarsInfo[0].Mileage.ToString();

                //}

                //double dsda = Convert.ToDouble(mileage);
                //mileage = dsda.ToString("0,0", CultureInfo.InvariantCulture);

                //string pricechng1 = obUsedCarsInfo[0].Price.ToString();
                //double pricechng2 = Convert.ToDouble(pricechng1);
                //string pricechng = pricechng2.ToString("0,0", CultureInfo.InvariantCulture);
                //if (pricechng.Contains("."))
                //{
                //    int index1 = 0;

                //    int Endindex1 = pricechng.IndexOf(".");

                //    pricechng = pricechng.ToString().Substring(index1, Endindex1 - index1);
                //    pricechng = "$" + pricechng;
                //}
                //else
                //{
                //    pricechng = "$" + pricechng;
                //}

                //label11.Text = obUsedCarsInfo[0].YearOfMake.ToString() + " / " + obUsedCarsInfo[0].Make.ToString() + " / " + obUsedCarsInfo[0].Model.ToString() + " / " + pricechng + " / " + mileage;


                //string pmake = obUsedCarsInfo[0].Make.ToString();
                //string pmodel = obUsedCarsInfo[0].Model.ToString();
                //string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
                //string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
                //string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
                //label12.Text = obUsedCarsInfo[0].Title.ToString();
                //label13.Text = url;
                //label14.Text = obUsedCarsInfo[0].Phone.ToString();
                //label15.Text = obUsedCarsInfo[0].City.ToString()+",".Trim() + obUsedCarsInfo[0].State.ToString().Trim();
                //label24.Text = obUsedCarsInfo[0].Fueltype.ToString() + " / " + obUsedCarsInfo[0].Transmission.ToString() + " / " + obUsedCarsInfo[0].NumberOfSeats.ToString() + " / " + obUsedCarsInfo[0].NumberOfCylinder.ToString();
                //string dep = obUsedCarsInfo[0].Description.ToString();
                //int val = 1000;
                //string pn = obUsedCarsInfo[0].Phone.ToString();
                //string details = " Make: " + obUsedCarsInfo[0].Make.ToString() + "\r\n Model: " + obUsedCarsInfo[0].Model.ToString() + "\r\n Year: " + obUsedCarsInfo[0].YearOfMake.ToString() + "\r\n Body Style: " + obUsedCarsInfo[0].Bodytype.ToString() + "\r\n Exterior Color: " + obUsedCarsInfo[0].ExteriorColor.ToString() + "\r\n Interior Color: " + obUsedCarsInfo[0].InteriorColor.ToString() + "\r\n Doors: " + obUsedCarsInfo[0].NumberOfDoors.ToString() + "\r\n Seats: " + obUsedCarsInfo[0].NumberOfSeats.ToString() + "\r\n Price: " + obUsedCarsInfo[0].Price.ToString() + "\r\n Mileage: " + obUsedCarsInfo[0].Mileage.ToString() + "\r\n Fuel: " + obUsedCarsInfo[0].Fueltype.ToString() + "\r\n Transmission: " + obUsedCarsInfo[0].Transmission.ToString() + "\r\n Drive Train: " + obUsedCarsInfo[0].DriveTrain.ToString() + "\r\n Vin: " + obUsedCarsInfo[0].VIN.ToString();
                //string dd = obUsedCarsInfo[0].DateOfPosting.ToString();


                //string URLDesp = WrapTextByMaxCharacters(details, dep, val, url, pn);

                //textBox1.Text = URLDesp;



            }
            catch (Exception ex)
            {
                //MessageBox.Show("Please try another CarId");
                textBox3.Text = "";
                comboBox1.Text = "";
                label38.Visible = false;
                label39.Visible = false;
                lblimages.Visible = false;
                btnGetAllPics.Visible = false;
                btnback.Visible = false;
                btnforward.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                dgvpostforpostedcarid.Visible = false;
                pnlpostcardata.Visible = false;
                pnlpostnotes.Visible = false;
                pnlposttkt.Visible = false;
                pnlpostbuttons.Visible = false;
                pnlpoststeps.Visible = false;
                webBrowser1.Visible = false;
                label40.Visible = false;
                label41.Visible = false;
                panel1.Visible = true;

            }
            Cursor.Current = Cursors.Default;
        }
        public void QCCarDetails(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {


            //LabelBind Start//////
            Cursor.Current = Cursors.WaitCursor;
            label10.Text = obUsedCarsInfo[0].Carid.ToString();
            string mileage = obUsedCarsInfo[0].Mileage.ToString();

            if (mileage.Contains("."))
            {
                int index = 0;

                int Endindex = mileage.IndexOf(".");

                mileage = mileage.ToString().Substring(index, Endindex - index);
            }
            else
            {
                mileage = obUsedCarsInfo[0].Mileage.ToString();

            }

            double dsda = Convert.ToDouble(mileage);
            mileage = dsda.ToString("0,0", CultureInfo.InvariantCulture);

            string pricechng1 = obUsedCarsInfo[0].Price.ToString();
            double pricechng2 = Convert.ToDouble(pricechng1);
            string pricechng = pricechng2.ToString("0,0", CultureInfo.InvariantCulture);
            if (pricechng.Contains("."))
            {
                int index1 = 0;

                int Endindex1 = pricechng.IndexOf(".");

                pricechng = pricechng.ToString().Substring(index1, Endindex1 - index1);
                pricechng = "$" + pricechng;
            }
            else
            {
                pricechng = "$" + pricechng;
            }

            label11.Text = obUsedCarsInfo[0].YearOfMake.ToString() + " / " + obUsedCarsInfo[0].Make.ToString() + " / " + obUsedCarsInfo[0].Model.ToString() + " / " + pricechng + " / " + mileage;
            pmake = obUsedCarsInfo[0].Make.ToString();
            pmodel = obUsedCarsInfo[0].Model.ToString();
            string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
            string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
            string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
            label12.Text = obUsedCarsInfo[0].Title.ToString();
            label13.Text = url;
            label14.Text = obUsedCarsInfo[0].Phone.ToString();
            textBox10.Text = obUsedCarsInfo[0].City.ToString().Trim() + "," + obUsedCarsInfo[0].State.ToString().Trim() + "," + obUsedCarsInfo[0].Zip.ToString().Trim();

            textBox10.Font = new Font(textBox10.Font.Name, 8, FontStyle.Bold);
            label24.Text = obUsedCarsInfo[0].Fueltype.ToString() + " / " + obUsedCarsInfo[0].Transmission.ToString() + " / " + obUsedCarsInfo[0].NumberOfSeats.ToString() + " / " + obUsedCarsInfo[0].NumberOfCylinder.ToString();
            string dep = obUsedCarsInfo[0].Description.ToString();
            int val = 1000;
            string pn = obUsedCarsInfo[0].Phone.ToString();
            string make = obUsedCarsInfo[0].Make.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Make.ToString() == "Unspecified" ? "" : "\r\nMake: " + obUsedCarsInfo[0].Make.ToString();

            string model = obUsedCarsInfo[0].Model.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Model.ToString() == "Unspecified" ? "" : "\r\nModel: " + obUsedCarsInfo[0].Model.ToString(); ;
            string year = obUsedCarsInfo[0].YearOfMake.ToString() == "Emp" ? "" : obUsedCarsInfo[0].YearOfMake.ToString() == "Unspecified" ? "" : "\r\nyear: " + obUsedCarsInfo[0].YearOfMake.ToString();
            string doors = obUsedCarsInfo[0].NumberOfDoors.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfDoors.ToString() == "Unspecified" ? "" : "\r\nDoors: " + obUsedCarsInfo[0].NumberOfDoors.ToString();
            string bodystyle = obUsedCarsInfo[0].Bodytype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Bodytype.ToString() == "Unspecified" ? "" : "\r\nBodytype: " + obUsedCarsInfo[0].Bodytype.ToString();

            string exteriorcolor = obUsedCarsInfo[0].ExteriorColor.ToString() == "Emp" ? "" : obUsedCarsInfo[0].ExteriorColor.ToString() == "Unspecified" ? "" : "\r\nExteriorColor: " + obUsedCarsInfo[0].ExteriorColor.ToString();
            string interior = obUsedCarsInfo[0].InteriorColor.ToString() == "Emp" ? "" : obUsedCarsInfo[0].InteriorColor.ToString() == "Unspecified" ? "" : "\r\nInteriorColor: " + obUsedCarsInfo[0].InteriorColor.ToString();
            string seats = obUsedCarsInfo[0].NumberOfSeats.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfSeats.ToString() == "Unspecified" ? "" : "\r\nSeats: " + obUsedCarsInfo[0].NumberOfSeats.ToString();
            string price = obUsedCarsInfo[0].Price.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Price.ToString() == "Unspecified" ? "" : "\r\nPrice: " + "$" + obUsedCarsInfo[0].Price.ToString();
            string fule = obUsedCarsInfo[0].Fueltype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Fueltype.ToString() == "Unspecified" ? "" : "\r\nFuelType: " + obUsedCarsInfo[0].Fueltype.ToString();
            string transmission = obUsedCarsInfo[0].Transmission.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Transmission.ToString() == "Unspecified" ? "" : "\r\nTransmission: " + obUsedCarsInfo[0].Transmission.ToString();
            string drivetrain = obUsedCarsInfo[0].DriveTrain.ToString() == "Emp" ? "" : obUsedCarsInfo[0].DriveTrain.ToString() == "Unspecified" ? "" : "\r\nDriveTrain: " + obUsedCarsInfo[0].DriveTrain.ToString();
            string mileage1 = obUsedCarsInfo[0].Mileage.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Mileage.ToString() == "Unspecified" ? "" : "\r\nMileage: " + obUsedCarsInfo[0].Mileage.ToString();


            string details = (make.Trim() == "" ? "" : make.Trim()) + (model.Trim() == "" ? "" : "\r\n" + model.Trim()) + (year.Trim() == "" ? "" : "\r\n" + year.Trim()) + (doors.Trim() == "" ? "" : "\r\n" + doors.Trim()) + (bodystyle.Trim() == "" ? "" : "\r\n" + bodystyle.Trim()) + (exteriorcolor.Trim() == "" ? "" : "\r\n" + exteriorcolor.Trim()) + (interior.Trim() == "" ? "" : "\r\n" + interior.Trim()) + (seats.Trim() == "" ? "" : "\r\n" + seats.Trim()) + (price.Trim() == "" ? "" : "\r\n" + price.Trim()) + (transmission.Trim() == "" ? "" : "\r\n" + transmission.Trim()) + (mileage.Trim() == "" ? "" : "\r\n" + mileage1.Trim());

            string dd = obUsedCarsInfo[0].DateOfPosting.ToString();
            string URLDesp = WrapTextByMaxCharacters(details, dep, val, url, pn);
            textBox1.Text = URLDesp;
            // tabControl1.SelectedIndex = 4;
            //LabelBind End///////
            pictureBoxlogo.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
        }
        string WrapTextByMaxCharacters(string details, string objText, int intMaxChars, string url, string phone)
        {

            string strReturnValue = "";
            if (objText != null)
            {

                //if (objText.ToString().Trim() != "")
                //{

                if (objText.ToString().Trim().Length > intMaxChars)
                {

                    strReturnValue = details.ToString() + "\r\n" + "\r\n" + "Description " + objText.ToString().Trim().Substring(0, intMaxChars) +

                   "..!!\r\nIf instrested please contact : " + phone + "\r\n\r\nFor More Details:  " + url;


                }

                else
                {

                    strReturnValue = details.ToString() + "\r\n" + "\r\n" + "Description: " + objText.ToString().Trim() + "..!!\rIf instrested please contact : " + phone + "\r\n\r\nFor More Details:  " + url;
                    if (objText.ToString().Trim() == "")
                    {
                        strReturnValue = strReturnValue.Replace("Description: ", "");
                    }
                    if (phone.Trim() == "")
                    {
                        strReturnValue = strReturnValue.Replace("..!!\rIf instrested please contact :  ", "");

                    }
                }

                //   }

            }

            return strReturnValue;
        }
        public void CreateImageURLPath(string URLPhoto, string CarPic, string carImageId)
        {




            if (!URLPhoto.Contains("Emp"))
            {


                string filepath = @"C:/UcePictures/" + carImageId + "/";
                string filename = CarPic + ".jpg";
                if (!System.IO.Directory.Exists(filepath))
                {
                    System.IO.Directory.CreateDirectory(filepath);
                }

                //   string URLPhoto = "http://www.unitedcarexchange.com/CollectedImages/2012/3/Ford/1712/4.jpg";

                HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(URLPhoto);
                WebResponse imageResponse = imageRequest.GetResponse();

                Stream responseStream = imageResponse.GetResponseStream();

                System.Drawing.Bitmap oBitmap1 = new System.Drawing.Bitmap(responseStream);

                Graphics oGraphic1 = default(Graphics);

                int newwidthimg1 = 300;
                // Here create a new bitmap object of the same height and width of the image.
                //  float AspectRatio = (float)oBitmap1.Size.Width / (float)oBitmap1.Size.Height;
                //int newHeight1 = Convert.ToInt32(newwidthimg1 / AspectRatio);
                int newHeight1 = 300;
                Bitmap bmpNew1 = new Bitmap(newwidthimg1, newHeight1);
                oGraphic1 = Graphics.FromImage(bmpNew1);

                oGraphic1.CompositingQuality = CompositingQuality.HighQuality;
                oGraphic1.SmoothingMode = SmoothingMode.HighQuality;
                oGraphic1.InterpolationMode = InterpolationMode.HighQualityBicubic;


                oGraphic1.DrawImage(oBitmap1, new Rectangle(0, 0, bmpNew1.Width, bmpNew1.Height), 0, 0, oBitmap1.Width, oBitmap1.Height, GraphicsUnit.Pixel);
                // Release the lock on the image file. Of course,
                // image from the image file is existing in Graphics object
                oBitmap1.Dispose();
                oBitmap1 = bmpNew1;

                oBitmap1.Save(filepath + filename, ImageFormat.Jpeg);

                oBitmap1.Dispose();





            }

            else
            {


                //string StockUrl = string.Empty;


                //{
                //    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                //    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                //    obUsedCarsInfo = objService.FindCarID(label10.Text);

                //    string mmake = obUsedCarsInfo[0].Make.ToString();
                //    string mmodel = obUsedCarsInfo[0].Model.ToString();

                //    string StockMake = mmake;
                //    StockMake = StockMake.Replace(" ", "-");
                //    StockMake = StockMake.Replace("/", "@");
                //    StockMake = StockMake.Replace("&", "@");
                //    string StockType = mmodel.ToString().Replace('&', '@');
                //    StockType = StockType.Replace("/", "@");
                //    StockType = StockType.Replace(" ", "-");
                //    StockUrl = "images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

                //    StockUrl = "http://www.UnitedCarExchange.com/" + StockUrl;




                //    string filepath = @"C:/UcePictures/" + carImageId + "/";
                //    string filename = CarPic + ".jpg";
                //    if (!System.IO.Directory.Exists(filepath))
                //    {
                //        System.IO.Directory.CreateDirectory(filepath);
                //    }

                //    //   string URLPhoto = "http://www.unitedcarexchange.com/CollectedImages/2012/3/Ford/1712/4.jpg";

                //    HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(URLPhoto);
                //    WebResponse imageResponse = imageRequest.GetResponse();

                //    Stream responseStream = imageResponse.GetResponseStream();

                //    System.Drawing.Bitmap oBitmap1 = new System.Drawing.Bitmap(responseStream);

                //    Graphics oGraphic1 = default(Graphics);

                //    int newwidthimg1 = 300;
                //    // Here create a new bitmap object of the same height and width of the image.
                //    //  float AspectRatio = (float)oBitmap1.Size.Width / (float)oBitmap1.Size.Height;
                //    //int newHeight1 = Convert.ToInt32(newwidthimg1 / AspectRatio);
                //    int newHeight1 = 315;
                //    Bitmap bmpNew1 = new Bitmap(newwidthimg1, newHeight1);
                //    oGraphic1 = Graphics.FromImage(bmpNew1);

                //    oGraphic1.CompositingQuality = CompositingQuality.HighQuality;
                //    oGraphic1.SmoothingMode = SmoothingMode.HighQuality;
                //    oGraphic1.InterpolationMode = InterpolationMode.HighQualityBicubic;


                //    oGraphic1.DrawImage(oBitmap1, new Rectangle(0, 0, bmpNew1.Width, bmpNew1.Height), 0, 0, oBitmap1.Width, oBitmap1.Height, GraphicsUnit.Pixel);
                //    // Release the lock on the image file. Of course,
                //    // image from the image file is existing in Graphics object
                //    oBitmap1.Dispose();
                //    oBitmap1 = bmpNew1;

                //    oBitmap1.Save(filepath + filename, ImageFormat.jpeg);

                //    oBitmap1.Dispose();
                //}
            }



        }
        public void SelectOption(WebBrowser objbrowser, string InnerTxt, String ControlName)
        {
            try
            {
                //foreach (HtmlElement el in objbrowser.Document.GetElementsByTagName("select"))
                //{
                //    if (el.GetAttribute("name") == ControlName)
                //    {
                        foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("option"))
                        {
                            if (element.InnerText == InnerTxt)
                            {
                                string value = element.GetAttribute("value").ToString();
                                GeneralFunction.SetDropDownNameandValue(webBrowser1, ControlName, value);
                                return;
                            }
                        }
                //    }
                //}
            }
            catch (Exception ex)
            { }
        }
        private void Navigate_btn_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Txt_Url.Text);
            Txt_Url.Visible = false;
            Navigate_btn.Visible = false;
        }
        #endregion
        //public Main(string strTextBox, string strType)
        //{
        //    InitializeComponent();

        //    label2.Text = "User: " + strTextBox;

        //    // Globaltry .GlobalVar = strTextBox;

        //}
        //private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{

        //    DataGridViewColumn newColumn = dataGridView1.Columns[e.ColumnIndex];
        //    DataGridViewColumn oldColumn = dataGridView1.SortedColumn;
        //    ListSortDirection direction;

        //    // If oldColumn is null, then the DataGridView is not sorted. 
        //    if (oldColumn != null)
        //    {
        //        // Sort the same column again, reversing the SortOrder. 
        //        if (oldColumn == newColumn &&
        //            dataGridView1.SortOrder == SortOrder.Ascending)
        //        {
        //            direction = ListSortDirection.Descending;
        //        }
        //        else
        //        {
        //            // Sort a new column and remove the old SortGlyph.
        //            direction = ListSortDirection.Ascending;
        //            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
        //        }
        //    }
        //    else
        //    {
        //        direction = ListSortDirection.Ascending;
        //    }

        //    // Sort the selected column.
        //    dataGridView1.Sort(newColumn, direction);
        //    newColumn.HeaderCell.SortGlyphDirection =
        //      direction == ListSortDirection.Ascending ?
        //      SortOrder.Ascending : SortOrder.Descending;


        //}
        //private void button6_Click(object sender, EventArgs e)
        //{


        //    //Adding//

        //    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    con.Open();

        //    //taemp1
        //    cmd.CommandText = "delete Tempt1";
        //    cmd.ExecuteNonQuery();

        //    string str = " insert into Tempt1 (Smname,Thisweek ) " +
        //        "select SU.SmartzUname,count(SMS.PostedBy) 'This wk#'  from Tbl_SmartzMultiSiteUrl  " +
        //        " as SMS inner join Tbl_SmartzUsers as SU on Su.SmartzUID=SMS.PostedBy where  " +
        //         " SMS.UrlPostDate>= DATEADD(dd, -7, getdate()) group by SMS.postedBy,SU.SmartzUname";
        //    cmd.CommandText = str;
        //    cmd.ExecuteNonQuery();


        //    cmd.CommandText = "delete tempt2";
        //    cmd.ExecuteNonQuery();
        //    //temp2
        //    string str1 = " insert into tempt2 (smartnam,lifetime ) " +
        //    "select SU.SmartzUname,count(SMS.PostedBy) 'Life time#'from Tbl_SmartzMultiSiteUrl as SMS inner join " +
        //    " Tbl_SmartzUsers as SU on Su.SmartzUID=SMS.PostedBy  group by SMS.postedBy,SU.SmartzUname ";
        //    cmd.CommandText = str1;
        //    cmd.ExecuteNonQuery();



        //    cmd.CommandText = "delete Temp3";
        //    cmd.ExecuteNonQuery();
        //    //Main Table
        //    string str2 = " insert into Temp3 (Sname,LifeTime,ThisWeek  ) " +
        //    "select a.smartnam,a.lifetime,b.Thisweek from tempt2 as a left join Tempt1 as b on a.smartnam=b.Smname ";
        //    cmd.CommandText = str2;
        //    cmd.ExecuteNonQuery();

        //    cmd.CommandText = "delete Tempt1";
        //    cmd.ExecuteNonQuery();
        //    cmd.CommandText = "delete tempt2";
        //    cmd.ExecuteNonQuery();
        //    //urlPening
        //    string str4 = " insert into Tempt1 (Smname,Thisweek)  " +
        //        "select SU.SmartzUname, count(MSS.PostedBy) as 'Pending' from Tbl_MultiStatusbySite as MSS  " +
        //     "inner join Tbl_SmartzUsers as SU on MSS.PostedBy=SU.SmartzUID where SubStatus='Pending' group by  " +
        //     " MSS.PostedBy,SU.SmartzUname ";
        //    cmd.CommandText = str4;
        //    cmd.ExecuteNonQuery();

        //    //Main Table with url pending
        //    string str7 = " insert into Temp3 (Sname,LifeTime,ThisWeek ) " +
        //    "select a.smartnam,a.lifetime,b.Thisweek from tempt2 as a left join Tempt1 as b on a.smartnam=b.Smname ";
        //    cmd.CommandText = str7;
        //    cmd.ExecuteNonQuery();

        //    //QcPening in t2
        //    //Main Table with url pending
        //    string str6 = " insert into tempt2 (smartnam,lifetime ) " +
        //    "select SU.SmartzUname, count(MSS.PostedBy) as 'Pending' from Tbl_MultiStatusbySite as MSS inner join Tbl_SmartzUsers as SU on  " +
        //    " MSS.PostedBy=SU.SmartzUID where QcStatus='Pending'and SubStatus='Completed' group by MSS.PostedBy,SU.SmartzUname ";
        //    cmd.CommandText = str6;
        //    cmd.ExecuteNonQuery();


        //    int value = 0; int value1; int value2 = 0;
        //    //GridBinding
        //    string S1 = "select isnull(a.Sname,'0')as 'Users',isnull(a.ThisWeek,'0')as 'ThisWeek#',isnull(a.lastWeek,'0')as 'LastWeek#',isnull(a.LifeTime,'0')as 'LifeTime#',isnull(b.Thisweek,'0') as UrlPending, " +
        //        " isnull(c.lifetime,'0') as [QC Pending] from Temp3 as a ";
        //    try
        //    {
        //        SqlDataReader dr;
        //        string str11 = " select count(lifetime)  as Va from tempt2";
        //        cmd.CommandText = str11;
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            value2 = Convert.ToInt32(dr["Va"].ToString());
        //        }
        //        dr.Close();



        //    }
        //    catch { value = 0; }
        //    //try
        //    //{
        //    //    string str111 = " select count(lifetime) from tempt2";
        //    //    cmd.CommandText = str111;
        //    //    value1 = cmd.ExecuteNonQuery();

        //    //}
        //    //catch { value = 0; }
        //    if (value2 == 0)
        //        S1 += " left join Tempt1 as b on a.Sname=B.Smname left join tempt2 as c on B.Smname=c.smartnam ";
        //    else
        //        S1 += " left join tempt2 as c on a.Sname=c.smartnam left join Tempt1 as B on c.smartnam=B.Smname ";
        //    SqlDataAdapter dap = new SqlDataAdapter(S1, con);
        //    DataTable dt = new DataTable();
        //    dap.Fill(dt);

        //    dataGridView2.DataSource = dt;

        //    //   dgvviewpendingsites.DefaultCellStyle.ForeColor = Color.Red;



        //    //Thisweek
        //    int sum = 0;
        //    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
        //    {
        //        try
        //        {
        //            sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);
        //        }
        //        catch { }
        //    }

        //    //lastweek sum
        //    int sum1 = 0;
        //    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
        //    {
        //        try
        //        {
        //            sum1 += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);
        //        }
        //        catch { }
        //    }



        //    //life time
        //    int sum2 = 0;
        //    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
        //    {
        //        try
        //        {
        //            sum2 += Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value);
        //        }
        //        catch { }
        //    }


        //    //pending
        //    int sum3 = 0;
        //    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
        //    {
        //        try
        //        {
        //            sum3 += Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value);
        //        }
        //        catch { }
        //    }


        //    //qcpending
        //    int sum4 = 0;
        //    for (int i = 0; i < dataGridView2.Rows.Count; ++i)
        //    {
        //        try
        //        {
        //            sum4 += Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
        //        }
        //        catch { }
        //    }




        //    dt.Rows.Add("TOTAL", sum, sum1, sum2, sum3, sum4);
        //    dataGridView2.Rows[5].Cells[0].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
        //  System.Drawing.FontStyle.Bold);
        //    dataGridView2.Rows[5].Cells[1].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
        // System.Drawing.FontStyle.Bold);
        //    dataGridView2.Rows[5].Cells[2].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
        // System.Drawing.FontStyle.Bold);
        //    dataGridView2.Rows[5].Cells[3].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
        // System.Drawing.FontStyle.Bold);

        //    dataGridView2.Rows[5].Cells[4].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
        // System.Drawing.FontStyle.Bold);
        //    dataGridView2.Rows[5].Cells[5].Style.Font = new System.Drawing.Font("Verdana", 8.0f,
        // System.Drawing.FontStyle.Bold);


        //    //closing///




        //    //starting//
        //    DataSet cntsites = new DataSet();
        //    cntsites = objSubmitionDetailsBL.MultiGetCountBySites();

        //    int k0 = Convert.ToInt32(cntsites.Tables[0].Rows[0]["Nopst"]);
        //    int k1 = Convert.ToInt32(cntsites.Tables[1].Rows[0]["LE5"]);
        //    int k2 = Convert.ToInt32(cntsites.Tables[2].Rows[0]["B6to10"]);
        //    int k3 = Convert.ToInt32(cntsites.Tables[3].Rows[0]["B11to15"]);
        //    int k4 = Convert.ToInt32(cntsites.Tables[4].Rows[0]["GT15"]);

        //    DataTable dc1 = new DataTable();
        //    dc1.Columns.Add("Posting Stats for published cars from last 90 days  ", typeof(string));
        //    dc1.Columns.Add("Total", typeof(int));
        //    dc1.Rows.Add("# of Published Cars with no posts ", k0);
        //    dc1.Rows.Add("#Published Cars with 1-5 posts ", k1);
        //    dc1.Rows.Add("#Published Cars with 6-10 posts ", k2);
        //    dc1.Rows.Add("#Published Cars with 11-15 posts", k3);
        //    dc1.Rows.Add("#Published Cars with 15+ posts", k4);
        //   // dataGridView5.DataSource = dc1;

        //    //DataGridViewColumn col0 = dataGridView5.Columns[0];
        //    //col0.Width = 300;
        //    //DataGridViewColumn col1 = dataGridView5.Columns[1];
        //    //col1.Width = 60;



        //    //closing//
        //}

        //private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    foreach (DataGridViewColumn column in dataGridView3.Columns)
        //    {
        //        column.SortMode = DataGridViewColumnSortMode.Programmatic;
        //    }
        //}
        //}
        //private void LiveButtonUrl_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    e.Cancel = true;
        //}
        ////private const int CP_NOCLOSE_BUTTON = 0 * 200;
        ////protected override CreateParams CreateParams
        ////{
        ////    get
        ////    {
        ////        CreateParams myCp = base.CreateParams;
        ////        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        ////        return myCp;
        ////    }
        ////} 
        //private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //private void label45_Click(object sender, EventArgs e)
        //{

        //}
        //private void circularProgressControl2_Load(object sender, EventArgs e)
        //{

        //}
        //private void pnlpostcardata_Paint_1(object sender, PaintEventArgs e)
        //{

        //}
        //private void panel2_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void label49_Click_1(object sender, EventArgs e)
        //{

        //}
        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{

        //}
        //private void webBrowser1_Move(object sender, EventArgs e)
        //{
        //    if (Website == "jeanza")
        //    {
        //    }
        //}
        //private void textBox6_TextChanged(object sender, EventArgs e)
        //{

        //}
        //private void tabadmin_Click(object sender, EventArgs e)
        //{

        //}
        //private void textBox5_TextChanged(object sender, EventArgs e)
        //{

        //}
        //private void pnlviewgrid_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        //{
        //    // webBrowser1.Url = webBrowser1.Url;
        //    //webBrowser1.Navigate(webBrowser1.StatusText, false);
        //    //e.Cancel = true;
        //}
        //private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        //private void dataGridView3_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        //{

        //}
        //private void panel3_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void label12_Click(object sender, EventArgs e)
        //{

        //}
        //private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        //{


        //}
        //private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        //{
        //    string currentURl = e.Url.ToString();

        //}
        //private void dgvpostforpostedcarid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //private void circularProgressControl1_Load(object sender, EventArgs e)
        //{

        //}
        //private void label3_Click(object sender, EventArgs e)
        //{

        //}
        //private void pnlpostnotes_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void circularProgressControl1_Load_1(object sender, EventArgs e)
        //{
        //}
        //private void label41_Click(object sender, EventArgs e)
        //{

        //}
        //private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //private void groupBox1_Enter(object sender, EventArgs e)
        //{

        //}      
        //private void viewdatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //private void tabposting_Click(object sender, EventArgs e)
        //{

        //}
        //private void viewtab_Click(object sender, EventArgs e)
        //{

        //}
        //private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //}
        //private void label21_Click(object sender, EventArgs e)
        //{

        //}
        //private void pnlpostcardata_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void label18_Click(object sender, EventArgs e)
        //{

        //}
        //private void Main_MouseHover(object sender, EventArgs e)
        //{

        //}
        //private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        //{

        //    //PostedSiteListForm objpostedlist = new PostedSiteListForm(result);

        //    ////--------------- postedlist by siteid start-------------

        //    //int sitid = (int)comboBox1.SelectedValue;


        //    //DataSet dst1 = new DataSet();
        //    //dst1 = objSubmitionDetailsBL.MultiGetpendbySiteid(sitid);

        //    //DataSet dst2 = new DataSet();
        //    //dst2 = objSubmitionDetailsBL.MultiGetQCbySiteid(sitid);


        //    //dataGridView2.DataSource = dst1.Tables[0];

        //    //PostedSiteListForm objpostedlist = new PostedSiteListForm();

        //    //objpostedlist.Show();



        //    ////---------------postedlist by siteid end-----------------


        //    // webBrowser1.Visible = false;
        //    // webBrowser1.Navigate("");

        //    //if (comboBox1.Text == "CarPosts" || comboBox1.Text == "Clazorg" || comboBox1.Text == "JustgoodCars" ||
        //    //    comboBox1.Text == "UsAdsciti" || comboBox1.Text == "UsNetads" || comboBox1.Text == "kugli" || comboBox1.Text == "jeanza"
        //    //    || comboBox1.Text == "classifiedsvalley" || comboBox1.Text == "classifiedsciti" || comboBox1.Text == "usa.motoseller.com" || comboBox1.Text == "American-classifieds.net" || comboBox1.Text == "www.classifiedsforfree.com"
        //    //    || comboBox1.Text == "www.epage.com" || comboBox1.Text == "www.classifiededition.com" || comboBox1.Text == "www.autoii.com" || comboBox1.Text == "www.postfreeadshere.com" || comboBox1.Text == "www.cathaylist.com" || comboBox1.Text == "www.adsciti.com")
        //    //{


        //    //    string SiteName = comboBox1.Text;
        //    //    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ds"].ToString());
        //    //    // SqlConnection con = new SqlConnection("Data source=66.23.236.151;Database=CarsdBTEst2;User ID=dbDSHugomirad;Password=dsadmin@123");
        //    //    con.Open();
        //    //    cmd.Connection = con;
        //    //    cmd.CommandText = "select SmrtzSiteId from Tbl_MultiGetSiteList where SiteName ='" + comboBox1.Text + "'";

        //    //    int result = ((int)cmd.ExecuteScalar());

        //    //    //cmd.ExecuteNonQuery();

        //    //    //int siteid = Convert.ToInt32(sqlstr);

        //    //  //  PostedSiteListForm objpostedlist = new PostedSiteListForm(result);


        //    //   // objpostedlist.ShowDialog();


        //    //}



        //}
        //private void dgvpostforpostedcarid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //private void label48_Click(object sender, EventArgs e)
        //{

        //}
        //private void pnlposttkt_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void label49_Click(object sender, EventArgs e)
        //{

        //}
        //private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //textBox2.Text = comboBox2.ValueMember.ToString();
        //}
    }
    #region global variables
    public static class GlobalNoteCarId
    {
        public static string _notecarid = "";
        public static string notecarid
        {
            get { return _notecarid; }
            set { _notecarid = value; }
        }
    }
    public static class GlobalpendURL
    {
        public static string _pendURL = "";
        public static string pendURL
        {
            get { return _pendURL; }
            set { _pendURL = value; }
        }
    }
    public static class Globalpenddate
    {
        public static string _penddate = "";
        public static string penddate
        {
            get { return _penddate; }
            set { _penddate = value; }
        }
    }
    public static class Globaltxtemail
    {
        public static string _txtemail = "";
        public static string txtemail
        {
            get { return _txtemail; }
            set { _txtemail = value; }
        }
    }
    public static class Globalpwd
    {
        public static string _pwd = "";
        public static string pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
    }
    public static class GlobalSite
    {
        public static string _Site = "";
        public static string Site
        {
            get { return _Site; }
            set { _Site = value; }
        }
    }
    public static class GlobalUrlid
    {
        public static int _Urlid = 0;
        public static int Urlid
        {
            get { return _Urlid; }
            set { _Urlid = value; }
        }
    }
    public static class GlobalUrlsid
    {
        public static int _Urlsid = 0;
        public static int Urlsid
        {
            get { return _Urlsid; }
            set { _Urlsid = value; }
        }
    }
    public static class GlobalCarid
    {
        public static int _Carid = 0;
        public static int Carid
        {
            get { return _Carid; }
            set { _Carid = value; }
        }
    }
    public static class GlobalUName1
    {
        public static string _UName1 = "";
        public static string UName1
        {
            get { return _UName1; }
            set { _UName1 = value; }
        }
    }
    public static class GlobalsiteId
    {
        public static int _siteId = 0;
        public static int siteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }
    }
    #endregion
    public class Prompt             
    {
        public string ShowDialog(string text, string caption)
        {

            string returnNote = String.Empty;
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
            textBox.Height = 100;
            Button confirmation = new Button() { Text = "Save", Left = 380, Width = 100, Top = 50 };
            confirmation.Click += (sender, e) =>
            {

                int addnotecarid = Convert.ToInt32(GlobalNoteCarId.notecarid.ToString());
                string note = textBox.Text == "" ? "" : textBox.Text + "\r\n" + "Added by :" + GlobalUserName.UserName + "," + System.DateTime.Now.ToString() + "\r\n........................\r\n";
                int AddedBy = 4;

                ProductionBL.SubmitionDetailsBL objSubmitionDetailsBL = new ProductionBL.SubmitionDetailsBL();
                if (note != "")
                {
                    DataSet dsnt = objSubmitionDetailsBL.MultiSaveNotes(addnotecarid, note, AddedBy);
                    if (dsnt.Tables.Count > 0)
                    {
                        if (dsnt.Tables[0].Rows.Count > 0)
                        {
                            returnNote = dsnt.Tables[0].Rows[0]["Note"].ToString();
                        }
                    }
                }
                prompt.Close();
            };
            Button btnclose = new Button() { Text = "Abandon", Left = 380, Width = 100, Top = 80 };
            btnclose.Click += (sender, e) =>
            {
                ProductionBL.SubmitionDetailsBL objSubmitionDetailsBL = new ProductionBL.SubmitionDetailsBL();
                DataSet dsnote = new DataSet();
                int carid = Convert.ToInt32(GlobalNoteCarId.notecarid);
                dsnote = objSubmitionDetailsBL.GetMultiNote(carid);
                if (dsnote.Tables.Count > 0)
                {
                    if (dsnote.Tables[0].Rows.Count > 0)
                    {
                       returnNote = dsnote.Tables[0].Rows[0]["Note"].ToString();
                    }
                }
                prompt.Close();
            };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(btnclose);
            prompt.ShowDialog();
            return returnNote;
        }
    }
    public class PromtCarId : Form  
    {
        public string ShowCarDialog(string text, string caption)
        {
            Form promptDt = new Form();

            promptDt.Width = 300;
            promptDt.Height = 150;
            promptDt.Text = caption;
            Label textLabelDt = new Label() { Left = 70, Top = 30, Width = 80, Text = text };
            TextBox textBoxDt = new TextBox() { Left = 150, Top = 29, Width = 80 };
            textBoxDt.Height = 100;
            Button confirmationDt = new Button() { Text = "Submit", Left = 155, Width = 70, Top = 58 };

            confirmationDt.Click += (sender, e) =>
            {
                if (textBoxDt.Text != "")
                {
                    Main objmn = new Main();
                    objmn.Show();
                    //  string num = textBoxDt.Text;
                    //  objmn.BringToFront();
                    objmn.GetCarDetails(textBoxDt.Text);
                    // promptDt.Close();
                }
                else
                {
                    MessageBox.Show("enter carid", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            };
            //Button btnclose = new Button() { Text = "Abandon", Left = 70, Width = 70, Top = 58 };
            // btnclose.Click += (sender, e) =>
            // {
            //     prompt.Close();
            // };
            promptDt.Controls.Add(confirmationDt);
            promptDt.Controls.Add(textLabelDt);
            promptDt.Controls.Add(textBoxDt);
            // prompt.Controls.Add(btnclose);
            // prompt.Close();
            promptDt.ShowDialog();
            return textBoxDt.Text;
        }
    }
}
