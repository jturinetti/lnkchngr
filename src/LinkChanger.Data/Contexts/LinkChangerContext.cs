using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkChanger.Data.Contexts
{
    public class LinkChangerContext : DbContext
    {
        public LinkChangerContext(DbContextOptions<LinkChangerContext> options)
            : base(options)
        { }

        public DbSet<UrlMap> UrlMaps { get; set; }
    }
}
