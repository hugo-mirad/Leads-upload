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

namespace AutoFillForm
{
    public class CarPosts:IWebSites  
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {

          
            //********** Carposts
            GeneralFunction.SetDropDownValue(webBrowser1, "Type", "For Sale");

            if (obUsedCarsInfo[0].Make.ToString() == "Alfa Romeo")
            {
                GeneralFunction.SetDropDownValue(webBrowser1, "Make", "Alfa");
            }
            else if (obUsedCarsInfo[0].Make.ToString() == "Lamborghini")
            {
                GeneralFunction.SetDropDownValue(webBrowser1, "Make", "Lamborgini");
            }
            else if (obUsedCarsInfo[0].Make.ToString() == "Mercedes-Benz")
            {
                GeneralFunction.SetDropDownValue(webBrowser1, "Make", "Mercedes");
            }
            else if (obUsedCarsInfo[0].Make.ToString() == "Rolls-Royce")
            {
                GeneralFunction.SetDropDownValue(webBrowser1, "Make", "Rolls Royce");
            }
            else if (obUsedCarsInfo[0].Make.ToString() == "Unspecified")
            {
                GeneralFunction.SetDropDownValue(webBrowser1, "Make", "OTHER");
            }
            else if (obUsedCarsInfo[0].Make.ToString() == "Volkswagen")
            {
                GeneralFunction.SetDropDownValue(webBrowser1, "Make", "VW");
            }
            else
            {

                GeneralFunction.SetDropDownValue(webBrowser1, "Make", obUsedCarsInfo[0].Make.ToString());
            }


            GeneralFunction.SetTextValue(webBrowser1, "Model", obUsedCarsInfo[0].Model);

            GeneralFunction.SetTextValue(webBrowser1, "Mileage", obUsedCarsInfo[0].Mileage.ToString());

            GeneralFunction.SetDropDownValue(webBrowser1, "Year", obUsedCarsInfo[0].YearOfMake.ToString());

         
            GeneralFunction.SetDropDownValue(webBrowser1, "ExtColor", obUsedCarsInfo[0].ExteriorColor.ToString());

            GeneralFunction.SetDropDownValue(webBrowser1, "BodyStyle", obUsedCarsInfo[0].Bodytype.ToString());

            GeneralFunction.SetDropDownName(webBrowser1, "Doors", obUsedCarsInfo[0].NumberOfDoors.ToString());

           // GeneralFunction.SetDropDownValue(webBrowser1, "Drive", obUsedCarsInfo[0].Transmission.ToString());

            if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("4"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "Engine", "4 Cylinder");
            }
            else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("6"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "Engine", "6 Cylinder");
            }
            else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("8"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "Engine", "8 Cylinder");
            }
            else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("12"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "Engine", "12 Cylinder");
            }

            GeneralFunction.SetDropDownName(webBrowser1, "Fuel", obUsedCarsInfo[0].Fueltype.ToString());

            if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("2"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "Drive", "2 Wheel");
            }
            else if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("4"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "Drive", "4 Wheel");
            }
            else if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("All"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "Drive", "All Wheel");
            }
            GeneralFunction.SetDropDownName(webBrowser1, "Drive", obUsedCarsInfo[0].DriveTrain.ToString());

            GeneralFunction.SetDropDownName(webBrowser1, "Drive", obUsedCarsInfo[0].Transmission.ToString());

            if (obUsedCarsInfo[0].Transmission.ToString().Contains("manual"))
            {
                GeneralFunction.SetDropDownValue(webBrowser1, "Trans", "Manual");
            }
            else if (obUsedCarsInfo[0].Transmission.ToString().Contains("Automatic"))
            {
                GeneralFunction.SetDropDownValue(webBrowser1, "Trans", "Automatic");
            }
            //GeneralFunction.SetTextValue(webBrowser1, "Stock", obUsedCarsInfo[0]..ToString());

           // GeneralFunction .SetTextValue (webBrowser1 ,"Stock",obUsedCarsInfo [0].

           // GeneralFunction.SetTextValue(webBrowser1, "VIN", obUsedCarsInfo[0].VIN.ToString());

            GeneralFunction.SetTextValue(webBrowser1, "Price", obUsedCarsInfo[0].Price.ToString());

            string pmake = obUsedCarsInfo[0].Make.ToString();

            string pmodel = obUsedCarsInfo[0].Model.ToString();

            string pyear = obUsedCarsInfo[0].YearOfMake.ToString();

            string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
         
            string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
            if (url.Contains(" "))
            {
                url = url.Replace(" ", "%20");
            }

            string make = obUsedCarsInfo[0].Make.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Make.ToString() == "Unspecified" ? "" : "\r\nMake: " + obUsedCarsInfo[0].Make.ToString();

            string model = obUsedCarsInfo[0].Model.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Model.ToString() == "Unspecified" ? "" : "\r\nModel: " + obUsedCarsInfo[0].Model.ToString(); ;
            string year = obUsedCarsInfo[0].YearOfMake.ToString() == "Emp" ? "" : obUsedCarsInfo[0].YearOfMake.ToString() == "Unspecified" ? "" : "\r\nyear: " + obUsedCarsInfo[0].YearOfMake.ToString();
            string doors = obUsedCarsInfo[0].NumberOfDoors.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfDoors.ToString() == "Unspecified" ? "" : "\r\nDoors: " + obUsedCarsInfo[0].NumberOfDoors.ToString();
            string bodystyle = obUsedCarsInfo[0].Bodytype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Bodytype.ToString() == "Unspecified" ? "" : "\r\nBodytype: " + obUsedCarsInfo[0].Bodytype.ToString();

            string exteriorcolor = obUsedCarsInfo[0].ExteriorColor.ToString() == "Emp" ? "" : obUsedCarsInfo[0].ExteriorColor.ToString() == "Unspecified" ? "" : "\r\nExteriorColor: " + obUsedCarsInfo[0].ExteriorColor.ToString();
            string interior = obUsedCarsInfo[0].InteriorColor.ToString() == "Emp" ? "" : obUsedCarsInfo[0].InteriorColor.ToString() == "Unspecified" ? "" : "\r\nInteriorColor: " + obUsedCarsInfo[0].InteriorColor.ToString();
            string seats = obUsedCarsInfo[0].NumberOfSeats.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfSeats.ToString() == "Unspecified" ? "" : "\r\nSeats: " + obUsedCarsInfo[0].NumberOfSeats.ToString();
            string price = obUsedCarsInfo[0].Price.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Price.ToString() == "Unspecified" ? "" : "\r\nPrice: " + "$" + obUsedCarsInfo[0].Price.ToString();
            // string fule = obUsedCarsInfo[0].Fueltype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Fueltype.ToString() == "Unspecified" ? "" : "\r\nFuelType: " + obUsedCarsInfo[0].Fueltype.ToString();
            string transmission = obUsedCarsInfo[0].Transmission.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Transmission.ToString() == "Unspecified" ? "" : "\r\nTransmission: " + obUsedCarsInfo[0].Transmission.ToString();
            string drivetrain = obUsedCarsInfo[0].DriveTrain.ToString() == "Emp" ? "" : obUsedCarsInfo[0].DriveTrain.ToString() == "Unspecified" ? "" : "\r\nDriveTrain: " + obUsedCarsInfo[0].DriveTrain.ToString();
            string mileage = obUsedCarsInfo[0].Mileage.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Mileage.ToString() == "Unspecified" ? "" : "\r\nMileage: " + obUsedCarsInfo[0].Mileage.ToString();

            string fuel = obUsedCarsInfo[0].Fueltype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Fueltype.ToString() == "Unspecified" ? "" : "\r\nFuelType: " + obUsedCarsInfo[0].Fueltype.ToString();

            string Engine = obUsedCarsInfo[0].NumberOfCylinder.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfCylinder.ToString() == "Unspecified" ? "" : "\r\nEngine: " + obUsedCarsInfo[0].NumberOfCylinder.ToString();


            string details = (make.Trim() == "" ? "" : make.Trim()) + (model.Trim() == "" ? "" : "\r\n" + model.Trim()) + (year.Trim() == "" ? "" : "\r\n" + year.Trim()) + (doors.Trim() == "" ? "" : "\r\n" + doors.Trim()) + (bodystyle.Trim() == "" ? "" : "\r\n" + bodystyle.Trim()) + (exteriorcolor.Trim() == "" ? "" : "\r\n" + exteriorcolor.Trim()) + (interior.Trim() == "" ? "" : "\r\n" + interior.Trim()) + (seats.Trim() == "" ? "" : "\r\n" + seats.Trim()) + (price.Trim() == "" ? "" : "\r\n" + price.Trim()) + (transmission.Trim() == "" ? "" : "\r\n" + transmission.Trim()) + (mileage.Trim() == "" ? "" : "\r\n" + mileage.Trim()) + (fuel.Trim() == "" ? "" : "\r\n" + fuel.Trim()) + (drivetrain.Trim() == "" ? "" : "\r\n" + drivetrain.Trim()) + (Engine.Trim() == "" ? "" : "\r\n" + Engine.Trim());

            string dep = obUsedCarsInfo[0].Description.ToString();
            int val=300;
            string pn = obUsedCarsInfo[0].Phone.ToString();
            dep = dep.Replace("\n", " ");
            string URLDesp = string.Empty;
            if (dep == "Emp")
            {
                 URLDesp = WrapTextByMaxCharacters(details, val, url, pn);
            }
            else
            {

                 URLDesp = WrapTextByMaxCharacters(dep, val, url, pn);
            }
        
            GeneralFunction.SetMultiTextValue(webBrowser1, "Description", URLDesp);
            GeneralFunction.SetTextValue(webBrowser1, "ContactName", "UCEURV");
            GeneralFunction.SetTextValue(webBrowser1, "Zip", obUsedCarsInfo[0].Zipcode.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ContactEmail", Globaltxtemail.txtemail);

            GeneralFunction.SetTextValue(webBrowser1, "ContactPhone", obUsedCarsInfo[0].Phone.ToString());

            //GeneralFunction.SetTextValue(webBrowser1, "Img1", Pics.GetPic0(obUsedCarsInfo));
            //GeneralFunction.SetTextValue(webBrowser1, "Img2", Pics.GetPic1(obUsedCarsInfo));

            GeneralFunction.LinkInvoke(webBrowser1, "Upload your picture");

         

           // GeneralFunction.LinkInvoke(webBrowser1, "Upload your picture");//image upload

        }


        string WrapTextByMaxCharacters(string objText, int intMaxChars, string url,string phone)
        {

            string strReturnValue = "";
            if (objText != null)
            {

                if (objText.ToString().Trim() != "")
                {

                    if (objText.ToString().Trim().Length > intMaxChars)
                    {

                        strReturnValue = "Description : "+objText.ToString().Trim().Substring(0, intMaxChars) +

                       "..!!\r\nIf intrested please contact : " + phone + "  \r\n For More Details: " + url;


                    }

                    else
                    {

                        strReturnValue = "Description : " + objText.ToString().Trim() + "..!!\r\nIf intrested please contact : " + phone + "  \r\n For More Details: \r\n " + url;

                    }

                }

            }

            return strReturnValue;
        }
    }
}
