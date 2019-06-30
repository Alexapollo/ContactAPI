using CustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public interface IPagination
    {
        IEnumerable<Contact> PagingContacts(int page);

        int CalculateTotalPages();
    }
}
