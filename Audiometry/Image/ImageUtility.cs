using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using OxyPlot;
using OxyPlot.Wpf;

namespace Audiometry.Image
{
    public static class ImageUtility
    {
        private static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        private static BitmapSource Bitmap2BitmapImage(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapSource retval;

            try
            {
                retval = Imaging.CreateBitmapSourceFromHBitmap(
                             hBitmap,
                             IntPtr.Zero,
                             Int32Rect.Empty,
                             BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }

            return retval;
        }

        public static Bitmap ResizeImage(Bitmap imgToResize, System.Windows.Size size)
        {
            Bitmap b = new Bitmap((int)size.Width, (int)size.Height);

            using (Graphics g = Graphics.FromImage((System.Drawing.Image)b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, (int)size.Width, (int)size.Height);
            }

            return b;
        }

        /// <summary>
        /// Exports the specified plot model to a bitmap.
        /// </summary>
        /// <param name="model">The plot model.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="background">The background.</param>
        /// <param name="resolution">The resolution (dpi).</param>
        /// <returns>A bitmap.</returns>
        public static BitmapSource ExportToBitmap(PlotModel model, int width, int height, OxyColor background, int resolution = 96)
        {
            var exporter = new PngExporter { Width = width, Height = height, Background = background, Resolution = resolution };
            return exporter.ExportToBitmap(model);
        }
    }
}
