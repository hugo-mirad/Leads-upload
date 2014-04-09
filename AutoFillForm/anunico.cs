﻿using System;
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
     
   public class anunico:IWebSites
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
       StateName objStateName = new StateName();
      
       public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
       {
           if (webBrowser1.Url.ToString() == "http://www.anunico.us/post_free_ads_in_united_states.html")
           {

               string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
               GeneralFunction.LinkInvoke(webBrowser1, statename);
           }
           string title = "";// obUsedCarsInfo[0].Model.ToString();
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
           //string title = obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString();
           GeneralFunction.SetTextValue(webBrowser1, "adtitle", title);

           string pmake = obUsedCarsInfo[0].Make.ToString();
           string pmodel = obUsedCarsInfo[0].Model.ToString();
           string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
           string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
           string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
           string url1 = "UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
           if (url.Contains(" "))
           {
               url = url.Replace(" ", "%20");
           }

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
           //string price = "Price: " + "$" + (obUsedCarsInfo[0].Price.ToString() == "0" ? "1" : obUsedCarsInfo[0].Price.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Price.ToString() == "Unspecified" ? "" : "\r\nPrice: " +"$"+ obUsedCarsInfo[0].Price.ToString());
           string price = "Price: " + "$" + (obUsedCarsInfo[0].Price.ToString() == "0" ? "1" : obUsedCarsInfo[0].Price.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Price.ToString() == "Unspecified" ? "" : obUsedCarsInfo[0].Price.ToString());
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
           string URLDesp = details.ToString() + "\r\n" + "\n" + "Description: " + dep.Trim() + "..!! If intrested contact : " + pn;
               //+ "..!!!For More Details:  " ;
               //WrapTextByMaxCharacters(details, dep, val, pn);

           GeneralFunction.SetMultiTextValue(webBrowser1, "addesc", URLDesp);

           GeneralFunction.SetTextValue(webBrowser1, "_link", url1);

           GeneralFunction.ButtonClickBody(webBrowser1, "button");
           GeneralFunction.SetTextValue(webBrowser1, "email", Globaltxtemail.txtemail);
           GeneralFunction.FileUploadInvokeanunico(webBrowser1, "pic[]");


       }


       string WrapTextByMaxCharacters(string details, string objText, int intMaxChars,string phone)
       {

           string strReturnValue = "";
           if (objText != null)
           {

               if (objText.ToString().Trim() != "")
               {

                   if (objText.ToString().Trim().Length > intMaxChars)
                   {

                       strReturnValue = details.ToString() + "\r\n" + "\n" + "Description: " + objText.ToString().Trim().Substring(0, intMaxChars) +

                      "..!! If intrested contact : " + phone ;


                   }

                   else
                   {

                       strReturnValue = details.ToString() + "\r\n" + "\n" + "Description: " + objText.ToString().Trim() 
                           + "..!! If intrested contact : " + phone ;

                   }

               }

           }

           return strReturnValue;
       }
    }
}
