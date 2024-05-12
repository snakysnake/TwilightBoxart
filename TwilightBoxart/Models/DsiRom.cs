using System.Threading.Tasks;
using TwilightBoxart.Models.Base;

namespace TwilightBoxart.Models
{
    public class DsiRom(byte[] header) : NdsRom(header)
    {
        public override ConsoleType ConsoleType => ConsoleType.NintendoDSi;

        public override async Task DownloadBoxArt(string targetFile)
        {
            try
            {
                await base.DownloadBoxArt(targetFile);
            }
            catch
            {
                // Todo: Make this less ugly, embedded and optional.
                if (TitleId[0] == 'K' || TitleId[0] == 'H') // This is DSiWare. There is no BoxArt available (probably) so use a default image.
                {
                    await ImgDownloader.DownloadAndResize("https://github.com/KirovAir/TwilightBoxart/raw/master/img/dsiware.jpg", targetFile);
                }
            }
        }
    }
}
