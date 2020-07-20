using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DTOs.Doctors.Specializations
{
    public class SpecializationUpdateDto
    {
        public Guid SpecializationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
