using BookingSystem.Models;
using BookingSystem.Models.Areas;
using BookingSystem.Models.Booking;
using BookingSystem.Models.Bookings;
using BookingSystem.Models.DoctorDomain;
using BookingSystem.Models.PatentsDomain;
using BookingSystem.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Data
{
    public class DoctorBookingContext : DbContext
    {
        public DoctorBookingContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // apply to all configuration files
            builder.ApplyConfigurationsFromAssembly(typeof(DoctorBookingContext).Assembly);

            base.OnModelCreating(builder);
        }

        // Users Domain
        public DbSet<User> Users { get; set; }

        // Doctors Domain
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<OpenDays> OpenDays { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
  
        //public DbSet<DoctorArea> DoctorAreas { get; set; }
        // Patents Domain 
        public DbSet<Patent> Patents { get; set; }

        // Areas Domain
        public DbSet<Area> Areas { get; set; }
        public DbSet<Region> Regions { get; set; }

        // Booking Domain
        public DbSet<Booking> Bookings { get; set; }

    }
}
