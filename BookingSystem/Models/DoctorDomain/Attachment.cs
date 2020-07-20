using BookingSystem.Enums;
namespace BookingSystem.Models.DoctorDomain
{
    public class Attachment : Base
    {
        public string DocumentName { get; set; }
        public string Url { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctors { get; set; }

    }
}
