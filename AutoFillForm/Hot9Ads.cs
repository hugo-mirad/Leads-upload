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
   public class Hot9Ads:IWebSites
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
           GeneralFunction.SetTextValue(webBrowser1, "s_name", "UCEURV");

           GeneralFunction.SetTextValue(webBrowser1, "s_password", "UCEURV123");
           GeneralFunction.SetTextValue(webBrowser1, "s_password2", "UCEURV123");


           GeneralFunction.SetDropDownNameandValue(webBrowser1, "catId", "31");
           string title = obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString();
           GeneralFunction.SetTextValue(webBrowser1, "title[en_US]", title);

           string pmake = obUsedCarsInfo[0].Make.ToString();
           string pmodel = obUsedCarsInfo[0].Model.ToString();
           string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
           string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
           string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
          // GeneralFunction.SetTextValue(webBrowser1, "f_url", url);
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


           string URLDesp = WrapTextByMaxCharacters(details, dep, val, url, pn);
           if (details.Contains("Emp"))
           {
               details = details.Replace("Emp", "");
           }

           GeneralFunction.SetMultiTextName(webBrowser1, "description[en_US]", URLDesp);
           GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
           GeneralFunction.ButtonClickInvoke(webBrowser1, "photos[]");

           GeneralFunction.SetDropDownNameandValue(webBrowser1, "countryId", "US");

           GeneralFunction.SetTextValue(webBrowser1, "cityArea", obUsedCarsInfo[0].City.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "address", obUsedCarsInfo[0].Address1.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "contactEmail", obUsedCarsInfo[0].Email.ToString());

           GeneralFunction.SetTextValue(webBrowser1, "contactEmail", obUsedCarsInfo[0].Email.ToString());
           GeneralFunction.SetClassValue(webBrowser1, "text", obUsedCarsInfo[0].Phone.ToString());
           GeneralFunction.SetClassValue(webBrowser1, "text", url);


           GeneralFunction.SetDropDownID(webBrowser1, "make", obUsedCarsInfo[0].Make.ToString());
           GeneralFunction.SetDropDownValue(webBrowser1, "model", obUsedCarsInfo[0].Model.ToString());
           GeneralFunction.SetDropDownValue(webBrowser1, "car_type", obUsedCarsInfo[0].DriveTrain.ToString());

           GeneralFunction.SetTextvaluebyName(webBrowser1, "year", obUsedCarsInfo[0].YearOfMake.ToString());



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
