using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkChanger.Data.Entities
{
    public class UrlMap
    {
        public int Id { get; set; }

        public string SourceUrl { get; set; }

        public string TargetUrl { get; set; }

        public int UrlHash { get; set; }
    }
}
