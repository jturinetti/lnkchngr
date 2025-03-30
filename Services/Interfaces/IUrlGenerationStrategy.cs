using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lnkchngr.Models;

namespace lnkchngr.Services.Interfaces
{
    public interface IUrlGenerationStrategy
    {
        UrlGenerationStrategyModel GenerateUniqueUrlMap(Uri uri);        
    }
}
