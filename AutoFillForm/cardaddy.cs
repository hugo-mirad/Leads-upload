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
    public class cardaddy : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {

            //  string[] x = obUsedCarsInfo[0].Make.ToString();
            GeneralFunction.SetDropDownName(webBrowser1, "make", obUsedCarsInfo[0].Make.ToString());
            //GeneralFunction.SetDropDownName(webBrowser1, "model", obUsedCarsInfo[0].Model.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "year", obUsedCarsInfo[0].YearOfMake.ToString());
            //string Trim = "other".ToString();
            //GeneralFunction.SetDropDownName(webBrowser1, "trim", "Trim");
            GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
            GeneralFunction.SetMultiTextValue(webBrowser1, "textarea", obUsedCarsInfo[0].Description.ToString());
            string state1 = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].City.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "stateDropdown", state1);
            //GeneralFunction.SetTextValue(webBrowser1, "regionDropdown", obUsedCarsInfo[0].City.ToString());
            ////GeneralFunction.SetTextValue(webBrowser1, "name", obUsedCarsInfo[0].SellerName.ToString());
            //GeneralFunction.SetTextValue(webBrowser1, "email", obUsedCarsInfo[0].Email.ToString());
            ////GeneralFunction.SetTextValue(webBrowser1, "phone", obUsedCarsInfo[0].Phone.ToString());
            //GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
            //GeneralFunction.CheckedInvoke(webBrowser1, "agree");
        }
            

    }
}
