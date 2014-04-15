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
    public class list2click : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {
            GeneralFunction.SetTextValue(webBrowser1, "Price_post_", obUsedCarsInfo[0].Price.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "Ad_post_Title", obUsedCarsInfo[0].Title.ToString());
            GeneralFunction.SetMultiTextValue(webBrowser1, "mceContentBody", obUsedCarsInfo[0].Description.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "Email_post_Address", obUsedCarsInfo[0].Email.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "_post_Phone", obUsedCarsInfo[0].Phone.ToString());
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "guiAdCountry", "1");
            string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
            GeneralFunction.SetDropDownValue(webBrowser1, "guiAdState", statename);
            GeneralFunction.SetTextValue(webBrowser1, "Map_post_Adress", "dfnhjsfj");
            GeneralFunction.SetTextValue(webBrowser1, "Address_post_Zip", "10954");
           // GeneralFunction.ButtonClick(webBrowser1, "submit");


        }
            

    }
}
