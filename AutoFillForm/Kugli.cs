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
    public class Kugli:IWebSites
    {
        int kug = 0;
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {


            //if (kug == 0)
            //{


            //    GeneralFunction.SetTextValue(webBrowser1, "email", "karunakar@datumglobal.net");
            //    GeneralFunction.SetTextValue(webBrowser1, "password", "9885544156");
            //    GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Login Now");

            //    GeneralFunction.LinkInvoke(webBrowser1, "Sell & Buy");
            //    GeneralFunction.LinkInvoke(webBrowser1, "Post Ad (Free!)");

            //    GeneralFunction.LinkInvoke(webBrowser1, "Cars");
            //    GeneralFunction.LinkInvoke(webBrowser1, "Post a Free Classified Ad Here!");
            //    kug = kug + 1;
            //}


            //else
            //{
                GeneralFunction.SetTextValue(webBrowser1, "adtitle", obUsedCarsInfo[0].Title.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "countryid", "United States");
                GeneralFunction.SetDropDownValue(webBrowser1, "cityid", obUsedCarsInfo[0].City.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "subcatid", "Cars");



                GeneralFunction.SetDropDownValue(webBrowser1, "moreoptionsid1", obUsedCarsInfo[0].Make.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "moreoptionsid2", obUsedCarsInfo[0].YearOfMake.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "moreoptionsid3", obUsedCarsInfo[0].Mileage.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "moreoptionsid4", obUsedCarsInfo[0].ExteriorColor.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "moreoptionsid5", obUsedCarsInfo[0].Bodytype.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "moreoptionsid6", obUsedCarsInfo[0].DriveTrain.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "moreoptionsid7", obUsedCarsInfo[0].Fueltype.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "moreoptionsid8", obUsedCarsInfo[0].Transmission.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "shortcurrency", "United States Dollars - USD");
                GeneralFunction.SetTextValue(webBrowser1, "email", obUsedCarsInfo[0].Email.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "external_link", "");// external link 
                GeneralFunction.SetMultiTextValue(webBrowser1, "addescription", obUsedCarsInfo[0].Description.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "keywords", "");//keywords

             //   GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Save Ad");
           // }
}
        }
    }

