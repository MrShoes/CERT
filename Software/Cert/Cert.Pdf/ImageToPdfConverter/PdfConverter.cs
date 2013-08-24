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
            try
            {
                ConvertToPdf(image);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ConvertImageToPdf(System.Drawing.Image image, iTextSharp.text.Rectangle pageSize)
        {
            PageSize = pageSize;
            try
            {
                ConvertToPdf(image);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ConvertImageToPdf(string imagePath)
        {
            try
            {
                var image = GetImageFromPath(imagePath);
                ConvertToPdf(image);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ConvertImageToPdf(string imagePath, iTextSharp.text.Rectangle pageSize)
        {
            PageSize = pageSize;
            try
            {
                var image = GetImageFromPath(imagePath);
                ConvertToPdf(image);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void ConvertToPdf(System.Drawing.Image image)
        {
            // TODO: Exception handling.
            using (var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                using (var document = new iTextSharp.text.Document(PageSize))
                {
                    PdfWriter.GetInstance(document, fileStream);
                    var imageByteConverter = new ImageByteConverter();
                    var bytes = imageByteConverter.ImageToByteArray(image);
                    var pdfImage = iTextSharp.text.Image.GetInstance(bytes);
                    pdfImage.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                    document.Open();
                    document.Add(pdfImage);
                    document.Close();
                }
            }
        }

        private System.Drawing.Image GetImageFromPath(string path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException(String.Format("The file {0} couldn't be found.", path));
            return System.Drawing.Image.FromFile(path);
        }
    }
}
