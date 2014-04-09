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
    public class Sellmycar : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {

            GeneralFunction.SetDropDownNameandValue(webBrowser1, "make_name", obUsedCarsInfo[0].Make.ToString());
            GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Go to next step");

            GeneralFunction.SetDropDownName(webBrowser1, "model", obUsedCarsInfo[0].Model.ToString());

            if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("4"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "engine", "4 CYL");
            }
            else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("6"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "engine", "6  CYL");
            }
            else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("8"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "engine", "8  CYL");
            }
            else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("10"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "engine", "10 CYL");
            }
            else if (obUsedCarsInfo[0].NumberOfCylinder.ToString().Contains("12"))
            {
                GeneralFunction.SetDropDownName(webBrowser1, "engine", "12  CYL");
            }
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "year", obUsedCarsInfo[0].YearOfMake.ToString());
            if (obUsedCarsInfo[0].NumberOfDoors.Contains("Two"))
            {
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "doors", "2");
            }
            else if (obUsedCarsInfo[0].NumberOfDoors.Contains("Three"))
            {
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "doors", "3");
            }
            else if (obUsedCarsInfo[0].NumberOfDoors.Contains("Four"))
            {
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "doors", "4");
            }
            else if (obUsedCarsInfo[0].NumberOfDoors.Contains("Five"))
            {
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "doors", "5");
            }
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "body", obUsedCarsInfo[0].Bodytype.ToString());
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "transmission", obUsedCarsInfo[0].Transmission.ToString());
            GeneralFunction.SetMultiTextValue(webBrowser1, "description", obUsedCarsInfo[0].Description.ToString());

            GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "trim", "");
            GeneralFunction.SetTextValue(webBrowser1, "mileage", obUsedCarsInfo[0].Mileage.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "color", obUsedCarsInfo[0].ExteriorColor.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "stockNumber", "");
            GeneralFunction.SetTextValue(webBrowser1, "vin", obUsedCarsInfo[0].VIN.ToString());

            GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Next -> Add Pictures");

            GeneralFunction.FileUploadInvoke(webBrowser1, "userfile");
            GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Upload Picture");
            GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Next -> Preview Ad");

            GeneralFunction.SetTextValue(webBrowser1, "first_name", obUsedCarsInfo[0].SellerName.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "last_name", obUsedCarsInfo[0].SellerName.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "zipcode", obUsedCarsInfo[0].Zipcode.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "email", obUsedCarsInfo[0].Email.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "phone2", obUsedCarsInfo[0].Phone.ToString());
           
        }
    }
    
}
