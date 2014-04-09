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
    public class PostFreeAdshere : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {

            GeneralFunction.SetDropDownNameandValue(webBrowser1, "category", "118");
            string clztitle = obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString();
            GeneralFunction.SetTextValue(webBrowser1, "title", clztitle);
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "listcurrency", "USD");
            GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());

            string pmake = obUsedCarsInfo[0].Make.ToString();
            string pmodel = obUsedCarsInfo[0].Model.ToString();
            string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
            string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
            string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
            if (url.Contains(" "))
            {
                url = url.Replace(" ", "%20");
            }

            string dep = obUsedCarsInfo[0].Description.ToString();
            int val = 1000;
            string pn = obUsedCarsInfo[0].Phone.ToString();

            string details = "\r\n Make: " + obUsedCarsInfo[0].Make.ToString() + "\r\n Model: " + obUsedCarsInfo[0].Model.ToString() + "\r\n Year: " + obUsedCarsInfo[0].YearOfMake.ToString() + "\r\n Body Style: " + obUsedCarsInfo[0].Bodytype.ToString() + "\r\n Exterior Color: " + obUsedCarsInfo[0].ExteriorColor.ToString() + "\r\n Interior Color: " + obUsedCarsInfo[0].InteriorColor.ToString() + "\r\n Doors: " + obUsedCarsInfo[0].NumberOfDoors.ToString() + "\r\n Seats: " + obUsedCarsInfo[0].NumberOfSeats.ToString() + "\r\n Price: " + obUsedCarsInfo[0].Price.ToString() + "\r\n Mileage: " + obUsedCarsInfo[0].Mileage.ToString() + "\r\n Fuel: " + obUsedCarsInfo[0].Fueltype.ToString() + "\r\n Transmission: " + obUsedCarsInfo[0].Transmission.ToString() + "\r\n Drive Train: " + obUsedCarsInfo[0].DriveTrain.ToString() + "\r\n Vin: " + obUsedCarsInfo[0].VIN.ToString();


            string URLDesp = WrapTextByMaxCharacters(details, dep, val, url, pn);
            GeneralFunction.SetDivValuebyClass(webBrowser1, "nicEdit-main", URLDesp);

            GeneralFunction.SetTextValue(webBrowser1, "place", obUsedCarsInfo[0].City.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "name", obUsedCarsInfo[0].SellerName.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "email", Globaltxtemail.txtemail);
            GeneralFunction.SetTextValue(webBrowser1, "phone", obUsedCarsInfo[0].Phone.ToString());
            GeneralFunction.FileUploadInvoke(webBrowser1, "pic1");
          //  GeneralFunction.FileUploadInvoke(webBrowser1, "pic2");
            //GeneralFunction.FileUploadInvoke(webBrowser1, "pic3");

        }


        string WrapTextByMaxCharacters(string details, string objText, int intMaxChars, string url, string phone)
        {

            string strReturnValue = "";
            if (objText != null)
            {

                if (objText.ToString().Trim() != "")
                {

                    if (objText.ToString().Trim().Length > intMaxChars)
                    {

                        strReturnValue = details.ToString() + objText.ToString().Trim().Substring(0, intMaxChars) +

                        "..!!!For More Details:  " + url;


                    }

                    else
                    {

                        strReturnValue = details.ToString() + objText.ToString().Trim() + "..!!!For More Details:  " + url;

                    }

                }

            }

            return strReturnValue;
        }
           
    }
}

