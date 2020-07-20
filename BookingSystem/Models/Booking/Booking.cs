using BookingSystem.Enums;
using BookingSystem.Models.DoctorDomain;
using BookingSystem.Models.PatentsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Models.Bookings
{
    public class Booking:Base
    {
        public Doctor Doctors { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatentId { get; set; }
        public Patent Patents { get; set; }
        public string PatentRating { get; set; }
        public BookingType bookingType { get; set; }
        public bool Status { get; set; }
    }
}
