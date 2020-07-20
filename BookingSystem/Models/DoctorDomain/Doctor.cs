using BookingSystem.Models.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Models.DoctorDomain
{
    public class Doctor : Base
    {
        public string FullName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Description { get; set; }
        public float DiacnoseCost { get; set; }
        public float CallCost { get; set; }
        public int ListCabacty { get; set; }
        public DateTime ReviewTime { get; set; }
        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public Area Area { get; set; }
        public Guid AreaId { get; set; }
        public Region Region { get; set; }
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
        //public IEnumerable<OpenDays> OpenDays { get; set; }
    }
}
