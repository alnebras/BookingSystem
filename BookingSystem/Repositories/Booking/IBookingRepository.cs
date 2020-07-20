using BookingSystem.DTOs.Booking;
using BookingSystem.DTOs.Doctors;
using BookingSystem.Models.Booking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.Bookings
{
    public interface IBookingRepository
    {
        Task<List<DoctorDto>> GetSearch(DoctorDto searchModel);
        Task<BookingDto> AddAsync(BookingCreationDto model);

    }
}
