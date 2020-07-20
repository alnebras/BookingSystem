using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DTOs.Doctors.OpenDaysDto
{
    public class OpenDaysDto
    {
        public string Satarday { get; set; }
        public string Sunday { get; set; }
        public string Monday { get; set; }
        public string Tuseday { get; set; }
        public string Wnesdday { get; set; }
        public string Thursday { get; set; }
        public string Friyday { get; set; }

        public int HoursFrom { get; set; }
        public int HoursTo { get; set; }
    }
}
