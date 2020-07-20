using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DTOs.Doctors
{
    public class DoctorUpdateDto
    {
        public Guid DoctorId { get; set; }
        public string FullName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Description { get; set; }
        public float DiacnoseCost { get; set; }
        public float CallCost { get; set; }
        public int ListCabacty { get; set; }
        public DateTime ReviewTime { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid AreaId { get; set; }
        public Guid RegionId { get; set; }
        public string SatarDay { get; set; }
        public string SunDay { get; set; }
        public string MonDay { get; set; }
        public string TuseDay { get; set; }
        public string WinsedrDay { get; set; }
        public string TharuseDay { get; set; }
        public string FrayDay { get; set; }
        public string HourFrom { get; set; }
        public string HourTo { get; set; }
    }
}
