using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TestCanvasToImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SaveToImage();
            SaveToPdf();
        }

        private void SaveToImage()
        {
            var rect = new Rect(MyCanvas.RenderSize);
            var renderTargetBmp = new RenderTargetBitmap((int)rect.Right, (int)rect.Bottom, 96d, 96d, PixelFormats.Default);
            renderTargetBmp.Render(MyCanvas);

            var pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(renderTargetBmp));

            using (var memStream = new MemoryStream())
            {
                pngEncoder.Save(memStream);
                memStream.Close();

                File.WriteAllBytes("Image.png", memStream.ToArray());
            }
        }

        private void SaveToPdf()
        {
            var rect = new Rect(MyCanvas.RenderSize);
            var renderTargetBmp = new RenderTargetBitmap((int)rect.Right, (int)rect.Bottom, 96d, 96d, PixelFormats.Default);
            renderTargetBmp.Render(MyCanvas);

            var pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(renderTargetBmp));

            using (var memStream = new MemoryStream())
            {
                pngEncoder.Save(memStream);
                memStream.Position = 0;

                var doc = new Document(new iTextSharp.text.Rectangle((float)rect.Width, (float)rect.Height));

                using (var fileStream = new FileStream("Image.pdf", FileMode.OpenOrCreate))
                {
                    PdfWriter.GetInstance(doc, fileStream);
                    doc.Open();
                    var image = iTextSharp.text.Image.GetInstance(memStream);
                    doc.Add(image);
                    doc.Close();
                }
            }
        }
    }
}
