using Core.Models;
using Microsoft.Extensions.Logging;

namespace Utilities.Ftp
{
    public class FileController: IFtpController
    {
        private string _ftpRootFolder;
        private const string DEFAULT_EXTENSION = ".TXT";
        private static readonly object Lock = new();
        private ILogger _logger;

        public FileController(ILogger<FileController> logger, string ftpRootFolder = "")
        {
            _ftpRootFolder = ftpRootFolder;
            _logger = logger;
        }

        public void SetRootFolder(string rootFolder)
        {
            _logger.LogInformation("FileController rootfolder = {0}", rootFolder);
            _ftpRootFolder = rootFolder;
        }

        public void Put(string destination, string fileName, byte[] payload)
        {
            var fullPath = GetFullPath(destination);
            CreateDirectory(fullPath);
            var fullName = fullPath + @"\" + fileName;
            lock (Lock)
            {
                File.WriteAllBytes(fullName, payload);
            }
        }

        public string CopyFile(string fileName, string folder, string destination, bool deleteOriginal, bool verify)
        {
            var fullPath = GetFullPath(folder);
            if (!Directory.Exists(fullPath))
            {
                _logger.LogError("Directory {0} does not exist!", fullPath);
                return fileName;
            }
            var file = Path.Combine(fullPath, fileName);
            if (!File.Exists(file))
            {
                if (file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    var newName = file.Substring(0, file.Length - 4);
                    if (File.Exists(newName))
                    {
                        file = newName;
                        fileName = fileName.Substring(0, fullPath.Length - 4);
                    }
                }
                else
                {
                    var newName = file + DEFAULT_EXTENSION;
                    if (File.Exists(newName))
                    {
                        file = newName;
                        fileName += DEFAULT_EXTENSION;
                    }
                }
            }
            lock (Lock)
            {
                CreateDirectory(destination);
                var destinationFileName = Path.GetFileName(file);
                var destinationFilePath = Path.Combine(destination, destinationFileName);
                File.Copy(file, destinationFilePath, true);
                if (deleteOriginal && File.Exists(destinationFilePath))
                    File.Delete(file);
            }
            return fileName;
        }

        public InputFile? Get(string fileName, string folder)
        {
            var fullPath = GetFullPath(folder);
            if (!Directory.Exists(fullPath))
            {
                _logger.LogError("Directory {0} does not exist!", fullPath);
                return null;
            }
            var fullName = Path.Combine(fullPath, fileName);
            if (!File.Exists(fullName))
            {
                _logger.LogError("File {0} does not exist!", fullName);
                return null;
            }

            var fileInfo = new FileInfo(fullName);
            var content = new byte[fileInfo.Length];
            using (var fileStream = new FileStream(fullName, FileMode.Open, FileAccess.Read))
            {
                fileStream.Read(content, 0, (int)fileInfo.Length);
            }
            var inputFile = new InputFile()
            {
                FileName = fileInfo.Name,
                Size = fileInfo.Length,
                Content = content,
                CreatedDate = DateTime.Now,
            };
            return inputFile;
        }

        public List<string> GetFileList(string folderName)
        {
            var fullPath = GetFullPath(folderName);
            if (!Directory.Exists(fullPath))
                return new List<string>();
            var files = Directory.GetFiles(fullPath).Select(x => Path.GetFileName(x)).ToList();
            return files;
        }

        public void DeleteFile(string fileName, string folder)
        {
            try
            {
                var fullPath = GetFullPath(folder);
                var fullName = Path.Combine(fullPath, fileName);
                if (File.Exists(fullName))
                    File.Delete(fullName);
            }
            catch
            {
                // files cannot be deleted, move on
            }
        }

        public void Connect()
        {
            // No Connect needed
        }

        public void Disconnect()
        {
            // No Disconnect needed
        }

        public string GetFullPath(string folderName)
        {
            return Path.Combine(_ftpRootFolder, folderName);
        }

        public static void CreateDirectory(string fullPath)
        {
            lock (Lock)
            {
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);
            }
        }

        public void TryDeleteFiles(List<string> workingFiles, string folder)
        {
            foreach (var fileName in workingFiles)
            {
                DeleteFile(fileName, folder);
            }
        }
    }
}
