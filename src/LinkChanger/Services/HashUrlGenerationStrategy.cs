using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Models;
using LinkChanger.Services.Interfaces;

namespace LinkChanger.Services
{
    public class HashUrlGenerationStrategy : IUrlGenerationStrategy
    {
        public UrlGenerationStrategyModel GenerateUniqueUrlMap(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri", "A valid Uri must be provided.");
            }

            var model = new UrlGenerationStrategyModel
            {
                InputUrl = uri
            };

            var hashCode = uri.AbsoluteUri.GetHashCode();

            model.SourceUrlHash = hashCode;
            model.UrlMap = hashCode.ToString();
            model.UrlMapHash = hashCode.ToString().GetHashCode();

            return model;
        }
    }
}