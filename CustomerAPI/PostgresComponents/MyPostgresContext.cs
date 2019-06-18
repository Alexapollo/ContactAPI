using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.PostgresComponents
{
    public class MyPostgresContext : DbContext
    {
        public MyPostgresContext(DbContextOptions<MyPostgresContext> options)
            : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Telephone> Telephones { get; set; }

    }
}
