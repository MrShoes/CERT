using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cert.Pdf.ImageToPdfConverter;
using iTextSharp.text;

namespace Cert.ConsoleTestBench
{
    class Program
    {
        static void Main(string[] args)
        {
            TestImageToPdfConverter();

            Console.ReadKey();
        }

        private static void TestImageToPdfConverter()
        {
            var path = @"G:\Pictures\Spidey.jpg";

            var converter = new PdfConverter();
            converter.FilePath = "Test.pdf";
            converter.PageSize = PageSize.A4;

            converter.ConvertImageToPdf(path);

        }
    }
}
