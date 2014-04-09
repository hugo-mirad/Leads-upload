using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoFillForm
{
   public  class kedna:IWebSites 
    {
       public void carpostfunc(WebBrowser webBrowser1, IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo,bool a)
       {
           GeneralFunction.SetTextValue(webBrowser1, "b[username]", "reachandreach@gmail.com");
           GeneralFunction.SetTextValue(webBrowser1, "b[password]", "reach123");
           GeneralFunction.ButtonClickByValue(webBrowser1, "Login >>");


           GeneralFunction.LinkInvoke(webBrowser1, "Start Over");
           GeneralFunction.SpanInnerText(webBrowser1, "Cars & Vehicles");
           GeneralFunction.SpanInnerText(webBrowser1, "Cars");

           GeneralFunction.SetTextValue(webBrowser1, "b[classified_title]", obUsedCarsInfo[0].Title.ToString());
           GeneralFunction.SetMultiTextValue (webBrowser1 ,"b[description]",obUsedCarsInfo [0].Description .ToString ());
           GeneralFunction.SetTextValue (webBrowser1 ,"b[price]",obUsedCarsInfo [0].Price .ToString ());
           GeneralFunction.SetTextValue (webBrowser1 ,"b[email_option]",obUsedCarsInfo [0].Email.ToString ());
           GeneralFunction.SetTextValue (webBrowser1 ,"b[phone_1_option]",obUsedCarsInfo [0].Phone.ToString ());
           GeneralFunction.SetTextValue (webBrowser1 ,"b[address]",obUsedCarsInfo [0].Address1.ToString ());
           GeneralFunction.SetDropDownName(webBrowser1, "geoRegion_location[2]", obUsedCarsInfo[0].State.ToString());
           GeneralFunction.SetDropDownName(webBrowser1, "geoRegion_location[3]", obUsedCarsInfo[0].City.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[zip_code]", obUsedCarsInfo[0].Zipcode.ToString());

           GeneralFunction.SetTextValue(webBrowser1,"b[url_link_1]","www.unitedcarexchange.com");
           GeneralFunction.SetTextValue(webBrowser1, "b[optional_field_15]", obUsedCarsInfo[0].VIN.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[question_value][92]", obUsedCarsInfo[0].Make.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[question_value][93]", obUsedCarsInfo[0].Model.ToString());

           GeneralFunction.SetDropDownName(webBrowser1, "b[question_value][94]", obUsedCarsInfo[0].YearOfMake.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[question_value_other][95]", obUsedCarsInfo[0].ConditionDescription.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[question_value_other][96]", obUsedCarsInfo[0].Transmission.ToString());

           GeneralFunction.SetDropDownName(webBrowser1, "b[question_value][97]", obUsedCarsInfo[0].NumberOfCylinder.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[question_value_other][98]", obUsedCarsInfo[0].InteriorColor.ToString());
           GeneralFunction.SetTextValue(webBrowser1, "b[question_value_other][99]", obUsedCarsInfo[0].ExteriorColor.ToString());

           GeneralFunction.ButtonClickInvoke(webBrowser1, "submit");
           GeneralFunction.ButtonClickByValue(webBrowser1, "Continue >>");
           GeneralFunction.ButtonClickByValue(webBrowser1, "Next Step >>");





       }
    }
}
