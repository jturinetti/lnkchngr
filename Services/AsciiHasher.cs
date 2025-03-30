using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lnkchngr.Services.Interfaces;

namespace lnkchngr.Services
{
    public class AsciiHasher : IHasher
    {
        public int HashMe(string value)
        {
            var hash = 0;            

            if (!string.IsNullOrEmpty(value))
            {
                var counter = 1;
                foreach (var c in value)
                {
                    hash = hash + 23 + (counter * Convert.ToInt32(c));
                    counter++;
                }
            }

            return hash;
        }
    }
}
