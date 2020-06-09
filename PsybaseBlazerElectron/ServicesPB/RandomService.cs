using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsybaseBlazerElectron.ServicesPB
{
    public class RandomService
    {
        public Guid RandomId { get; } = Guid.NewGuid();

    }

    public class RandomServiceChange
    {
        public Guid RandomId { get; } = Guid.NewGuid();

    }

   
}
