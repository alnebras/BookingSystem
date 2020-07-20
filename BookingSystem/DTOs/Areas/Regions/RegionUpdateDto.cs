using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DTOs.Areas
{
    public class RegionUpdateDto
    {
        public Guid RegionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AreaId { get; set; }
    }
}
