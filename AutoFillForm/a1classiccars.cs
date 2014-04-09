using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoFillForm
{
   public class a1classiccars:IWebSites 
    {

       public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
       {
           if (webBrowser1.Url.ToString() == "http://a1classiccars.com/?view=selectcity&targetview=post&cityid=-9&lang=en")
           {
               string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
               GeneralFunction.LinkInvoke(webBrowser1, statename);
           }
           if (webBrowser1.Url.ToString() != "http://a1classiccars.com/?view=post&cityid=53&lang=en&catid=1&subcatid=1")
           {
               GeneralFunction.LinkInvoke(webBrowser1, "Antique Cars (1900-1945)");
           }
           if (webBrowser1.Url.ToString() != "http://a1classiccars.com/?view=post&cityid=53&lang=en&catid=1&subcatid=1")
           {
               GeneralFunction.LinkInvoke(webBrowser1, "Antique Cars (1900-1945)");
           }

           GeneralFunction.SetTextValue(webBrowser1, "adtitle", obUsedCarsInfo[0].Title.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "area", obUsedCarsInfo[0].City.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "addesc", obUsedCarsInfo[0].Description.ToString());

           GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "x[1]", obUsedCarsInfo[0].YearOfMake.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "x[2]", obUsedCarsInfo[0].Make.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "x[3]", obUsedCarsInfo[0].Model.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "x[4]", obUsedCarsInfo[0].Description.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "x[5]", "3333333333");
           GeneralFunction.SetTextValue(webBrowser1, "x[6]", "emp");
           GeneralFunction.SetTextValue(webBrowser1, "email", "emp@gmail.com");
           GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
           GeneralFunction.CheckedInvoke(webBrowser1, "agree");
           //GeneralFunction.ButtonClickBody(webBrowser1, "submit");

       }
    }
}
