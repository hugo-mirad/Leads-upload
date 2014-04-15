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
    public class cathaylist : IWebSites
    {
        public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {
            int pcthy = 0;


            //if (webBrowser1.Url.ToString() == "http://www.cathaylist.com/?view=selectcity&targetview=post&cityid=0&lang=en")
            //{

            //    string cityex = obUsedCarsInfo[0].City.ToString();
            //    GeneralFunction.LinkInvoke(webBrowser1, cityex);
            //}

            //GeneralFunction.LinkInvoke(webBrowser1, "Cars & vehicles");
            //GeneralFunction.LinkInvoke(webBrowser1, "Cars");
            string clztitle = ""; // obUsedCarsInfo[0].YearOfMake.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString();
            if (obUsedCarsInfo[0].Title != "Emp")
            {
                clztitle = obUsedCarsInfo[0].Title + "-" + "$"+obUsedCarsInfo[0].Price.ToString();
            }
            else
            {
                if (obUsedCarsInfo[0].Model.ToString() != "Other")
                    clztitle = obUsedCarsInfo[0].YearOfMake.ToString() + "  " + obUsedCarsInfo[0].Make.ToString() + "  " + obUsedCarsInfo[0].Model.ToString() + " - " + "$"+obUsedCarsInfo[0].Price.ToString();
                else
                    clztitle = obUsedCarsInfo[0].YearOfMake.ToString() + "  " + obUsedCarsInfo[0].Make.ToString() + " - " + "$"+obUsedCarsInfo[0].Price.ToString();
            }
            GeneralFunction.SetTextValue(webBrowser1, "adtitle", clztitle);
            string statename = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
            GeneralFunction.SetTextValue(webBrowser1, "area", statename);

            string pmake = obUsedCarsInfo[0].Make.ToString();
            string pmodel = obUsedCarsInfo[0].Model.ToString();
            string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
            string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();

            string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";


            string dep = obUsedCarsInfo[0].Description.ToString();
            int val = 1000;
            string pn = obUsedCarsInfo[0].Phone.ToString();

            string details = "\r\n Make: " + obUsedCarsInfo[0].Make.ToString() + "\r\n Model: " + obUsedCarsInfo[0].Model.ToString() + "\r\n Year: " + obUsedCarsInfo[0].YearOfMake.ToString() + "\r\n Body Style: " + obUsedCarsInfo[0].Bodytype.ToString() + "\r\n Exterior Color: " + obUsedCarsInfo[0].ExteriorColor.ToString() + "\r\n Interior Color: " + obUsedCarsInfo[0].InteriorColor.ToString() + "\r\n Doors: " + obUsedCarsInfo[0].NumberOfDoors.ToString() + "\r\n Seats: " + obUsedCarsInfo[0].NumberOfSeats.ToString() + "\r\n Price: " + obUsedCarsInfo[0].Price.ToString() + "\r\n Mileage: " + obUsedCarsInfo[0].Mileage.ToString() + "\r\n Fuel: " + obUsedCarsInfo[0].Fueltype.ToString() + "\r\n Transmission: " + obUsedCarsInfo[0].Transmission.ToString() + "\r\n Drive Train: " + obUsedCarsInfo[0].DriveTrain.ToString() + "\r\n Vin: " + obUsedCarsInfo[0].VIN.ToString();
            string URLDesp = WrapTextByMaxCharacters(details,dep, val, url, pn);

            GeneralFunction.SetMultiTextValue(webBrowser1, "addesc", URLDesp);
            GeneralFunction.SetTextValue(webBrowser1, "email", Globaltxtemail.txtemail);
            GeneralFunction.SetTextvaluebyName(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
            if (pcthy == 0)
            {
                GeneralFunction.FileUploadInvoke(webBrowser1, "pic[]");
                pcthy++;
            }
            GeneralFunction.CheckedInvoke(webBrowser1, "agree");



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

                       "..!! If instrested contact : " + phone + "..!!!For More Details:  " + url;


                    }

                    else
                    {

                        strReturnValue = details.ToString() + objText.ToString().Trim() + "..!! If instrested contact : " + phone + "..!!!For More Details:  " + url;

                    }

                }

            }

            return strReturnValue;
        }
    }
}
