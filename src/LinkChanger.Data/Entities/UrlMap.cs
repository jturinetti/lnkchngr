using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkChanger.Data.Entities
{
    [Table("UrlMap")]
    public class UrlMap
    {
        [Key]
        public int Id { get; set; }

        public string SourceUrl { get; set; }

        public int SourceUrlMapHash { get; set; }

        public string TargetUrlMap { get; set; }

        public int TargetUrlMapHash { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastAccessed { get; set; }
    }
}
