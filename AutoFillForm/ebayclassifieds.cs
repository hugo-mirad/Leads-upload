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
    class ebayclassifieds : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {
           
                GeneralFunction.SetTextValue(webBrowser1, "title", obUsedCarsInfo[0].Title.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price .ToString());
                GeneralFunction.SetTextValue(webBrowser1, "cars.year", obUsedCarsInfo[0].YearOfMake.ToString());
                GeneralFunction.SetDropDownName(webBrowser1, "cars.make", obUsedCarsInfo[0].Make.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "cars.model", obUsedCarsInfo[0].Model.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "cars.mileage", obUsedCarsInfo[0].Mileage.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "cars.vin", obUsedCarsInfo[0].VIN.ToString());
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "cars.forSaleBy", "Owner");
                GeneralFunction.SetMultiTextValue(webBrowser1, "description", obUsedCarsInfo[0].Description.ToString());
                GeneralFunction.FileUploadInvoke(webBrowser1, "u");
                GeneralFunction.SetTextValue(webBrowser1, "email", obUsedCarsInfo[0].Email.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "phoneNumber", obUsedCarsInfo[0].Phone.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "streetAddress", obUsedCarsInfo[0].Address1.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "zipCode", obUsedCarsInfo[0].Zipcode.ToString());
               GeneralFunction.ButtonClickInvoke(webBrowser1, "btn-previwe-ad");
            

    }
    }
}
