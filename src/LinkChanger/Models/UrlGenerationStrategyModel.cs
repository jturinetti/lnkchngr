using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkChanger.Models
{
    public class UrlGenerationStrategyModel
    {
        public int HashCode { get; set; }

        public string MappedUrlSuffix { get; set; }

        public Uri InputUrl { get; set; }
    }
}
