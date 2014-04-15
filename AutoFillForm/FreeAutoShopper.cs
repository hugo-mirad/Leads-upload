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
    public class FreeAutoShopper : IWebSites
    {
         public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
         {
         
                //Website == "freeautoshopper"
                GeneralFunction.SetDropDownValue(webBrowser1, "top_category", "Autos");
                // GeneralFunction.SetDropDownName(webBrowser1, "sub_category", "Cars - Trucks");
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "sub_category", "1:3");
                GeneralFunction.SetTextValue(webBrowser1, "name", obUsedCarsInfo[0].Title.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
                GeneralFunction.SetBodyValuebyClass(webBrowser1, "mceContentBody", obUsedCarsInfo[0].Description.ToString());
                GeneralFunction.FileUploadInvoke(webBrowser1, "image1");

                GeneralFunction.SetTextValue(webBrowser1, "seller_name", obUsedCarsInfo[0].SellerName.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "seller_email", obUsedCarsInfo[0].Email.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "c_seller_email", obUsedCarsInfo[0].Email.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "seller_phone", obUsedCarsInfo[0].Phone.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "seller_url", "www.unitedcarexchange.com");

                string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
                GeneralFunction.SetDropDownValue(webBrowser1, "state", statename);
                GeneralFunction.SetDropDownValue(webBrowser1, "city", obUsedCarsInfo[0].City.ToString());

                GeneralFunction.SetTextValue(webBrowser1, "address", obUsedCarsInfo[0].Address1.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "neighborhood", obUsedCarsInfo[0].Address2.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "zip_code", obUsedCarsInfo[0].Zipcode.ToString());
            

     }
    }
}
