using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFillForm
{
   public class Pics
    {
        public static string GetPic0(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {
             string StockUrl = string.Empty;

                if (obUsedCarsInfo[0].PIC0.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC0.ToString().Trim() == "")
                {
                    string StockMake = obUsedCarsInfo[0].Make.ToString();
                    StockMake = StockMake.Replace(" ", "-");
                    StockMake = StockMake.Replace("/", "@");
                    StockMake = StockMake.Replace("&", "@");
                    string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                    StockType = StockType.Replace("/", "@");
                    StockType = StockType.Replace(" ", "-");

                    StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

                }
                else
                {
                    var path = obUsedCarsInfo[0].PICLOC0.ToString() + "/" + obUsedCarsInfo[0].PIC1.ToString();
                    path = path.Replace("//", "/");
                    StockUrl = "http://www.UnitedCarExchange.com/" + path;


                }

                return StockUrl;
          

        }



        public static string GetPic1(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC1.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC1.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType +".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC1.ToString() + "/" + obUsedCarsInfo[0].PIC2.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic2(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC2.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC2.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC2.ToString() + "/" + obUsedCarsInfo[0].PIC3.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;

                


            }

            return StockUrl;

        }
        public static string GetPic3(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC3.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC3.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC3.ToString() + "/" + obUsedCarsInfo[0].PIC4.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }
        public static string GetPic4(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC4.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC4.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC4.ToString() + "/" + obUsedCarsInfo[0].PIC5.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }
        public static string GetPic5(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC5.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC5.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC5.ToString() + "/" + obUsedCarsInfo[0].PIC6.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }
        public static string GetPic6(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC6.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC6.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC6.ToString() + "/" + obUsedCarsInfo[0].PIC7.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }
        public static string GetPic7(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC7.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC7.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC7.ToString() + "/" + obUsedCarsInfo[0].PIC8.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }
        public static string GetPic8(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC8.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC8.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC8.ToString() + "/" + obUsedCarsInfo[0].PIC9.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }
        public static string GetPic9(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC9.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC9.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC9.ToString() + "/" + obUsedCarsInfo[0].PIC10.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic10(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC10.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC10.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC10.ToString() + "/" + obUsedCarsInfo[0].PIC11.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic11(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC11.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC11.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC11.ToString() + "/" + obUsedCarsInfo[0].PIC11.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic12(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC12.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC12.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC12.ToString() + "/" + obUsedCarsInfo[0].PIC12.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic13(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC13.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC13.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC13.ToString() + "/" + obUsedCarsInfo[0].PIC13.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic14(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC14.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC14.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC14.ToString() + "/" + obUsedCarsInfo[0].PIC14.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic15(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC15.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC15.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC15.ToString() + "/" + obUsedCarsInfo[0].PIC15.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic16(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC16.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC16.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC16.ToString() + "/" + obUsedCarsInfo[0].PIC16.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic17(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC17.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC17.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC17.ToString() + "/" + obUsedCarsInfo[0].PIC17.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic18(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {
            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC18.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC18.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC18.ToString() + "/" + obUsedCarsInfo[0].PIC18.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }

        public static string GetPic19(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC19.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC19.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC19.ToString() + "/" + obUsedCarsInfo[0].PIC19.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }
        public static string GetPic20(IList<com.unitedcarexchange.UsedCarsInfo> obUsedCarsInfo)
        {

            string StockUrl = string.Empty;

            if (obUsedCarsInfo[0].PIC20.ToString().Trim() == "" && obUsedCarsInfo[0].PICLOC20.ToString().Trim() == "")
            {
                string StockMake = obUsedCarsInfo[0].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obUsedCarsInfo[0].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

            }
            else
            {
                var path = obUsedCarsInfo[0].PICLOC20.ToString() + "/" + obUsedCarsInfo[0].PIC20.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;




            }

            return StockUrl;

        }


    
      
    }
}
