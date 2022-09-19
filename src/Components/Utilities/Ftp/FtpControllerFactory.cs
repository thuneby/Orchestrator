using Microsoft.Extensions.Logging;

namespace Utilities.Ftp
{
    public class FtpControllerFactory
    {
        public IFtpController GetController(FtpSettings settings, ILoggerFactory loggerFactory)
        {
            if (string.IsNullOrWhiteSpace(settings.Host))
                return new FileController(loggerFactory.CreateLogger<FileController>(), settings.RootFolder);
            return new FtpController(settings, loggerFactory.CreateLogger<FtpController>());
        }
    }
}
