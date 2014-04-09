using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProductionBL;

namespace AutoFillForm
{
    class WebCosmo:IWebSites
    {
        string Comfort = string.Empty;
        string Seats = string.Empty;
        string Safety = string.Empty;
        string soundsystem = string.Empty;
        string powerWindows = string.Empty;
        string New = string.Empty;
        string Other = string.Empty;
        string Specials = string.Empty;
        int count;
        SubmitionDetailsBL objSubmitionDetailsBL = new SubmitionDetailsBL();

        public void carpostfunc(System.Windows.Forms.WebBrowser webBrowser1, IList<AutoFillForm.com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo, bool a)
        {
            string URLDesp = "";
            com.unitedcarexchange.CarsService objService = new com.unitedcarexchange.CarsService();
            //IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo = new List<com.unitedcarexchange.UsedCarsInfo>();
            string statename1 = StateName.GetStateName(obUsedCarsInfo, obUsedCarsInfo[0].State.ToString(), obUsedCarsInfo[0].Carid.ToString());
            GeneralFunction.SetDropDownName(webBrowser1, "ctl00$cphContent$ddlState", statename1);
            GeneralFunction.SetDropDownNameandValue(webBrowser1, "ctl00$cphContent$ddlDepartment", "38");

            {
                string pmake = obUsedCarsInfo[0].Make.ToString();
                string pmodel = obUsedCarsInfo[0].Model.ToString();
                string pyear = obUsedCarsInfo[0].YearOfMake.ToString();
                string caruniqueid = obUsedCarsInfo[0].CarUniqueID.ToString();
                string url = "http://UnitedCarExchange.com/a1/" + pyear + "-" + pmake + "-" + pmodel + "-" + caruniqueid + "";
                if (url.Contains(" "))
                {
                    url = url.Replace(" ", "%20");
                }


                string make = obUsedCarsInfo[0].Make.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Make.ToString() == "Unspecified" ? "" : "\r\nMake: " + obUsedCarsInfo[0].Make.ToString();

                string model = obUsedCarsInfo[0].Model.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Model.ToString() == "Unspecified" ? "" : "\r\nModel: " + obUsedCarsInfo[0].Model.ToString(); ;
                string year = obUsedCarsInfo[0].YearOfMake.ToString() == "Emp" ? "" : obUsedCarsInfo[0].YearOfMake.ToString() == "Unspecified" ? "" : "\r\nyear: " + obUsedCarsInfo[0].YearOfMake.ToString();
                string doors = obUsedCarsInfo[0].NumberOfDoors.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfDoors.ToString() == "Unspecified" ? "" : "\r\nDoors: " + obUsedCarsInfo[0].NumberOfDoors.ToString();
                string bodystyle = obUsedCarsInfo[0].Bodytype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Bodytype.ToString() == "Unspecified" ? "" : "\r\nBodytype: " + obUsedCarsInfo[0].Bodytype.ToString();

                string exteriorcolor = obUsedCarsInfo[0].ExteriorColor.ToString() == "Emp" ? "" : obUsedCarsInfo[0].ExteriorColor.ToString() == "Unspecified" ? "" : "\r\nExteriorColor: " + obUsedCarsInfo[0].ExteriorColor.ToString();
                string interior = obUsedCarsInfo[0].InteriorColor.ToString() == "Emp" ? "" : obUsedCarsInfo[0].InteriorColor.ToString() == "Unspecified" ? "" : "\r\nInteriorColor: " + obUsedCarsInfo[0].InteriorColor.ToString();
                string seats = obUsedCarsInfo[0].NumberOfSeats.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfSeats.ToString() == "Unspecified" ? "" : "\r\nSeats: " + obUsedCarsInfo[0].NumberOfSeats.ToString();
                string price = "Price: " + "$" + (obUsedCarsInfo[0].Price.ToString() == "0" ? "1" : obUsedCarsInfo[0].Price.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Price.ToString() == "Unspecified" ? "" : obUsedCarsInfo[0].Price.ToString());
                // string fule = obUsedCarsInfo[0].Fueltype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Fueltype.ToString() == "Unspecified" ? "" : "\r\nFuelType: " + obUsedCarsInfo[0].Fueltype.ToString();
                string transmission = obUsedCarsInfo[0].Transmission.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Transmission.ToString() == "Unspecified" ? "" : "\r\nTransmission: " + obUsedCarsInfo[0].Transmission.ToString();
                string drivetrain = obUsedCarsInfo[0].DriveTrain.ToString() == "Emp" ? "" : obUsedCarsInfo[0].DriveTrain.ToString() == "Unspecified" ? "" : "\r\nDriveTrain: " + obUsedCarsInfo[0].DriveTrain.ToString();
                string mileage = obUsedCarsInfo[0].Mileage.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Mileage.ToString() == "Unspecified" ? "" : "\r\nMileage: " + obUsedCarsInfo[0].Mileage.ToString();

                string fuel = obUsedCarsInfo[0].Fueltype.ToString() == "Emp" ? "" : obUsedCarsInfo[0].Fueltype.ToString() == "Unspecified" ? "" : "\r\nFuelType: " + obUsedCarsInfo[0].Fueltype.ToString();

                string Engine = obUsedCarsInfo[0].NumberOfCylinder.ToString() == "Emp" ? "" : obUsedCarsInfo[0].NumberOfCylinder.ToString() == "Unspecified" ? "" : "\r\nEngine: " + obUsedCarsInfo[0].NumberOfCylinder.ToString();

                int carid = Convert.ToInt32(obUsedCarsInfo[0].Carid.ToString());


                DataSet dsfeatures = objSubmitionDetailsBL.MultisiteGetCarFeatures(carid);


                if (dsfeatures.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < dsfeatures.Tables[0].Rows.Count; k++)
                    {
                        if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "1")
                        {


                            Comfort += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";



                            //Comfort += Comfort + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                        }
                        if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "2")
                        {


                            Seats += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";



                            // Seats = Seats + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                        }
                        if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "3")
                        {


                            Safety += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";



                            //Safety = Safety + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                        }
                        if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "4")
                        {

                            soundsystem += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";


                            //  soundsystem = soundsystem + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                        }
                        if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "5")
                        {

                            powerWindows += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";


                            //  powerWindows = powerWindows + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                        }
                        if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "6")
                        {

                            Other += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";

                            //  Other = Other + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                        }
                        if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "7")
                        {

                            New += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";


                            //  New = New + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                        }
                        if (dsfeatures.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "8")
                        {

                            Specials += dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString() + ",";

                            // Specials = Specials + ", " + dsfeatures.Tables[0].Rows[k]["FeatureName"].ToString();

                        }
                    }

                    if (Comfort != "")
                    {
                        Comfort = Comfort.TrimEnd(',') + ".";
                    }
                    if (Seats != "")
                    {
                        Seats = Seats.TrimEnd(',') + ".";
                    }
                    if (Safety != "")
                    {
                        Safety = Safety.TrimEnd(',') + ".";
                    }
                    if (soundsystem != "")
                    {
                        soundsystem = soundsystem.TrimEnd(',') + ".";
                    }
                    if (powerWindows != "")
                    {
                        powerWindows = powerWindows.TrimEnd(',') + ".";
                    }
                    if (Other != "")
                    {
                        Other = Other.TrimEnd(',') + ".";
                    }
                    if (New != "")
                    {
                        New = New.TrimEnd(',') + ".";
                    }
                    if (Specials != "")
                    {
                        Specials = Specials.TrimEnd(',') + ".";
                    }
                }


                Comfort = Comfort == "" ? "" : Comfort == "Unspecified" ? "" : "\r\nComfort: " + Comfort;

                Seats = Seats == "" ? "" : Seats == "Unspecified" ? "" : "\r\nSeats: " + Seats;

                Safety = Safety == "" ? "" : Safety == "Unspecified" ? "" : "\r\nSafety: " + Safety;
                soundsystem = soundsystem == "" ? "" : soundsystem == "Unspecified" ? "" : "\r\nsoundsystem: " + soundsystem;
                powerWindows = powerWindows == "" ? "" : powerWindows == "Unspecified" ? "" : "\r\npowerWindows: " + powerWindows;
                Other = Other == "" ? "" : Other == "Unspecified" ? "" : "\r\nOther: " + Other;
                New = New == "" ? "" : New == "Unspecified" ? "" : "\r\nNew: " + New;
                Specials = Specials == "" ? "" : Specials == "Unspecified" ? "" : "\r\nSpecials: " + Specials;





                string details = (make.Trim() == "" ? "" : make.Trim()) + (model.Trim() == "" ? "" : "\r\n" + model.Trim()) + (year.Trim() == "" ? "" : "\r\n" + year.Trim()) + (doors.Trim() == "" ? "" : "\r\n" + doors.Trim()) + (bodystyle.Trim() == "" ? "" : "\r\n" + bodystyle.Trim()) + (exteriorcolor.Trim() == "" ? "" : "\r\n" + exteriorcolor.Trim()) + (interior.Trim() == "" ? "" : "\r\n" + interior.Trim()) + (seats.Trim() == "" ? "" : "\r\n" + seats.Trim()) + (price.Trim() == "" ? "" : "\r\n" + price.Trim()) + (transmission.Trim() == "" ? "" : "\r\n" + transmission.Trim()) + (mileage.Trim() == "" ? "" : "\r\n" + mileage.Trim()) + (fuel.Trim() == "" ? "" : "\r\n" + fuel.Trim()) + (drivetrain.Trim() == "" ? "" : "\r\n" + drivetrain.Trim()) + (Engine.Trim() == "" ? "" : "\r\n" + Engine.Trim()) + "\r\n" + (Comfort.Trim() == "" ? "" : "\r\n" + Comfort.Trim()) + (Seats.Trim() == "" ? "" : "\r\n" + Seats.Trim()) + (Safety.Trim() == "" ? "" : "\r\n" + Safety.Trim()) + (soundsystem.Trim() == "" ? "" : "\r\n" + soundsystem.Trim()) + (powerWindows.Trim() == "" ? "" : "\r\n" + powerWindows.Trim()) + (Other.Trim() == "" ? "" : "\r\n" + Other.Trim()) + (New.Trim() == "" ? "" : "\r\n" + New.Trim()) + (Specials.Trim() == "" ? "" : "\r\n" + Specials.Trim());





                //string details = "\r\n Make: " + obUsedCarsInfo[0].Make.ToString() + "\r\n Model: " + obUsedCarsInfo[0].Model.ToString() + "\r\n Year: " + obUsedCarsInfo[0].YearOfMake.ToString() + "\r\n Body Style: " + obUsedCarsInfo[0].Bodytype.ToString() + "\r\n Exterior Color: " + obUsedCarsInfo[0].ExteriorColor.ToString() + "\r\n Interior Color: " + obUsedCarsInfo[0].InteriorColor.ToString() + "\r\n Doors: " + obUsedCarsInfo[0].NumberOfDoors.ToString() + "\r\n Seats: " + obUsedCarsInfo[0].NumberOfSeats.ToString() + "\r\n Price: " + obUsedCarsInfo[0].Price.ToString() + "\r\n Mileage: " + obUsedCarsInfo[0].Mileage.ToString() + "\r\n Fuel: " + obUsedCarsInfo[0].Fueltype.ToString() + "\r\n Transmission: " + obUsedCarsInfo[0].Transmission.ToString() + "\r\n Drive Train: " + obUsedCarsInfo[0].DriveTrain.ToString() + "\r\n Vin: " + obUsedCarsInfo[0].VIN.ToString();
                if (details.Contains("Emp"))
                {
                    details = details.Replace("Emp", "");
                }
                if (details.Contains("Other"))
                {
                    details = details.Replace("Other", "");
                }
                string des = obUsedCarsInfo[0].Description.ToString();
                URLDesp = details.ToString() + "\r\n" + "\n" + "Description: " + des.Trim() + "..!! If intrested contact : " + obUsedCarsInfo[0].Phone.ToString() + "..!!!For More Details:  " + url;
                    //WrapTextByMaxCharacters(details, obUsedCarsInfo[0].Description.ToString(), 50000, url, obUsedCarsInfo[0].Phone.ToString());

            }
            //if (obUsedCarsInfo[0].Title.ToString() != "Emp")
            //{
            //    GeneralFunction.SetTextvaluebyName(webBrowser1, "ctl00$cphContent$txtTitle", obUsedCarsInfo[0].Title.ToString());
            //}
            //else
            string title="";
            if (obUsedCarsInfo[0].Title != "Emp" )
            {
                title = obUsedCarsInfo[0].Title + "-" + "$"+obUsedCarsInfo[0].Price.ToString();
            }
            else
            {
                if (obUsedCarsInfo[0].Model.ToString() != "Other")
                    title = obUsedCarsInfo[0].YearOfMake.ToString() + "  " + obUsedCarsInfo[0].Make.ToString() + "  " + obUsedCarsInfo[0].Model.ToString() + " - " + "$"+obUsedCarsInfo[0].Price.ToString();
                else
                    title = obUsedCarsInfo[0].YearOfMake.ToString() + "  " + obUsedCarsInfo[0].Make.ToString() + " - " + "$"+obUsedCarsInfo[0].Price.ToString();
            }
            GeneralFunction.SetTextvaluebyName(webBrowser1, "ctl00$cphContent$txtTitle",title );
            //}
            GeneralFunction.SetMultiTextName(webBrowser1, "ctl00$cphContent$txtDescription", URLDesp);
            GeneralFunction.SetTextValue(webBrowser1, "ctl00$cphContent$txtPrice", obUsedCarsInfo[0].Price.ToString());
            GeneralFunction.RadioSetValue(webBrowser1, "ctl00$cphContent$rdgrVisibility", "rdVisivility3");
            GeneralFunction.SetTextvaluebyName(webBrowser1, "ctl00$cphContent$txtEmail", Globaltxtemail.txtemail);
            GeneralFunction.SetTextvaluebyName(webBrowser1, "ctl00$cphContent$txtEmailConfirm", Globaltxtemail.txtemail);
            GeneralFunction.FileUploadInvoke(webBrowser1, "ctl00$cphContent$fileUploadImage");
            GeneralFunction.ButtonClickInvoke(webBrowser1, "ctl00$cphContent$btnUploadImage");
            
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
