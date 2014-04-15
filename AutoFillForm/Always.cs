using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AutoFillForm
{
   public class Always
    {

       public  void show(string weburl)
       {
           Form f1 = new Form();
           f1.Show();
           f1.TopMost = true;
           Label l1 = new Label();
           l1.Size = new Size(200, 32);
           l1.AutoSize = false;
           l1.Location = new System.Drawing.Point(7, 21);
           Label l2 = new Label();
           l2.Size = new Size(200, 32);
           l2.AutoSize = false;
           l2.Location = new System.Drawing.Point(7, 51);
           Label l3 = new Label();
           l3.Size = new Size(200, 32);
           l3.AutoSize = false;
           l3.Location = new System.Drawing.Point(7, 81);
           Label l4 = new Label();
           l4.Size = new Size(200, 32);
           l4.AutoSize = false;
           l4.Location = new System.Drawing.Point(7, 111);
           Label l5 = new Label();
           l5.Size = new Size(200, 32);
           l5.AutoSize = false;
           l5.Location = new System.Drawing.Point(7, 141);
           Label l6 = new Label();
           l6.Size = new Size(200, 32);
           l6.AutoSize = false;
           l6.Location = new System.Drawing.Point(7, 171);
           Label l7 = new Label();
           l7.Size = new Size(200, 32);
           l7.AutoSize = false;
           l7.Location = new System.Drawing.Point(7, 201);
           f1.Controls.Add(l1);
           f1.Controls.Add(l2);
           f1.Controls.Add(l3);
           f1.Controls.Add(l4 );
           f1.Controls.Add(l5 );
           f1.Controls.Add(l6 );
           f1.Controls.Add(l7 );


           if (weburl == "carposts")
           {
               f1.Text = "carposts";
               l1.Text = "1.Click Upload " ;
               l2.Text = "2.Click Submit ";
          
           }
           else if (weburl == "JustgoodCars")
           {

           f1.Text = "JustgoodCars";
           l1.Text = "1.Click Upload ";
           l2.Text = "2.Click Upload ";
           l3.Text = "3.Click Upload";
           l4.Text = "4.Click Upload";
           l5.Text = "5.Click Upload";
           l6.Text = "6.Click Submit";
           l7.Text = "Imge upload not working in the webisite*";
  

           }
           else if (weburl == "classifiedsforfree")
           {
               f1.Text = "classifiedsforfree";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Select City ";
               l3.Text = "3.Enter Security Code ";
               l4.Text = "4.Click Post the Above Ad";
           }
           else if (weburl == "clazorg")
           {
               f1.Text = "clazorg";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Click Browse button for Image Upload ";
               l3.Text = "3.Click Submit";
           }
           else if (weburl == "americanclassifieds")
           {
               f1.Text = "americanclassifieds";
               l1.Text = "1.Click Uload";
               l2.Text = "2.Select City ";
               l3.Text = "3.Enter Security Code ";
               l4.Text = "4.Click Submit";
           }
           else if (weburl == "postfreeadshere")
           {
               f1.Text = "postfreeadshere";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Enter Validation Code";
               l3.Text = "3.Click Submit ";
           }
           else if (weburl == "Usadsciti")
           {
               f1.Text = "Usadsciti";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Enter Validation Code";
               l3.Text = "3.Click Submit ";
           }
           else if (weburl == "freeautoshopper")
           {
               f1.Text = "freeautoshopper";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Select SubCategory";
               l3.Text = "3.Add Content(description)";
               l4.Text = "4.Select City";
               l5.Text = "5.Enter Security Code";
               l6.Text = "6.Click Submit";

           }
           else if (weburl == "Locate Any Auto")
           {
               f1.Text = "Locate Any Auto";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Select SubCategory";
               l3.Text = "3.Add Content(description)";
               l4.Text = "4.Select City";
               l5.Text = "5.Enter Security Code";
               l6.Text = "6.Click Submit";
           }
           else if (weburl == "FreeAddList")
           {
               f1.Text = "FreeAddList";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Select SubCategory";
               l3.Text = "3.Add Content(description)";
               l4.Text = "4.Select City";
               l5.Text = "5.Enter Security Code";
               l6.Text = "6.Click Submit";
           }
           else if (weburl == "autoii")
           {
               f1.Text = "autoii";
              l1.Text = "1.Click Upload ";
              l2.Text ="2.Click Submit";
           }
           else if (weburl == "ebayclassifieds")
           {
               f1.Text = "ebayclassifieds";
              
               l1.Text = "1.Click Upload ";
               l2.Text = "2.Click Submit";
           }
           else if (weburl == "biggestclassifieds")
           {
               f1.Text = "biggestclassifieds";
               l1.Text = "1.Select City";
               l2.Text = "2.Upload";
               l3.Text = "3.Upload";
               l4.Text = "4.Enter Security Code";
               l5.Text = "5. Click Submit";
           }
           else if (weburl == "ClassifiedAds")
           {
               f1.Text = "ClassifiedAds";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Enter Code";
               l3.Text = "3.Click finished->";
           }
           else if (weburl == "Locanto")
           {
               f1.Text = "Locanto";
               l1.Text = "1.Select Vechicles";
               l2.Text = "2.Select usedcars";
               l3.Text = "3.Select make";
               l3.Text = "4.Select Proceed";
               l4.Text = "5.Click Upload";
               l5.Text = "6.Click Submit";
           }
           else if (weburl == "75VN")
           {
               f1.Text = "75VN";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Click Upload";
               l3.Text = "3.Click Upload";
               l4.Text = "4.Click Submit";
             
           }
           else if (weburl == "adoos")
           {
               f1.Text = "adoos";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Select city";
               l3.Text = "3.Click Submit";

           }
           else if (weburl == "fastautosale")
           {
               f1.Text = "fastautosale";
               l1.Text = "Temporarily Problem";
           }
           else if (weburl == "sell.com")
           {
               f1.Text = "sell.com";
               l1.Text = "Temporarily not working";
               //l1.Text = "1.Click Upload";
               //l2.Text = "2.Click Upload";
               // l3.Text = "3.Click Upload";
               // l4.Text = "4.Click Upload";
               // l5.Text = "5.Select Image upload";
               //  l6.Text = "6.Select proceed";
               //   l7.Text = "7.Click Submit";

           }
           else if (weburl == "sellmycar")
           {
               f1.Text = "sellmycar";
               l1.Text = "Temporarily not working";
               //l1.Text = "1.Click Upload";
               //l2.Text = "2.Select Model";
               //l3.Text = "3.Click Upload";
               //l4.Text = "4.Click Upload";
               //l5.Text = "5.Click Upload";
               //l6.Text = "6.Click Submit";
           }
           else if (weburl == "Recycler")
           {
               f1.Text = "Recycler";
               l1.Text = "1.Temporarily pending";
           }
           else if (weburl == "epage")
           {
                 f1.Text = "epage";
                 l1.Text = "1.Click Upload";
                 l2.Text = "2.Click Upload";
                 l3.Text = "3.Click Upload";
                 l4.Text = "4.Click Upload";
                 l5.Text = "5.Click Upload";
                 l6.Text = "6.Click Submit";
              

           }
           else if (weburl == "kedna")
           {
               f1.Text = "kedna";
                l1.Text = "1.Click Upload";
                l2.Text = "2.Click Upload";
                l3.Text = "3.Click Upload";
                l4.Text = "4.Click Upload";
                l5.Text = "5.Click Upload";
                l6.Text = "6.Click Upload";
                l7.Text = "7.Click Submit";

           }
           else if (weburl == "UsNetads")
           {
               f1.Text = "UsNetads";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Enter Validation Code";
               l3.Text = "3.Click Submit";
             
           }
           else if (weburl == "classifiedsciti")
           {
               f1.Text = "classifiedsciti";
               l1.Text = "1.Click Upload";
               l2.Text = "2.Enter Verification Code Place at bottom";
               l3.Text = "3.Click Submit";
           }
           else if (weburl == "classifiedsvalley")
           {
               f1.Text = "classifiedsvalley";
               l1.Text = "1. Click Upload Button 5 times  ";

               l2.Text = "2. Enter verifaction code";
               l3.Text = "3. Click Submit";
           }

           else if (weburl == "collectorcarads")
           {
               f1.Text = "collectorcarads";
               l1.Text = "1. Click Upload button 7 times ";
               l2.Text = "2.Click Submit";
           }
           else if (weburl == "motoseller")
           {
               f1.Text = "motoseller";
               l1.Text = "1.Click Upload Button 10 times in 10 steps";
               l2.Text = "2.Click Submit button";
           }
           else if (weburl == "list2click")
           {
               f1.Text = "list2click";
               l1.Text = "1.Click Upload Button";
               l2.Text = "2.Enter description manually";
               l3.Text = "3.Upload pic manually";
               l4.Text = "4.Enter Verfication Code";
               l5.Text = "5.Click Submit Button";

           }

           else if (weburl == "us.boss33")
           {
               f1.Text = "boss33";
               l1.Text = "1.Select City manually";
               l2.Text = "2.Click Upload Button 3 time";
               l3.Text = "3.Enter Security Code";
               l4.Text = "4.Click Submit Button";
           }
           else if (weburl == "carsforsale")
           {
               f1.Text = "carsforsale";
               l1.Text = "1.Select Uplaod Button";
               l2.Text = "2.Click Model";
               l3.Text = "3.UploadPic";
               l4.Text = "4.Click Continue Button";
               l5.Text = "5.Click Upload Button";
               l6.Text = "6.Click Submit Button";
           }
           else if (weburl == "cathaylist")
           {
               f1.Text = "cathaylist";
               l1.Text = "1.Select City Manually";
               l2.Text = "2.Click Upload Button 3 Times";
               l3.Text = "3.Enter Verification Code";
               l4.Text = "4.Click Submit Button";

           }
           else if (weburl == "freeadsinus")
           {
               f1.Text = "freeadsinus";
               l1.Text = "1.Click Upload Button 4 Times";
               l2.Text = "2.Enter Verification Code";
               l3.Text = "3.Enter Submit";
               l4.Text = "NOTE1:Title Should be 20 characters";
               l5.Text = "NOTE2:If city not match with displayed fields ,select city manually";
           }
           else if (weburl == "highlandclassifieds")
           {
               f1.Text = "highlandclassifieds";
               l1.Text = "1. Click Upload Button 5 times";
               l2.Text = "2.Click Submit";
           }
           else if (weburl == "adlandpro")
           {
               f1.Text = "adlandpro";
               l1.Text = "1. Click Upload Button 3 times";
               l2.Text = "2.Select SubCatageory and city manually";
               l3.Text = "3.Click Uplaod Button 2 times";
               l4.Text = "4.Upload Image";
               l5.Text = "5.Click Upload Button";
               l6.Text = "6.Click Submit Button";
           }
           else if (weburl == "a1classiccars")
           {
               f1.Text = "a1classiccars";
               l1.Text = "1. Click Upload Button 4 times";
               l2.Text = "2.Enter Security Code";
               l3.Text = "3.Click Submit Button";
             
           }
           else if (weburl == "backpage")
           {
               f1.Text = "backpage";
               l1.Text = "Temporarily pending";
               //l1.Text = "1. Click Upload B";
               //l2.Text = "2.Select SubCatageory and city manually";
               //l3.Text = "3. Uplaod Image Manually";
               //l4.Text = "4.Click Upload Button 3 times";
           }

       }
    }
}
