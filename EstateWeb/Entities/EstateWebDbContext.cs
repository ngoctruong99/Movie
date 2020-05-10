using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Entities
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

        public DbSet<Info> Info { get; set; }


        public DbSet<User> Details { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Ward> Wards { get; set; }



        public DbSet<Street> Streets { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Seat> Seats { get; set; }

    }
}
