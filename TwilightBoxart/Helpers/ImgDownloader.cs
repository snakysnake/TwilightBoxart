using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace TwilightBoxart.Helpers
{
    public class ImgDownloader(int width, int height)
    {
        private static readonly HttpClient Client = new();

        private int _width = width;
        private int _height = height;

        public async Task DownloadAndResize(string url, string targetFile)
        {
            HttpResponseMessage response = await Client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream data = await response.Content.ReadAsStreamAsync();

                var image = Image.Load(data);
                image.Metadata.ExifProfile = null;
                image.Mutate(x => x.Resize(_width, _height));

                var encoder = GetEncoder(image, targetFile);
                image.Save(targetFile, encoder);
            }
        }

        private static IImageEncoder GetEncoder(Image image, string targetFile)
        {
            var ext = Path.GetExtension(targetFile);
            var manager = image.Configuration.ImageFormatsManager;
            manager.TryFindFormatByFileExtension(ext, out IImageFormat format);
            var encoder = manager.GetEncoder(format);

            if (encoder is PngEncoder)
            {
                return new PngEncoder
                {
                    CompressionLevel = PngCompressionLevel.Level9,
                    InterlaceMethod = PngInterlaceMode.None,
                    BitDepth = PngBitDepth.Bit8,
                    ColorType = PngColorType.Rgb,
                    FilterMethod = PngFilterMethod.Adaptive,
                };
            }

            return encoder;
        }


        public void SetSizeAdjustedToAspectRatio(Size aspectRatio)
        {
            if (_width == aspectRatio.Width || _height == aspectRatio.Height)
            {
                _height = aspectRatio.Height;
                _width = aspectRatio.Width;
                return;
            }

            var sourceWidth = aspectRatio.Width;
            var sourceHeight = aspectRatio.Height;
            var dWidth = _width;
            var dHeight = _height;

            var isLandscape = sourceWidth > sourceHeight;

            int newHeight;
            int newWidth;
            if (isLandscape)
            {
                newHeight = dWidth * sourceHeight / sourceWidth;
                newWidth = dWidth;
            }
            else
            {
                newWidth = dHeight * sourceWidth / sourceHeight;
                newHeight = dHeight;
            }

            _width = newWidth;
            _height = newHeight;
        }
    }
}
