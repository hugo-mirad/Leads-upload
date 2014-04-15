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
    public class fastautosales : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {

               // GeneralFunction.SetTextValue(webBrowser1, "search[zip]", obUsedCarsInfo[0].Zipcode.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "car[year]", obUsedCarsInfo[0].YearOfMake.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "car[mileage]", obUsedCarsInfo[0].Mileage.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "car[car_zip]", obUsedCarsInfo[0].Zipcode.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "car[price]", obUsedCarsInfo[0].Price.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "car[vin]", obUsedCarsInfo[0].VIN.ToString());

                GeneralFunction.SetDropDownName(webBrowser1, "car[make_id]", obUsedCarsInfo[0].Make.ToString());
                GeneralFunction.SetDropDownName(webBrowser1, "car[model_id]", obUsedCarsInfo[0].Model.ToString());
                GeneralFunction.SetDropDownName(webBrowser1, "car[body_style]", obUsedCarsInfo[0].Bodytype.ToString());
                GeneralFunction.SetDropDownName(webBrowser1, "car[color_ext]", obUsedCarsInfo[0].ExteriorColor.ToString());
                GeneralFunction.SetDropDownName(webBrowser1, "car[color_int]", obUsedCarsInfo[0].InteriorColor.ToString());

                if (obUsedCarsInfo[0].NumberOfDoors.Contains("Two"))
                {
                    GeneralFunction.SetDropDownNameandValue(webBrowser1, "car[doors]", "2");
                }
                else if (obUsedCarsInfo[0].NumberOfDoors.Contains("Three"))
                {
                    GeneralFunction.SetDropDownNameandValue(webBrowser1, "car[doors]", "3");
                }
                else if (obUsedCarsInfo[0].NumberOfDoors.Contains("Four"))
                {
                    GeneralFunction.SetDropDownNameandValue(webBrowser1, "car[doors]", "4");
                }
                else if (obUsedCarsInfo[0].NumberOfDoors.Contains("Five"))
                {
                    GeneralFunction.SetDropDownNameandValue(webBrowser1, "car[doors]", "5");
                }
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "car[fuel]", obUsedCarsInfo[0].Fueltype.ToString());
                GeneralFunction.SetDropDownNameandValue(webBrowser1, "car[engine]", obUsedCarsInfo[0].NumberOfCylinder.ToString());

                if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("All"))
                {
                    GeneralFunction.SetDropDownNameandValue(webBrowser1, "car[drive_type]", "AWD");
                }
                else if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("Rear"))
                {
                    GeneralFunction.SetDropDownNameandValue(webBrowser1, "car[drive_type]", "Rear");
                }
                else if (obUsedCarsInfo[0].DriveTrain.ToString().Contains("Front"))
                {
                    GeneralFunction.SetDropDownNameandValue(webBrowser1, "car[drive_type]", "FWD");
                }

                GeneralFunction.SetMultiTextValue(webBrowser1, "car[description]", obUsedCarsInfo[0].Description.ToString());

                GeneralFunction.SetTextValue(webBrowser1, "user[first_name]", obUsedCarsInfo[0].SellerName.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "user[phone]", obUsedCarsInfo[0].Phone.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "user[email]", obUsedCarsInfo[0].Email.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "user[username]", obUsedCarsInfo[0].Email.ToString());
                GeneralFunction.SetTextValue(webBrowser1, "user[password]","123456");
                GeneralFunction.SetTextValue(webBrowser1, "user[password2]","123456");

              //  GeneralFunction.ButtonClickType(webBrowser1, "elm");
              //  GeneralFunction.FileUploadInvoke(webBrowser1, "car_pic");
              //  GeneralFunction.ButtonClickInvokeValue(webBrowser1, "Upload"); 

              //  GeneralFunction.ButtonClickType(webBrowser1, "elm");

              //  GeneralFunction.LinkInvoke(webBrowser1, "Skip step");
 }
  
}
}
