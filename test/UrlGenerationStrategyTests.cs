using lnkchngr.Services;
using lnkchngr.Services.Interfaces;
using Xunit;

namespace lnkchngr.Tests
{
    public class UrlGenerationStrategyTests
    {
        [Fact]
        public void HashUrlGenerationStrategy_NullArgument()
        {
            IHasher hasher = new AsciiHasher();
            IUrlGenerationStrategy strategy = new HashUrlGenerationStrategy(hasher);
            Assert.Throws<ArgumentNullException>(() => strategy.GenerateUniqueUrlMap(null));
        }

        [Theory]
        [InlineData("http://www.google.com")]
        [InlineData("http://www.reddit.com/r/all")]
        [InlineData("https://www.facebook.com/")]
        public void HashUrlGenerationStrategy_ValidUrl(string url)  
        {
            IHasher hasher = new AsciiHasher();
            var uri = new Uri(url);
            var hash = hasher.HashMe(uri.AbsoluteUri);

            IUrlGenerationStrategy strategy = new HashUrlGenerationStrategy(hasher);

            var result = strategy.GenerateUniqueUrlMap(uri);

            Assert.NotNull(result);
            Assert.Equal(hash, result.SourceUrlHash);
            Assert.Equal(uri.AbsoluteUri, result.InputUrl.AbsoluteUri);
            Assert.EndsWith(hash.ToString(), result.UrlMap);
        }
    }
}
