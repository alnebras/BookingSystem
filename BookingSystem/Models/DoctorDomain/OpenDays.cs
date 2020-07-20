using BookingSystem.Enums;
using System;

namespace BookingSystem.Models.DoctorDomain
{
    public class OpenDays : Base
    {
        public OpenedDays OpenedDays { get; set; }
        public string Satarday { get; set; }
        public string Sunday { get; set; }
        public string Monday { get; set; }
        public string Tuseday { get; set; }
        public string Wnesdday { get; set; }
        public string Thursday { get; set; }
        public string Friyday { get; set; }

        //public int OpenedDaysFrom { get; set; }
        //public int OpenedDaysTo { get; set; }
        public int HoursFrom { get; set; }
        public int HoursTo { get; set; }
        public Doctor Doctors { get; set; }
        public Guid DoctorId { get; set; }
    }
}
