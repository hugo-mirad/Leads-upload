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
    public class Sell : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {
            GeneralFunction.LinkInvoke(webBrowser1, "Cars & Vehicles");
            GeneralFunction.LinkInvoke(webBrowser1, "Cars");
            GeneralFunction.LinkInvoke(webBrowser1, obUsedCarsInfo[0].Make.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "title", obUsedCarsInfo[0].Title.ToString());
            GeneralFunction.SetMultiTextValue(webBrowser1, "description", obUsedCarsInfo[0].Description.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "asking_price", obUsedCarsInfo[0].Price.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "location_city", obUsedCarsInfo[0].City.ToString());
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "location_state", obUsedCarsInfo[0].State.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "location_postal_code", obUsedCarsInfo[0].Zipcode.ToString());

            GeneralFunction.RadioSetValue(webBrowser1, "shipping_option", "na");
            GeneralFunction.RadioSetValue(webBrowser1, "refund_policy", "ask");
            GeneralFunction.RadioSetValue(webBrowser1, "price_option", "fixed");
            GeneralFunction.RadioSetValue(webBrowser1, "quantity_option", "no_quantity");
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "item_condition", "other");
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "location_country", "840");
            GeneralFunction.ImgeButtonClickInvokeTypeandName(webBrowser1, "action:next");

            GeneralFunction.FileUploadInvoke(webBrowser1, "action:upload-0");
            GeneralFunction.FileUploadInvoke(webBrowser1, "image");
            GeneralFunction.ImgeButtonClickInvokeTypeandName(webBrowser1, "upload");
            GeneralFunction.ImgeButtonClickInvokeTypeandName(webBrowser1, "action:savepost");



        }
            
    }
}
