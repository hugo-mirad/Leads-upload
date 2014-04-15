using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ProductionInfo;
using ProductionBL;
using System.IO;
using System.Net;

namespace AutoFillForm
{

    public interface IWebSites
    {
        void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo);

    }
    public partial class Main : Form
    {
        Form1 u3 = new Form1();
        ManageUsers m3 = new ManageUsers();
        ChangePwd c3 = new ChangePwd();
        LogIn l3 = new LogIn();


        LogInIfno objLogInIfno = new LogInIfno();
        LogIn objLogid = new LogIn();

        string Website = string.Empty;
        string statename = string.Empty;
        string linkItem = string.Empty;
        int websiteId = 0;




        string cnt = string.Empty;
        Form timerform = new Form();









        Label lblinfrm1 = new Label();
        Label lbinfrm2 = new Label();
        Label lbinfrm3 = new Label();
        Label lbinfrm4 = new Label();
        Label lbinfrm5 = new Label();
        Label lbinfrm6 = new Label();
        Label lbinfrm7 = new Label();
        Label lbinfrm8 = new Label();
        Label lbinfrm9 = new Label();
        Label lbinfrm10 = new Label();
        Label lbinfrm11 = new Label();
        Label lbinfrm12 = new Label();
        //frminitlize();

        Form LiveFormUrl = new Form();


        DataGridView dgobjpending = new DataGridView();
        TextBox txtpndg = new TextBox();


        TextBox LiveTextBoxUrl = new TextBox();
        Button LiveButtonUrl = new Button();
        Button LiveButtonLater = new Button();


        RecentPosts objrecntpost = new RecentPosts();










        //DataGridView dgobjpending = new DataGridView();

        //TextBox txtpndg = new TextBox();





        SubmitionDetailsInfo objsubdetailsinfo = new SubmitionDetailsInfo();
        SubmitionDetailsBL objSubmitionDetailsBL = new SubmitionDetailsBL();
        int count = 0;

        int imgcount = 0;
        int countdes = 1000;

        int rp = 0;

        int subby = 0;
        int btncnt = 0;
        int carid = 0;
        int timercount = 0;
        int timer2count = 0;
        string timeryes = "";

        int servicetimer = 0;
      
    
        public Main()
        {
            InitializeComponent();

            this.SizeChanged += new EventHandler(form1_sizeeventhandler);
            this.Dock = DockStyle.Fill;




            timer1.Interval = 1;
            timer1.Start();



            //  dtgridSubDet.Visible = false;
            //btnGetAllPics.Visible = false;
            lblsubdetails.Visible = false;

            btnlive.Visible = false;



           // lblpics.Visible = false;
            //  panel1.Visible = false;
            panel2.Visible = false;
            cbBoxWebsite.Visible = false;
            UplaodDetails.Visible = false;
            btnSubmit.Visible = false;

            cbBoxWebsite.Enabled = false;


            btnSubmit.Visible = false;

            // lblRecent.Visible = false;
            //  dtgvRecent.Visible = false;
            // panel3.Visible = false;





            lblTitle.Text = "";
            lblCarId.Text = "";

            lblState.Text = "";
            lblCity.Text = "";
            lblMake.Text = "";
            lblModel.Text = "";
            lblYear.Text = "";
            lblPrice.Text = "";
            lblMileage.Text = "";
            lblExtColor.Text = "";
            lblBodyType.Text = "";
            lblCylinders.Text = "";
            lblDoors.Text = "";
            lblTrans.Text = "";
            lblFuel.Text = "";
            lblDrive.Text = "";
            lblVIN.Text = "";
            //lblDescript.Text = obUsedCarsInfo[0].Description.ToString();
            textBox1.Text = "";
            //  lblContactName.Text = "";
            lblZip.Text = "";
            //   lblEmail.Text = "";

            textBox2.Text = "";
            //M_parent = objlogin;
        }


        public void FillCarDetails(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {


            // //for Image Download
            //if (Pics.GetPic0(obUsedCarsInfo) == null)
            //{
            //    CreateImageURLPath(Pics.GetPic1(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-2", obUsedCarsInfo[0].Carid.ToString());
            //    CreateImageURLPath(Pics.GetPic2(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-3", obUsedCarsInfo[0].Carid.ToString());

            //}
            //else if (Pics.GetPic1(obUsedCarsInfo) == null)
            //{
            //    CreateImageURLPath(Pics.GetPic0(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-1", obUsedCarsInfo[0].Carid.ToString());
            //    CreateImageURLPath(Pics.GetPic2(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-3", obUsedCarsInfo[0].Carid.ToString());

            //}
            //else if (Pics.GetPic2(obUsedCarsInfo) == null)
            //{
            //    CreateImageURLPath(Pics.GetPic0(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-1", obUsedCarsInfo[0].Carid.ToString());
            //    CreateImageURLPath(Pics.GetPic1(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-2", obUsedCarsInfo[0].Carid.ToString());


            //}
            //   else

            // {


            CreateImageURLPath(Pics.GetPic0(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-1", obUsedCarsInfo[0].Carid.ToString());
            CreateImageURLPath(Pics.GetPic1(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-2", obUsedCarsInfo[0].Carid.ToString());
            CreateImageURLPath(Pics.GetPic2(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-3", obUsedCarsInfo[0].Carid.ToString());
            //  }

            try
            {
                for (int i = 1; i <= 3; i++)
                {
                    string filePath = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + i + "" + ".jpeg";
                    int fileSize = (int)new System.IO.FileInfo(filePath).Length;
                    if (fileSize != 0)
                    {
                        imgcount++;
                        if (imgcount == 1)
                        {
                            pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-1" + ".jpeg";

                            label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-1" + ".jpeg";
                        }
                        if (imgcount == 2)
                        {
                            pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-2" + ".jpeg";
                            label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-2" + ".jpeg";
                        }
                        if (imgcount == 3)
                        {
                            pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-3" + ".jpeg";
                            label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-3" + ".jpeg";
                        }

                    }
                }
                //for (int i = 1; i <= 3; i++)
                //{
                //    string filePath = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + i + "" + ".jpeg";
                //    int fileSize = (int)new System.IO.FileInfo(filePath).Length;
                //    if (fileSize != 0)
                //    {
                //        imgcount++;
                //    }

                //}


                if (imgcount == 0)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    label19.Visible = false;

                    label20.Visible = false;

                    label21.Visible = false;
                    btnGetAllPics.Visible = false;
                }


                lblTitle.Text = obUsedCarsInfo[0].Title.ToString();
                lblCarId.Text = obUsedCarsInfo[0].Carid.ToString();

                lblState.Text = GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString()) + " /";
                lblCity.Text = obUsedCarsInfo[0].City.ToString() + " /";
                lblMake.Text = obUsedCarsInfo[0].Make.ToString() + " /";
                lblModel.Text = obUsedCarsInfo[0].Model.ToString() + " /";
                lblYear.Text = obUsedCarsInfo[0].YearOfMake.ToString();
                lblPrice.Text = obUsedCarsInfo[0].Price.ToString();
                lblMileage.Text = obUsedCarsInfo[0].Mileage.ToString() + " /";
                lblExtColor.Text = obUsedCarsInfo[0].ExteriorColor.ToString() + " /";
                lblBodyType.Text = obUsedCarsInfo[0].Bodytype.ToString() + " /";
                lblCylinders.Text = obUsedCarsInfo[0].NumberOfCylinder.ToString() + " /";
                lblDoors.Text = obUsedCarsInfo[0].NumberOfDoors.ToString() + " /";
                lblTrans.Text = obUsedCarsInfo[0].Transmission.ToString();
                lblFuel.Text = obUsedCarsInfo[0].Fueltype.ToString() + " /";
                lblDrive.Text = obUsedCarsInfo[0].DriveTrain.ToString();
                lblVIN.Text = obUsedCarsInfo[0].VIN.ToString();
                //lblDescript.Text = obUsedCarsInfo[0].Description.ToString();


                string pmake = obUsedCarsInfo[0].Make.ToString();
                string pmodel = obUsedCarsInfo[0].Model.ToString();
                string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
                string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
                string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";


                string dep = obUsedCarsInfo[0].Description.ToString();
                int val = 300;
                string pn = obUsedCarsInfo[0].Phone.ToString();
                string details = "\r\n Make: " + obUsedCarsInfo[0].Make.ToString() + "\r\n Model: " + obUsedCarsInfo[0].Model.ToString() + "\r\n Year: " + obUsedCarsInfo[0].YearOfMake.ToString() + "\r\n Body Style: " + obUsedCarsInfo[0].Bodytype.ToString() + "\r\n Exterior Color: " + obUsedCarsInfo[0].ExteriorColor.ToString() + "\r\n Interior Color: " + obUsedCarsInfo[0].InteriorColor.ToString() + "\r\n Doors: " + obUsedCarsInfo[0].NumberOfDoors.ToString() + "\r\n Seats: " + obUsedCarsInfo[0].NumberOfSeats.ToString() + "\r\n Price: " + obUsedCarsInfo[0].Price.ToString() + "\r\n Mileage: " + obUsedCarsInfo[0].Mileage.ToString() + "\r\n Fuel: " + obUsedCarsInfo[0].Fueltype.ToString() + "\r\n Transmission: " + obUsedCarsInfo[0].Transmission.ToString() + "\r\n Drive Train: " + obUsedCarsInfo[0].DriveTrain.ToString() + "\r\n Vin: " + obUsedCarsInfo[0].VIN.ToString();


                string URLDesp = WrapTextByMaxCharacters(details, dep, val, url, pn);

                textBox1.Text = URLDesp;
                //  lblContactName.Text = obUsedCarsInfo[0].SellerName.ToString();
                lblZip.Text = obUsedCarsInfo[0].Zipcode.ToString();
                // lblEmail.Text = obUsedCarsInfo[0].Email.ToString();

                textBox2.Text = obUsedCarsInfo[0].Address1.ToString();



            }
            catch (Exception ex)
            {

            }

        }


        string WrapTextByMaxCharacters(string details, string objText, int intMaxChars, string url, string phone)
        {

            string strReturnValue = "";
            if (objText != null)
            {

                if (objText.ToString().Trim() != "")
                {

                    if (objText.ToString().Trim().Length > intMaxChars)
                    {

                        strReturnValue = details.ToString() + "\r\n" + "\r\n" + "Description " + objText.ToString().Trim().Substring(0, intMaxChars) +

                       "..!!\r\nIf instrested please contact : " + phone + "\r\n\r\n For More Details:  " + url;


                    }

                    else
                    {

                        strReturnValue = details.ToString() + "\r\n" + "\r\n" + "Description: " + objText.ToString().Trim() + "..!!\r\n If instrested please contact : " + phone + "\r\n\r\n For More Details:  " + url;

                    }

                }

            }

            return strReturnValue;
        }

        public void form1_sizeeventhandler(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                QCFormcheck objqcfrmchk = new QCFormcheck();
                objqcfrmchk.Hide();
            }
        }
        public Main(string strTextBox,string strType)
        {
            InitializeComponent();
          
           Globaltry .GlobalVar = strTextBox;
          
        }

    

        //private void toolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    LogIn f2 = new LogIn();
        //    f2.MdiParent = this;
        //    f2.Show();
            
           
        //}

        public void Main_Load(object sender, EventArgs e)
        {
            //qcCheckToolStripMenuItem.Enabled = false;

            //pendingUrlsToolStripMenuItem1.Enabled = false;
            //recentCarIdsToolStripMenuItem.Enabled = false;

            
            //postToolStripMenuItem.Enabled = false;

           // popform.objfrm2.MdiParent = this;
            popform.popform1.MdiParent = this;
            popform.popform2.MdiParent = this;
            popform.popform3.MdiParent = this;
            popform.popform4.MdiParent = this;
            popform.popform5.MdiParent = this;
            //popform.objqcchk.MdiParent=this;




            // btnRecent.Visible = false;
            //btnQcchk.Visible = false;
            // button1.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            comboBox1.Visible = false;
            lblimages.Visible = false;
            btnGetAllPics.Visible = false;
            //Steps to be followed
            panel3.Visible = false;
            ////label5.Visible = false;
            ////label6.Visible = false;
            ////label8.Visible = false;
            ////label10.Visible = false;
            ////label12.Visible = false;
            ////label13.Visible = false;
            ////label15.Visible = false;
            ////label16.Visible = false;
            ////label18.Visible = false;




            // button2.Visible = false;

            panel1.Visible = false;











            //  btnback.Visible = false;
            // btnForward.Visible = false;

            label31.Text = Globaltry.GlobalVar.ToString();
            cbBoxWebsite.Enabled = false;
            UplaodDetails.Visible = false;
            btnSubmit.Visible = false;

            lblwebsite.Visible = false;


            lblTitle.Text = "";
            lblCarId.Text = "";

            lblState.Text = "";
            lblCity.Text = "";
            lblMake.Text = "";
            lblModel.Text = "";
            lblYear.Text = "";
            lblPrice.Text = "";
            lblMileage.Text = "";
            lblExtColor.Text = "";
            lblBodyType.Text = "";
            lblCylinders.Text = "";
            lblDoors.Text = "";
            lblTrans.Text = "";
            lblFuel.Text = "";
            lblDrive.Text = "";
            lblVIN.Text = "";
            //lblDescript.Text = obUsedCarsInfo[0].Description.ToString();
            txtCarID.Text = "";
            //   lblContactName.Text = "";
            lblZip.Text = "";
            // lblEmail.Text = "";

            textBox2.Text = "";
            pictureBox1.ImageLocation = "";
            pictureBox2.ImageLocation = "";
            pictureBox3.ImageLocation = "";
            label19.Text = "";
            label20.Text = "";
            label21.Text = "";
            btnback.Visible = false;
            btnforward.Visible = false;
          
            



            
         
        }

        public void CreateImageURLPath(string URLPhoto, string CarPic, string carImageId)
        {

            System.IO.DirectoryInfo ImagePath = new DirectoryInfo(@"C:\UcePictures\" + carImageId + "");

            if (!ImagePath.Exists)
            {
                ImagePath.Create();

            }




            if (!URLPhoto.Contains("Emp"))
            {
                FileStream fs = null;
                BinaryWriter bw = null;

                try
                {

                    string saveLocation = @"C:\UcePictures\" + carImageId + "/" + CarPic + "" + ".jpeg";

                    byte[] imageBytes;
                    fs = new FileStream(saveLocation, FileMode.Create);
                    bw = new BinaryWriter(fs);



                    HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(URLPhoto);
                    WebResponse imageResponse = imageRequest.GetResponse();

                    Stream responseStream = imageResponse.GetResponseStream();

                    using (BinaryReader br = new BinaryReader(responseStream))
                    {
                        imageBytes = br.ReadBytes(500000);
                        br.Close();
                    }
                    responseStream.Close();
                    imageResponse.Close();


                    bw.Write(imageBytes);
                }


                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    fs.Close();
                    bw.Close();
                }
            }
            else { }

        }

        private void uploadCarDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  label1.Visible = false;
           // label2.Visible = false;
           // label3.Visible = false;
            //label4.Visible = false;
            logOutToolStripMenuItem.Enabled = true;
            postToolStripMenuItem.Enabled = false;

            qcCheckToolStripMenuItem.Enabled = true;

            pendingUrlsToolStripMenuItem1.Enabled = true;
            recentCarIdsToolStripMenuItem.Enabled = true;
        
            l3.Hide();
            m3.Hide();
            c3.Hide();
           


            u3.MdiParent = this;
            u3.Show();
            uploadCarDetailsToolStripMenuItem.Enabled = false;
         
           //Form1 newform = new Form1(usrname);
           //newform.MdiParent = this;
           //newform.Show();


         
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popform.popform1.Hide();
            popform.popform2.Hide();
            popform.popform3.Hide();

            uploadCarDetailsToolStripMenuItem.Enabled = true;
        
            logOutToolStripMenuItem.Enabled = true;
            
            l3.Hide();
            u3.Hide();
            c3.Hide();
            

            m3.MdiParent = this;
            m3.Show();
          

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popform.popform1.Hide();
            popform.popform2.Hide();
            popform.popform3.Hide();

            //uploadCarDetailsToolStripMenuItem.Enabled = true;
          
            logOutToolStripMenuItem.Enabled = true;

           // ChangePwd cp = new ChangePwd(uname1);
           // cp.Hide();
            l3.Hide();
            u3.Hide();
            m3.Hide();

            c3.MdiParent = this;
            c3.Show();
           // changePasswordToolStripMenuItem.Enabled = false;

          
            logOutToolStripMenuItem.Enabled = false;
         
            uploadCarDetailsToolStripMenuItem.Enabled = false;

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // label1.Visible = false;
            popform.popform1.Hide();
            popform.popform2.Hide();
            popform.popform3.Hide();
            //Main newForm = new Main(objlogin);
            //newForm.Hide();

            uploadCarDetailsToolStripMenuItem.Enabled = false ;
            recentCarIdsToolStripMenuItem.Enabled = false;
      qcCheckToolStripMenuItem.Enabled=false;
      pendingUrlsToolStripMenuItem1.Enabled = false;
      postToolStripMenuItem.Enabled = false;
      qcCheckToolStripMenuItem.Visible = false;
           
           c3.Hide();
            u3.Hide();
            m3.Hide();

        
            //newForm.Hide();
            l3.MdiParent = this;
            l3.Show();
            
            logOutToolStripMenuItem.Enabled = false;
            
           // M_parent.msgme();
            
            
            
          
           
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LatestUrlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            

           
        }

        private void qcCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {

            qcCheckToolStripMenuItem.Enabled = false;
            pendingUrlsToolStripMenuItem1.Enabled = true;
            recentCarIdsToolStripMenuItem.Enabled = true;
            
            
            Cursor.Current = Cursors.WaitCursor;

            QcCheck objqcchk = new QcCheck();

            objqcchk.MdiParent = this;

            
            objqcchk.Show();
            objqcchk.FormClosed += new FormClosedEventHandler(objqcchk_FormClosed);
            objqcchk.BringToFront();
            Cursor.Current = Cursors.Default;
            //qcCheckToolStripMenuItem.Enabled = false;

            //pendingUrlsToolStripMenuItem1.Enabled = true;

            //recentCarIdsToolStripMenuItem.Enabled = true;
        }

        public void objqcchk_FormClosed(object sender, FormClosedEventArgs e)
        {


            qcCheckToolStripMenuItem.Enabled = true;
        }

        private void pendingUrlsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            qcCheckToolStripMenuItem.Enabled = true;
            pendingUrlsToolStripMenuItem1.Enabled = false;
            recentCarIdsToolStripMenuItem.Enabled = true;
    
            Cursor.Current = Cursors.WaitCursor;
            
            PendingDetails objpend = new PendingDetails();


            // button1.Enabled = false;
          
            objpend.Show();
            objpend.FormClosed += new FormClosedEventHandler(objpend_FormClosed);
            //objpend.BringToFront();
            objpend.MdiParent = this;
            this.BringToFront();
            
           


            Cursor.Current = Cursors.Default;
            //pendingUrlsToolStripMenuItem1.Enabled = false;
            //qcCheckToolStripMenuItem.Enabled = true;
            //recentCarIdsToolStripMenuItem.Enabled = true;

            
            //----------------------
        }


        public void objpend_FormClosed(object sender, FormClosedEventArgs e)
        {


            pendingUrlsToolStripMenuItem1.Enabled = true;
        }

        private void pendingUrlsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void recentCarIdsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qcCheckToolStripMenuItem.Enabled = true;
            pendingUrlsToolStripMenuItem1.Enabled = true;
            recentCarIdsToolStripMenuItem.Enabled = false;
           
           // postToolStripMenuItem.Enabled = true;
            Cursor.Current = Cursors.WaitCursor;



            LatestCarids objLatestCarids = new LatestCarids();




           objLatestCarids.MdiParent = this;
           objLatestCarids.BringToFront();

            objLatestCarids.Show();
            objLatestCarids.FormClosed += new FormClosedEventHandler(objLatestCarids_FormClosed);

            Cursor.Current = Cursors.Default;
            //recentCarIdsToolStripMenuItem.Enabled = false;

            //qcCheckToolStripMenuItem.Enabled = true;
            //pendingUrlsToolStripMenuItem1.Enabled = true;


        }

        private void objLatestCarids_FormClosed(object sender, FormClosedEventArgs e)
        {
            LatestCarids objLatestCarids1 = new LatestCarids();

            recentCarIdsToolStripMenuItem.Enabled = true;
        }

        public void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
               postToolStripMenuItem.Enabled = false;
            pendingUrlsToolStripMenuItem1.Enabled = true;
            recentCarIdsToolStripMenuItem.Enabled = true;
            qcCheckToolStripMenuItem.Enabled = true;
         
            RecentPosts objrecntpost = new RecentPosts();
            objrecntpost.MdiParent = this;
            objrecntpost.Show();
            objrecntpost.FormClosed += new FormClosedEventHandler(objrecntpost_FormClosed);
            objrecntpost.BringToFront();
            this.BringToFront();
        }

        public void objrecntpost_FormClosed(object sender, FormClosedEventArgs e)
        {


            postToolStripMenuItem.Enabled = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
          //  label1.Visible = false;
            popform.popform1.Hide();
            popform.popform2.Hide();
            popform.popform3.Hide();
            //Main newForm = new Main(objlogin);
            //newForm.Hide();

            uploadCarDetailsToolStripMenuItem.Enabled = false;
            recentCarIdsToolStripMenuItem.Enabled = false;
            qcCheckToolStripMenuItem.Enabled = false;
            pendingUrlsToolStripMenuItem1.Enabled = false;
            postToolStripMenuItem.Enabled = false;
            qcCheckToolStripMenuItem.Visible = false;

            c3.Hide();
            u3.Hide();
            m3.Hide();


            //newForm.Hide();
            l3.MdiParent = this;
            l3.Show();

            logOutToolStripMenuItem.Enabled = false;

            // M_parent.msgme();

            Main obj = new Main();
            obj.Close();





        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Application.Restart();
           //this.FormClosed();
           // label1.Visible = false;
          //  label2.Visible = false;
//label3.Visible = false;
           // label4.Visible = false;
            popform.popform1.Hide();
            popform.popform2.Hide();
            popform.popform3.Hide();
            //Main newForm = new Main(objlogin);
            //newForm.Hide();

            uploadCarDetailsToolStripMenuItem.Enabled = false;
            recentCarIdsToolStripMenuItem.Enabled = false;
            qcCheckToolStripMenuItem.Enabled = false;
            pendingUrlsToolStripMenuItem1.Enabled = false;
            postToolStripMenuItem.Enabled = false;
            qcCheckToolStripMenuItem.Visible = false;

            c3.Hide();
            u3.Hide();
            m3.Hide();


            //newForm.Hide();
            l3.MdiParent = this;
            l3.Show();

            logOutToolStripMenuItem.Enabled = false;

            // M_parent.msgme();

        }

        private void postToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

           
        }

        private void postToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            //objrecntpost.Hide();
        }

        public void Main_Resize(object sender, EventArgs e)
        {

            QcCheck objqcchk = new QcCheck();
            objqcchk.Hide();

            //objqcchk.MdiParent = this;

            //QCFormcheck objqcfrm = new QCFormcheck();
            //objqcfrm.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void GetCarDetails_Click(object sender, EventArgs e)
        {
              
            string number = txtCarID.Text;
            Regex regex = new Regex(@"[\d]");
            if (regex.IsMatch(number))
            {

              //  ((Main)this.ParentForm).postToolStripMenuItem.Enabled = true;
              //  ((Main)this.MdiParent)..Enabled = false;
                //true


                // if (txtCarID.Text == "")
                //{
                //  MessageBox.Show("Enter Carid");
                //}
                // Main main = new Main();
                // popform.objfrm2.Controls["postToolStripMenuItem"].Enabled = true;
                Globalcarid.txtCarID = Convert.ToInt32(txtCarID.Text);
                // servicetimer++;
                // 1000 X 15
                // int servicecount0 = servicecount % 2000;
                Cursor.Current = Cursors.WaitCursor;

                // dtgridSubDet.Visible = true;
                objsubdetailsinfo.CarId = txtCarID.Text;
                DataSet dsSubDet = new DataSet();
                btnGetdetails.Enabled = false;

                label28.Visible = true;

                btnGetAllPics.Visible = true;
                lblsubdetails.Visible = true;
                btnback.Visible = false;
                btnforward.Visible = false;



                cbBoxWebsite.Visible = true;
               
                btnSubmit.Visible = true;
                lblwebsite.Visible = true;

                if (txtCarID.Text == "")
                {

                    // dtgridSubDet.Visible = false;
                    MessageBox.Show("Please Enter Car Id");
                    btnGetdetails.Enabled = false;
                    lblwebsite.Visible = false;
                    cbBoxWebsite.Visible = false;
                    btnSubmit.Visible = false;
                    btnGetdetails.Enabled = true;
                }
                UplaodDetails.Visible = false;
                btnSubmit.Visible = false;

                cbBoxWebsite.ResetText();
                webBrowser1.Navigate("about:blank");


                try
                {
                    com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                    IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                    obUsedCarsInfo = objService.FindCarID(txtCarID.Text);




                    FillCarDetails(obUsedCarsInfo);
                    // panel1.Visible = true;
                    carid = Convert.ToInt32(txtCarID.Text);
                    dsSubDet = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);

                    if (dsSubDet.Tables[0].Rows.Count == 0)
                    {
                        // dtgridSubDet.Visible = false;
                        lblsubdetails.Visible = false;
                    }
                    else
                    {
                        // dtgridSubDet.Visible = true;

                        //   dtgridSubDet.AutoGenerateColumns = true;
                        // dtgridSubDet.DataSource = dsSubDet.Tables[0];
                        // lblsubdetails.Text = "Car Id " + txtCarID.Text + " Submitted Details :";
                    }






                    // button2.Visible = true;
                    panel1.Visible = true;


                    cbBoxWebsite.Enabled = true;




                    DataSet Eds = new DataSet();
                    Eds = objSubmitionDetailsBL.GetEmailData();

                    comboBox1.DataSource = Eds.Tables[0];
                    comboBox1.DisplayMember = Eds.Tables[0].Columns["EmailId"].ToString();
                    comboBox1.ValueMember = Eds.Tables[0].Columns["Password"].ToString();

                    //comboBox1.Items.Insert(0, new Items("--Select--", "0"));

                    Cursor.Current = Cursors.Default;

                }
                catch (Exception ex)
                {

                    // MessageBox.Show("I am Sorry we cannot provide you the service .Please contact Our Administrator");

                }

            }

            else 
            {
                MessageBox.Show(" enter carid");
            }
        }
        protected void LiveButtonUrl_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LiveTextBoxUrl.Text))
            {
                errorProvider1.SetError(LiveTextBoxUrl, "URL required!");
            }
            //Response.Write("you clicked on button");
            //  MessageBox.Show("Done");
            else
            {

                int carid = Convert.ToInt32(txtCarID.Text);
                if (LiveTextBoxUrl.Text != "")
                {
                    // if (LiveTextBoxUrl.Text.Contains(sitename))
                    // {
                    // string Regex = " /(ftp|http|https):\\/\\/(\\w+:{0,1}\\w*@)?(\\S+)(:[0-9]+)?(\\/|\\/([\\w#!:.?+=&%@!-\\/]))?/;";
                    //if (Regex.(txtpndg.Text))
                    //{ 
                    //}

                    Regex urlCheck = new Regex(@"((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)");
                    if (urlCheck.IsMatch(LiveTextBoxUrl.Text))
                    {

                        string SubStatus = "Pending";
                        string QcStatus = "Pending";
                        //objSubmitionDetailsBL.MultiSaveSubmitionDetails(objsubdetailsinfo, carid, LiveTextBoxUrl.Text, websiteId, subby);
                        objSubmitionDetailsBL.MultiSaveSubmitionDetails(carid, LiveTextBoxUrl.Text, websiteId, subby, SubStatus, QcStatus);
                        MessageBox.Show("Uploaded to Live successfully");
                        LiveTextBoxUrl.Text = "";
                        btnlive.Visible = false;
                        LiveFormUrl.Hide();

                        carid = Convert.ToInt32(txtCarID.Text);
                        DataSet dss = new DataSet();
                        dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);

                        if (dss.Tables[0].Rows.Count == 0)
                        {
                            // dtgridSubDet.Visible = false;
                            lblsubdetails.Visible = false;
                        }
                        else
                        {
                            //  dtgridSubDet.Visible = true;

                            // dtgridSubDet.AutoGenerateColumns = true;
                            //  dtgridSubDet.DataSource = dss.Tables[0];
                            //lblsubdetails.Text = "Car Id " + txtCarID.Text + " Submitted Details :";
                        }
                        // }
                    }
                }
            }
        }
        protected void LiveButtonLater_click(object sender, EventArgs e)
        {

            string SubStatus = "Pending";
            string QcStatus = "Pending";

            objSubmitionDetailsBL.MultiSaveSubmitionDetails(carid, linkItem, websiteId, subby, SubStatus, QcStatus);
            LiveFormUrl.Hide();

            carid = Convert.ToInt32(txtCarID.Text);
            DataSet dss = new DataSet();
            dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);

            if (dss.Tables[0].Rows.Count == 0)
            {
                // dtgridSubDet.Visible = false;
                lblsubdetails.Visible = false;
            }
            else
            {
                // dtgridSubDet.Visible = true;

                // dtgridSubDet.AutoGenerateColumns = true;
                // dtgridSubDet.DataSource = dss.Tables[0];
                //lblsubdetails.Text = "Car Id " + txtCarID.Text + " Submitted Details :";
            }
        }




        private void cbBoxWebsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        
           
            panel3.Visible = true;
            label31.Visible = true;
            label6.Visible = true;
            label8.Visible = true;
            label10.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label18.Visible = true;

            label31.Text = "";
            label6.Text = "";
            label8.Text = "";
            label10.Text = "";
            label12.Text = "";
            label13.Text = "";
            label15.Text = "";
            label16.Text = "";
            label23.Text = "";
            label24.Text = "";
            label25.Text = "";
           // label126.Text = "";
            //label18.Text = "";

            label18.Text = "Steps to follow for " + cbBoxWebsite.SelectedItem.ToString(); ;


            comboBox1.Visible = true;
            label27.Visible = true;


            label31.Font = new System.Drawing.Font("Verdana", 8.0f,
     System.Drawing.FontStyle.Regular);

            label6.Font = new System.Drawing.Font("Verdana", 8.0f,
  System.Drawing.FontStyle.Regular);

            label8.Font = new System.Drawing.Font("Verdana", 8.0f,
  System.Drawing.FontStyle.Regular);

            label10.Font = new System.Drawing.Font("Verdana", 8.0f,
  System.Drawing.FontStyle.Regular);

            label12.Font = new System.Drawing.Font("Verdana", 8.0f,
System.Drawing.FontStyle.Regular);

            label13.Font = new System.Drawing.Font("Verdana", 8.0f,
     System.Drawing.FontStyle.Regular);

            label15.Font = new System.Drawing.Font("Verdana", 8.0f,
  System.Drawing.FontStyle.Regular);

            label16.Font = new System.Drawing.Font("Verdana", 8.0f,
  System.Drawing.FontStyle.Regular);

            label18.Font = new System.Drawing.Font("Verdana", 8.0f,
  System.Drawing.FontStyle.Regular);

            label23.Font = new System.Drawing.Font("Verdana", 8.0f,
System.Drawing.FontStyle.Regular);

            label24.Font = new System.Drawing.Font("Verdana", 8.0f,
 System.Drawing.FontStyle.Regular);

            label25.Font = new System.Drawing.Font("Verdana", 8.0f,
System.Drawing.FontStyle.Regular);
            label26.Font = new System.Drawing.Font("Verdana", 8.0f,
System.Drawing.FontStyle.Regular);



            //frminitlize()
            count = 0;
            
           
            UplaodDetails.Enabled = false;
            
            btnSubmit.Visible = false; 
        
            panel2.Visible = true;
            btnlive.Visible =false;
          
            //label23.Visible = false;
            //label24.Visible = false;
            //label25.Visible = false;
            //label26.Visible = false;
            //label27.Visible = false;
            //label28.Visible = false;
            //label29.Visible = false;

           // lblRecent.Visible = false;
           // dtgvRecent.Visible = false;
           // panel3.Visible = false;

          

            lblinfrm1.Visible = true;
            lbinfrm2.Visible = true;
            lbinfrm3.Visible = true;
            lbinfrm4.Visible = true;
            lbinfrm5.Visible = true;










            if (cbBoxWebsite.SelectedIndex == 0)
            {


                label10.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label26.Visible = false;



                label31.Text = "1.Click Upload (to upload the data)";
                label6.Text = "2.Click Submit (to post ad )";
                label8.Text = "3.Click upload to love (To upload in live)";


              //  popform.popform1.Visible = true;
               // Application.OpenForms[0].Show();
                Cursor.Current = Cursors.WaitCursor;

               popform.popform2.Hide();
               popform.popform3.Hide();
               popform.popform4.Hide();
               popform.popform5.Hide();

              popform.popform1.ControlBox = false;

              
                lbinfrm4.Visible = false;
                lbinfrm5.Visible = false;

                lblinfrm1.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm2.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm3.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm4.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm5.Font = new System.Drawing.Font("Verdana", 8.0f,
 System.Drawing.FontStyle.Regular);

                popform.popform1.Text = "CarPosts";
                popform.popform1.TopMost = true;

                lblinfrm1.Location = new System.Drawing.Point(30, 34);
                lblinfrm1.Width = 300;
                lblinfrm1.Text = "1.Click Upload (to upload car details) ";


                lbinfrm2.Location = new System.Drawing.Point(30, 64);
                lbinfrm2.Width = 300;
                lbinfrm2.Text = "2.Click Submit (to post Ad) ";

                lbinfrm3.Location = new System.Drawing.Point(30, 94);
                lbinfrm3.Width = 300;
                lbinfrm3.Text = "3.Click Upload To Live (to upload in live) ";

                popform.popform1.Controls.Add(lblinfrm1);
                popform.popform1.Controls.Add(lbinfrm2);
                popform.popform1.Controls.Add(lbinfrm3);
                //popform1.Controls.Add(lbwebsite);
                //popform1.Controls.Add(lbCarId);


                
               // popform.popform1.Show();




              
               
                Cursor.Current = Cursors.WaitCursor;
                webBrowser1.Navigate("http://www.carposts.com/AutoEdit.php?SaveAuto=AddNew&Type=For%20Salet");
                
            
            

               
              
                //Form1.ActiveForm.Text = "Carposts";
                Website = "CarPosts";
              //  objalways.show("carposts");
              //  MessageBox.Show("carposts \n 1.Upload \n 2.Submit");
              
             

                objsubdetailsinfo.Webname = Website;
              //  DataSet dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);
              //if (dss.Tables.Count > 0)
              //{
              //    if (dss.Tables[0].Rows.Count > 0)
              //    {
              //        string lastdate = dss.Tables[0].Rows[0]["Sub_Time"].ToString();
              //        string SubBy = dss.Tables[0].Rows[0]["SubmitedBy"].ToString();
              //        string CarId = dss.Tables[0].Rows[0]["CarId"].ToString();


                    
                   
                  

                    
              //    }
              //}

                Cursor.Current = Cursors.Default;
            
               // UplaodDetails.Visible = true;
               
              
            }
            else if (cbBoxWebsite.SelectedIndex == 2)
            {
                Cursor.Current = Cursors.WaitCursor;
                btnlive.Enabled = false;
                label31.Text = "1.Click Upload (to Enter Login details) ";
                label6.Text = "2.Click Upload (to Enter Make and Model)";
                label8.Text = "3.Click Upload (to upload car details)";


                label10.Text = "4.Click Submit (to post Ad)";
                label12.Text = "5.Click Upload  (to upload image)";
                label13.Text = "6.Click Submit(to upload image)";
                label15.Text = "7.Click Submit(to select image)";
                label16.Text = "8.Click Submit (to submit image)";
                label23.Text = "9.Click Submit(to view details)";
                label24.Text = "10.Click Submit (to Click Free))";
                label25.Text = "11.Click Submit(to Cilck View.Edit)";
                label26.Text = "12.Click Upload to Live (to save post link)";








                popform.popform2.Height = 460;
                popform.popform2.Width = 340;

                popform.popform1.Hide();
                popform.popform3.Hide();
                popform.popform2.ControlBox = false;
                popform.popform4.Hide();
                popform.popform5.Hide();


                lblinfrm1.Font = new System.Drawing.Font("Verdana", 8.0f,
   System.Drawing.FontStyle.Regular);

                lbinfrm2.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm3.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm4.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm5.Font = new System.Drawing.Font("Verdana", 8.0f,
    System.Drawing.FontStyle.Regular);

                lbinfrm6.Font = new System.Drawing.Font("Verdana", 8.0f,
    System.Drawing.FontStyle.Regular);


                lbinfrm7.Font = new System.Drawing.Font("Verdana", 8.0f,
 System.Drawing.FontStyle.Regular);

                lbinfrm8.Font = new System.Drawing.Font("Verdana", 8.0f,
System.Drawing.FontStyle.Regular);

                lbinfrm9.Font = new System.Drawing.Font("Verdana", 8.0f,
System.Drawing.FontStyle.Regular);

                lbinfrm10.Font = new System.Drawing.Font("Verdana", 8.0f,
System.Drawing.FontStyle.Regular);

                lbinfrm11.Font = new System.Drawing.Font("Verdana", 8.0f,
System.Drawing.FontStyle.Regular);

                lbinfrm12.Font = new System.Drawing.Font("Verdana", 8.0f,
System.Drawing.FontStyle.Regular);

               // lbinfrm7.Font = new System.Drawing.Font("Verdana", 8.0f,
//System.Drawing.FontStyle.Regular);

                popform.popform2.Text = "Justgoodcars";
                popform.popform2.TopMost = true;

                lblinfrm1.Location = new System.Drawing.Point(30, 34);
                lblinfrm1.Width = 300;
                lblinfrm1.Text = "1.Click Upload (to Enter Login details) ";


                lbinfrm2.Location = new System.Drawing.Point(30, 64);
                lbinfrm2.Width = 300;
                lbinfrm2.Text = "2.Click Upload (to Enter Make and Model) ";

                lbinfrm3.Location = new System.Drawing.Point(30, 94);
                lbinfrm3.Width = 300;
                lbinfrm3.Text = "3.Click Upload (to upload car details)";

                lbinfrm4.Location = new System.Drawing.Point(30, 124);
                lbinfrm4.Width = 300;
                lbinfrm4.Text = "4.Click Submit (to post Ad)";


                lbinfrm5.Location = new System.Drawing.Point(30, 154);
                lbinfrm5.Width = 300;
                lbinfrm5.Text = "5.Click Upload  (to upload image)";

                lbinfrm6.Location = new System.Drawing.Point(30, 184);
                lbinfrm6.Width = 300;
                lbinfrm6.Text = "6.Click Submit(to upload image)";


                lbinfrm7.Location = new System.Drawing.Point(30, 214);
                lbinfrm7.Width = 300;
                lbinfrm7.Text = "7.Click Submit(to select image)";

                lbinfrm8.Location = new System.Drawing.Point(30, 244);
                lbinfrm8.Width = 300;
                lbinfrm8.Text = "8.Click Submit (to submit image)";


                lbinfrm9.Location = new System.Drawing.Point(30, 274);
                lbinfrm9.Width = 300;
                lbinfrm9.Text = "9.Click Submit(to view details)";


                lbinfrm10.Location = new System.Drawing.Point(30, 304);
                lbinfrm10.Width = 300;
                lbinfrm10.Text = "10.Click Submit (to Click Free)";


                lbinfrm11.Location = new System.Drawing.Point(30, 334);
                lbinfrm11.Width = 300;
                lbinfrm11.Text = "11.Click Submit( to Cilck View.Edit )";


                lbinfrm12.Location = new System.Drawing.Point(30, 364);
                lbinfrm12.Width = 300;
                lbinfrm12.Text = "12.Click Upload to Live (to save post link)";




                //lbinfrm5.Location = new System.Drawing.Point(30, 154);
                //lbinfrm5.Width = 300;
                //lbinfrm5.Text = "Image upload not working in this webisite*";

                ////lbinfrm2.Location = new System.Drawing.Point(30, 64);
                ////lbinfrm2.Width = 300;
                ////lbinfrm2.Text = "2.Click Submit(To post Ad) ";


                popform.popform2.Controls.Add(lblinfrm1);
                popform.popform2.Controls.Add(lbinfrm2);
                popform.popform2.Controls.Add(lbinfrm3);
                popform.popform2.Controls.Add(lbinfrm4);
                popform.popform2.Controls.Add(lbinfrm5);
                popform.popform2.Controls.Add(lbinfrm6);
                popform.popform2.Controls.Add(lbinfrm7);
                popform.popform2.Controls.Add(lbinfrm8);
                popform.popform2.Controls.Add(lbinfrm9);
                popform.popform2.Controls.Add(lbinfrm10);
                popform.popform2.Controls.Add(lbinfrm11);
                popform.popform2.Controls.Add(lbinfrm12);




                //popform.popform2.Show();
              


               // Cursor.Current = Cursors.WaitCursor;
                webBrowser1.Navigate("http://www.justgoodcars.com/sign-in.php");
          //  http://www.justgoodcars.com/members/members_index.php
               

               // Cursor.Current = Cursors.Default;
               // f1.Dispose();
              
               
               // Form1.ActiveForm.Text = "justgoodcars";
                Website = "JustgoodCars";
              //  objalways.show("JustgoodCars");
              
                //label29.Text = "Image upload not working in this webisite*";

                objsubdetailsinfo.Webname = Website;
                //DataSet dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);
                //if (dss.Tables.Count > 0)
                //{
                //    if (dss.Tables[0].Rows.Count > 0)
                //    {
                //        string lastdate = dss.Tables[0].Rows[0]["Sub_Time"].ToString();
                //        string SubBy = dss.Tables[0].Rows[0]["SubmitedBy"].ToString();
                //        string CarId = dss.Tables[0].Rows[0]["CarId"].ToString();




                //    }
                //}
              
               // UplaodDetails.Visible = true;
                Cursor.Current = Cursors.Default;

            }
            //else if (cbBoxWebsite.SelectedIndex == 7)
            //{

            //    webBrowser1.Navigate("http://www.classifiedsforfree.com/post-ad/City.htm");
            //    //Form1.ActiveForm.Text = "classifiedsforfree";
            //    Website = "classifiedsforfree";
            //   // objalways.show("classifiedsforfree");
              
            //}
            else if (cbBoxWebsite.SelectedIndex == 1)
            {

                Cursor.Current = Cursors.WaitCursor;
                label12.Visible = false;
                label13.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label26.Visible = false;



                webBrowser1.Navigate("http://claz.org/classifieds/post");
              //  Form1.ActiveForm.Text = "clazorg";

                label31.Text = "1.Click Upload (to Upload car details) ";
                label6.Text = "Note:Need to UPload Image Manually";
                label8.Text = "2.Click Submit (to post Ad)";


                label10.Text = "3.Click Upload To Live (to upload in live)";




                popform.popform1.Hide();
                popform.popform2.Hide();
                popform.popform4.ControlBox = false;
                popform.popform3.Hide();
                popform.popform5.Hide();


                lbinfrm5.Visible = false;
                //lbinfrm3.Visible = false;

                lblinfrm1.Font = new System.Drawing.Font("Verdana", 8.0f,
   System.Drawing.FontStyle.Regular);

                lbinfrm2.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm3.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm4.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);


                popform.popform4.Text = "claz.org";
                popform.popform4.TopMost = true;

                lblinfrm1.Location = new System.Drawing.Point(30, 34);
                lblinfrm1.Width = 300;
                lblinfrm1.Text = "1.Click Upload (to Upload car details) ";


                lbinfrm2.Location = new System.Drawing.Point(30, 64);
                lbinfrm2.Width = 300;
                lbinfrm2.Text = "Note:Need to UPload Image Manually";

                lbinfrm3.Location = new System.Drawing.Point(30, 94);
                lbinfrm3.Width = 300;
                lbinfrm3.Text = "2.Click Submit (to post Ad)";

                lbinfrm4.Location = new System.Drawing.Point(30, 124);
                lbinfrm4.Width = 300;
                lbinfrm4.Text = "3.Click Upload To Live (to upload in live)";





                popform.popform4.Controls.Add(lblinfrm1);
                popform.popform4.Controls.Add(lbinfrm2);
                popform.popform4.Controls.Add(lbinfrm3);
                popform.popform4.Controls.Add(lbinfrm4);




                //popform.popform4.Show();



                Website = "clazorg";


                objsubdetailsinfo.Webname = Website;
                //DataSet dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);
                //if (dss.Tables.Count > 0)
                //{
                //    if (dss.Tables[0].Rows.Count > 0)
                //    {
                //        string lastdate = dss.Tables[0].Rows[0]["Sub_Time"].ToString();
                //        string SubBy = dss.Tables[0].Rows[0]["SubmitedBy"].ToString();
                //        string CarId = dss.Tables[0].Rows[0]["CarId"].ToString();




                //    }
                //}
              //  objalways.show("clazorg");

               
              
                Cursor.Current = Cursors.Default;
            }
            //else if (cbBoxWebsite.SelectedIndex == 4)
            //{
            //    webBrowser1.Navigate("http://www.jeanza.com/publish-a-new-ad.htm");
            //    Form1.ActiveForm.Text = "jeanza";
            //    Website = "jeanza";
            //}
            //else if (cbBoxWebsite.SelectedIndex == 4)
            //{
            //    webBrowser1.Navigate("http://www.american-classifieds.net/postad.php?submittype=0&categ=");
            //  //  Form1.ActiveForm.Text = "americanclalassifieds";
            //    Website = "americanclassifieds";
            //   // objalways.show("americanclassifieds");
            //}
            //else if (cbBoxWebsite.SelectedIndex == 5)
            //{

            //    webBrowser1.Navigate("http://www.postfreeadshere.com/publish-a-new-ad.htm");
            //   // Form1.ActiveForm.Text = "Postfreeadshere";
            //    Website = "postfreeadshere";
            //   // objalways.show("postfreeadshere");

            //    //webBrowser1.Navigate("http://freead1.net/post-free-ad-to-USA-42");
            //    //Form1.ActiveForm.Text = "FreeAdd.net";
            //    //Website = "freeadd.net";
            //}
            else if (cbBoxWebsite.SelectedIndex == 3)
            {

                Cursor.Current = Cursors.WaitCursor;
                label13.Visible = false;
                label15.Visible = false;
                label16.Visible = false;

                label26.Visible = false;

                webBrowser1.Navigate("http://www.usadsciti.com/publish-a-new-ad.htm");

                label31.Text = "1.Click Upload (to Upload car details) ";
                label6.Text = "Note:Need to Enter Description & Verification Code";
                label8.Text = "Note:Enter Validation code manually";


                label10.Text = "2.Click Submit (to post Ad)";
                label12.Text = "3.Click Upload To Live(to upload in live)";




                popform.popform1.Hide();
                popform.popform2.Hide();
                popform.popform5.ControlBox = false;
                popform.popform3.Hide();
                popform.popform4.Hide();


            
                //lbinfrm5.Visible = false;
                //lbinfrm3.Visible = false;

                lblinfrm1.Font = new System.Drawing.Font("Verdana", 8.0f,
   System.Drawing.FontStyle.Regular);

                lbinfrm2.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm3.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm4.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);
                lbinfrm5.Font = new System.Drawing.Font("Verdana", 8.0f,
     System.Drawing.FontStyle.Regular);


                popform.popform5.Text = "usadsciti";
                popform.popform5.TopMost = true;

                lblinfrm1.Location = new System.Drawing.Point(30, 34);
                lblinfrm1.Width = 300;
                lblinfrm1.Text = "1.Click Upload (to Upload car details) ";


                lbinfrm2.Location = new System.Drawing.Point(30, 64);
                lbinfrm2.Width = 300;
                lbinfrm2.Text = "Note:Need to Enter Description & Verification Code";

                lbinfrm5.Location = new System.Drawing.Point(30, 94);
                lbinfrm5.Width = 300;
                lbinfrm5.Text = "Note:Enter Validation code manually";


                lbinfrm3.Location = new System.Drawing.Point(30, 124);
                lbinfrm3.Width = 300;
                lbinfrm3.Text = "2.Click Submit (to post Ad)";

                lbinfrm4.Location = new System.Drawing.Point(30, 154);
                lbinfrm4.Width = 300;
                lbinfrm4.Text = "3.Click Upload To Live(to upload in live)";




                popform.popform5.Controls.Add(lblinfrm1);
                popform.popform5.Controls.Add(lbinfrm2);
                popform.popform5.Controls.Add(lbinfrm3);
                popform.popform5.Controls.Add(lbinfrm4);
                popform.popform5.Controls.Add(lbinfrm5);



               // popform.popform5.Show();




              //  Form1.ActiveForm.Text = "Usadsciti";
                Website = "Usadsciti";


                objsubdetailsinfo.Webname = Website;
                //DataSet dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);
                //if (dss.Tables.Count > 0)
                //{
                //    if (dss.Tables[0].Rows.Count > 0)
                //    {
                //        string lastdate = dss.Tables[0].Rows[0]["Sub_Time"].ToString();
                //        string SubBy = dss.Tables[0].Rows[0]["SubmitedBy"].ToString();
                //        string CarId = dss.Tables[0].Rows[0]["CarId"].ToString();




                //    }
                //}
                //webBrowser1.Navigate("http://www.freeadlists.com/index.php?pag=postAd#");
                //Form1.ActiveForm.Text = "FreeAddList";
                //Website = "freeaddlist";
              //  objalways.show("Usadsciti");

               
                Cursor.Current = Cursors.Default;
              // if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
              //{
              //   // webBrowser1.DocumentCompleted += WhenItsDone;
              
             
              // }
            }
            else if (cbBoxWebsite.SelectedIndex == 4)
            {

                Cursor.Current = Cursors.WaitCursor;

                label12.Visible = false;
                label13.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label26.Visible = false;



                label31.Text = "1.Click Upload (to Upload car details) ";
                label6.Text = "Note:Need to give validation code";
                label8.Text = "2.Click Submit (to post Ad)";


                label10.Text = "3.Click Uplod To Live (to upload to live)";
               // label12.Text = "3.Click Upload To Live(to upload in live)";







                popform.popform1.Hide();
                popform.popform2.Hide();
                popform.popform3.ControlBox = false;
                popform.popform4.Hide();
                popform.popform5.Hide();


               
                lbinfrm5.Visible = false;
                //lbinfrm3.Visible = false;



                lblinfrm1.Font = new System.Drawing.Font("Verdana", 8.0f,
   System.Drawing.FontStyle.Regular);

                lbinfrm2.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm3.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);

                lbinfrm4.Font = new System.Drawing.Font("Verdana", 8.0f,
      System.Drawing.FontStyle.Regular);


                popform.popform3.Text = "Usnetads";
                popform.popform3.TopMost = true;

                lblinfrm1.Location = new System.Drawing.Point(30, 34);
                lblinfrm1.Width = 300;
                lblinfrm1.Text = "1.Click Upload (to Upload car details) ";


                lbinfrm2.Location = new System.Drawing.Point(30, 64);
                lbinfrm2.Width = 300;
                lbinfrm2.Text = "Note:Need to give validation code";

                lbinfrm3.Location = new System.Drawing.Point(30, 94);
                lbinfrm3.Width = 300;
                lbinfrm3.Text = "2.Click Submit (to post Ad)";


                lbinfrm4.Location = new System.Drawing.Point(30, 124);
                lbinfrm4.Width = 300;
                lbinfrm4.Text = "3.Click Uplod To Live (to upload to live)";





                popform.popform3.Controls.Add(lblinfrm1);
                popform.popform3.Controls.Add(lbinfrm2);
                popform.popform3.Controls.Add(lbinfrm3);
                popform.popform3.Controls.Add(lbinfrm4);



               // popform.popform3.Show();





              
                webBrowser1.Navigate("http://www.usnetads.com/post/post-free-ads.php");
             //   Form1.ActiveForm.Text = "UsNetads";
                Website = "UsNetads";
              //  objalways.show("UsNetads");

               
                //  objalways.show("carposts");
                //  MessageBox.Show("carposts \n 1.Upload \n 2.Submit");
              
            

                objsubdetailsinfo.Webname = Website;
                //DataSet dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);
                //if (dss.Tables.Count > 0)
                //{
                //    if (dss.Tables[0].Rows.Count > 0)
                //    {
                //        string lastdate = dss.Tables[0].Rows[0]["Sub_Time"].ToString();
                //        string SubBy = dss.Tables[0].Rows[0]["SubmitedBy"].ToString();
                //        string CarId = dss.Tables[0].Rows[0]["CarId"].ToString();


                     
                //    }
                //}
               
                Cursor.Current = Cursors.Default;
               // if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
              //  {
                    
                  //  UplaodDetails.Visible = true;
               // }
            }
            else if (cbBoxWebsite.SelectedIndex == 8)
            {
                webBrowser1.Navigate("http://www.freeautoshopper.com/post_ad.php");
              //  Form1.ActiveForm.Text = "FreeAutoShopper";
                Website = "FreeAutoShopper";
             //   objalways.show("freeautoshopper");

            
            }
            else if (cbBoxWebsite.SelectedIndex == 9)
            {

                webBrowser1.Navigate("http://www.locateanyauto.com/post_ad.php");
             //   Form1.ActiveForm.Text = "Locate Any Auto";
                Website = "Locate Any Auto";
              //  objalways.show("Locate Any Auto");
            }
            else if (cbBoxWebsite.SelectedIndex == 10)
            {

                webBrowser1.Navigate("http://www.freeadlists.com/index.php?pag=postAd#");
            //    Form1.ActiveForm.Text = "FreeAddList";
                Website = "FreeAddList";
              //  objalways.show("FreeAddList");
            }
            else if (cbBoxWebsite.SelectedIndex == 11)
            {

                webBrowser1.Navigate("http://www.autoii.com/auto/AutoEdit.php?SaveAuto=AddNew&Type=For%20Sale");
              //  Form1.ActiveForm.Text = "autoii";
                Website = "autoii";
              //  objalways.show("autoii");
            }
            else if (cbBoxWebsite.SelectedIndex == 12)
            {

                webBrowser1.Navigate("http://www.ebayclassifieds.com/m/PostAd?scrid=23520191-6011683319352158146");
             //   Form1.ActiveForm.Text = "ebayclassifieds";
                Website = "ebayclassifieds";
             //   objalways.show("ebayclassifieds");
               
            }
            else if (cbBoxWebsite.SelectedIndex == 13)
            {

                webBrowser1.Navigate("http://www.biggestclassifieds.com/?view=selectcity&targetview=post&cityid=0&lang=en");
              //  Form1.ActiveForm.Text = "biggestclassifieds";
                Website = "biggestclassifieds";
              //  objalways.show("biggestclassifieds");
                
            }
            else if (cbBoxWebsite.SelectedIndex == 14)
            {

                webBrowser1.Navigate("http://www.classifiedads.com/post.php");
            //    Form1.ActiveForm.Text = "ClassifiedAds";
                Website = "ClassifiedAds";
              //  objalways.show("ClassifiedAds");

            }
            else if (cbBoxWebsite.SelectedIndex == 15)
            {

                webBrowser1.Navigate("http://www.locanto.com/post/");
                
             //   Form1.ActiveForm.Text = "Locanto";
                Website = "Locanto";
               // objalways.show("Locanto");

            }
            else if (cbBoxWebsite.SelectedIndex == 16)
            {

                webBrowser1.Navigate("http://www.75vn.com/member/login.php?TypeItem=&action=M");

             //   Form1.ActiveForm.Text = "75vn";
                Website = "75vn";
              //  objalways.show("75VN");

            }
             else if (cbBoxWebsite.SelectedIndex == 17)
            {

                webBrowser1.Navigate("http://www.adoos.com/posting/");

             //   Form1.ActiveForm.Text = "adoos";
                Website = "adoos";
              //  objalways.show("adoos");
             }
            else if (cbBoxWebsite.SelectedIndex == 18)
            {

                webBrowser1.Navigate("http://www.fastautosales.com/sell_used_car");

             //   Form1.ActiveForm.Text = "fastautosales";
                Website = "fastautosale";
              //  objalways.show("fastautosale");
            }
            else if (cbBoxWebsite.SelectedIndex == 19)
            {

                webBrowser1.Navigate("http://www.sell.com/sell/?_d=1");

             //   Form1.ActiveForm.Text = "Sell.com";
                Website = "Sell.com";
              //  objalways.show("sell.com");
            }
            else if (cbBoxWebsite.SelectedIndex == 20)
            {

                webBrowser1.Navigate("http://www.sellmycar.com/sellacar.aspx");

             //   Form1.ActiveForm.Text = "Sellmycar";
                Website = "Sellmycar";
              //  objalways.show("sellmycar");
            }
            else if (cbBoxWebsite.SelectedIndex == 21)
            {

                webBrowser1.Navigate("https://www.recycler.com/Account/Login?ReturnUrl=%2fListing");

              //  Form1.ActiveForm.Text = "recycler";
                Website = "recycler";
              //  objalways.show("Recycler");
            }
            //----------karunakar start---------------------------------
            else if (cbBoxWebsite.SelectedIndex == 22)
            {
                webBrowser1.Navigate("http://www.classifiedsciti.com/publish-a-new-ad.htm");
                // Form1.ActiveForm.Text = "classifiedsciti";
                Website = "classifiedsciti";
               // objalways.show("classifiedsciti");
            }


            else if (cbBoxWebsite.SelectedIndex == 23)
            {
                webBrowser1.Navigate("http://www.classifiedsvalley.com");
                // Form1.ActiveForm.Text = "classifiedsciti";
                Website = "classifiedsvalley";
              //  objalways.show("classifiedsvalley");
            }

            else if (cbBoxWebsite.SelectedIndex == 24)
            {
                webBrowser1.Navigate("http://www.collectorcarads.com/logonCustomer.asp");
                // Form1.ActiveForm.Text = "classifiedsciti";
                Website = "collectorcarads";
              //  objalways.show("collectorcarads");
            }

            //else if (cbBoxWebsite.SelectedIndex == 25)
            //{
            //    webBrowser1.Navigate("http://www.cardaddy.com/sell_my_car/vehicledetails");
            //    // Form1.ActiveForm.Text = "classifiedsciti";
            //    Website = "cardaddy";
            //}



            else if (cbBoxWebsite.SelectedIndex == 25)
            {
                webBrowser1.Navigate("http://a1classiccars.com/?view=selectcity&targetview=post&cityid=-9&lang=en");
                Website = "a1classiccars";
              //  objalways.show("a1classiccars");
            }


           


            else if (cbBoxWebsite.SelectedIndex == 26)
            {
                webBrowser1.Navigate("http://usa.motoseller.com/c/sys.php?a=10&amp;c=a*is*1");
                // Form1.ActiveForm.Text = "classifiedsciti";
                Website = "usa.motoseller.com";
             //   objalways.show("motoseller");
            }


            else if (cbBoxWebsite.SelectedIndex == 27)
            {
                webBrowser1.Navigate("http://www.list2click.com/c-CategorySelect/6/");
                // Form1.ActiveForm.Text = "classifiedsciti";
                Website = "list2click";
             //   objalways.show("list2click");
            }



            else if (cbBoxWebsite.SelectedIndex == 28)
            {
                webBrowser1.Navigate("http://us.boss33.com/?view=selectcity&targetview=post&cityid=0&lang=en");
                // Form1.ActiveForm.Text = "classifiedsciti";
                Website = "us.boss33.com";
              //  objalways.show("us.boss33");
            }


            else if (cbBoxWebsite.SelectedIndex == 29)
            {
                webBrowser1.Navigate("http://www.carsforsale.com/Sell_Car_Free/");
                // Form1.ActiveForm.Text = "classifiedsciti";
                Website = "carsforsale";
              //  objalways.show("carsforsale");
            }

            else if (cbBoxWebsite.SelectedIndex == 30)
            {
                webBrowser1.Navigate("http://www.cathaylist.com/?view=selectcity&targetview=post&cityid=0&lang=en");
                Website = "cathaylist";
              //  objalways.show("cathaylist");
            }

        
            else if (cbBoxWebsite.SelectedIndex == 31)
            {
                webBrowser1.Navigate("http://farmington.backpage.com/");
                Website = "backpage";
             //   objalways.show("backpage");
            }


            else if (cbBoxWebsite.SelectedIndex == 32)
            {
                webBrowser1.Navigate("http://www.adlandpro.com/createad.aspx");
                Website = "adlandpro";
              //  objalways.show("adlandpro");
            }



            else if (cbBoxWebsite.SelectedIndex == 33)
            {
                webBrowser1.Navigate("http://www.freeadsinus.com/us-i-add.html");
                Website = "freeadsinus";
              //  objalways.show("freeadsinus");
            }

            else if (cbBoxWebsite.SelectedIndex == 34)
            {
                webBrowser1.Navigate("http://ww1.highlandclassifieds.com/js/post/c45757");
                Website = "highlandclassifieds";
              //  objalways.show("highlandclassifieds");
            }

            else if (cbBoxWebsite.SelectedIndex == 35)
            {
                webBrowser1.Navigate("http://india.glasyads.com/login");
                Website = "glasyads";
             //   objalways.show("glasyads");
            }

       
            else if (cbBoxWebsite.SelectedIndex == 36)
            {
                webBrowser1.Navigate("http://epage.com/js/post/c0/");
                Website = "epage";
              //  objalways.show("epage");
            }
            else if (cbBoxWebsite.SelectedIndex == 37)
            {
                webBrowser1.Navigate("http://www.kedna.com/place-ads.html");
                Website = "kedna";
              //  objalways.show("kedna");
            }
 
        }

        private void UplaodDetails_Click(object sender, EventArgs e)
        {
             
            string email = comboBox1.Text.ToString();
            if (comboBox1.Text.ToString() == "   -----SELECT-----")
            {
                MessageBox.Show("Please Select Emailid from dropdrow list");
               
            }
            else
            {

                Globaltxtemail.txtemail = email;
                Cursor.Current = Cursors.WaitCursor;

                btnSubmit.Visible = true;
                count++;
               
                //  for (int i = 0; i < 10; i++)
                // {

                com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                obUsedCarsInfo = objService.FindCarID(txtCarID.Text);


                //List<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                //UsedCarsSearch obj = new UsedCarsSearch();
                //obUsedCarsInfo = (List<com.unitedcarexchange.UsedCarsInfo>)obj.FindCarID(txtCarID.Text);

                if (Website == "CarPosts")
                {


                    popform.popform1.BringToFront();

                    IWebSites objClass = new CarPosts();
                    label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                 System.Drawing.FontStyle.Bold);


                    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                    UplaodDetails.Enabled = false;
                    Cursor.Current = Cursors.Default;
                }
                else if (Website == "JustgoodCars")
                {
                    UplaodDetails.Enabled = false;
                    popform.popform2.BringToFront();
                    Cursor.Current = Cursors.WaitCursor;

                    if (count == 3)
                    {


                        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise1.php")
                        {
                            UplaodDetails.Enabled = false;
                        }
                    }

                    if (count == 4)
                    {

                //        label12.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.FontStyle.Bold);
                //        btnSubmit.Enabled = true;
                      UplaodDetails.Enabled = false;
                    }
                    // btnSubmit.Visible = false;


                    // if( webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/members_index.php")


                    //     if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/members_index.php")
                    //     {
                    //         label26.Font = new System.Drawing.Font("Verdana", 8.0f,
                    //System.Drawing.FontStyle.Bold);
                   

                    //     }
                    if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise.php")
                    {
                        label6.Font = new System.Drawing.Font("Verdana", 8.0f,
                System.Drawing.FontStyle.Bold);
                       
                        btnSubmit.Visible = false;


                    }
                    if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise1.php")
                    {
                        label8.Font = new System.Drawing.Font("Verdana", 8.0f,
               System.Drawing.FontStyle.Bold);
                       
                        
                        btnSubmit.Visible = true;
                        // UplaodDetails.Enabled = false;


                    }


                    //MessageBox.Show(buttonCount.ToString());
                    if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/sign-in.php")
                    {

                        label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                   System.Drawing.FontStyle.Bold);
                        
                       
                    }
                    //  if (i == 0)
                    //  {
                    if (count == 1)
                    {
                        IWebSites objClass = new JustgoodCars();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                        webBrowser1.Navigate("http://www.justgoodcars.com/members/advertise.php");
                    }
                    //}
                    // if (i == 1)
                    // {
                    if (count == 1)
                    {
                        webBrowser1.Navigate("http://www.justgoodcars.com/members/advertise.php");
                        btnSubmit.Visible = false;
                        UplaodDetails.Enabled = true;
                    }
                    // }
                    // if (i == 2)
                    // {
                    if (count == 2)
                    {
                        IWebSites objClass = new JustgoodCars();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                        UplaodDetails.Enabled = true;
                    }
                    // }
                    //  if (i == 3)
                    //  {
                    if (count == 3)
                    {

                        IWebSites objClass = new JustgoodCars();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                    }
                    //}
                    // if (i == 4)
                    // {
                    if (count == 4)
                    {
                        IWebSites objClass = new JustgoodCars();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                    }
                    // }


                    // if (i == 5)
                    //  {
                    if (count == 5)
                    {
                        IWebSites objClass = new JustgoodCars();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                    }
                    //  }

                    // if (i == 6)
                    // {
                    if (count == 6)
                    {
                        IWebSites objClass = new JustgoodCars();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                    }
                    //}

                    // if (i == 7)
                    // {
                    if (count == 7)
                    {
                        IWebSites objClass = new JustgoodCars();
                        objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                    }
                    // }
                    Cursor.Current = Cursors.Default;
                }
                //else if (Website == "classifiedsforfree")
                //{
                //    IWebSites objClass = new ClassifiedsForFree();


                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);


                //}
                else if (Website == "clazorg")
                {
                    popform.popform4.BringToFront();

                    Cursor.Current = Cursors.WaitCursor;

                    IWebSites objClass = new ClazOrg();
                    if (webBrowser1.Url.ToString() == "http://claz.org/classifieds/post")
                    {
                        label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                   System.Drawing.FontStyle.Bold);
                        btnSubmit.Visible = true;
                        UplaodDetails.Enabled = false;

                    }


                    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                    Cursor.Current = Cursors.Default;

                }
                //else if (Website == "americanclassifieds")
                //{
                //    IWebSites objClass = new AmericanClassifieds();


                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}

                //else if (Website == "postfreeadshere")
                //{
                //    IWebSites objClass = new PostFreeAdshere();


                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                else if (Website == "Usadsciti")
                {
                    popform.popform5.BringToFront();

                    Cursor.Current = Cursors.WaitCursor;

                    //  if (i == 0)
                    //  {
                    IWebSites objClass = new Usadsciti();

                    label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                  System.Drawing.FontStyle.Bold);


                    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                    btnSubmit.Visible = true;
                    Cursor.Current = Cursors.Default;
                    UplaodDetails.Enabled = false;
                    // }

                }
                else if (Website == "UsNetads")
                {
                    popform.popform3.BringToFront();
                    Cursor.Current = Cursors.WaitCursor;


                    //  if (i == 0)
                    // {
                    IWebSites objClass = new UsnetAds();

                    label31.Font = new System.Drawing.Font("Verdana", 8.0f,
                  System.Drawing.FontStyle.Bold);



                    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                    btnSubmit.Visible = true;
                    btnSubmit.Enabled = true;
                    UplaodDetails.Enabled = false;
                    Cursor.Current = Cursors.Default;
                    // }

                }

                //else if (Website == "FreeAutoShopper")
                //{

                //    IWebSites objClass = new FreeAutoShopper();


                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "Locate Any Auto")
                //{
                //    IWebSites objClass = new LocateAnyAuto();


                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "FreeAddList")
                //{
                //    IWebSites objClass = new FreeAddList();


                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}

                //else if (Website == "autoii")
                //{
                //    IWebSites objClass = new Autoii();


                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "ebayclassifieds")
                //{
                //    IWebSites objClass = new ebayclassifieds();


                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "biggestclassifieds")
                //{
                //    IWebSites objClass = new biggestclassifieds();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "ClassifiedAds")
                //{
                //    IWebSites objClass = new ClassifiedAdds();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "Locanto")
                //{
                //    IWebSites objClass = new Locanto();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}

                //else if (Website == "75vn")
                //{
                //    IWebSites objClass = new Vn75();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}


                //else if (Website == "adoos")
                //{
                //    IWebSites objClass = new adoos();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}

                //else if (Website == "fastautosale")
                //{
                //    IWebSites objClass = new fastautosales();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "Sell.com")
                //{
                //    IWebSites objClass = new Sell();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}
                //else if (Website == "Sellmycar")
                //{
                //    IWebSites objClass = new Sellmycar();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}

                //else if (Website == "recycler")
                //{
                //    IWebSites objClass = new Recycler();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "classifiedsciti")
                //{
                //    IWebSites objClass = new classifiedsciti();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}

                //else if (Website == "classifiedsvalley")
                //{
                //    IWebSites objClass = new classifiedsvalley();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}

                //else if (Website == "collectorcarads")
                //{
                //    IWebSites objClass = new collectorcarads();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}

                ////else if (Website == "cardaddy")
                ////{
                ////    IWebSites objClass = new cardaddy();
                ////    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                ////}
                //else if (Website == "a1classiccars")
                //{
                //    IWebSites objClass = new a1classiccars();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}



                //else if (Website == "usa.motoseller.com")
                //{
                //    IWebSites objClass = new Motoseller();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "list2click")
                //{
                //    IWebSites objClass = new list2click();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "us.boss33.com")
                //{
                //    IWebSites objClass = new Boss33();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "carsforsale")
                //{
                //    IWebSites objClass = new carsforsale();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "cathaylist")
                //{
                //    IWebSites objClass = new cathaylist();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}



                //else if (Website == "backpage")
                //{
                //    IWebSites objClass = new backpage();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}

                //else if (Website == "adlandpro")
                //{
                //    IWebSites objClass = new adlandpro();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}

                //else if (Website == "highlandclassifieds")
                //{
                //    IWebSites objClass = new highlandclassifieds();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}
                //else if (Website == "glasyads")
                //{
                //    IWebSites objClass = new glasyads();
                //    objClass.carpostfunc(webBrowser1, obUsedCarsInfo);

                //}
                //else if (Website == "epage")
                //{
                //   IWebSites objepage = new epage();
                //   objepage.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}
                //else if (Website == "kedna")
                //{
                //    IWebSites objkedna = new kedna();
                //    objkedna.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}
                //else if (Website == "freeadsinus")
                //{
                //    IWebSites objkedna = new freeadsinus();
                //    objkedna.carpostfunc(webBrowser1, obUsedCarsInfo);
                //}


                // }
            }
        
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            //frminitlize();
            btncnt++;

            btnlive.Visible = true;
            btnlive.Enabled = false;
            if (Website == "CarPosts")
            {
                Cursor.Current = Cursors.WaitCursor;
              

                popform.popform1.BringToFront();
                GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Save");//Carposts Submit


                //if (webBrowser1.Url.ToString() == "http://www.carposts.com/AutoEdit.php")
                //{


                //    label6.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.FontStyle.Bold);
                //    btnlive.Enabled = true;
                //}
              
                objsubdetailsinfo.Webname  = "CarPosts";
                objsubdetailsinfo.SubmittedBy  = label31.Text;
                objsubdetailsinfo.CarId = txtCarID.Text;

               

               // objSubmitionDetailsBL.SaveSubmitionDetails(objsubdetailsinfo);

                Cursor.Current = Cursors.Default;
              
               
                
            }
            if (Website == "JustgoodCars")
            {


                btnSubmit.Enabled = false;

                if (btncnt == 7)
                {
                  
                    btnSubmit.Enabled = false;
                    GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "View / Edit");
                    label25.Font = new System.Drawing.Font("Verdana", 8.0f,
              System.Drawing.FontStyle.Bold);
                    btnlive.Enabled = true;
                }
                if (btncnt == 6)
                {
                   // btnlive.Visible = true;
                    GeneralFunction.ButtonClickInvokeValue(webBrowser1, "FREE >");//SubmitButton for GoLive justgoodcars

                    label24.Font = new System.Drawing.Font("Verdana", 8.0f,
              System.Drawing.FontStyle.Bold);
                   
                    objsubdetailsinfo.Webname = "JustgoodCars";
                    objsubdetailsinfo.SubmittedBy = label31.Text;
                    objsubdetailsinfo.CarId = txtCarID.Text;
                    btnSubmit.Enabled = true;
                   // btnSubmit.Enabled = false;
                   // btnlive.Enabled = true;

                    //objSubmitionDetailsBL.SaveSubmitionDetails(objsubdetailsinfo);

                    


                        webBrowser1.Navigate("http://www.justgoodcars.com/members/members_index.php");

                   //}
                    
                        webBrowser1.Navigate("http://www.justgoodcars.com/members/adverts.php");
                    
                    
                }
           //     if (btncnt == 8)
           //     {
           //         //GeneralFunction.ButtonClickInvokeValueJustgoods(webBrowser1, "View / Edit");
           //         GeneralFunction.geturl(webBrowser1);
           //         btnlive.Visible = true;
           //         lbinfrm5.Font = new System.Drawing.Font("Verdana", 8.0f,
           //System.Drawing.FontStyle.Bold);
           //         btnlive.Enabled = true;
           //        // btnSubmit.Enabled = false;
           //     }

                //if (btncnt == 8)
                //{
                //    if (cbBoxWebsite.Text == "JustgoodCars")
                //    {
                //        if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/members_index.php")
                //        {
                //            GeneralFunction.HfClickInvoke(webBrowser1, "/images/btn-logout.gif");
                //        }
                //    }
                //}
                if (btncnt == 2)
                {
                    if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/adverts_edit_image-upload.php")
                    {

                        GeneralFunction.LinkInvoke(webBrowser1, "Try this Simple Upload Tool");
                        label13.Font = new System.Drawing.Font("Verdana", 8.0f,
             System.Drawing.FontStyle.Bold);
                        btnSubmit.Enabled = true;
                    }
                }
                if (btncnt == 4)
                {

                    GeneralFunction.Submit(webBrowser1, "Submit");
                    label16.Font = new System.Drawing.Font("Verdana", 8.0f,
             System.Drawing.FontStyle.Bold);
                    btnSubmit.Enabled = true;
                }
                if (btncnt == 5)
                {
                    GeneralFunction.ButtonClickInvokeValue(webBrowser1, "< Back");
                    label23.Font = new System.Drawing.Font("Verdana", 8.0f,
             System.Drawing.FontStyle.Bold);
                    btnSubmit.Enabled = true;
                }
                if (btncnt == 3)
                {
                    GeneralFunction.FileUploadInvoke(webBrowser1, "userfile");
                    label15.Font = new System.Drawing.Font("Verdana", 8.0f,
             System.Drawing.FontStyle.Bold);
                    btnSubmit.Enabled = true;
                }

                if (btncnt == 1)
                {

                    if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise1.php")
                    {
                        GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");//submit details
                        UplaodDetails.Enabled = true;
                        btnSubmit.Enabled = false;
                        label10.Font = new System.Drawing.Font("Verdana", 8.0f,
              System.Drawing.FontStyle.Bold);


                    }
                }
            }
      //      GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Post the Above Ad");//ClassifiedForfree Submit
      //      GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Post to Classifieds");//ClazOrg
      //   // GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Post to Classifieds");//Jeanza post classified
      //      GeneralFunction.ButtonClickInvoke(webBrowser1, "submitted");//americanclassifeds
      //  //  Post It For Free Now!
      //     // GeneralFunction.ButtonClickInvokeValue(webBrowser1, "POST IT FOR FREE NOW");
     
     
      //// GeneralFunction .ButtonClickInvokeValue(webBrowser1 ,"Save Ad");//kugli
      //      // GeneralFunction.LinkInvoke(webBrowser1, "POST FREE AD");//freeadd.net
      //  GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Post It For Free Now!");//usadciti
            if (Website == "UsNetads")
            {
                Cursor.Current = Cursors.WaitCursor;

                popform.popform3.BringToFront();
                if (webBrowser1.Url.ToString() == "http://www.usnetads.com/post/post-free-ads.php")
                {
                    GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Submit");//usnetads

                //    label8.Font = new System.Drawing.Font("Verdana", 8.0f,
                //System.Drawing.FontStyle.Bold);
                //    btnlive.Enabled = true;
                   
                    objsubdetailsinfo.Webname = "UsNetads";
                    objsubdetailsinfo.SubmittedBy = label31.Text;
                    objsubdetailsinfo.CarId = txtCarID.Text;
                  
                    Cursor.Current = Cursors.Default;

                    //objSubmitionDetailsBL.SaveSubmitionDetails(objsubdetailsinfo);
                }
            }

              if (Website == "Usadsciti")
            {
                Cursor.Current = Cursors.WaitCursor;
                popform.popform5.BringToFront();
       GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Post It For Free Now!");//usadciti

       if (webBrowser1.Url.ToString() == "http://www.usadsciti.com/publish-a-new-ad.htm")
       {

       //    label10.Font = new System.Drawing.Font("Verdana", 8.0f,
       //System.Drawing.FontStyle.Bold);
       //    btnlive.Enabled = true;

           objsubdetailsinfo.Webname = "Usadsciti";
           objsubdetailsinfo.SubmittedBy = label31.Text;
           objsubdetailsinfo.CarId = txtCarID.Text;
          // btnlive.Enabled = true;
           Cursor.Current = Cursors.Default;

          // objSubmitionDetailsBL.SaveSubmitionDetails(objsubdetailsinfo);
       }
            }




             if (Website == "clazorg")
            {
                Cursor.Current = Cursors.WaitCursor;
                popform.popform4.BringToFront();

                GeneralFunction.ButtonClickByValue(webBrowser1, "Post to Classifieds");//epage
               // label8.Font = new System.Drawing.Font("Verdana", 8.0f,
               //System.Drawing.FontStyle.Bold);
               // btnlive.Visible = true;
               // btnlive.Enabled = true;

                objsubdetailsinfo.Webname = "clazorg";
                objsubdetailsinfo.SubmittedBy = label31.Text;
                objsubdetailsinfo.CarId = txtCarID.Text;
                
                Cursor.Current = Cursors.Default;
                
               // objSubmitionDetailsBL.SaveSubmitionDetails(objsubdetailsinfo);
            }





      //  GeneralFunction.ButtonClickByName(webBrowser1, "post_submit");//freeautoshopper
      //  GeneralFunction.ImgeButtonClickInvoke(webBrowser1, "Post Ad");

      //    GeneralFunction.ButtonClickInvoke(webBrowser1, "post-btn-bottom");
      //    GeneralFunction .ButtonClickInvokeInnerText (webBrowser1 ,"Post Now");//biggestclassifies

      //     GeneralFunction.ButtonClickInvoke(webBrowser1, "Post your ad »");//locanto
      //     GeneralFunction.ButtonClickInvoke(webBrowser1, "btn_Add");//75VN

      //     GeneralFunction.ButtonClickByValue(webBrowser1, "Post Ad!"); //adoos
      //     GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Submit");//sellmycar
      //     GeneralFunction.ButtonClickByValue(webBrowser1, "Yes");//epage

      //     GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Submit");
      //     GeneralFunction.ImgeButtonClickInvoke(webBrowser1, "Post Ad");
      //     GeneralFunction.ButtonClickBody(webBrowser1, "submit");//ClassifiedValley
      //     GeneralFunction.ButtonClick(webBrowser1, "Submit");//carcollectorads
      //     GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Complete Transaction");//usa.motosellercars.com
      //     GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Preview / Post Your AD");//list2click.com
      //     GeneralFunction.ButtonClickInvoke(webBrowser1, "ctl00$phMainContent$btnContinue");//CarsforSale
      //     GeneralFunction.ButtonClick(webBrowser1, "submit");//cathylist.com
      //     GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Submit and preview");//freeadnius.com
      //     GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Yes");//ww1.highlandclassifieds.com


      
        }

        private void btnlive_Click(object sender, EventArgs e)
        {
            

          //  frminitlize();

            linkItem = "";
            if (Website == "CarPosts")
            {
                popform.popform1.BringToFront();
                websiteId = 1;
            }
            else if (Website == "UsNetads")
            {
                popform.popform3.BringToFront();
                websiteId = 7;
            }
            else if (Website == "JustgoodCars")
            {
                popform.popform2.BringToFront();
                websiteId = 4;
            }
            else if (Website == "clazorg")
            {
                popform.popform4.BringToFront();
                websiteId = 16;
            }
            else if (Website == "Usadsciti")
            {
                popform.popform5.BringToFront();
                websiteId = 48;
            }

         
       
         
            if (Website == "CarPosts")
            {
                btnlive.Enabled = false;
                int i = 0;
              
                foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                {
                    i++;
                    if (i == 5)
                    {
                        string tabItem = htmlElement.InnerText;
                        linkItem = htmlElement.GetAttribute("HREF").ToString();
                        label8.Font = new System.Drawing.Font("Verdana", 8.0f,
     System.Drawing.FontStyle.Bold);

                    }
                }
            }
            if (Website == "UsNetads")
            {
                btnlive.Enabled = false;
                int i = 0;
              
                foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                {
                    i++;
                    if (i == 7)
                    {
                        string tabItem = htmlElement.InnerText;
                        linkItem = htmlElement.GetAttribute("HREF").ToString();
                        label10.Font = new System.Drawing.Font("Verdana", 8.0f,
            System.Drawing.FontStyle.Bold);
                    }
                    
                }

            }
            if (Website == "JustgoodCars")
            {
                btnlive.Enabled = true;
                int i = 0;
                GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "View / Edit");
                foreach (HtmlElement htmlElement in webBrowser1.Document.Links)
                {
                    i++;
                    if (i == 8)
                    {

                        string tabItem = htmlElement.InnerText;
                        linkItem = htmlElement.GetAttribute("HREF").ToString();
                        label26.Font = new System.Drawing.Font("Verdana", 8.0f,
             System.Drawing.FontStyle.Bold);

                        webBrowser1.Navigate("http://www.justgoodcars.com/members/members_index.php");

                        //webBrowser1.Navigate("http://www.justgoodcars.com/");

                    }
                    btnSubmit.Enabled = true;
                }
                //if (cbBoxWebsite.Text == "JustgoodCars")
                //{
                //    if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/members_index.php")
                //    {
                //        GeneralFunction.Linkhref(webBrowser1, "/members/logout2.php");
                //    }
                //}
               

            }
            if (Website == "clazorg")
            {
                btnlive.Enabled = false;
                label10.Font = new System.Drawing.Font("Verdana", 8.0f,
    System.Drawing.FontStyle.Bold);
            }
            if (Website == "Usadsciti")
            {
                btnlive.Enabled = false;
                label12.Font = new System.Drawing.Font("Verdana", 8.0f,
    System.Drawing.FontStyle.Regular);

            }
            
             int carid=Convert .ToInt32 (txtCarID .Text );

             subby = GlobalLogId.globallogidVar;

             if (linkItem != "")
             {
                 string SubStatus = "Completed";
                 string QcStaus = "Pending";
                 //@CarID int,@URL varchar(500),@SiteID int,@PostedBy int
                 objSubmitionDetailsBL.MultiSaveSubmitionDetails(carid, linkItem, websiteId, subby, SubStatus, QcStaus);
                 MessageBox.Show("Uploaded to Live successfully");
                 btnlive.Visible = false;


             }
             else
             {
                 //LiveButtonUrl.Click += new System.EventHandler(LiveButtonUrl_click);
                 //LiveButtonLater.Click += new System.EventHandler(LiveButtonLater_click);

       

                 //LiveFormUrl.Text = "To Enter Live Url";
                 //LiveFormUrl.Width = 300;
                 //LiveFormUrl.Height = 300;
                 //Label lblliveurl = new Label();
                 //LiveFormUrl.Controls.Add(LiveTextBoxUrl);
                 //LiveFormUrl.Controls.Add(LiveButtonUrl);
                 //LiveFormUrl.Controls.Add(lblliveurl);
                 //lblliveurl.Location = new System.Drawing.Point(10, 65);
                 //LiveTextBoxUrl.Location = new System.Drawing.Point(95, 64);
                 //LiveTextBoxUrl.Width = 150;
                 //lblliveurl.Text = "Enter Live URL: ";




                 //LiveButtonUrl.Location = new System.Drawing.Point(95, 94);
                 //LiveButtonUrl.Width = 75;
                 //LiveButtonUrl.Text = "Submit";
                 //LiveFormUrl.Show();

                 //Form LiveFormUrl = new Form();
                 LiveFormUrl.ControlBox = false;
                 LiveFormUrl.MdiParent = this.MdiParent;

                 LiveButtonUrl.Click += new System.EventHandler(LiveButtonUrl_click);
                 LiveButtonLater.Click += new System.EventHandler(LiveButtonLater_click);



                 LiveFormUrl.Text = "To Enter Live Url";
                 LiveFormUrl.Width = 300;
                 LiveFormUrl.Height = 300;
                 Label lblliveurl = new Label();
                 LiveFormUrl.Controls.Add(LiveTextBoxUrl);
                 LiveFormUrl.Controls.Add(LiveButtonUrl);
                 LiveFormUrl.Controls.Add(LiveButtonLater);
                 LiveFormUrl.Controls.Add(lblliveurl);
                 lblliveurl.Location = new System.Drawing.Point(10, 65);
                 LiveTextBoxUrl.Location = new System.Drawing.Point(95, 64);
                 LiveTextBoxUrl.Width = 150;
                 lblliveurl.Text = "Enter Live URL: ";




                 LiveButtonUrl.Location = new System.Drawing.Point(95, 94);
                 LiveButtonUrl.Width = 75;
                 LiveButtonUrl.Text = "Submit";
                 LiveFormUrl.Show();

                 LiveButtonLater.Location = new System.Drawing.Point(175, 94);
                 LiveButtonLater.Width = 75;
                 LiveButtonLater.Text = "TryLater";
                 LiveFormUrl.Show();
              
                

             }

             carid = Convert.ToInt32(txtCarID.Text);
             DataSet dss = new DataSet();
             dss = objSubmitionDetailsBL.GetSubmitionDetailsByCarId(carid);

             if (dss.Tables[0].Rows.Count == 0)
             {
                // dtgridSubDet.Visible = false;
                 lblsubdetails.Visible = false;
             }
             else
             {
               //  dtgridSubDet.Visible = true;

               //  dtgridSubDet.AutoGenerateColumns = true;
                 //dtgridSubDet.DataSource = dss.Tables[0];
                // lblsubdetails.Text = "Car Id " + txtCarID.Text + " Submitted Details :";
             }
               
           
        
        }

        private void btnGetAllPics_Click(object sender, EventArgs e)
        {
             

           
            //btnForward.Visible = true;
           // btnback.Visible = true;
            if (imgcount > 3)
            {
                btnforward.Visible = true;
                btnback.Visible = true;
                lblimages.Text = imgcount.ToString() + "  Images downloaded ";
            }

            try
            {
                com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


                IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                obUsedCarsInfo = objService.FindCarID(txtCarID.Text);

                //List<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
                //UsedCarsSearch obj = new UsedCarsSearch();
                //obUsedCarsInfo = (List<com.unitedcarexchange.UsedCarsInfo>)obj.FindCarID(txtCarID.Text);

                Cursor.Current = Cursors.WaitCursor;
                lblpics.Visible = false;
              
          
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
               // @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpeg";

                for (int i = 4; i <= 20; i++)
                {
                    string filePath=  @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +  i + "" + ".jpeg";
                    int fileSize = (int)new System.IO.FileInfo(filePath).Length;
                    if (fileSize != 0)
                    {
                        imgcount++;
                    }
                
                }
                //------------------

            }
            catch (Exception ex)
            {
                MessageBox.Show("All Images downloaded successfully");

            }
            btnGetAllPics.Visible = false;
            lblimages.Visible = true;
             lblimages.Text = imgcount.ToString() +"  Images downloaded ";

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
            obUsedCarsInfo = objService.FindCarID(txtCarID.Text);


            //if (Convert.ToInt32(cnt) > 2)
            //{
               
            //    btnback.Enabled = true;



            //    string ex = label19.Text;

            //    char[] sepem = { '-' };
            //    string[] msplit = ex.Split(sepem);
            //    cnt = msplit[1].ToString();
            //    cnt = cnt.Replace(".jpeg", " ");
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

            //        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpeg";

            //        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpeg";

            //        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpeg";
            //        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpeg";

            //        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpeg";
            //        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpeg";

            //    }



            //    if (cnt == "4 ")
            //    {
            //        btnback.Enabled = false;
            //        btnForward.Enabled = true;
            //        //CreateImageURLPath(Pics.GetPic0(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + c + "", obUsedCarsInfo[0].Carid.ToString());
            //        //CreateImageURLPath(Pics.GetPic1(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + d + "", obUsedCarsInfo[0].Carid.ToString());
            //        //CreateImageURLPath(Pics.GetPic3(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + b + "", obUsedCarsInfo[0].Carid.ToString());

            //        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpeg";

            //        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpeg";

            //        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpeg";
            //        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpeg";

            //        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpeg";
            //        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpeg";

            //    }



            //}
            //----------------------

            string ex = label21.Text;

            char[] sepem = { '-' };
            string[] msplit = ex.Split(sepem);
            cnt = msplit[1].ToString();
            cnt = cnt.Replace(".jpeg", "");
            cnt = cnt.Replace(".jpg", "");

            int cntt = Convert.ToInt32(cnt);


            switch (imgcount)
            {
                case 1:
                 
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = "";
                    label21.Text = "";


                    break;
                case 2:
                   
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = "";

                    break;
                case 3:
                 
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";



                    break;
                case 4:
                  
                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";

                    if (cnt == "4") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    }
                     if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                       
                    }




                    break;

                case 5:

                
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";

                    if (cnt == "5") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    }
                    if (cnt == "3")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                      
                    }


                    break;
                case 6:


                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    if (cnt == "6")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    }
                    if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                      
                    }
                    break;
                case 7:

                   
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";

                    if (cnt == "7") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                     if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    }
                     if (cnt == "3")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                      
                    }


                    break;
                case 8:
                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";

                    if (cnt == "8") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                     if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    }
                      if (cnt == "3")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                      
                    }



                    break;

                case 9:
                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                    if (cnt == "9")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                      if (cnt == "6")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    }
                      if (cnt == "3")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                      
                    }




                    break;
                case 10:
                   
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";

                    if (cnt == "10")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                    }
                    if (cnt == "9")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6+ "" + ".jpeg";
                    }
                    if (cnt == "6")  //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    }
                     if (cnt == "3")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                     
                    }




                    break;
                case 11:
                   
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";

                  //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg")
                    if(cnt=="11")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8+ "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                    }
                    // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    if(cnt=="9")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                    }
                    // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    if(cnt=="6")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    }
                    // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +3 + "" + ".jpeg")
                    if(cnt=="3")
                    {
                      
                    }


                    break;
                case 12:
                   
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +11 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                    if (cnt == "12") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                    }
                    if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                    }
                     if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                    }
                     if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                      
                    }



                    break;

                case 13:
                
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";

                    if (cnt == "13")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                    }
                     if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                     if (cnt == "9")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                    }
                     if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    }
                     if (cnt == "12")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                      
                    }



                    break;
                case 14:
                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";

                    if (cnt == "14")// if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                    }
                      if (cnt == "12")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                     if (cnt == "9")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                    }
                     if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                     
                    }

                    break;
                case 15:


                 
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    if (cnt == "15") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                    }
                     if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                     if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                    }
                     if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    }
                     if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                       
                    }

                    break;
                case 16:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";

                    if (cnt == "16") // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    }
                    if (cnt == "15")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                    if (cnt == "12") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                    if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                     if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";


                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                      
                    }

                    break;
                case 17:


                   
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +16 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17+ "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";

                    if (cnt == "17") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    }
                      if (cnt == "15")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                     if (cnt == "12")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +9 + "" + ".jpeg";
                    }
                     if (cnt == "9")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                     if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";


                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                       
                    }

                    break;
                case 18:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +17 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";

                    if (cnt == "18") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    }
                     if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12+ "" + ".jpeg";
                    }
                    if (cnt == "12") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                     if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                     if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";


                    }
                     if (cnt == "3") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                       
                    }

                    break;

                case 19:

                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18+ "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpeg";

                    if (cnt == "19") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +18 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";


                    }
                     if (cnt == "18") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18+ "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                    }
                     if (cnt == "15")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                    if (cnt == "12") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                    }
                     if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";


                    }
                     if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";


                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                     
                    }

                    break;
                case 20:


                 
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +19 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +19 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +20 + "" + ".jpeg";

                    if (cnt == "20") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";

                    }
                    if (cnt == "18") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                    }
                      if (cnt == "15")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                      if (cnt == "12")  //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                    }
                    if (cnt == "9")  //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" +6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";


                    }
                     if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";


                    }
                    if (cnt == "3") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                     
                    }
                    break;
            }

            //-----------------------
        

        }

        private void btnforward_Click(object sender, EventArgs e)
        {
              
        
            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();


            IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
            obUsedCarsInfo = objService.FindCarID(txtCarID.Text);

         

            //btnback.Enabled = true;
            //btnForward.Enabled = true;
            //string ex = label21.Text;

            //char[] sepem = { '-' };
            //string[] msplit = ex.Split(sepem);
            //cnt = msplit[1].ToString();
            //cnt = cnt.Replace(".jpeg", " ");
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

            //    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpeg";

            //    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpeg";

            //    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpeg";
            //    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpeg";

            //    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpeg";
            //    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpeg";

            //}



            //if (cnt == "6 ")
            //{

            //    //CreateImageURLPath(Pics.GetPic6(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + c + "", obUsedCarsInfo[0].Carid.ToString());
            //    //CreateImageURLPath(Pics.GetPic7(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + d + "", obUsedCarsInfo[0].Carid.ToString());
            //    //CreateImageURLPath(Pics.GetPic8(obUsedCarsInfo), obUsedCarsInfo[0].Carid.ToString() + "-" + b + "", obUsedCarsInfo[0].Carid.ToString());

            //    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpeg";

            //    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + c + "" + ".jpeg";

            //    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpeg";
            //    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + d + "" + ".jpeg";

            //    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpeg";
            //    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + b + "" + ".jpeg";

            //}


            //   //int picshowcount = imgcount - 1;
            //   //if (picshowcount > 9)

            //   //{ 


            //   //}


            
        

            //   //    List<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
            //   //    UsedCarsSearch obj = new UsedCarsSearch();
            //   //    obUsedCarsInfo = (List<com.unitedcarexchange.UsedCarsInfo>)obj.FindCarID(txtCarID.Text);

           

            //   // //pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-4" + ".jpeg";

            //   // //label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-4" + ".jpeg";

            //   // //pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-5" + ".jpeg";
            //   // //label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() +"-5"+ ".jpeg";

            //   // //pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() +"-6"+ ".jpeg";
            //   // //label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() +"-6"+ ".jpeg";
       //   ----------------------


            string ex = label21.Text;

            char[] sepem = { '-' };
            string[] msplit = ex.Split(sepem);
            cnt = msplit[1].ToString();
            cnt = cnt.Replace(".jpeg", "");
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
                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = "";
                    label21.Text = "";


                    break;
                case 2:
                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = "";

                    break;
                case 3:
                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";



                    break;
                case 4:

                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                   //   if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    if (cnt == "3")  
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";

                    }
                  //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg")
                    if (cnt == "4") 
                    {
                    
                    }

                 


                    break;

                case 5:

                    
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                  //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    if (cnt == "3") 
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";

                    }
                  //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg")
                    if (cnt == "5") 
                    {
                      
                    }


                    break;
                case 6:


               
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                  //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    if (cnt == "3") 
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                  //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    if (cnt == "6") 
                    {
                      
                    }
                    break;
                case 7:

                 
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                    if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                     }
                  if (cnt == "7")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg")
                    {
                       
                    }
                 

                    break;
                case 8:
                   
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                   if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                    }
                   if (cnt == "8") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg")
                    {
                     
                    }
                 


                    break;

                case 9:
                   
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                   if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                  if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                      
                    }
                 



                    break;
                case 10:
                 
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3")  //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                    if (cnt == "6")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                  if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                         pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                    }
                  if (cnt == "10")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg")
                    {
                      
                    }
            



                    break;
                case 11:
                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                   // if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    if (cnt == "3") 
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                        break;

                       
                    }
                  //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    if (cnt == "6")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                        break;
                    }
                 //  if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                       if (cnt == "9")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                      
                        break;
                    }
                 //   if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg")
                       if (cnt == "11")
                    {
                       
                        break;
                    }
                    break;
                  
                  
                case 12:
                
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                         break;
                    }
                   if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                        break;
                    }
                   if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                        break;
                    }
                   if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        break;
                    }
            


                    break;

                case 13:
                 
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                        break;

                    }
                    if (cnt == "6") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                        break;
                    }
                   if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                        break;
                    }
                    if (cnt == "12") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        break;
                       
                    }
                   if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        break; 
                    }
            


                    break;
                case 14:
                 
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";



                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";
                        break;

                    }
                   if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                    }
                   if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                   if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";

                    }
                   if (cnt == "14") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg")
                    {
                      
                    }

                    break;
                case 15:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                   if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                  if (cnt == "9") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                   if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    }
                   if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                     
                    }

                    break;
                case 16:


                
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                  if (cnt == "6") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                   if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                   if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    }
                   if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";

                    
                    }
                   if (cnt == "16") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg")
                    {
                      
                    }

                    break;
                case 17:


               
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                   if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                   if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                  if (cnt == "12") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    }
                 if (cnt == "15") //   else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";


                    }
                 if (cnt == "17")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg")
                    {
                       
                    }

                    break;
                case 18:


                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                  if (cnt == "6") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                   if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                   if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    }
                   if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";


                    }
                    if (cnt == "18") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg")
                    {
                        
                    }

                    break;

                case 19:

                  
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";


                    }
                  if (cnt == "6") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                    if (cnt == "9") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                   if (cnt == "12") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    }
                   if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";


                    }
                   if (cnt == "18")  // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpeg";

                      
                    }
                    if (cnt == "19") //else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpeg")
                    {
                       
                    }
                  
                    break;
                case 20:


               
                    pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 1 + "" + ".jpeg";
                    label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 2 + "" + ".jpeg";
                    label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg";

                    if (cnt == "3") //if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 3 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 4 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 5 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg";

                    }
                   if (cnt == "6") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 6 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 7 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 8 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg";
                    }
                   if (cnt == "9") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 9 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 10+ "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 11 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg";
                    }
                  if (cnt == "12")  //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 12 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 13 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 14 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg";

                    }
                   if (cnt == "15") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 15 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 16 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 17 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";


                    }
                  if (cnt == "18") //  else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg")
                    {
                        pictureBox1.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";
                        pictureBox2.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpeg";
                        pictureBox3.ImageLocation = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpeg";

                        label19.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 18 + "" + ".jpeg";
                        label20.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 19 + "" + ".jpeg";
                        label21.Text = @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpeg";


                    }
                   if (cnt == "20") // else if (pictureBox3.ImageLocation == @"C:\UcePictures\" + obUsedCarsInfo[0].Carid.ToString() + "\\" + obUsedCarsInfo[0].Carid.ToString() + "-" + 20 + "" + ".jpeg")
                    {
                       
                    }
                    break;
            }

      //---------------------------


          
            

        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // timercount++;

            // timercount = timercount % 500;
            //if (timercount ==0)
            // {

            //     if (MessageBox.Show("Do you want to continue ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //     {

            //         timeryes = "ok";


            //     }
            //     else
            //     {
            //         Application.Exit();
            //     }
            // }

            //if (timeryes != "ok" && timercount == 0)
            //{
            //    Application.Exit();

            //}
            //---------------------------------

            timercount++;
            // 1000 X 15
            int timercount0 = timercount % 120000; // 1/2 min

            if (timercount0 == 0)
            {
                timeryes = "";


                timerform.Text = "Do u want to Continue";
                Button timerbutton = new Button();
                timerbutton.Location = new System.Drawing.Point(20, 40);
                Label timerlbl = new Label();
                //string time= timercount--.ToString();
                timerlbl.Text = "10 Sec more to close";
                //timerlbl.Text = time;
                timerlbl.Location = new System.Drawing.Point(20, 70);
                timerform.Controls.Add(timerbutton);
                timerform.Controls.Add(timerlbl);
                timerform.Height = 200;
                timerform.Width = 200;
                // timerform.
                timerbutton.Click += new System.EventHandler(timerbutton_click);
                timerbutton.Text = "Continue... ";
                timerform.Show();
                timerform.Width = 250;

                timer2.Start();


            }



        }


        protected void timerbutton_click(object sender, EventArgs e)
        {
            timeryes = "ok";
            timer2.Stop();
            timerform.Hide();

        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            timer2count++;
            int r = countdes--;
            int rr = r % 66;
            if (rr <= 10)
            {
                rp++;
                int y = rp % 11;
                if (y <= 17)
                {
                    int z = y++;
                    // label5.Text = z.ToString();
                }
            }


            if (timer2count == 1000 && timeryes != "ok")
            {
                Application.Exit();
            }

            //else
            //{
            //    timer2.Stop();
            //    timerform.Hide();

            //}

        }


        public string GetStateName(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo, string stateid, string carid)
        {

            string state = string.Empty;

            if (obUsedCarsInfo[0].State.ToString() == "PA")
            {
                state = "Pennsylvania";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "TX")
            {
                state = "Texas";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NJ")
            {
                state = "New Jersey";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "AL")
            {
                state = "Alabama";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "AK")
            {
                state = "Alaska";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "AS")
            {
                state = "American Samoa";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "AZ")
            {
                state = "Arizona";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "Ar")
            {
                state = "Arkansas";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "CA")
            {
                state = "California";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "CO")
            {
                state = "Colorado";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "CT")
            {
                state = "Connecticut";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "DE")
            {
                state = "Delaware";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "DC")
            {
                state = "District of Columbia";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "FL")
            {
                state = "Florida";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "GA")
            {
                state = "Georgia";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "GU")
            {
                state = "Guam";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "HI")
            {
                state = "Hawaii";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "IL")
            {
                state = "Illinois";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "IN")
            {
                state = "Indiana";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "IA")
            {
                state = "Iowa";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "KS")
            {
                state = "Kansas";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "KY")
            {
                state = "Kentucky";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "LA")
            {
                state = "Lousiana";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "ME")
            {
                state = "Maine";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MI")
            {
                state = "Machigan";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MN")
            {
                state = "Mannesote";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MS")
            {
                state = "Mississippi";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NJ")
            {
                state = "New Jersey";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MO")
            {
                state = "Missouri";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MT")
            {
                state = "Montana";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NE")
            {
                state = "Nebraska";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NV")
            {
                state = "Nevada";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NH")
            {
                state = "New Hampshire";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NM")
            {
                state = "New Mexico";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NY")
            {
                state = "New York";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NC")
            {
                state = "North Carolina";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "OH")
            {
                state = "Ohio";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "OK")
            {
                state = "Oklahoma";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "OR")
            {
                state = "Oregon";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "PR")
            {
                state = "Puerto rico";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "RI")
            {
                state = "Rhode Island";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "SC")
            {
                state = "South Carolina";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "SD")
            {
                state = "South Dakota";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "TN")
            {
                state = "Tennessee";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "UT")
            {
                state = "Utah";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "VT")
            {
                state = "Vermont";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "VI")
            {
                state = "US Virgin Islands";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "VA")
            {
                state = "Varginia";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "WA")
            {
                state = "Washington";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "WV")
            {
                state = "West virginia";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "WI")
            {
                state = "New Jersey";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NJ")
            {
                state = "Wisconsin";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "WY")
            {
                state = "Wyoming";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MD")
            {
                state = "Maryland";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MA")
            {
                state = "Massachusetts";
            }
            return state;

        }

      
        

       
    }
    public static class Globaltry
    {
        public static string _globalVar = "";

        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
    }


}
