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
    public class Motoseller : IWebSites
    {
       public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
       {


           //if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=10&amp;c=a*is*1")
           //{
           //    GeneralFunction.LinkInvoke(webBrowser1, "Click Here");
           //}

           string email = "dhanurao";
           string password = "123456";
           GeneralFunction.SetTextValue(webBrowser1, "b[username]",email);
           GeneralFunction.SetTextValue(webBrowser1, "b[password]", password);
           if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=10&amp;c=a*is*1")
           {
               GeneralFunction.ButtonClick(webBrowser1, "submit");
           }
           // GeneralFunction.LinkInvokeMotoSeller(webBrowser1);LinkInvokep3
           //  GeneralFunction.LinkInvokep3(webBrowser1);
           //
           GeneralFunction.LinkInvoke(webBrowser1, "\r\nPlace New Ad");
           if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=1")
           {
               GeneralFunction.LinkInvokeMotoSeller(webBrowser1, "category_links");
           }
           if (webBrowser1.Url.ToString() == "http://usa.motoseller.com/c/sys.php?a=1&b=302&set_cat=1")
           {
               GeneralFunction.LinkInvokeContainsMotoSeller(webBrowser1, "category_links");
           }
           string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
           GeneralFunction.LinkInvokeMotoSellerStateName(webBrowser1, "category_links", statename);


           GeneralFunction.SetTextValue(webBrowser1, "b[classified_title]", obUsedCarsInfo[0].Title.ToString());
           GeneralFunction.SetMultiTextValue(webBrowser1, "b[description]", obUsedCarsInfo[0].Description.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[price]", obUsedCarsInfo[0].Price.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[city]", obUsedCarsInfo[0].City.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[optional_field_5]", obUsedCarsInfo[0].VIN.ToString());
           string statename1 = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
           GeneralFunction.SetDropDownValue(webBrowser1, "b[state]", statename1);
           GeneralFunction.SetDropDownValue(webBrowser1, "b[question_value][170]", "Coupe");
           GeneralFunction.SetDropDownValue(webBrowser1, "b[question_value][168]", obUsedCarsInfo[0].Transmission.ToString());
           GeneralFunction.SetDropDownValue(webBrowser1, "b[question_value][165]", obUsedCarsInfo[0].DriveTrain.ToString());
           GeneralFunction.SetDropDownValue(webBrowser1, "b[question_value][165]", obUsedCarsInfo[0].DriveTrain.ToString());
           GeneralFunction.SetDropDownValue(webBrowser1, "b[question_value][167]", "Used - Clean");
           GeneralFunction.SetTextValue(webBrowser1, "b[optional_field_2]", obUsedCarsInfo[0].Model.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[optional_field_3]", obUsedCarsInfo[0].YearOfMake.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[optional_field_1]", obUsedCarsInfo[0].Make.ToString());
           //GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Enter Ad Details >>");
           //GeneralFunction.FileUploadInvoke(webBrowser1, "d[1]");
           //GeneralFunction.ButtonClickInvoke(webBrowser1, "c[no_images]");
           //GeneralFunction.LinkInvoke(webBrowser1, "Approve this ad");
           //GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Calculate Total");
           



       

            


       }

            

    }
}
