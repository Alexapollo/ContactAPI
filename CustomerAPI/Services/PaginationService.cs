using CustomerAPI.Models;
using CustomerAPI.PostgresComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class PaginationService : IPagination
    {
        private readonly MyPostgresContext _context;
        private readonly int pageSize = 2;

        public PaginationService(MyPostgresContext context)
        {
            _context = context;
        }

        public int CalculateTotalPages()
        {
            return (int)Math.Ceiling((double)_context.Contacts.Count() / pageSize);
        }

        public IEnumerable<Contact> PagingContacts(int page)
        {
            var total = _context.Contacts.Count();
            var skip = pageSize * (page - 1);
            var canPage = skip < total;

            if (!canPage) { return null; }

            return _context.Contacts
                .Skip(skip)
                .Take(pageSize);
        }
    }
}
