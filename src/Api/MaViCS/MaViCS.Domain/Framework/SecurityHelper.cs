using MaViCS.Domain.Framework.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaViCS.Domain.Framework
{
    public class SecurityHelper
    {
        private readonly IOptions<SecuritySettings> _settings;

        public SecurityHelper(IOptions<SecuritySettings> settings)
        {
            _settings = settings;
        }


    }
}
