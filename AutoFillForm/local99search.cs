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

namespace AutoFillForm
{
   public class local99search:IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {

            string title=obUsedCarsInfo[0].YearOfMake.ToString()+" "+obUsedCarsInfo[0].Make.ToString()+" "+obUsedCarsInfo[0].Model.ToString();

               GeneralFunction.SetTextvaluebyName(webBrowser1,"txt_adtitle", "title");
               GeneralFunction.SetTextvaluebyName(webBrowser1, "txt_contactperson", "UCEURV");
               GeneralFunction.SetTextvaluebyName(webBrowser1, "txt_mobile", obUsedCarsInfo[0].Phone.ToString());
               string location = obUsedCarsInfo[0].City.ToString() + "," + obUsedCarsInfo[0].State.ToString() + "," + obUsedCarsInfo[0].Zip.ToString();
               GeneralFunction.SetTextvaluebyName(webBrowser1, "txt_locality", location);
               GeneralFunction.SetTextvaluebyName(webBrowser1, "txt_city", obUsedCarsInfo[0].City.ToString());


               string pmake = obUsedCarsInfo[0].Make.ToString();
               string pmodel = obUsedCarsInfo[0].Model.ToString();
               string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
               string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
               string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
               GeneralFunction.SetTextvaluebyName(webBrowser1, "txt_website", url);

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
               string mileage = obUsedCarsInfo[0].Mileage.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Mileage.ToString() == "Unspecified" ? "" : "\r\nMileage: " + obUsedCarsInfo[0].Mileage.ToString();


               string details = (make.Trim() == "" ? "" : make.Trim()) + (model.Trim() == "" ? "" : "\r\n" + model.Trim()) + (year.Trim() == "" ? "" : "\r\n" + year.Trim()) + (doors.Trim() == "" ? "" : "\r\n" + doors.Trim()) + (bodystyle.Trim() == "" ? "" : "\r\n" + bodystyle.Trim()) + (exteriorcolor.Trim() == "" ? "" : "\r\n" + exteriorcolor.Trim()) + (interior.Trim() == "" ? "" : "\r\n" + interior.Trim()) + (seats.Trim() == "" ? "" : "\r\n" + seats.Trim()) + (price.Trim() == "" ? "" : "\r\n" + price.Trim()) + (transmission.Trim() == "" ? "" : "\r\n" + transmission.Trim()) + (mileage.Trim() == "" ? "" : "\r\n" + mileage.Trim());

               dep = dep.Replace("\n", " ");
               string URLDesp = WrapTextByMaxCharacters(details, dep, val, pn);


               GeneralFunction.SetMultiTextValue(webBrowser1, "txt_description", URLDesp);

               
        GeneralFunction.SetDropDownNameandValue(webBrowser1, "dl_category", "273");

        // GeneralFunction.SetDropDownValue(webBrowser1, "dl_category", "Buy & Sale");
            
               //GeneralFunction.SetDropDownNameandValue(webBrowser1, "dl_sub_categ", "481");
           
        }



        string WrapTextByMaxCharacters(string details, string objText, int intMaxChars, string phone)
        {

            string strReturnValue = "";
            if (objText != null)
            {

                if (objText.ToString().Trim() != "")
                {

                    if (objText.ToString().Trim().Length > intMaxChars)
                    {

                        strReturnValue = details.ToString() + "\r\n" + "Description: " + objText.ToString().Trim() + "..!! If instrested contact : " + phone;


                    }

                    else
                    {

                        strReturnValue = details.ToString() + "\r\n" + "Description: " + objText.ToString().Trim() + "..!! If instrested contact : " + phone;

                    }

                }

            }

            return strReturnValue;
        }
    }
}