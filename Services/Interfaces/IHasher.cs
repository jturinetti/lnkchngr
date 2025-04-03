using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lnkchngr.Services.Interfaces
{
    public interface IHasher
    {
        int HashMe(string value);
    }
}
