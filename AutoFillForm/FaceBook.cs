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
  public  class FaceBook:IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {

            GeneralFunction.SetTextValue(webBrowser1, "email", "vinayy5544@gmail.com");
            GeneralFunction.SetTextValue(webBrowser1, "pass", "vinayy12345");



            
        }
    }
}
