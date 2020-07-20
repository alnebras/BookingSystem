using System;

namespace BookingSystem.DTOs.Doctors.Specializations
{
    public class SpecializationDto
    {
        public Guid SpecializationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
