using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cert.Pdf.ImageToPdfConverter
{
    public interface IPdfConverter
    {
        string FilePath { get; set; }

        bool ConvertImageToPdf(Image image);
    }
}
