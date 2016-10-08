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
        private readonly IHasher _hasher;

        public HashUrlGenerationStrategy(IHasher hasher)
        {
            _hasher = hasher;
        }

        public UrlGenerationStrategyModel GenerateUniqueUrlMap(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri), "A valid Uri must be provided.");
            }

            var model = new UrlGenerationStrategyModel
            {
                InputUrl = uri
            };

            var hashCode = _hasher.HashMe(uri.AbsoluteUri);

            model.SourceUrlHash = hashCode;
            model.UrlMap = hashCode.ToString();
            model.UrlMapHash = _hasher.HashMe(hashCode.ToString());            

            return model;
        }
    }
}