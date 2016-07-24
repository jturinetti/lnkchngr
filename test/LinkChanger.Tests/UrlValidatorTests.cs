using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Services;
using LinkChanger.Services.Interfaces;
using Xunit;

namespace LinkChanger.Tests
{
    public class UrlValidatorTests
    {
        [Fact]
        public void UrlValidator_NullArgument()
        {
            IUrlValidator validator = new UrlValidator();
            Assert.Throws<ArgumentNullException>(() => validator.Validate(null));
        }        

        [Theory]
        [InlineData("")]
        [InlineData("justarandomstring")]
        [InlineData("awebsite.com")]
        [InlineData("ftp://myftpsite.com")]        
        public void UrlValidator_InvalidUrl(string url)
        {
            IUrlValidator validator = new UrlValidator();
            Assert.Throws<ArgumentException>(() => validator.Validate(url));
        }

        [Theory]
        [InlineData("http://www.google.com")]
        [InlineData("https://www.facebook.com")]
        [InlineData("https://reddit.com/r/all/")]
        [InlineData("http://awebsite?just=query&string=things")]
        public void UrlValidator_ValidUrl(string url)
        {
            IUrlValidator validator = new UrlValidator();
            Assert.NotNull(validator.Validate(url));
        }
    }
}
