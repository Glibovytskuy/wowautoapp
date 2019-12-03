using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;
using WowAutoApp.Core.Domain.Media;
using WowAutoApp.Core.Enums;
using static SixLabors.ImageSharp.Configuration;

namespace WowAutoApp.Services.Utilities
{
    public static class ImageUtilities
    {
        /// <summary>
        /// Calculates picture dimensions whilst maintaining aspect
        /// </summary>
        /// <param name="originalSize">The original picture size</param>
        /// <param name="targetSize">The target picture size (longest side)</param>
        /// <param name="resizeType">Resize type</param>
        /// <param name="ensureSizePositive">A value indicating whether we should ensure that size values are positive</param>
        /// <returns></returns>
        public static Size CalculateDimensions(Size originalSize, int targetSize,
            ResizeType resizeType = ResizeType.LongestSide, bool ensureSizePositive = true)
        {
            float width, height;

            switch (resizeType)
            {
                case ResizeType.LongestSide:
                    if (originalSize.Height > originalSize.Width)
                    {
                        // portrait
                        width = originalSize.Width * (targetSize / (float)originalSize.Height);
                        height = targetSize;
                    }
                    else
                    {
                        // landscape or square
                        width = targetSize;
                        height = originalSize.Height * (targetSize / (float)originalSize.Width);
                    }
                    break;
                case ResizeType.Width:
                    width = targetSize;
                    height = originalSize.Height * (targetSize / (float)originalSize.Width);
                    break;
                case ResizeType.Height:
                    width = originalSize.Width * (targetSize / (float)originalSize.Height);
                    height = targetSize;
                    break;
                default:
                    throw new Exception("Not supported ResizeType");
            }

            if (ensureSizePositive)
            {
                if (width < 1)
                    width = 1;
                if (height < 1)
                    height = 1;
            }

            return new Size((int)Math.Round(width), (int)Math.Round(height));
        }

        /// <summary>
        /// Encode the image into a byte array in accordance with the specified image format
        /// </summary>
        /// <typeparam name="T">Pixel data type</typeparam>
        /// <param name="image">Image data</param>
        /// <param name="imageFormat">Image format</param>
        /// <param name="mediaSettings">Media settings</param>
        /// <param name="quality">Quality index that will be used to encode the image</param>
        /// <returns>Image binary data</returns>
        public static byte[] EncodeImage<T>(Image<T> image, IImageFormat imageFormat, MediaSettings mediaSettings, int? quality = null) where T : struct, IPixel<T>
        {
            using (var stream = new MemoryStream())
            {
                var imageEncoder = Default.ImageFormatsManager.FindEncoder(imageFormat);
                switch (imageEncoder)
                {
                    case JpegEncoder jpegEncoder:
                        jpegEncoder.IgnoreMetadata = true;
                        jpegEncoder.Quality = quality ?? mediaSettings.DefaultImageQuality;
                        jpegEncoder.Encode(image, stream);
                        break;

                    case PngEncoder pngEncoder:
                        pngEncoder.PngColorType = PngColorType.RgbWithAlpha;
                        pngEncoder.Encode(image, stream);
                        break;

                    case BmpEncoder bmpEncoder:
                        bmpEncoder.BitsPerPixel = BmpBitsPerPixel.Pixel32;
                        bmpEncoder.Encode(image, stream);
                        break;

                    case GifEncoder gifEncoder:
                        gifEncoder.IgnoreMetadata = true;
                        gifEncoder.Encode(image, stream);
                        break;

                    default:
                        imageEncoder.Encode(image, stream);
                        break;
                }

                return stream.ToArray();
            }
        }
    }
}