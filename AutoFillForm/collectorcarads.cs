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
    public class collectorcarads : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {
          
                string Email = "emp@gmail.com";
                GeneralFunction.SetTextValue(webBrowser1, "username", Email);
                string passwrd = "123";
                GeneralFunction.SetTextValue(webBrowser1, "password", passwrd);
                GeneralFunction.ButtonClick(webBrowser1, "submit");
                // Thread.Sleep(10000);
                GeneralFunction.LinkInvokehf(webBrowser1);


                if (obUsedCarsInfo[0].Make.ToString() == "Mercedes-Benz")
                {
                    GeneralFunction.SetDropDownName(webBrowser1, "make", "Mercedes");
                }
                else if (obUsedCarsInfo[0].Make.ToString() == "hummer")
                {
                    GeneralFunction.SetDropDownName(webBrowser1, "make", "humber");
                }
                else if (obUsedCarsInfo[0].Make.ToString() == "Rolls-Royce")
                {
                    GeneralFunction.SetDropDownName(webBrowser1, "make", "RollsRoyce");
                }
                else
                {
                    GeneralFunction.SetDropDownName(webBrowser1, "make", obUsedCarsInfo[0].Make.ToString());
                }


                //GeneralFunction.SetDropDownName(webBrowser1, "make", obUsedCarsInfo[0].Make.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "model", obUsedCarsInfo[0].Model.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "year", obUsedCarsInfo[0].YearOfMake.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "body", obUsedCarsInfo[0].Bodytype.ToString());
                // GeneralFunction.SetTextValue(webBrowser1, "engine", obUsedCarsInfo[0]..ToString());
                GeneralFunction.SetTextValue(webBrowser1, "exterior", obUsedCarsInfo[0].ExteriorColor.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "interior", obUsedCarsInfo[0].InteriorColor.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "city", obUsedCarsInfo[0].City.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "mileage", obUsedCarsInfo[0].Mileage.ToString());
                GeneralFunction.SetMultiTextValue(webBrowser1, "description", obUsedCarsInfo[0].Description.ToString());
                // GeneralFunction.SetTextValue(webBrowser1, "mileage", obUsedCarsInfo[0].Mileage.ToString());
                if (webBrowser1.Url.ToString() == "http://www.collectorcarads.com/createad.asp")
                {
                    GeneralFunction.ButtonClick(webBrowser1, "Submit");
                }
                GeneralFunction.LinkInvokepic(webBrowser1);
                GeneralFunction.LinkInvokeCollectorCarsPic(webBrowser1);
                GeneralFunction.ButtonClick(webBrowser1, "file");
            // GeneralFunction.ButtonClick(webBrowser1, "Submit");
        }

    }
}
