using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using iTextSharp.text;

namespace Cert.Pdf.ImageToPdfConverter
{
    /// <summary>
    /// An interface for converting an <see cref="Image"/> to a PDF document.
    /// </summary>
    public interface IPdfConverter
    {
        /// <summary>
        /// Gets or sets the path where the file is to be saved.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the page size to convert to.
        /// </summary>
        PageSize PageSize { get; set; }

        /// <summary>
        /// Converts the selected <see cref="Image"/> to a PDF document.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> to convert.</param>
        /// <returns><c>true</c> if converted successfully; otherwise, <c>false</c>.</returns>
        bool ConvertImageToPdf(System.Drawing.Image image);

        /// <summary>
        /// Converts the selected <see cref="Image"/> to a PDF document.
        /// </summary>
        /// <param name="image">The <see cref="Image"/> to convert.</param>
        /// <param name="pageSize">The page size to convert to.</param>
        /// <returns><c>true</c> if converted successfully; otherwise, <c>false</c>.</returns>
        bool ConvertImageToPdf(System.Drawing.Image image, PageSize pageSize);

        /// <summary>
        /// Converts an image at the selected file path to a PDF document.
        /// </summary>
        /// <param name="imagePath">The file path of he image to convert.</param>
        /// <returns><c>true</c> if converted successfully; otherwise, <c>false</c>.</returns>
        bool ConvertImageToPdf(string imagePath);

        /// <summary>
        /// Converts an image at the selected file path to a PDF document.
        /// </summary>
        /// <param name="imagePath">The file path of he image to convert.</param>
        /// <param name="pageSize">The page size to convert to.</param>
        /// <returns><c>true</c> if converted successfully; otherwise, <c>false</c>.</returns>
        bool ConvertImageToPdf(string imagePath, PageSize pageSize);
    }
}
