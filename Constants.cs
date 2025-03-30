using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lnkchngr
{
    public static class Constants
    {           
        public const string ValidUrlRegularExpression = @"^([a-zA-Z]+\:\/\/)?([a-zA-Z0-9]+(\.[a-zA-Z0-9]+)+.*)$";
        public const string HTTP_SCHEME = "http";
        public const string HTTPS_SCHEME = "https";
        public const string FTP_SCHEME = "ftp";
        public const string FTPS_SCHEME = "ftps";
    }
}
