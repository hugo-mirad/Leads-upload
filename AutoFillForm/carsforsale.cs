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
    public class carsforsale : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$phMainContent$ddlBodyStyle", obUsedCarsInfo[0].Bodytype.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$phMainContent$ddlYear", obUsedCarsInfo[0].YearOfMake.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$phMainContent$ddlMake", obUsedCarsInfo[0].Make.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$phMainContent$ddlModel", obUsedCarsInfo[0].Model.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtMileage", obUsedCarsInfo[0].Mileage.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtPrice", obUsedCarsInfo[0].Price.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtTransmission", obUsedCarsInfo[0].Transmission.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtColor", obUsedCarsInfo[0].ExteriorColor.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtInteriorColor", obUsedCarsInfo[0].InteriorColor.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtVin", obUsedCarsInfo[0].VIN.ToString());
            //GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtPrice", obUsedCarsInfo[0]..ToString());
            GeneralFunction.SetMultiTextValue(webBrowser1, "ctl00$phMainContent$txtDescription", obUsedCarsInfo[0].Description.ToString());
            GeneralFunction.FileUploadInvoke(webBrowser1, "ctl00$phMainContent$fuImg");
            // GeneralFunction.ButtonClick(webBrowser1, "submit");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtEmail", "emp@gmail.com");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtPassword", "123456");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtFname", "123456");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtLname", "123456");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtCity", "123456");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$phMainContent$txtZip", "123456");
            string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
            string statename1 = statename.ToUpper();
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$phMainContent$ddlState", statename1);
            //GeneralFunction.ButtonClick(webBrowser1, "submit");



        }
            

    }
}
