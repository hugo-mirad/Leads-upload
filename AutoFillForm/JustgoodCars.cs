
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
    // static int count = 0;
    public class JustgoodCars : IWebSites
    {
        
     public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
        {



            GeneralFunction.SetTextValue(webBrowser1, "email", "emp");
         GeneralFunction.SetTextValue(webBrowser1, "password", "ruba123456");
         if (webBrowser1.Url.ToString() != "http://www.justgoodcars.com/members/advertise1.php")
         {
             GeneralFunction.ButtonClickInvoke(webBrowser1, "Submit");
          
         }
        
             GeneralFunction.LinkInvoke(webBrowser1, "Advertise a car >");
          
         

         //************justgoodcars
         //Step1
         //GeneralFunction.SetTextValue(webBrowser1, "first_name", obUsedCarsInfo[0].SellerName.ToString());
         //GeneralFunction.SetTextValue(webBrowser1, "last_name", "abjkot");
         //GeneralFunction.SetTextValue(webBrowser1, "street_address_1", obUsedCarsInfo[0].Address1.ToString());
         //GeneralFunction.SetDropDownValue(webBrowser1, "country", "US");
         //GeneralFunction.SetTextValue(webBrowser1, "city", obUsedCarsInfo[0].City.ToString());
         //GeneralFunction.SetTextValue(webBrowser1, "postcode", obUsedCarsInfo[0].Zipcode.ToString());
         //GeneralFunction.SetTextValue(webBrowser1, "home_phone", obUsedCarsInfo[0].Phone.ToString());
         //GeneralFunction.SetTextValue(webBrowser1, "email", obUsedCarsInfo[0].Email.ToString());//email
         //GeneralFunction.SetTextValue(webBrowser1, "password", "ruba123456");
         //GeneralFunction.CheckedInvoke(webBrowser1, "terms");
         //GeneralFunction.ButtonClickInvoke(webBrowser1, "Submit");//RegistrationButton

         //Step2
         // GeneralFunction.LinkInvoke(webBrowser1, "Login");//AfterRegistration Login Button

         //Step3
        
             GeneralFunction.SetDropDownValue(webBrowser1, "make", obUsedCarsInfo[0].Make.ToString());
             GeneralFunction.SetDropDownValue(webBrowser1, "model", obUsedCarsInfo[0].Model.ToString());
            
         
         if (webBrowser1.Url.ToString() != "http://www.justgoodcars.com/members/advertise1.php")
         {
             GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");//MakeMode Button
            
         }


         string name = obUsedCarsInfo[0].Make.ToString()+" "+ obUsedCarsInfo[0].Model.ToString();

         GeneralFunction.SetTextValue(webBrowser1, "name", name);
             GeneralFunction.SetTextValue(webBrowser1, "vin", obUsedCarsInfo[0].VIN.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "interior", obUsedCarsInfo[0].InteriorColor.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "fuel", obUsedCarsInfo[0].Fueltype.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "capacity", obUsedCarsInfo[0].NumberOfSeats.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "mileage", obUsedCarsInfo[0].Mileage.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "year", obUsedCarsInfo[0].YearOfMake.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "power", obUsedCarsInfo[0].NumberOfCylinder);
             GeneralFunction.SetTextValue(webBrowser1, "stereo", "------");
             GeneralFunction.SetTextValue(webBrowser1, "colour", obUsedCarsInfo[0].ExteriorColor.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "price", obUsedCarsInfo[0].Price.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "telmobno", obUsedCarsInfo[0].Phone.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "city", obUsedCarsInfo[0].City.ToString());
             GeneralFunction.SetTextValue(webBrowser1, "postcode", obUsedCarsInfo[0].Zip.ToString());
             GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "View / Edit");//MakeMode Button


             string pmake = obUsedCarsInfo[0].Make.ToString();
             string pmodel = obUsedCarsInfo[0].Model.ToString();
             string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
             string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
             string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";


             string dep = obUsedCarsInfo[0].Description.ToString();
             int val = 1000;
             string pn = obUsedCarsInfo[0].Phone.ToString();


             string URLDesp = WrapTextByMaxCharacters(dep, val, url, pn);


             GeneralFunction.SetMultiTextValue(webBrowser1, "description", URLDesp);

             GeneralFunction.SetDropDownValue(webBrowser1, "bodytype", obUsedCarsInfo[0].Bodytype.ToString());
             GeneralFunction.SetDropDownValue(webBrowser1, "doors", obUsedCarsInfo[0].NumberOfDoors.ToString());

             GeneralFunction.SetDropDownValue(webBrowser1, "steering", "Right Hand Drive");
             //GeneralFunction.SetDropDownValue(webBrowser1, "mileage1", obUsedCarsInfo[0].Make.ToString());--km/miles
             GeneralFunction.SetDropDownValue(webBrowser1, "gearbox", obUsedCarsInfo[0].Transmission.ToString());


             //if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/advertise1.php")
             //{
             //    GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");//submit details

             //}
             
         
                 

         GeneralFunction.ButtonClickBYTypeAndValue(webBrowser1, "Upload Pictures >");
         if (webBrowser1.Url.ToString() == "http://www.justgoodcars.com/members/adverts_edit_image-upload.php")
         {

             GeneralFunction.LinkInvoke(webBrowser1, "Try this Simple Upload Tool");
         }
         
        
         //FREE> button invoke

     }




     string WrapTextByMaxCharacters(string objText, int intMaxChars, string url, string phone)
        {

            string strReturnValue = "";
            if (objText != null)
            {

                if (objText.ToString().Trim() != "")
                {

                    if (objText.ToString().Trim().Length > intMaxChars)
                    {

                        strReturnValue = objText.ToString().Trim().Substring(0, intMaxChars) +

                         "..!!\r\nIf instrested please contact : " + phone + "\r\n\r\n For More Details:  " + url;


                    }

                    else
                    {

                        strReturnValue = objText.ToString().Trim() + "\r\n" + "\r\n" +  "\r\n If instrested please contact : " + phone + "\r\n\r\n For More Details:  " + url;

                    }

                }

            }

            return strReturnValue;
        }
    }
}
