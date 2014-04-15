using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarsBL;
using CarsInfo;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using ProductionBL;

namespace AutoFillForm
{
    public class highlandclassifieds : IWebSites
    {
        string Comfort = string.Empty;
        string Seats = string.Empty;
        string Safety = string.Empty;
        string soundsystem = string.Empty;
        string powerWindows = string.Empty;
        string New = string.Empty;
        string Other = string.Empty;
        string Specials = string.Empty;
        SubmitionDetailsBL objSubmitionDetailsBL = new SubmitionDetailsBL();
       public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
       {
           GeneralFunction.RadioSetOnlyValue(webBrowser1, "place", "pp1100000,45757,1100000,Vehicles");
           if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post/c45757")
           {
               GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Continue");
           }
           int pyear = Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString());
           if (pyear < 1991)
           {
               GeneralFunction.LinkInvoke(webBrowser1, "Classics");
           }
           else
               GeneralFunction.LinkInvoke(webBrowser1, "Cars and Trucks");

           if ((webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post?c=0&b=0&process=2&cnum=1100300") || (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post?c=45757&b=45757&process=2&cnum=1100300") || (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post?c=0&b=0&process=2&cnum=1102000") || (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post?c=45757&b=45757&process=2&cnum=1102000"))//1102000
           {
               GeneralFunction.ButtonClickByValue(webBrowser1, "Continue");
           }
           // GeneralFunction.ButtonClick(webBrowser1, "submit");
           //GeneralFunction.ButtonClick(webBrowser1, "submit");
           //GeneralFunction.SetTextValue(webBrowser1, "loginemail", "danunjay@gmail.com");
           //GeneralFunction.SetTextValue(webBrowser1, "loginpasswd", "123456");
           //GeneralFunction.SetTextValue(webBrowser1, "linertext", obUsedCarsInfo[0].Description.ToString());
           //GeneralFunction.SetMultiTextValue(webBrowser1, "moreinfo", obUsedCarsInfo[0].Description.ToString());
           //GeneralFunction.ButtonClickInvoke(webBrowser1, "file_1");
           //GeneralFunction.RadioSetValue(webBrowser1, "countryonly", "0");
           //GeneralFunction.SetTextValue(webBrowser1, "text", obUsedCarsInfo[0].Description.ToString());
           //GeneralFunction.SetTextValue(webBrowser1, "location", obUsedCarsInfo[0].City.ToString());
           //GeneralFunction.SetTextValue(webBrowser1, "zip", obUsedCarsInfo[0].Zip.ToString());
           ////  GeneralFunction.ButtonClick(webBrowser1, "submit");
           //GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "  OK   ");
           //if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post")
           //{
           //    GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Continue");
           //}
           //if (webBrowser1.Url.ToString() == "http://ww1.highlandclassifieds.com/js/post?c=45757")
           //{
           //    GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Continue");
           //}







           string username = Globaltxtemail.txtemail;

           Char[] seprt = { '@' };
           string[] splitemail = username.Split(seprt);

           username = splitemail[0].ToString();


           GeneralFunction.SetTextValue(webBrowser1, "loginuserid", username);

           //GeneralFunction.SetTextValue(webBrowser1, "txt_email", Globaltxtemail.txtemail);
           GeneralFunction.SetTextValue(webBrowser1, "loginemail", Globaltxtemail.txtemail);
           GeneralFunction.SetTextValue(webBrowser1, "loginpasswd", Globalpwd.pwd);
           GeneralFunction.SetTextValue(webBrowser1, "loginfirstname", username);
           GeneralFunction.SetTextValue(webBrowser1, "loginlastname", username);

           GeneralFunction.SetDropDownName(webBrowser1, "logincountry", "United States (US)");
           GeneralFunction.SetTextValue(webBrowser1, "loginzip", obUsedCarsInfo[0].Zip.ToString());
           //GeneralFunction.ButtonClickByValue(webBrowser1, "  OK   ");

           //GeneralFunction.ButtonClickByValue(webBrowser1, "Sign Up");

           GeneralFunction.RadioSetValue(webBrowser1, "selling", "0");

         
           string pmake = obUsedCarsInfo[0].Make.ToString();
           string pmodel = obUsedCarsInfo[0].Model.ToString();
           //string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
           string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
           string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
           if (url.Contains(" "))
           {
               url = url.Replace(" ", "%20");
           }

