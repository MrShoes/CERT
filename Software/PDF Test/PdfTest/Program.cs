using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PdfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateBasicPdf();

            //CreateA5Pdf();

            //CreateSmallBluePdf();

            CreatePdfWithName();
        }

        private static void CreatePdfWithName()
        {
            Console.WriteLine("Enter your name.");

            var name = Console.ReadLine();

            var doc = new Document(new Rectangle(400f, 500f) { BackgroundColor = PatternColor.GREEN });

            using (var fileStream = new FileStream("TestPdf.pdf", FileMode.OpenOrCreate))
            {
                PdfWriter.GetInstance(doc, fileStream);
                doc.Open();
                doc.Add(new Paragraph(String.Format("Your name is {0}", name)));
                doc.Close();
            }
        }

        private static void CreateSmallBluePdf()
        {
            var rectangle = new Rectangle(300f, 500f);
            rectangle.BackgroundColor = BaseColor.BLUE;
            var doc = new Document(rectangle);
                        
            using (var fileStream = new FileStream("TestPdf.pdf", FileMode.OpenOrCreate))
            {
                PdfWriter.GetInstance(doc, fileStream);
                doc.Open();
                doc.Add(new Paragraph("This PDF is BLUE."));
                doc.Close();
            }
        }


        private static void CreateA5Pdf()
        {
            var doc = new Document(PageSize.A5);
            using (var fileStream = new FileStream("TestPdf.pdf", FileMode.OpenOrCreate))
            {
                PdfWriter.GetInstance(doc, fileStream);
                doc.Open();
                doc.Add(new Paragraph("This PDF is in A5."));
                doc.Close();
            }
        }

        private static void CreateBasicPdf()
        {
            var doc = new Document();


            using (var fileStream = new FileStream("TestPdf.pdf", FileMode.OpenOrCreate))
            {
                PdfWriter.GetInstance(doc, fileStream);
                doc.Open();
                doc.Add(new Paragraph("Test PDF."));
                doc.Close();
            }
        }
    }
}
