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
    public class reachoo : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {
            GeneralFunction.SetDropDownName(webBrowser1, "ad[category_id]", "For Sale");
            GeneralFunction.SetDropDownName(webBrowser1, "ad[sub_category_id]", "Cars, boats, vehicles & parts");
            string st_Code = obUsedCarsInfo[0].State.ToString();
            string city = obUsedCarsInfo[0].City.ToString();
            string country = "USA";
            string Location = city + "," + st_Code + "," + country;
            //string Location1 = city + "," + st_Code + "," + country;ad[selected_location]
            GeneralFunction.SetTextValue(webBrowser1, "ad[selected_location]", Location);
            GeneralFunction.SetTextValue(webBrowser1, "ad[title]", obUsedCarsInfo[0].Title.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ad[price]", obUsedCarsInfo[0].Price.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "margin:4px; font:10pt Arial,Verdana; cursor:text", obUsedCarsInfo[0].Description.ToString());

            GeneralFunction.SetDropDownName(webBrowser1, "ad[ad_properties_attributes][1364452365.9347095][value]", obUsedCarsInfo[0].Make.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ad[ad_properties_attributes][1364452391.7488933][value]", obUsedCarsInfo[0].Model.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ad[ad_properties_attributes][1364452365.9559278][value]", obUsedCarsInfo[0].Bodytype.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ad[ad_properties_attributes][1364452366.2309475][value]", obUsedCarsInfo[0].ExteriorColor.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ad[street]", obUsedCarsInfo[0].Address1.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ad[city]", obUsedCarsInfo[0].City.ToString());
            // GeneralFunction.SetTextValue(webBrowser1, "ad[postal_code]", obUsedCarsInfo[0].Title.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ad[email]", obUsedCarsInfo[0].Email.ToString());
            GeneralFunction.ButtonClick(webBrowser1, "submit");
        }

    }
}
