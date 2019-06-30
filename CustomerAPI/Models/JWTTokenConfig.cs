using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class JWTTokenConfig
    {
        public string Secret { get; set; }
        public int ExpirationTimeDays { get; set; }
        public int ExpirationOffsetHours { get; set; }
    }
}
