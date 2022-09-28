using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Ftp
{
    public class FtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RootFolder { get; set; }
        public string BsInputFolder { get; set; }
        public string BsOutputFolder { get; set; }
        public string OsInputFolder { get; set; }
        public string OsOutputFolder { get; set; }
    }
}
