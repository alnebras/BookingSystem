using BookingSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DTOs.Booking
{
    public class BookingUpdateDto
    {
        public Guid DoctorId { get; set; }
        public Guid PatentId { get; set; }
        public string PatentRating { get; set; }
        public BookingType bookingType { get; set; }
        public bool Status { get; set; }
    }
}
