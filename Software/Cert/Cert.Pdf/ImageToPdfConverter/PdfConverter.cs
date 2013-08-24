using Cert.Utilities.Converters;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cert.Pdf.ImageToPdfConverter
{
    /// <summary>
    /// Concrete implementation of the <see cref="IPdfConverter"/> interface.
    /// Converts an image to PDF document.
    /// </summary>
    public class PdfConverter : IPdfConverter
    {
        public string FilePath
        {
            get;
            set;
        }

        public iTextSharp.text.Rectangle PageSize
        {
            get;
            set;
        }

        public bool ConvertImageToPdf(System.Drawing.Image image)
        {
            throw new NotImplementedException();
        }

        public bool ConvertImageToPdf(System.Drawing.Image image, iTextSharp.text.Rectangle pageSize)
        {
            throw new NotImplementedException();
        }

        public bool ConvertImageToPdf(string imagePath)
        {
            throw new NotImplementedException();
        }

        public bool ConvertImageToPdf(string imagePath, iTextSharp.text.Rectangle pageSize)
        {
            throw new NotImplementedException();
        }

        private async void ConvertImageToPdf(System.Drawing.Image image)
        {
            using (var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                using (var document = new iTextSharp.text.Document(PageSize))
                {
                    PdfWriter.GetInstance(document, fileStream);
                    var imageByteConverter = new ImageByteConverter();
                    var bytes = imageByteConverter.ImageToByteArray(image);
                    var pdfImage = iTextSharp.text.Image.GetInstance(bytes);
                }
            }
        }
    }
}
