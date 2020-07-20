using BookingSystem.Models.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Models.DoctorDomain
{
    public class DoctorArea : Base
    {
        public Area Area { get; set; }
        public Guid AreaId { get; set; }

        public Doctor Doctor { get; set; }
        public Guid DoctorId { get; set; }
    }
}
