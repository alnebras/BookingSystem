using AutoMapper;
using BookingSystem.DTOs.Booking;
using BookingSystem.Models.Bookings;
namespace BookingSystem.Mapping.Bookings
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            // Mapp to Create New Booking
            CreateMap<BookingCreationDto, Booking>();

            CreateMap<BookingDto, Booking>();
            CreateMap<Booking, BookingDto>();

            // Mapp to Update Exsisting Booking
            CreateMap<BookingUpdateDto, Booking>();
        }
    }
}
