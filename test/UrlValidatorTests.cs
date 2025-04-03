using lnkchngr.Services;
using lnkchngr.Services.Interfaces;
using Xunit;

namespace lnkchngr.Tests
{
    public class UrlValidatorTests
    {
        [Fact]
        public void UrlValidator_NullArgument()
        {
            IUrlValidator validator = new UrlValidator();
            Assert.Throws<ArgumentNullException>(() => validator.Validate(null));
        }        

        [Fact]
        public void UrlValidator_EmptyStringArgument()
        {
            IUrlValidator validator = new UrlValidator();
            Assert.Throws<ArgumentException>(() => validator.Validate(string.Empty));
        }

        [Theory]        
        [InlineData("justarandomstring")]
        [InlineData(".....oh hi there")]
        [InlineData("http://            derp")]        
        [InlineData("ftps//blah.crap")]
        [InlineData("mailto:fakeemail@test.com")]
        public void UrlValidator_InvalidUrl(string url)
        {
            IUrlValidator validator = new UrlValidator();
            Assert.Throws<ArgumentException>(() => validator.Validate(url));
        }

        [Theory]
        [InlineData("http://www.google.com")]
        [InlineData("http://google.com")]
        [InlineData("www.mycoolsite.com")]        
        [InlineData("https://www.facebook.com")]
        [InlineData("https://reddit.com/r/all/")]
        [InlineData("http://awebsite.net?just=query&string=things")]
        [InlineData("ftp://myftpsite.com")]
        public void UrlValidator_ValidUrl(string url)
        {
            IUrlValidator validator = new UrlValidator();
            Assert.NotNull(validator.Validate(url));
        }
    }
}
