using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace AutoFillForm.General
{
    public class ExcelFormat
       
    {

       public void ProcessedSheetExcel(int carid,DataSet dsProcessedLeads,string date)
       {
           string carImageId = string.Empty;

           int carid2 = carid;

          // string folderDate = (System.DateTime.Now).ToString();

           if (carid == 0)
           {

               carImageId = (System.DateTime.Now).ToString("yyyy-MM");
               carImageId = carImageId + "/" + date;

               ////string dt = DateTime.Now.ToString("yyyy-MM");
               ////dt = dt.Replace("-", "/");
               ////dt = dt + "/" + dateoftoday;
               //Char[] Sepe = { ' ' };
               //string[] split = carImageId.Split(Sepe);
               //carImageId = split[0].ToString();
               carImageId = carImageId.Replace("/", "-");
           }
           else
           {
               carImageId = carid.ToString();
           }

           System.IO.DirectoryInfo ImagePath = new DirectoryInfo(@"C:\MultiSiteEXL\" + "");

           if (!ImagePath.Exists)
           {
               ImagePath.Create();

           }
           string cellByCellFilePath = "C:\\MultiSiteEXL\\MultiSiteUrl_" + carImageId + ".xls";
           string fastExportFilePath = "C:\\MultiSiteEXL\\MultiSiteUrl_" + carImageId + ".xls";


           // Object to mark the times for each process
           Stopwatch stopwatch = new Stopwatch();
         //  this.UseWaitCursor = true;

           try
           {
               // Get the demo DataSet
               stopwatch.Start();
               DataSet demoDataSet = dsProcessedLeads;
               stopwatch.Stop();


               // Use the "Copy-cell-by-cell" method
               stopwatch.Start();

              // General.FastExcelExportingDemoCs objFastExcelExportingDemoCs = new General.FastExcelExportingDemoCs();
               General.FastExcelExportingDemoCs.ExportToExcel(demoDataSet, cellByCellFilePath);
               stopwatch.Stop();


               // Use the "fast export" method
               //stopwatch.Start();
               //FastExportingMethod.ExportToExcel(demoDataSet, fastExportFilePath);
               //stopwatch.Stop();



           }
           finally
           {
               
              // this.UseWaitCursor = false;
           }

       }
    }
}
