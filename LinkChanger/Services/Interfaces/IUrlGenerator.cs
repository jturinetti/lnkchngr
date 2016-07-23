using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkChanger.Services.Interfaces
{
    public interface IUrlGenerator
    {
        Uri GenerateUrl();
    }
}
