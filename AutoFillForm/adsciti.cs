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
    public class adsciti : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {


           int Myear=Convert.ToInt32(obUsedCarsInfo[0].YearOfMake.ToString());
           string title = "";
           if (a)
           {
               GeneralFunction.SetDropDownNameandValue(webBrowser1, "category", "117");
           }
           else
           {
               if (Myear < 1991)
               {
                   GeneralFunction.SetDropDownNameandValue(webBrowser1, "category", "125");
               }
               else
               {
                   GeneralFunction.SetDropDownNameandValue(webBrowser1, "category", "118");
               }
           }
           if (obUsedCarsInfo[0].Title != "Emp")
           {
               title = obUsedCarsInfo[0].Title;//+ "-" + "$"+obUsedCarsInfo[0].Price.ToString();
           }
           else
           {
               if (obUsedCarsInfo[0].Model.ToString() != "Other")
                   title = obUsedCarsInfo[0].YearOfMake.ToString() + "  " + obUsedCarsInfo[0].Make.ToString() + "  " + obUsedCarsInfo[0].Model.ToString();//+ " - " + "$"+obUsedCarsInfo[0].Price.ToString();
               else
                   title = obUsedCarsInfo[0].YearOfMake.ToString() + "  " + obUsedCarsInfo[0].Make.ToString();// +" - " + "$" + obUsedCarsInfo[0].Price.ToString();
           }
           GeneralFunction.SetTextValue(webBrowser1, "title", title);//obUsedCarsInfo[0].Title.ToString()
            if (obUsedCarsInfo[0].Price.ToString() == "0")
            {
                GeneralFunction.SetTextValue(webBrowser1, "price", "1");
            }
            else
            {
                GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
            }
            // GeneralFunction.SetDivValuebyClass(webBrowser1, "nicEdit-main", obUsedCarsInfo[0].Description.ToString());

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
            if (details.Contains("Emp"))
            {
                details = details.Replace("Emp", "");
            }

            //string URLDesp = WrapTextByMaxCharacters(details, dep, val, url, pn);
            string URLDesp = details.ToString() + "\r\n" + "\n" + "Description: " + dep.Trim() + "..!! If intrested contact : " + pn + "..!!!For More Details:  " ;
            GeneralFunction.SetMultiTextName(webBrowser1, "description", URLDesp + url);
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "location", "36");

            string city = obUsedCarsInfo[0].City.ToString() + " " + obUsedCarsInfo[0].State.ToString() + " " + obUsedCarsInfo[0].Zip.ToString();
            GeneralFunction.SetTextValue(webBrowser1, "place", obUsedCarsInfo[0].City.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "name", "UCECRV");
            GeneralFunction.SetTextValue(webBrowser1, "email", Globaltxtemail.txtemail);
            GeneralFunction.SetTextValue(webBrowser1, "phone", obUsedCarsInfo[0].Phone.ToString());
            GeneralFunction.FileUploadInvoke(webBrowser1, "pic1");
            //GeneralFunction.FileUploadInvoke(webBrowser1, "pic2");
           // GeneralFunction.FileUploadInvoke(webBrowser1, "pic3");

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

                       "..!! If intrested contact : " + phone + "..!!!For More Details:  " + url;


                    }

                    else
                    {

                        strReturnValue = details.ToString() + objText.ToString().Trim() + "..!! If intrested contact : " + phone + "..!!!For More Details:  " + url;

                    }

                }

            }

            return strReturnValue;
        }
    }
}