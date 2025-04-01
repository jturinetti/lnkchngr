using System.Text.RegularExpressions;
using lnkchngr.Services.Interfaces;

namespace lnkchngr.Services
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

            Uri uri;            
            if (Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                // no Uri.UriSchemeHttp in .NET Core?  WTF
                if (uri.Scheme == Constants.HTTP_SCHEME || uri.Scheme == Constants.HTTPS_SCHEME 
                    || uri.Scheme == Constants.FTP_SCHEME || uri.Scheme == Constants.FTPS_SCHEME)
                {
                    return uri;
                }

                throw new ArgumentException("Invalid Uri scheme.", nameof(url));                
            }
            else
            {
                // we may need to prepend the http scheme to the URL to get the Uri class to like it
                // ...if it is a valid URL
                if (Regex.IsMatch(url, Constants.ValidUrlRegularExpression))
                {
                    // assume user entered an HTTP url and help them out a bit
                    url = $"http://{url}";
                    if (Uri.TryCreate(url, UriKind.Absolute, out uri))
                    {
                        return uri;
                    }
                }                

                throw new ArgumentException("Was not able to form a valid Uri.", nameof(url));
            }            
        }
    }
}
