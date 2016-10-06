using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Data.Contexts;
using LinkChanger.Data.Entities;
using LinkChanger.Models;
using LinkChanger.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LinkChanger.Tests.Fixtures
{
    public class UrlEngineFixture
    {
        public Mock<IUrlGenerationStrategy> UrlGenerationStrategyMock
        {
            get;
            private set;
        }

        public Mock<IHttpContextAccessor> HttpContextProviderMock
        {
            get;
            private set;
        }

        public Mock<IHasher> HasherMock
        {
            get;
            private set;
        }

        public Mock<LinkChangerContext> DbContextMock
        {
            get;
            private set;
        }

        public UrlEngineFixture()
        {
            UrlGenerationStrategyMock = new Mock<IUrlGenerationStrategy>();
            UrlGenerationStrategyMock.Setup(m => m.GenerateUniqueUrlMap(It.IsAny<Uri>()))
                .Returns<UrlGenerationStrategyModel>(r => new UrlGenerationStrategyModel
                {
                    InputUrl = new Uri("http://www.google.com"),
                    SourceUrlHash = 12345,
                    UrlMap = "heyitsmeurgooglehash",
                    UrlMapHash = 67890
                });

            HttpContextProviderMock = new Mock<IHttpContextAccessor>();
            var httpContextMock = new Mock<HttpContext>();
            var httpRequestMock = new Mock<HttpRequest>();
            httpRequestMock.Setup(m => m.Scheme).Returns("http");
            httpRequestMock.Setup(m => m.Host).Returns(new HostString("arandomhost.com", 12345));
            httpContextMock.Setup(m => m.Request).Returns(httpRequestMock.Object);
            HttpContextProviderMock.Setup(m => m.HttpContext).Returns(httpContextMock.Object);

            HasherMock = new Mock<IHasher>();
            HasherMock.Setup(m => m.HashMe(It.IsAny<string>())).Returns(99999);

            DbContextMock = new Mock<LinkChangerContext>();
            var urlMapList = new List<UrlMap>()
            {
                new UrlMap
                {
                    Id = 10,
                    SourceUrl = "source1",
                    SourceUrlMapHash = 2323,
                    TargetUrlMap = "target1",
                    TargetUrlMapHash = 2424,
                    Created = DateTime.UtcNow.AddMonths(-10),
                    LastAccessed = DateTime.UtcNow.AddMonths(-5)
                }
            };            
            
            // TODO: set up DbContextMock here
        }
    }
}
