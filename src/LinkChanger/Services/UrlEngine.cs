using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Data.Contexts;
using LinkChanger.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LinkChanger.Services
{
    public class UrlEngine : IUrlEngine
    {
        private readonly IUrlGenerationStrategy _strategy;
        private readonly IHttpContextAccessor _httpContextProvider;
        private readonly LinkChangerContext _context;

        public UrlEngine(IUrlGenerationStrategy strategy, IHttpContextAccessor httpContextProvider, LinkChangerContext context)
        {
            _strategy = strategy;
            _httpContextProvider = httpContextProvider;
            _context = context;
        }

        public Uri GenerateUrl(Uri url)
        {
            // generate unique url mapping
            var generatedUrlModel = _strategy.GenerateUniqueUrlMap(url);

            // build target url
            var uriBuilder = new UriBuilder(_httpContextProvider.HttpContext.Request.Scheme,
                    _httpContextProvider.HttpContext.Request.Host.Host,
                    (_httpContextProvider.HttpContext.Request.Host.Port.HasValue ? _httpContextProvider.HttpContext.Request.Host.Port.Value : 80),
                    generatedUrlModel.MappedUrlSuffix);            

            // very simple, dumb method to get data into database
            var existingMappedUrls = _context.UrlMaps.Where(u => u.UrlHash == generatedUrlModel.HashCode).ToList();            
            if (existingMappedUrls.Any())
            {
                // ensure existing row is the same as the generated model (it should be?)
                if (existingMappedUrls.First().SourceUrl != generatedUrlModel.InputUrl.AbsoluteUri)
                {
                    throw new Exception("NOT EQUAL VALUES!");
                }
            }
            else
            {
                _context.UrlMaps.Add(new Data.Entities.UrlMap
                {
                    SourceUrl = generatedUrlModel.InputUrl.AbsoluteUri,
                    TargetUrl = uriBuilder.Uri.AbsoluteUri,
                    UrlHash = generatedUrlModel.HashCode
                });

                _context.SaveChanges();
            }

            return uriBuilder.Uri;            
        }

        public Uri LookupUrl(string map)
        {
            // another dumb, simple way of handling this since I'm too tired to think right now
            var firstResult = _context.UrlMaps.FirstOrDefault(u => u.TargetUrl.EndsWith(map));
            if (firstResult == null)
            {
                throw new Exception("URL NOT FOUND");
            }

            return new Uri(firstResult.SourceUrl);
        }
    }
}
