using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AutoFillForm.General
{
   public static class FastExcelExportingDemoCs
    {

       public static  void ExportToExcel(DataSet dataSet, string outputPath)
       {

           try
           {
               // Create the Excel Application object
               ApplicationClass excelApp = new ApplicationClass();

               // Create a new Excel Workbook
               Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);

               int sheetIndex = 0;

               // Copy each DataTable as a new Sheet
               foreach (System.Data.DataTable dt in dataSet.Tables)
               {

                   // Create a new Sheet
                   Worksheet excelSheet = (Worksheet)excelWorkbook.Sheets.Add(
                       excelWorkbook.Sheets.get_Item(++sheetIndex),
                       Type.Missing, 1, XlSheetType.xlWorksheet);

                   excelSheet.Name = dt.TableName;

                   // Copy the column names (cell-by-cell)
                   for (int col = 0; col < dt.Columns.Count; col++)
                   {
                       excelSheet.Cells[1, col + 1] = dt.Columns[col].ColumnName;
                   }

                   ((Range)excelSheet.Rows[1, Type.Missing]).Font.Bold = true;


                   // Copy the values (cell-by-cell)
                   for (int col = 0; col < dt.Columns.Count; col++)
                   {
                       for (int row = 0; row < dt.Rows.Count; row++)
                       {
                           excelSheet.Cells[row + 2, col + 1] = dt.Rows[row].ItemArray[col];
                       }
                   }

               }

               // Save and Close the Workbook
               excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                   Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive,
                   Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
               excelWorkbook.Close(true, Type.Missing, Type.Missing);
               excelWorkbook = null;

               // Release the Application object
               excelApp.Quit();
               excelApp = null;

               // Collect the unreferenced objects
               GC.Collect();
               GC.WaitForPendingFinalizers();
           }
           catch(Exception ex)
           {
           }

       }
    }
}
