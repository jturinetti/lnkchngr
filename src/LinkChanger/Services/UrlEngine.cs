using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Data.Contexts;
using LinkChanger.Models;
using LinkChanger.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LinkChanger.Services
{
    public class UrlEngine : IUrlEngine
    {
        private readonly IUrlGenerationStrategy _strategy;
        private readonly IHttpContextAccessor _httpContextProvider;
        private readonly IHasher _hasher;
        private readonly LinkChangerContext _context;        

        public UrlEngine(IUrlGenerationStrategy strategy, IHttpContextAccessor httpContextProvider, IHasher hasher, LinkChangerContext context)
        {
            _strategy = strategy;
            _httpContextProvider = httpContextProvider;
            _hasher = hasher;
            _context = context;            
        }

        public UrlEngineResponseModel GenerateUrl(Uri url)
        {
            // generate unique url mapping
            var generatedUrlModel = _strategy.GenerateUniqueUrlMap(url);

            // see if url already exists in database based on generated hash
            var existingRecord = _context.UrlMaps.FirstOrDefault(u => u.SourceUrlMapHash == generatedUrlModel.SourceUrlHash);
            if (existingRecord == null)
            {
                _context.UrlMaps.Add(new Data.Entities.UrlMap
                {
                    SourceUrl = generatedUrlModel.InputUrl.AbsoluteUri,
                    SourceUrlMapHash = generatedUrlModel.SourceUrlHash,
                    TargetUrlMap = generatedUrlModel.UrlMap,
                    TargetUrlMapHash = generatedUrlModel.UrlMapHash,
                    Created = DateTime.UtcNow,
                    LastAccessed = DateTime.MinValue
                });                
            }
            else
            {
                existingRecord.LastAccessed = DateTime.UtcNow;                
            }

            // TODO: add error handling to this method

            _context.SaveChanges();

            // build target url
            var uriBuilder = new UriBuilder(_httpContextProvider.HttpContext.Request.Scheme,
                    _httpContextProvider.HttpContext.Request.Host.Host,
                    (_httpContextProvider.HttpContext.Request.Host.Port.HasValue ? _httpContextProvider.HttpContext.Request.Host.Port.Value : 80),
                    generatedUrlModel.UrlMap);

            return new UrlEngineResponseModel
            {
                Url = uriBuilder.Uri
            };
        }

        public UrlEngineResponseModel LookupUrl(string map)
        {
            var mapHash = _hasher.HashMe(map);

            var model = new UrlEngineResponseModel();
            var result = _context.UrlMaps.FirstOrDefault(u => u.TargetUrlMapHash == mapHash);
            
            if (result == null)
            {
                model.ErrorMessage = "No matching URL found.";
                return model;
            }

            result.LastAccessed = DateTime.UtcNow;
            _context.SaveChanges();

            model.Url = new Uri(result.SourceUrl);
            return model;            
        }       
    }
}
