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
    public class adoos : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {

            GeneralFunction.LinkInvoke(webBrowser1, "Vehicles");
            GeneralFunction.LinkInvoke(webBrowser1, "Used Cars");

            GeneralFunction.SetTextValue(webBrowser1, "Title", obUsedCarsInfo[0].Title.ToString());
            GeneralFunction.SetMultiTextValue(webBrowser1, "Description", obUsedCarsInfo[0].Description.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "Price", obUsedCarsInfo[0].Price.ToString());

            GeneralFunction.SetDropDownName(webBrowser1, "make_id", obUsedCarsInfo[0].Make.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "model_id", obUsedCarsInfo[0].Model.ToString());

            if (obUsedCarsInfo[0].NumberOfDoors.Contains("Two"))
            {
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "Doors", "1");
            }
            else if (obUsedCarsInfo[0].NumberOfDoors.Contains("Three"))
            {
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "Doors", "2");
            }
            else if (obUsedCarsInfo[0].NumberOfDoors.Contains("Four"))
            {
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "Doors", "3");
            }
            else if (obUsedCarsInfo[0].NumberOfDoors.Contains("Five"))
            {
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "Doors", "4");
            }
            else
            {
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "Doors", "5");
            }

            GeneralFunction.SetDropDownName(webBrowser1, "Colour", obUsedCarsInfo[0].ExteriorColor.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "Fuel", obUsedCarsInfo[0].Fueltype.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "Transmission", obUsedCarsInfo[0].Transmission.ToString());

            GeneralFunction.SetDropDownNameandValue(webBrowser1, "fd_year", obUsedCarsInfo[0].YearOfMake.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "Mileage", obUsedCarsInfo[0].Mileage.ToString());
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "geo1_id", obUsedCarsInfo[0].State.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "geo3_id", obUsedCarsInfo[0].City.ToString());
            GeneralFunction.FileUploadInvoke(webBrowser1, "photo_basic[1]");
            GeneralFunction.RadioSetValue(webBrowser1, "PrivateTrade", "1");

            GeneralFunction.SetTextValue(webBrowser1, "ContactName", obUsedCarsInfo[0].SellerName.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "email", obUsedCarsInfo[0].Email.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "telephone", obUsedCarsInfo[0].Phone.ToString());
        }


    }
}
