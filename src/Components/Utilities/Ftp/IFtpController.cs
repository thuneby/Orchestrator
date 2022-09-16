using Core.Models;

namespace Utilities.Ftp
{
    public interface IFtpController
    {
        void SetRootFolder(string rootFolder);
        void Put(string destination, string fileName, byte[] payload);
        string CopyFile(string fileName, string folder, string destination, bool deleteOriginal, bool verify);
        InputFile? Get(string fileName, string folder);
        List<string> GetFileList(string folder);
        void DeleteFile(string fileName, string folder);
        void Connect();
        void Disconnect();
    }
}
