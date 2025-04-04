using System.ComponentModel.DataAnnotations;

namespace lnkchngr.Models
{
    public class UrlModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You should probably enter a URL.")]
        [RegularExpression(Constants.ValidUrlRegularExpression, ErrorMessage = "Please enter a valid URL.")]
        public string Url { get; set; }

        public string MappedUrl { get; set; }
    }
}
