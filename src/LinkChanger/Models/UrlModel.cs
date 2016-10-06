using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkChanger.Models
{
    public class UrlModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You should probably enter a URL.")]
        public string Url { get; set; }

        public string MappedUrl { get; set; }
    }
}
