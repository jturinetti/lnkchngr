using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lnkchngr.Models;
using lnkchngr.Services;
using lnkchngr.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;

namespace lnkchngr.Tests.Fixtures
{
    public class UrlEngineFixture
    {
        public UrlEngine UrlEngine
        {
            get;
            private set;
        }

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

        /*public Mock<LinkChangerContext> DbContextMock
        {
            get;
            private set;
        }*/

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

            /*var urlMapList = new List<UrlMap>()
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
            }.AsQueryable();

            DbContextMock = new Mock<LinkChangerContext>();
            var dbSetMock = new Mock<DbSet<UrlMap>>();
            dbSetMock.As<IQueryable<UrlMap>>().Setup(m => m.Provider).Returns(urlMapList.Provider);
            dbSetMock.As<IQueryable<UrlMap>>().Setup(m => m.ElementType).Returns(urlMapList.ElementType);
            dbSetMock.As<IQueryable<UrlMap>>().Setup(m => m.Expression).Returns(urlMapList.Expression);
            dbSetMock.As<IQueryable<UrlMap>>().Setup(m => m.GetEnumerator()).Returns(urlMapList.GetEnumerator());

            DbContextMock.Setup(m => m.UrlMaps).Returns(dbSetMock.Object);*/

            UrlEngine = new UrlEngine(UrlGenerationStrategyMock.Object,
                HttpContextProviderMock.Object,
                HasherMock.Object);
                // DbContextMock.Object);
        }
    }
}