           string dep = obUsedCarsInfo[0].Description.ToString();
           if (dep.Contains("Emp"))
           {
               dep.Replace("Emp", "");
           }
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
           string price = obUsedCarsInfo[0].Price.ToString();
           price = "$" + price;
           //string price = "Price: " + "$" + (obUsedCarsInfo[0].Price.ToString() == "0" ? "1" : obUsedCarsInfo[0].Price.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Price.ToString() == "Unspecified" ? "" : "\r\nPrice: " +"$"+ obUsedCarsInfo[0].Price.ToString());
           price = "Price: " + "$" + (obUsedCarsInfo[0].Price.ToString() == "0" ? "1" : obUsedCarsInfo[0].Price.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Price.ToString() == "Unspecified" ? "" : obUsedCarsInfo[0].Price.ToString());
           //  string fule = obUsedCarsInfo[0].Fueltype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Fueltype.ToString() == "Unspecified" ? "" : "\r\nFuelType: " + obUsedCarsInfo[0].Fueltype.ToString();
           string transmission = obUsedCarsInfo[0].Transmission.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Transmission.ToString() == "Unspecified" ? "" : "\r\nTransmission: " + obUsedCarsInfo[0].Transmission.ToString();
           string drivetrain = obUsedCarsInfo[0].DriveTrain.ToString() == "Emp" ? "" : obUsedCarsInfo[0].DriveTrain.ToString() == "Unspecified" ? "" : "\r\nDriveTrain: " + obUsedCarsInfo[0].DriveTrain.ToString();
           string mileage = obUsedCarsInfo[0].Mileage.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Mileage.ToString() == "Unspecified" ? "" : "\r\nMileage: " + obUsedCarsInfo[0].Mileage.ToString();

           string fuel = obUsedCarsInfo[0].Fueltype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Fueltype.ToString() == "Unspecified" ? "" : "\r\nFuelType: " + obUsedCarsInfo[0].Fueltype.ToString();

           string Engine = obUsedCarsInfo[0].NumberOfCylinder.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfCylinder.ToString() == "Unspecified" ? "" : "\r\nEngine: " + obUsedCarsInfo[0].NumberOfCylinder.ToString();

           int carid = Convert.ToInt32(obUsedCarsInfo[0].Carid.ToString());


           DataSet dsfeatures = objSubmitionDetailsBL.MultisiteGetCarFeatures(carid);


           if (dsfeatures.Tables[0].Rows.Count > 0)
           {
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


           dep = dep.Replace("\n", " ");

           string URLDesp = WrapTextByMaxCharacters(details, dep, url, pn);
           string price1 = obUsedCarsInfo[0].Price.ToString();
           price1 = "- $" + price1;
           GeneralFunction.SetTextValue(webBrowser1, "price", price1);


           string title = "";
           if (obUsedCarsInfo[0].Title != "Emp")
           {
               title = obUsedCarsInfo[0].Title + "-" + "$"+obUsedCarsInfo[0].Price.ToString();
           }
           else
           {
               if (obUsedCarsInfo[0].Model.ToString() != "Other")
                   title = obUsedCarsInfo[0].YearOfMake.ToString() + "  " + obUsedCarsInfo[0].Make.ToString() + "  " + obUsedCarsInfo[0].Model.ToString() + " - " + "$"+obUsedCarsInfo[0].Price.ToString();
               else
                   title = obUsedCarsInfo[0].YearOfMake.ToString() + "  " + obUsedCarsInfo[0].Make.ToString() + " - " + "$"+obUsedCarsInfo[0].Price.ToString();
           }
           //obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString() + " " + price1;
           GeneralFunction.SetTextValue(webBrowser1, "linertext", title);
           GeneralFunction.SetMultiTextValue(webBrowser1, "moreinfo", URLDesp);
           GeneralFunction.FileUploadInvoke(webBrowser1, "file_1");
           GeneralFunction.SetTextValue(webBrowser1, "location", obUsedCarsInfo[0].City.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "zip", obUsedCarsInfo[0].Zipcode.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "email", Globaltxtemail.txtemail);
           GeneralFunction.RadioSetValue(webBrowser1, "countryonly", "0");
       }

       public string WrapTextByMaxCharacters(string details, string objText, string url, string phone)
       {

           string strReturnValue = "";
           if (objText != null)
           {

               if (objText.ToString().Trim() != "")
               {



                   strReturnValue = details.ToString() + "\n" + "\n" + "Description " + objText.ToString().Trim() +

                  "..!!\nIf instrested please contact : " + phone + "\n\n For More Details:  " + url;






               }

           }

           return strReturnValue;
       }
    }
}
