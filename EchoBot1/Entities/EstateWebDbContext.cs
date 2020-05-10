using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBot1.Entities
{
    public class EstateWebDbContext : DbContext
    {
        public EstateWebDbContext(DbContextOptions<EstateWebDbContext> ops) : base(ops)
        {

        }

        public EstateWebDbContext() : base()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

    }
}
