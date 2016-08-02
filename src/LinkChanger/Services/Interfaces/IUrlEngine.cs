using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Models;

namespace LinkChanger.Services.Interfaces
{
    public interface IUrlEngine
    {
        UrlEngineResponseModel GenerateUrl(Uri url);

        UrlEngineResponseModel LookupUrl(string map);
    }
}
