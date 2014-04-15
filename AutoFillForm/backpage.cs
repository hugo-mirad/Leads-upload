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
 public class backpage: IWebSites
    {

     public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
     {

                if (webBrowser1.Url.ToString() == "http://farmington.backpage.com/")
                {
                    string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
                    GeneralFunction.SetDropDownID(webBrowser1, "city_filter_selector", statename);
                    string City1 = obUsedCarsInfo[0].City.ToString();
                    string State1 = obUsedCarsInfo[0].State.ToString();
                    string city2 = City1.Trim() + ", " + State1;
                    string city3 = city2.Trim();
                    string lwcity = city3.ToLower();
                    GeneralFunction.LinkInvoke(webBrowser1, lwcity);
                    //  GeneralFunction.ButtonClickID(webBrowser1, "postAdButton");
                }
                   //Thread.Sleep(2000);
                //GeneralFunction.ButtonClickID(webBrowser1, "postAdButton");

                if (webBrowser1.Url.ToString() != "http://farmington.backpage.com/")
                {


                    GeneralFunction.LinkInvoke(webBrowser1, "automotive");
                    GeneralFunction.LinkInvoke(webBrowser1, "autos for sale");
                    string mcity = obUsedCarsInfo[0].City.ToString().Trim();
                    GeneralFunction.LinkInvoke(webBrowser1, mcity);
                    GeneralFunction.SetTextValue(webBrowser1, "title", obUsedCarsInfo[0].Title.ToString());
                    GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
                    GeneralFunction.SetTextValue(webBrowser1, "regionOther", obUsedCarsInfo[0].City.ToString());
                    GeneralFunction.SetTextValue(webBrowser1, "mapCrossStreetB", obUsedCarsInfo[0].City.ToString());
                    GeneralFunction.SetTextValue(webBrowser1, "mapCrossStreetA", obUsedCarsInfo[0].Address1.ToString());
                    GeneralFunction.SetTextValue(webBrowser1, "regionOther", obUsedCarsInfo[0].City.ToString());
                    GeneralFunction.SetTextValue(webBrowser1, "mapAddress", obUsedCarsInfo[0].Address1.ToString());
                    GeneralFunction.SetTextValue(webBrowser1, "mapZip", obUsedCarsInfo[0].Zip.ToString());
                    GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Zip.ToString());

                    GeneralFunction.SetTextValue(webBrowser1, "mapCrossStreetZip", obUsedCarsInfo[0].Zip.ToString());



                    GeneralFunction.SetMultiTextValue(webBrowser1, "ad", obUsedCarsInfo[0].Description.ToString());
                    GeneralFunction.SetTextValue(webBrowser1, "email", "emp@gmail.com");
                    GeneralFunction.SetTextValue(webBrowser1, "emailConfirm", "emp@gmail.com");
                    GeneralFunction.SetTextValue(webBrowser1, "contactPhone", obUsedCarsInfo[0].Phone.ToString());
                    GeneralFunction.ButtonClick(webBrowser1, "file");
                    GeneralFunction.ButtonClick(webBrowser1, "submit");
                }

}



    }
}
