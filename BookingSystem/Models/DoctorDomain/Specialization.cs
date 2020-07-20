using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Models.DoctorDomain
{
    public class Specialization:Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
