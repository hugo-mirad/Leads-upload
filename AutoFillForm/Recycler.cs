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
    public class Recycler : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {

            GeneralFunction.SetTextValue(webBrowser1, "login", "reachandreach@gmail.com");
            GeneralFunction.SetTextValue(webBrowser1, "password", "reach123");
            GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Login");

            GeneralFunction.SetTextValue(webBrowser1, "ZipCode", obUsedCarsInfo[0].Zipcode.ToString());
            GeneralFunction.LinkInvokeOnMouseOver(webBrowser1, "Cars and Vehicles");

            GeneralFunction.LinkInvoke(webBrowser1, "Cars");

            GeneralFunction.ImgeButtonClickInvokeTypeandValue(webBrowser1, "2");

            GeneralFunction.SetTextValue(webBrowser1, "dyn_tex_140", obUsedCarsInfo[0].Price.ToString());
            GeneralFunction.SetDropDownValue(webBrowser1, "dyn_dro_116", obUsedCarsInfo[0].YearOfMake.ToString());
            GeneralFunction.SetDropDownValue(webBrowser1, "dyn_dro_117", obUsedCarsInfo[0].Make.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "dyn_dro_118", obUsedCarsInfo[0].Model.ToString());
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "dyn_dro_122", "755");

            GeneralFunction.SetTextValue(webBrowser1, "dyn_phone", obUsedCarsInfo[0].Phone.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "title", obUsedCarsInfo[0].Title.ToString());
            GeneralFunction.SetMultiTextValue(webBrowser1, "onlinetext", obUsedCarsInfo[0].Description.ToString());

            GeneralFunction.ButtonClickInvoke(webBrowser1, "btn-next");
            ////GeneralFunction.ButtonClickInvoke(webBrowser1, "btn-checkout");

        }
            
         
    }
}
