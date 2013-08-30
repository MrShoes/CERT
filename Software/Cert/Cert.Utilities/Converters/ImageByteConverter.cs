using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Cert.Utilities.Converters
{
    /// <summary>
    /// Converts between images and arrays of bytes.
    /// </summary>
    public class ImageByteConverter
    {
        /// <summary>
        /// Converts an image to an array of bytes.
        /// </summary>
        /// <param name="imageIn">The image to convert.</param>
        /// <returns>The bytes from the image.</returns>
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Converts a byte array to an image.
        /// </summary>
        /// <param name="byteArrayIn">The bytes to convert.</param>
        /// <returns>An image from the bytes.</returns>
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
