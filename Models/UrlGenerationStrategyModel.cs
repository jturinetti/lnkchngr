using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lnkchngr.Models
{
    public class UrlGenerationStrategyModel
    {
        public int SourceUrlHash { get; set; }

        public string UrlMap { get; set; }

        public int UrlMapHash { get; set; }

        public Uri InputUrl { get; set; }
    }
}
