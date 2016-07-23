using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkChanger.Services.Interfaces;

namespace LinkChanger.Services
{
    public class DefaultUrlGenerator : IUrlGenerator
    {
        private readonly IUrlGenerationStrategy _strategy;

        public DefaultUrlGenerator(IUrlGenerationStrategy strategy)
        {
            _strategy = strategy;
        }

        public Uri GenerateUrl()
        {
            throw new NotImplementedException();
        }
    }
}
