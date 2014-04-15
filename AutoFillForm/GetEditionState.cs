using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFillForm
{
    public class GetEditionState
    {
        public static string GetStateName(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo, string stateid, string carid)
        {

            string state = string.Empty;
            string funcountry = string.Empty;

            if (obUsedCarsInfo[0].State.ToString().Trim() == "PA")
            {
                state = "Pennsylvania,108";
              //  funcountry ="112";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "TX")
            {
                state = "Texas,113";
               //funcountry ="113";
            }

            else if (obUsedCarsInfo[0].State.ToString().Trim() == "AL")
            {
                state = "Alabama,12";
             //   funcountry ="12";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "AK")
            {
                state = "Alaska,73";
               // funcountry ="73";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "AS")
            {
                state = "American Samoa";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "AZ")
            {
                state = "Arizona,22";
             //  funcountry = "22";
            }
            else if ((obUsedCarsInfo[0].State.ToString().Trim() == "Ar") || (obUsedCarsInfo[0].State.ToString() == "AR"))
            {
                state = "Arkansas,23";
             //  funcountry = "23";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "CA")
            {
                state = "California,74";
              //  funcountry ="74";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "CO")
            {
                state = "Colorado,75";
              //  funcountry ="75";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "CT")
            {
                state = "Connecticut,76";
                funcountry = "76";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "DE")
            {
                state = "Delaware,77";
               // funcountry ="77";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "DC")
            {
                state = "District of Columbia";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "FL")
            {
                state = "Florida,79";
               // funcountry ="79";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "GA")
            {
                state = "Georgia,80";
               // funcountry ="80";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "GU")
            {
                state = "Guam";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "HI")
            {
                state = "Hawaii,81";
              //  funcountry ="81";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "IL")
            {
                state = "Illinois,83";
              // funcountry ="83";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "IN")
            {
                state = "Indiana,84";
            //  funcountry ="84";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "IA")
            {
                state = "Iowa,85";
              //  funcountry ="85";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "KS")
            {
                state = "Kansas,86";
               // funcountry ="86";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "KY")
            {
                state = "Kentucky,87";
             //  funcountry = "87";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "LA")
            {
                state = "Lousiana,88";
               // funcountry ="88";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "ME")
            {
                state = "Maine,89";
              //  funcountry ="89";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "MI")
            {
                state = "Michigan,92";
              //  funcountry ="92";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "MN")
            {
                state = "Minnesota,93";
               // funcountry ="93";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "MS")
            {
                state = "Mississippi,94";
              //  funcountry ="94";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "NJ")
            {
                state = "New Jersey,100";
               //   funcountry ="100";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "MO")
            {
                state = "Missouri,95";
              // funcountry ="95";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "MT")
            {
                state = "Montana,96";
               // funcountry ="96";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "NE")
            {
                state = "Nebraska,97";
              //  funcountry ="97";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "NV")
            {
                state = "Nevada,98";
              //  funcountry ="98";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "NH")
            {
                state = "New Hampshire,99";
              //  funcountry ="99";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "NM")
            {
                state = "New Mexico,101";
              // funcountry ="101";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "NY")
            {
                state = "New York,102";
              // funcountry ="102";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "NC")
            {
                state = "North Carolina,103";
               // funcountry = "103";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "OH")
            {
                state = "Ohio,105";
              // funcountry ="105";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "OK")
            {
                state = "Oklahoma,106";
                		//funcountry ="106";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "OR")
            {
                state = "Oregon,107";
              //funcountry ="107";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "PR")
            {
                state = "Puerto rico";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "RI")
            {
                state = "Rhode Island,109";
             // funcountry ="109";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "SC")
            {

                state = "South Carolina,110";
             // funcountry ="110";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "SD")
            {
                state = "South Dakota,111";
                //funcountry ="111";
			
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "ND")
            {
                state = "North Dakota,104";
             // funcountry ="104";
			
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "TN")
            {
                state = "Tennessee,112";
               //funcountry ="112";
            }

            else if (obUsedCarsInfo[0].State.ToString().Trim() == "UT")
            {
                state = "Utah,114";
                //funcountry ="114";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "VT")
            {
                //funcountry ="115";
                state = "Vermont,115";
                
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "VI")
            {
                state = "US Virgin Islands";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "VA")
            {
                state = "Virginia,116";
              // funcountry ="116";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "WA")
            {
                state = "Washington,117";
              //  funcountry ="117";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "WV")
            {
                state = "West Virginia,119";
                   // funcountry ="119";
            }


            else if (obUsedCarsInfo[0].State.ToString().Trim() == "WI")
            {
                state = "Wisconsin,120";
                
			//funcountry ="120";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "WY")
            {
                state = "Wyoming,121";
                //funcountry ="121";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "MD")
            {
                state = "Maryland,90";
                 //funcountry ="90";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "MA")
            {
                state = "Massachusetts,91";
              // funcountry ="91";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "ID")
            {
                state = "Idaho,82";
                // funcountry ="91";
            }
            else if (obUsedCarsInfo[0].State.ToString().Trim() == "GA")
            {
                state = "Georgia,80";
                // funcountry ="91";
            }

        http://www.classifiededition.com/80_Georgia/
       
                return state;
              //  return funcountry;


        }
    }

    }
