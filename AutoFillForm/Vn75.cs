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
    public class Vn75 : IWebSites
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
           GeneralFunction.SetTextValue(webBrowser1, "txt_email", Globaltxtemail.txtemail);
           GeneralFunction.SetTextValue(webBrowser1, "txt_password", Globalpwd.pwd);
           GeneralFunction.SetTextValue(webBrowser1, "txt_passwordC", Globalpwd.pwd);
           GeneralFunction.SetTextValue(webBrowser1, "txt_name", "UCEURV");

           string phone=obUsedCarsInfo[0].Phone.ToString();

           if (phone.Length == 10)
           {
               phone = phone[0].ToString() + "" + phone[1].ToString() + "" + phone[2].ToString() + "" + phone[3].ToString() + "" + phone[4].ToString() + "" + phone[5].ToString() + "" + phone[6].ToString() + "" + phone[7].ToString() + "" + phone[8].ToString() + "" + phone[9].ToString();
           }
           else
           {
               phone = "8887776666";
           }
           GeneralFunction.SetTextValue(webBrowser1, "txt_phone1", phone);

           //GeneralFunction.LinkInvoke(webBrowser1, "Place an ad");
          // GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");
           int pyear = Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString());
           //if (a)
           //{
           //    GeneralFunction.LinkInvoke(webBrowser1, "Place an ad to sell your commercial truck.");
           //}
           //else
           //{
           //    if (pyear < 1991)
           //    {
           //        GeneralFunction.LinkInvoke(webBrowser1, "Place an ad to sell your classic car.");
           //    }
           //    else
           //    {
           //        GeneralFunction.LinkInvoke(webBrowser1, "Place an ad to sell your car.");
           //    }
           //}
           string title = "";
           if (obUsedCarsInfo[0].Title != "Emp" )
           {
               title = obUsedCarsInfo[0].Title + "-" + "$" + obUsedCarsInfo[0].Price.ToString();
           }
           else
           {
               if (obUsedCarsInfo[0].Model.ToString() != "Other")
               {
                   title = obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString() + "-" + "$" + obUsedCarsInfo[0].Price.ToString();
               }
               else
                   title = obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + "-" + "$" + obUsedCarsInfo[0].Price.ToString() ;
           }
           GeneralFunction.SetTextValue(webBrowser1, "ad_title", title);
           GeneralFunction.SetTextValue(webBrowser1, "ad_city", obUsedCarsInfo[0].City.ToString());
           string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
           GeneralFunction.SetDropDownName(webBrowser1, "ad_state", statename);
           GeneralFunction.SetTextValue(webBrowser1, "ad_zip", obUsedCarsInfo[0].Zipcode.ToString());

           if (obUsedCarsInfo[0].Make.ToString() == "Mercedes-Benz")
           {
               GeneralFunction.SetDropDownName(webBrowser1, "ad_manufacturer", "Mercedes-Benz");
           }
           else
           {
               GeneralFunction.SetDropDownName(webBrowser1, "ad_manufacturer", obUsedCarsInfo[0].Make.ToString());
           }

           GeneralFunction.SetTextValue(webBrowser1, "ad_model", obUsedCarsInfo[0].Model.ToString());


           if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("4"))
           {
               GeneralFunction.SetDropDownName(webBrowser1, "ad_length", "4");
           }
           else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("6"))
           {
               GeneralFunction.SetDropDownName(webBrowser1, "ad_length", "6");
           }
           else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("8"))
           {
               GeneralFunction.SetDropDownName(webBrowser1, "ad_length", "8");
           }
           else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("12"))
           {
               GeneralFunction.SetDropDownName(webBrowser1, "ad_length", "12");
           }


            string pmake = obUsedCarsInfo[0].Make.ToString();
            string pmodel = obUsedCarsInfo[0].Model.ToString();
            //string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
            string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
            string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";

            if (url.Contains(" "))
            {
                url = url.Replace(" ", "%20");
            }
            GeneralFunction.SetTextValue(webBrowser1, "f_url", url);

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
            string price = "Price: " + "$" + (obUsedCarsInfo[0].Price.ToString() == "0" ? "1" : obUsedCarsInfo[0].Price.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Price.ToString() == "Unspecified" ? "" : obUsedCarsInfo[0].Price.ToString());
           // string fule = obUsedCarsInfo[0].Fueltype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Fueltype.ToString() == "Unspecified" ? "" : "\r\nFuelType: " + obUsedCarsInfo[0].Fueltype.ToString();
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


                        Seats += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();



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
                //Comfort = Comfort.Substring(0, Comfort.Length - 1) + ",";
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


            string URLDesp = details.ToString() + "\r\n" + "\n" + "Description: " + dep.Trim() + "..!! If intrested contact : " + pn
                                        + "..!!!For More Details:  "; 
           //WrapTextByMaxCharacters(details,dep, val, url, pn);
            if (details.Contains("Emp"))
            {
                details = details.Replace("Emp", "");
            }
           // GeneralFunction.SetDivValuebyInnerText(webBrowser1,"nicEdit-main",obUsedCarsInfo[0].Description.ToString());
            
           GeneralFunction.SetMultiTextValue(webBrowser1, "ad_description", URLDesp+url);
           GeneralFunction.SetTextValue(webBrowser1, "ad_fuel", obUsedCarsInfo[0].Fueltype.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "ad_doors", obUsedCarsInfo[0].NumberOfDoors.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "ad_color", obUsedCarsInfo[0].ExteriorColor.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "ad_mileage", obUsedCarsInfo[0].Mileage.ToString());
           GeneralFunction.SetDropDownName(webBrowser1, "ad_year", obUsedCarsInfo[0].YearOfMake.ToString());
           GeneralFunction.SetDropDownNameandValue(webBrowser1, "ad_transmission", obUsedCarsInfo[0].Transmission.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "ad_condition", obUsedCarsInfo[0].ConditionDescription.ToString());


           if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("All"))
           {
               GeneralFunction.SetDropDownNameandValue(webBrowser1, "ad_drivestrain", "All Wheel Drive");
           }
           else if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("Four"))
           {
               GeneralFunction.SetDropDownNameandValue(webBrowser1, "ad_drivestrain", "Four Wheel Drive");
           }
           else if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("Front"))
           {
               GeneralFunction.SetDropDownNameandValue(webBrowser1, "ad_drivestrain", "Front Wheel Drive");
           }
           else if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("Rear"))
           {
               GeneralFunction.SetDropDownNameandValue(webBrowser1, "ad_drivestrain", "Rear Wheel Drive");
           }
           else { GeneralFunction.SetDropDownNameandValue(webBrowser1, "ad_drivestrain", "Other"); }
           // GeneralFunction.SetDropDownNameandValue(webBrowser1, "ad_drivestrain", obUsedCarsInfo[0].DriveTrain.ToString ());
           GeneralFunction.SetTextValue(webBrowser1, "ad_price", obUsedCarsInfo[0].Price.ToString());
           GeneralFunction.SetDropDownName(webBrowser1, "ad_typeproduct", obUsedCarsInfo[0].Bodytype.ToString());
           


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

                       strReturnValue = details.ToString() + "\r\n" + "\n" + "Description: " + objText.ToString().Trim().Substring(0, intMaxChars) +

                      "..!! If intrested contact : " + phone + "..!!!For More Details:  " + url;


                   }

                   else
                   {

                       strReturnValue = details.ToString() + "\r\n" + "\n" + "Description: " + objText.ToString().Trim() + "..!! If intrested contact : " + phone + "..!!!For More Details:  " + url;

                   }

               }

           }

           return strReturnValue;
       }


            
           
    }
}
