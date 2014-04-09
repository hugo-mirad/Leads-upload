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
    public class Locanto : IWebSites
    {
       public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
       {


           GeneralFunction.LinkInvoke(webBrowser1, "Vehicles");


           GeneralFunction.LinkInvoke(webBrowser1, "used cars");
           if (obUsedCarsInfo[0].Make.ToString() == "Mercedes-Benz")
           {
               GeneralFunction.LinkInvoke(webBrowser1, "Mercedes Benz");
           }
           else
           {
               GeneralFunction.LinkInvoke(webBrowser1, obUsedCarsInfo[0].Make.ToString());
           }
           GeneralFunction.LinkInvoke(webBrowser1, "Proceed  »");
           GeneralFunction.SetTextValue(webBrowser1, "subject", obUsedCarsInfo[0].Title.ToString());
           GeneralFunction.SetDivValuebyClass(webBrowser1, "redactor_ redactor_editor", obUsedCarsInfo[0].Description.ToString());
           // GeneralFunction.SetMultiTextValue(webBrowser1, "description", obUsedCarsInfo[0].Description.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
           GeneralFunction.FileUploadInvoke(webBrowser1, "img_name_input[1]");
           GeneralFunction.SetTextValue(webBrowser1, "mapStreet", obUsedCarsInfo[0].Address1.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "mapCity", obUsedCarsInfo[0].City.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "mapZip", obUsedCarsInfo[0].Zipcode.ToString());
           GeneralFunction.ButtonClickInvoke(webBrowser1, "Update map »");

           GeneralFunction.SetTextValue(webBrowser1, "replyEmail", obUsedCarsInfo[0].Email.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "replyEmail2", obUsedCarsInfo[0].Email.ToString());



       } 

            
    }
}
