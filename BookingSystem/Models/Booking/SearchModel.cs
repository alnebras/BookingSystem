using BookingSystem.Models.DoctorDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Models.Booking
{
    public class SearchModel
    {
        public Specialization  Specialization { get; set; }
        public Guid SpecializationId { get; set; }

        public Doctor Doctor{ get; set; }
        public Guid DoctorId { get; set; }

    }
}
