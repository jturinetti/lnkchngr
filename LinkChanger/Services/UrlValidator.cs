using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Services.Interfaces;

namespace LinkChanger.Services
{
    public class UrlValidator : IUrlValidator
    {
        public Uri Validate(string url)
        {
            // TODO: add ACTUAL validation
            return new Uri(url);
        }
    }
}
