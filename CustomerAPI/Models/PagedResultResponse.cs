using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class PagedResultResponse<T> where T : class
    {
        public IEnumerable<T> Results { get; set; }
        public int TotalPages { get; set; }
    }
}
