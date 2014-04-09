using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFillForm
{
   public class GetStatesMotoseller
    {
       public static string GetStateName(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo, string stateid, string carid)
       {

       
            string state = string.Empty;
            string funcountry = string.Empty;

            if (obUsedCarsInfo[0].State.ToString() == "PA")
            {
                state = "Pennsylvania,353";
              //  funcountry ="112";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "TX")
            {
                state = "Texas,113";
               //funcountry ="113";
            }
          
            else if (obUsedCarsInfo[0].State.ToString() == "AL")
            {
                state = "Alabama,314";
             //   funcountry ="12";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "AK")
            {
                state = "Alaska,315";
               // funcountry ="73";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "AS")
            {
                state = "American Samoa";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "AZ")
            {
                state = "Arizona,316";
             //  funcountry = "22";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "Ar")
            {
                state = "Arkansas,317";
             //  funcountry = "23";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "CA")
            {
                state = "California,318";
              //  funcountry ="74";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "CO")
            {
                state = "Colorado,319";
              //  funcountry ="75";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "CT")
            {
                state = "Connecticut,320";
                funcountry = "76";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "DE")
            {
                state = "Delaware,322";
               // funcountry ="77";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "DC")
            {
                state = "District of Columbia,321";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "FL")
            {
                state = "Florida,323";
               // funcountry ="79";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "GA")
            {
                state = "Georgia,324";
               // funcountry ="80";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "GU")
            {
                state = "Guam,325";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "HI")
            {
                state = "Hawaii,326";
              //  funcountry ="81";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "IL")
            {
                state = "Illinois,328";
              // funcountry ="83";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "IN")
            {
                state = "Indiana,329";
            //  funcountry ="84";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "IA")
            {
                state = "Iowa,330";
              //  funcountry ="85";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "KS")
            {
                state = "Kansas,331";
               // funcountry ="86";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "KY")
            {
                state = "Kentucky,332";
             //  funcountry = "87";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "LA")
            {
                state = "Lousiana,333";
               // funcountry ="88";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "ME")
            {
                state = "Maine,334";
              //  funcountry ="89";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MI")
            {
                state = "Machigan,337";
              //  funcountry ="92";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MN")
            {
                state = "Mannesote,338";
               // funcountry ="93";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MS")
            {
                state = "Mississippi,339";
              //  funcountry ="94";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NJ")
            {
                state = "New Jersey,345";
               //   funcountry ="100";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MO")
            {
                state = "Missouri,340";
              // funcountry ="95";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MT")
            {
                state = "Montana,341";
               // funcountry ="96";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NE")
            {
                state = "Nebraska,342";
              //  funcountry ="97";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NV")
            {
                state = "Nevada,343";
              //  funcountry ="98";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NH")
            {
                state = "New Hampshire,344";
              //  funcountry ="99";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NM")
            {
                state = "New Mexico,346";
              // funcountry ="101";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NY")
            {
                state = "New York,347";
              // funcountry ="102";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "NC")
            {
                state = "North Carolina,103";
               // funcountry = "103";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "OH")
            {
                state = "Ohio,350";
              // funcountry ="105";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "OK")
            {
                state = "Oklahoma,351";
                		//funcountry ="106";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "OR")
            {
                state = "Oregon,352";
              //funcountry ="107";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "PR")
            {
                state = "Puerto rico,354";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "RI")
            {
                state = "Rhode Island,355";
             // funcountry ="109";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "SC")
            {

                state = "South Carolina,356";
             // funcountry ="110";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "SD")
            {
                state = "South Dakota,357";
                //funcountry ="111";
			
            }
                 else if (obUsedCarsInfo[0].State.ToString() == "ND")
            {
                state = "North Dakota,104";
             // funcountry ="104";
			
            }
            else if (obUsedCarsInfo[0].State.ToString() == "TN")
            {
                state = "Tennessee,358";
               //funcountry ="112";
            }
    
            else if (obUsedCarsInfo[0].State.ToString() == "UT")
            {
                state = "Utah,360";
                //funcountry ="114";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "VT")
            {
                //funcountry ="115";
                state = "Vermont,361";
                
            }
            else if (obUsedCarsInfo[0].State.ToString() == "VI")
            {
                state = "US Virgin Islands";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "VA")
            {
                state = "Varginia,362";
              // funcountry ="116";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "WA")
            {
                state = "Washington,363";
              //  funcountry ="117";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "WV")
            {
                state = "West virginia,364";
                   // funcountry ="119";
            }
           
          
            else if (obUsedCarsInfo[0].State.ToString() == "WI")
            {
                state = "Wisconsin,365";
                
			//funcountry ="120";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "WY")
            {
                state = "Wyoming,366";
                //funcountry ="121";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MD")
            {
                state = "Maryland,335";
                 //funcountry ="90";
            }
            else if (obUsedCarsInfo[0].State.ToString() == "MA")
            {
                state = "Massachusetts,336";
              // funcountry ="91";
            }
                return state;
              //  return funcountry;


        }
    }
}
