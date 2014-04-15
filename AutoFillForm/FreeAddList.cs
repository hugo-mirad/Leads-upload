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
   public class FreeAddList : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {


            //  Website == "freeaddlist"
            GeneralFunction.SetDropDownName(webBrowser1, "cat", "For Sale");
            GeneralFunction.SetDropDownValue(webBrowser1, "subcat", "Autos");
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "cnty", "5");
            string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
            GeneralFunction.SetDropDownValue(webBrowser1, "state", statename);
            obUsedCarsInfo[0].YearOfMake.ToString();
            string clztitle = obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString();
            GeneralFunction.SetTextValue(webBrowser1, "title", clztitle);
            GeneralFunction.SetDropDownValue(webBrowser1, "city", obUsedCarsInfo[0].City.ToString());
           // GeneralFunction.SetTextValue(webBrowser1, "title", "qwertyyu");
            GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
            GeneralFunction.CheckedInvoke(webBrowser1, "adult");
            GeneralFunction.SetBodyValuebyClass(webBrowser1, "mceContentBody", obUsedCarsInfo[0].Description.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "email", obUsedCarsInfo[0].Email.ToString());
            GeneralFunction.CheckedInvoke(webBrowser1, "oki");
            GeneralFunction.LinkInvoke(webBrowser1, "Click here to upload pictures");
            GeneralFunction.CheckedInvoke(webBrowser1, "trei");
            // GeneralFunction.ImgeButtonClickInvoke(webBrowser1, "Post Ad");
        }
    }
}
