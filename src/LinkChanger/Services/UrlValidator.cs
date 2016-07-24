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
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            if (!url.StartsWith("http"))
            {
                throw new ArgumentException("URL must begin with http.", "url");
            }

            Uri uri;

            if (Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                return uri;
            }
            else
            {
                throw new ArgumentException("Invalid URL format.", "url");
            }            
        }
    }
}
