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
    public class freeadsinus : IWebSites
    {
       public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
       {

           string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
           GeneralFunction.LinkInvoke(webBrowser1, statename);
           GeneralFunction.LinkInvoke(webBrowser1, obUsedCarsInfo[0].City .ToString ());
           string city2 = obUsedCarsInfo[0].City.ToString();
           string city1 = "Used cars in " + city2;
           GeneralFunction.LinkInvoke(webBrowser1, city1);
           GeneralFunction.SetTextValue(webBrowser1, "ResourceOffer_11_ResourceOfferTitle", obUsedCarsInfo[0].Title.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "ResourceOffer_11_ResourceOfferPrice", obUsedCarsInfo[0].Price.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "UserField_11_Phone", "3333333333");
           GeneralFunction.SetMultiTextValue(webBrowser1, "ResourceOffer_11_ResourceOfferContent", obUsedCarsInfo[0].Description.ToString());
           GeneralFunction.ButtonClickInvoke(webBrowser1, "uploadFile[ResourceOfferIcon]");

           GeneralFunction.SetTextValue(webBrowser1, "ResourceOffer_11_ResourceOfferKeywords", "CarsForSale");
           GeneralFunction.SetTextValue(webBrowser1, "User_11_Email", "dhanu@gmail.com");
           GeneralFunction.SetTextValue(webBrowser1, "Email2", "dhanu@gmail.com");
           GeneralFunction.SetTextValue(webBrowser1, "User_11_Password", "123456");
           GeneralFunction.SetTextValue(webBrowser1, "UserField_11_FirstName", "dhanu");


       }
            
    }
}
