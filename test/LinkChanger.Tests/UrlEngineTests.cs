using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Tests.Fixtures;
using Xunit;

namespace LinkChanger.Tests
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
            // TODO
        }

        [Fact]
        public void LookupUrl_NullArgument()
        {
            // TODO
        }

        [Fact]
        public void LookupUrl_EmptyArgument()
        {
            // TODO
        }
    }
}
