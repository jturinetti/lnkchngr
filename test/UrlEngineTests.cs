using lnkchngr.Tests.Fixtures;
using Xunit;

namespace lnkchngr.Tests
{
    public class UrlEngineTests : IClassFixture<UrlEngineFixture>
    {
        private readonly UrlEngineFixture _testContext;        

        public UrlEngineTests(UrlEngineFixture testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public void GenerateUrl_NullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => _testContext.UrlEngine.GenerateUrl(null));
        }

        [Fact]
        public void LookupUrl_NullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => _testContext.UrlEngine.LookupUrl(null));
        }

        [Fact]
        public void LookupUrl_EmptyArgument()
        {
            Assert.Throws<ArgumentException>(() => _testContext.UrlEngine.LookupUrl(string.Empty));
        }
    }
}
