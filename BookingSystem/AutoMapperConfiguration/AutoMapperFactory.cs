using AutoMapper;
using BookingSystem.Mapping.Areas;
using BookingSystem.Mapping.Bookings;
using BookingSystem.Mapping.Doctors;
using BookingSystem.Mapping.Patents;
using BookingSystem.Mapping.Regions;
using BookingSystem.Mapping.Specializations;
using BookingSystem.Mapping.Users;
namespace BookingSystem.AutoMapperConfiguration
{
    public class AutoMapperFactory
    {
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(cgf =>
          {
              cgf.AddProfile<UserProfile>();
              cgf.AddProfile<DoctorProfile>();
              cgf.AddProfile<PatentProfile>();
              cgf.AddProfile<AreaProfile>();
              cgf.AddProfile<RegionProfile>();
              cgf.AddProfile<SpecializationProfile>();
              cgf.AddProfile<BookingProfile>();
          }).CreateMapper();

        }
    }
}
