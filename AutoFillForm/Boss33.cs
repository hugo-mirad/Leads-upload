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
    public class Boss33 : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {
            GeneralFunction.LinkInvoke(webBrowser1, obUsedCarsInfo[0].City.ToString());
            GeneralFunction.LinkInvoke(webBrowser1, "Cars & vehicles");
            GeneralFunction.LinkInvoke(webBrowser1, "Cars");
            GeneralFunction.SetTextValue(webBrowser1, "adtitle", obUsedCarsInfo[0].Title.ToString());
            string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "area", statename);
            GeneralFunction.SetMultiTextValue(webBrowser1, "addesc", obUsedCarsInfo[0].Description.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "email", obUsedCarsInfo[0].Email.ToString());
            GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
            GeneralFunction.CheckedInvoke(webBrowser1, "agree");
            GeneralFunction.ButtonClick(webBrowser1, "submit");

        }
            

    }
}
