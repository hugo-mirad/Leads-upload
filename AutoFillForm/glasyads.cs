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
    public class glasyads : IWebSites
    {
       public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
       {
           GeneralFunction.SetTextValue(webBrowser1, "username1", "karunakar@datumglobal.net");
           GeneralFunction.SetTextValue(webBrowser1, "password1", "12345678");
           GeneralFunction.ButtonClick(webBrowser1, "submit");
           GeneralFunction.LinkInvokeDiv(webBrowser1, "newlisting_items_sel", "Automobiles");
           GeneralFunction.LinkInvokeDiv(webBrowser1, "newlisting_items", "Car for Sale");
           GeneralFunction.SetTextValue(webBrowser1, "adtitle", obUsedCarsInfo[0].Title.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
           GeneralFunction.SetMultiTextValue(webBrowser1, "desc", obUsedCarsInfo[0].Description.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "contact_name", obUsedCarsInfo[0].Price.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "laddress1", obUsedCarsInfo[0].Price.ToString());
           GeneralFunction.SetDropDownName(webBrowser1, "lcountry", "India");
           GeneralFunction.SetDropDownName(webBrowser1, "lstate", "Andhra Pradesh");
           GeneralFunction.SetDropDownName(webBrowser1, "currency", "INDIAN RUPEE");
           GeneralFunction.SetTextValue(webBrowser1, "lcity", obUsedCarsInfo[0].City.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "lpincode", obUsedCarsInfo[0].Zip.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "lphoneno", obUsedCarsInfo[0].Phone.ToString());
           GeneralFunction.ButtonClick(webBrowser1, "file");
           GeneralFunction.ButtonClick(webBrowser1, "updatelistings");
           

       }
            

    }
}
