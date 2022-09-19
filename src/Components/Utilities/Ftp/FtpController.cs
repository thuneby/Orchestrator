using FluentFTP;
using Microsoft.Extensions.Logging;
using System.Net;
using Core.Models;

namespace Utilities.Ftp
{
    public class FtpController: IFtpController
    {
        private static string _serverFolderPath;
        private const string DEFAULT_EXTENSION = ".TXT";
        private readonly FtpClient _client;
        private readonly ILogger _logger;

        public FtpController(FtpSettings settings, ILogger<FtpController> logger) 
        {
            _serverFolderPath = settings.RootFolder;
            _logger = logger;
            _client = new FtpClient(settings.Host);
            if (!string.IsNullOrWhiteSpace(settings.UserName))
            {
                _client.Credentials = new NetworkCredential(settings.UserName, settings.Password); // else anonymous
            }
        }

        public void SetRootFolder(string rootFolder)
        {
            _serverFolderPath = rootFolder;
        }

        public void Put(string destination, string fileName, byte[] payload)
        {
            if (!_client.IsConnected)
                _client.Connect();
            var fullPath = GetFullPath(destination);
            if (!_client.DirectoryExists(fullPath))
                _client.CreateDirectory(fullPath);
            var stream = new MemoryStream(payload);
            var fullName = fullPath + fileName;
            _client.UploadStream(stream, fileName);
        }

        public string CopyFile(string fileName, string folder, string destination, bool deleteOriginal, bool verify)
        {
            if (!_client.IsConnected)
                _client.Connect();
            var fullPath = GetFullPath(folder);
            if (!_client.DirectoryExists(fullPath))
                return fileName;
            var fullName = fullPath + fileName;
            if (!_client.FileExists(fullName))
            {
                if (fullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    var newName = fullName.Substring(0, fullPath.Length - 4);
                    if (_client.FileExists(newName))
                    {
                        fullName = newName;
                        fileName = fileName.Substring(0, fullPath.Length - 4);
                    }
                }
                else
                {
                    var newName = fullName + DEFAULT_EXTENSION;
                    if (_client.FileExists(newName))
                    {
                        fullName = newName;
                        fileName += DEFAULT_EXTENSION;
                    }
                }
            }

            var fileSize = _client.GetFileSize(fullName);

            var destinationName = destination + @"\" + fileName;
            if (File.Exists(destinationName))
            {
                // Remove partially/already downloaded file when re-running
                File.Delete(destinationName);
            }
            var fileInfo = fileSize < 100 ? Download(fullName, destinationName, false) : Download(fullName, destinationName, verify);
            if (fileInfo == null)
            {
                var message = "Download failed for file" + fileName;
                _logger.LogError(message);
                throw new FileNotFoundException(message);
            }
            if (deleteOriginal)
                DeleteFile(fileName, folder);
            return fileName;
        }

        public InputFile? Get(string fileName, string folder)
        {
            if (!_client.IsConnected)
                _client.Connect();
            var fullPath = GetFullPath(folder);
            if (!_client.DirectoryExists(fullPath))
                return null;
            var fullName = fullPath + fileName;
            var success = _client.DownloadBytes(out var content, fullName);
            if (!success)
                return null;
            var payload = new InputFile
            {
                Id = Guid.NewGuid(),
                Content = content,
                FileName = fileName,
                Size = content.Length,
                DocumentType = DocumentType.Unknown
            };
            return payload;
        }


        public List<string> GetFileList(string folder)
        {
            return GetFileList(GetFullPath(folder), true);
        }

        public void DeleteFile(string fileName, string folder)
        {
            if (!_client.IsConnected)
                _client.Connect();
            var fullPath = GetFullPath(folder);
            if (!_client.DirectoryExists(fullPath))
            {
                _logger.LogError("Directory does not exist: {0}", fullPath);
                return;
            }
            var fullName = fullPath + fileName;
            if (_client.FileExists(fullName))
            {
                _logger.LogInformation("Deleting file: {0}", fullName);
                _client.DeleteFile(fullName);
            }
            else
            {
                _logger.LogError("File to delete does not exist: {0}", fullName);
            }
        }

        public void Connect()
        {
            _client.Connect();
        }

        public void Disconnect()
        {
            _client.Disconnect();
        }

        public List<string> GetFileList(string fullPath, bool sortAscending = true)
        {
            if (!_client.IsConnected)
                _client.Connect();
            if (!_client.DirectoryExists(fullPath))
                return new List<string>();
            var listing = _client.GetListing(fullPath).Where(x => x.Type == FtpObjectType.File).ToList();
            LogDirFromFtp(listing);
            return sortAscending ? listing.OrderBy(x => x.Modified).Select(x => x.Name).ToList() :
                listing.OrderByDescending(x => x.Modified).Select(x => x.FullName).ToList();
        }

        private void LogDirFromFtp(List<FtpListItem> listing)
        {
            if (!listing.Any())
            {
                _logger.LogInformation("No files found on FTP server");
            }
            _logger.LogInformation("{0} files found on FTP server: ", listing.Count());
            foreach (var ftpListItem in listing)
            {
                _logger.LogInformation(ftpListItem.Name + " Size: " + ftpListItem.Size + " Last modified :" + ftpListItem.Modified.ToString("G"));
            }
        }

        public FileInfo Download(string fullPath, string destination, bool verify)
        {
            _logger.LogInformation("Downloading file {0} to destination {1}", fullPath, destination);
            if (!_client.IsConnected)
                _client.Connect();
            var ftpVerify = verify ? FtpVerify.Retry : FtpVerify.None;
            try
            {
                var result = _client.DownloadFile(destination, fullPath, FtpLocalExists.Overwrite, ftpVerify);
                _logger.LogInformation("FtpStatus from download: " + result);
                if (result != FtpStatus.Failed)
                    return new FileInfo(destination);
                if (!File.Exists(destination)) return null;
                var compare = _client.CompareFile(fullPath, destination, FtpCompareOption.Size);
                return compare == FtpCompareResult.Equal ? new FileInfo(destination) : null;
            }
            catch (Exception e)
            {
                _logger.LogError("Error in FtpController DownloadAsync " + e.Message, e);
                throw;
            }
        }

        private static string GetFullPath(string folder)
        {
            var result = string.IsNullOrWhiteSpace(folder) ? _serverFolderPath : _serverFolderPath + @"/" + folder;
            if (!result.EndsWith("/"))
                result += "/";
            return result;
        }

    }
}
