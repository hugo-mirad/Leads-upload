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
    public class adlandpro:IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {
            GeneralFunction.RadioSetValue(webBrowser1, "unauthChoice", "login");
            //GeneralFunction.LinkInvoke(webBrowser1, "Next >>");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$Username", "vinayykumar@gmail.com");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$Password", "123456");
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$pickCategory$ddlCategory", "Automotive");
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$pickSubcategory$ddlSubcategory", "Cars");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$Password", "123456");
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$pickCategory$ddlCategory", "Automotive");
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$txtPhone", obUsedCarsInfo[0].Phone.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$pickCurrency$txtPrice", obUsedCarsInfo[0].Price.ToString());


            // GeneralFunction.LinkInvoke(webBrowser1, "Select a City");
            // string statename = GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
            // GeneralFunction.LinkInvoke(webBrowser1, statename);
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$txtHeading", obUsedCarsInfo[0].Title.ToString());
            GeneralFunction.SetMultiTextValue(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$txtDescription", obUsedCarsInfo[0].Description.ToString());
            GeneralFunction.ButtonClickInvoke(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$cmdCreatePhoto");

            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$mgrAutos$pickYear$ddlYear", obUsedCarsInfo[0].YearOfMake.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$mgrAutos$pickCompany$ddlCarCompany", obUsedCarsInfo[0].Make.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$mgrAutos$txtModel", obUsedCarsInfo[0].Model.ToString());


            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$mgrAutos$pickOdometer$ddlOdometer", obUsedCarsInfo[0].Mileage.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$mgrAutos$pickTransmission$ddlTransmission", obUsedCarsInfo[0].Transmission.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$mgrAutos$pickColour$ddlCarColour", obUsedCarsInfo[0].ExteriorColor.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$mgrAutos$pickDoors$ddlDoors", obUsedCarsInfo[0].NumberOfDoors.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$ctl00$PageContentRoot$MainContent$AdWizard$wcc$mgrAutos$pickCylinders$ddlCylinders", obUsedCarsInfo[0].NumberOfCylinder.ToString());
            GeneralFunction.ButtonClick(webBrowser1, "submit");
            GeneralFunction.ButtonClick(webBrowser1, "file");
            GeneralFunction.ButtonClickByName(webBrowser1, "ctl00$cmdSubmit");
            GeneralFunction.LinkInvoke(webBrowser1, "Next >>");

        }
    }


    
}
