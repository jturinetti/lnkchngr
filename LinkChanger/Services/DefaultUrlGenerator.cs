using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LinkChanger.Services
{
    public class DefaultUrlGenerator : IUrlGenerator
    {
        private readonly IUrlGenerationStrategy _strategy;
        private readonly IHttpContextAccessor _httpContextProvider;

        public DefaultUrlGenerator(IUrlGenerationStrategy strategy, IHttpContextAccessor httpContextProvider)
        {
            _strategy = strategy;
            _httpContextProvider = httpContextProvider;
        }

        public Uri GenerateUrl(Uri url)
        {
            var generatedUrlModel = _strategy.GenerateUniqueUrlMap(url);

            // TODO: incorporate database operations            

            if (_httpContextProvider.HttpContext.Request.Host.HasValue)
            {                
                var uriBuilder = new UriBuilder(_httpContextProvider.HttpContext.Request.Scheme,
                    _httpContextProvider.HttpContext.Request.Host.Host,
                    (_httpContextProvider.HttpContext.Request.Host.Port.HasValue ? _httpContextProvider.HttpContext.Request.Host.Port.Value : 80),
                    generatedUrlModel.MappedUrlSuffix);

                return uriBuilder.Uri;
                
            }
            else
            {
                // WHAT DO HERE??
                throw new InvalidOperationException();
            }
        }
    }
}
