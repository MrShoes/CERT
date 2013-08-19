using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace ImportFromExcel
{
    class Program
    {
        private const string filePath = @"C:\Users\Ian\Documents\Visual Studio 2010\Projects\C#\Experiments\PdfTest\ImportFromExcel\bin\Debug\Sample.xlsx";

        static void Main(string[] args)
        {
            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Open(filePath);
            Excel._Worksheet worksheet = workbook.Sheets[1];
            var range = worksheet.UsedRange;

            var excelTable = new System.Data.DataTable();

            for (var i = 1; i <= range.Columns.Count; i++)
            {
                excelTable.Columns.Add(range.Cells[1,i].Value2.ToString());
                var type = range.Cells[1, i].DataType;
            }

            DataRow dataRow = null;
            for (var row = 2; row < range.Rows.Count + 1; row++)
            {
                dataRow = excelTable.NewRow();

                for (var col = 1; col <= range.Columns.Count; col++)
                {
                    dataRow[col - 1] = range.Cells[row, col].Value2;
                }
                excelTable.Rows.Add(dataRow);
            }

            workbook.Close();
            excelApp.Quit();

            for (var i = 0; i < excelTable.Columns.Count; i++)
            {
                Console.Write("| {0}\t", excelTable.Columns[i].ColumnName);
            }
            Console.WriteLine("|");

            foreach (DataRow row in excelTable.Rows)
            {
                for(var i = 0; i < row.ItemArray.Length; i++)
                {
                    Console.Write("| {0}\t", row.ItemArray[i]);
                }
                Console.WriteLine("|");
            }

            var convertedDouble = double.Parse(excelTable.Rows[0].ItemArray[1].ToString());

            Console.WriteLine("{0}", DateTime.FromOADate(convertedDouble));

            Console.ReadKey();
        }
    }
}
