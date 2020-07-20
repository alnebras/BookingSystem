using System;
namespace BookingSystem.DTOs.Areas
{
    public class RegionDto
    {
        public Guid RegionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AreaId { get; set; }
    }
}
