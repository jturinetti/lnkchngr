using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Services;
using LinkChanger.Services.Interfaces;
using Xunit;

namespace LinkChanger.Tests
{
    public class UrlGenerationStrategyTests
    {
        [Fact]
        public void HashUrlGenerationStrategy_NullArgument()
        {
            IUrlGenerationStrategy strategy = new HashUrlGenerationStrategy();
            Assert.Throws<ArgumentNullException>(() => strategy.GenerateUniqueUrlMap(null));
        }

        [Theory]
        [InlineData("http://www.google.com")]
        [InlineData("http://www.reddit.com/r/all")]
        [InlineData("https://www.facebook.com/")]
        public void HashUrlGenerationStrategy_ValidUrl(string url)  
        {
            var uri = new Uri(url);
            var hash = uri.AbsoluteUri.GetHashCode();

            IUrlGenerationStrategy strategy = new HashUrlGenerationStrategy();            

            var result = strategy.GenerateUniqueUrlMap(uri);

            Assert.NotNull(result);
            Assert.Equal(hash, result.SourceUrlHash);
            Assert.Equal(uri.AbsoluteUri, result.InputUrl.AbsoluteUri);
            Assert.EndsWith(hash.ToString(), result.UrlMap);
        }
    }
}
