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
    public class biggestclassifieds : IWebSites
    {
       public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
       {
           // GeneralFunction.LinkInvoke(webBrowser1, obUsedCarsInfo[0]..ToString());
           GeneralFunction.LinkInvoke(webBrowser1, "Automobiles");
           GeneralFunction.LinkInvoke(webBrowser1, "Car");

           GeneralFunction.SetTextValue(webBrowser1, "adtitle", obUsedCarsInfo[0].Title.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "area", obUsedCarsInfo[0].Address1.ToString());
           GeneralFunction.SetMultiTextValue(webBrowser1, "addesc", obUsedCarsInfo[0].Description.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "email", obUsedCarsInfo[0].Email.ToString());
           GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
           GeneralFunction.CheckedInvoke(webBrowser1, "othercontactok");
           GeneralFunction.CheckedInvoke(webBrowser1, "agree");
         
       }
                   

            
    }
}
