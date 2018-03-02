using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidnightLizard.Commons.Domain.Versioning
{
    public class DomainVersion
    {
        public DomainVersion(string version)
        {
            Value = new SemVer.Version(version);
        }

        public virtual SemVer.Version Value { get; private set; }

        public override string ToString()
        {
            return Value?.ToString();
        }
    }
}
