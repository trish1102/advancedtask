global using NUnit.Framework;
global using OpenQA.Selenium;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using AdvanceTask.Utilities;
global using AdvanceTask.Pages;
global using System.Data;
global using ExcelDataReader;
global using NUnit.Framework.Interfaces;
global using System.IO;
global using System.Text.Encodings;
global using AventStack.ExtentReports;
global using AventStack.ExtentReports.Reporter;
global using static AdvanceTask.Utilities.Global;
global using OpenQA.Selenium.Chrome;
global using DocumentFormat.OpenXml.Math;
global using OpenQA.Selenium.Support.UI;
global using DocumentFormat.OpenXml.Bibliography;


namespace AdvanceTask.Utilities
{
      class Global
      {
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (@"C:\AdvanceTask\advancedtask\AdvanceTask\AdvanceTask\ExtentReport\Screenshot\");

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }
                Thread.Sleep(1000);
                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Png);
                return fileName.ToString();
            }
        }



        public class ExcelLib
        {

            static List<Datacollection> dataCol = new List<Datacollection>();

            public class Datacollection
            {
                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }


            public static void ClearData()
            {
                dataCol.Clear();
            }
           

            private static DataTable ExcelToDataTable(string fileName, string SheetName)
            {
                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))//[filepath=path till your excelfile put @in front]
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(
                                            new ExcelDataSetConfiguration()
                                            {
                                                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                                {
                                                    UseHeaderRow = true
                                                }
                                            }
                                          );
                        DataTableCollection table=result.Tables;
                        DataTable resultTable = table[SheetName];
                        //return
                        return resultTable;
                    }
                }

            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations

                    rowNumber = rowNumber - 1;
                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


                    return data.ToString();
                }

                catch (Exception e)
                {
                    
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }

            public static void PopulateInCollection(string fileName, string SheetName)
            {
                ExcelLib.ClearData();
                DataTable table = ExcelToDataTable(fileName, SheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };


                        //Add all the details for each row
                        dataCol.Add(dtTable);

                    }
                }

            }
        }

    }
}

