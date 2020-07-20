using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DTOs.Areas
{
    public class AreaUpdateDto
    {
        public Guid AreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
