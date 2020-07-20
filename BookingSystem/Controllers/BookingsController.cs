using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.DTOs.Booking;
using BookingSystem.DTOs.Doctors;
using BookingSystem.Repositories.Bookings;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet("DocotrSearch")]
        public async Task<ActionResult<DoctorDto>> DocotrSearch(DoctorDto doctorDto)
        {
            var result = await _bookingRepository.GetSearch(doctorDto);
            return Ok(result);
        }

        [HttpPost("AddBooking")]
        public async Task<ActionResult> AddBooking([FromBody] BookingCreationDto creationDto)
        {
            if (creationDto == null)
                return NotFound();
            var booking = await _bookingRepository.AddAsync(creationDto);
            return Ok(booking);
        }

    }
}