using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Models.Areas
{
    public class Region:Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AreaId { get; set; }
        public Area  Areas { get; set; }
    }
}
