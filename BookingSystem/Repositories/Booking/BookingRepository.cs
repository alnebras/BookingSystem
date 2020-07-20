using AutoMapper;
using BookingSystem.Data;
using BookingSystem.DTOs.Booking;
using BookingSystem.DTOs.Doctors;
using BookingSystem.Models.Bookings;
using BookingSystem.Models.DoctorDomain;
using BookingSystem.Repositories.Bookings;
using BookingSystem.Repositories.DoctorsRepository;
using BookingSystem.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.BookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DoctorBookingContext _context;
        private readonly IUsersRepository _usersRepository;
        private readonly IDoctorsRepository _doctorRepository;
        private readonly IMapper _mapper;
        public BookingRepository(DoctorBookingContext context, IUsersRepository usersRepository, IDoctorsRepository doctorsRepository, IMapper mapper)
        {
            _context = context;
            _usersRepository = usersRepository;
            _doctorRepository = doctorsRepository;
            _mapper = mapper;
        }

        public async Task<BookingDto> AddAsync(BookingCreationDto model)
        {
            var DLCDoctor = _context.Doctors.Where(d => d.Id == model.DoctorId).FirstOrDefault().ListCabacty;

            var booking = _mapper.Map<Booking>(model);
            booking.CreatedBy = _usersRepository.GetCurrentUserId();
            booking.CreatedOn = DateTime.Now;

            var DLCBooking = _context.Bookings.Where(b => b.DoctorId == model.DoctorId && b.CreatedOn.Day == DateTime.Now.Day)
                .Count(b => b.DoctorId == model.DoctorId);
            if (DLCBooking < DLCDoctor)
            {
                await _context.Bookings.AddAsync(booking).ConfigureAwait(false);
            }
            else
            {
                return null;
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
            var bookingDto = _mapper.Map<BookingDto>(booking);
            return bookingDto;
        }

        public async Task<List<DoctorDto>> GetSearch(DoctorDto searchModel)
        {
       

            var result = await _context.Doctors.
                   Include(d => d.Specialization)
                  .Include(d => d.Region)
                  .Include(d => d.Area)
                  //.Include(d => d.OpenDays)
                  .Where(dr => dr.IsActive == true
                  & (dr.FullName.Trim().Contains(searchModel.FullName) || string.IsNullOrEmpty(searchModel.FullName))
                  & (dr.SpecializationId == new Guid(searchModel.SpecializationId) || string.IsNullOrEmpty(searchModel.SpecializationId))
                  & (dr.AreaId == new Guid(searchModel.AreaId) || string.IsNullOrEmpty(searchModel.AreaId))
                  & (dr.RegionId == new Guid(searchModel.RegionId) || string.IsNullOrEmpty(searchModel.RegionId)))
                  .Select(dr => new DoctorDto
                  {
                      Id = dr.Id,
                      FullName = dr.FullName,
                      Phone1 = dr.Phone1,
                      Phone2 = dr.Phone2,
                      DiacnoseCost = dr.DiacnoseCost,
                      SpecializationName = dr.Specialization.Name,
                      CallCost = dr.CallCost,
                      ListCabacty = dr.ListCabacty,
                      AreaName = dr.Area.Name,
                      RegionName = dr.Region.Name,
                      ReviewTime = dr.ReviewTime,
                      IsActive = dr.IsActive,
                      SatarDay = dr.SatarDay,
                      SunDay = dr.SunDay,
                      MonDay = dr.MonDay,
                      TuseDay = dr.TuseDay,
                      WinsedrDay = dr.WinsedrDay,
                      TharuseDay = dr.TharuseDay,
                      FrayDay = dr.FrayDay,
                      HourFrom = dr.HourFrom,
                      HourTo = dr.HourTo

                      //OpenDays = dr.OpenDays.Select(od => od.Satarday)
                  }).ToListAsync();
            return result;
        }

    }
}
