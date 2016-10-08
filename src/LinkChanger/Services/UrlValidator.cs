using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                throw new ArgumentNullException(nameof(url));
            }

            if (url == string.Empty)
            {
                throw new ArgumentException("A URL must be provided.", nameof(url));
            }

            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            if (!Regex.IsMatch(url, Constants.ValidUrlRegularExpression))
            {
                throw new ArgumentException("Invalid URL format.", nameof(url));
            }            

            Uri uri;
            if (Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                return uri;
            }
            else
            {
                throw new ArgumentException("Was not able to form Uri for this argument.", nameof(url));
            }            
        }
    }
}
