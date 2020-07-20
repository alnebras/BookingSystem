using AutoMapper;
using BookingSystem.Data;
using BookingSystem.DTOs.Doctors;
using BookingSystem.Models.DoctorDomain;
using BookingSystem.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.DoctorsRepository
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly DoctorBookingContext _context;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public DoctorsRepository(DoctorBookingContext context, IUsersRepository usersRepository, IMapper mapper)
        {
            _context = context;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> AddAsync(DoctorCreationDto model)
        {

            var doctor = _mapper.Map<Doctor>(model);

            doctor.CreatedBy = _usersRepository.GetCurrentUserId();
            doctor.CreatedOn = DateTime.Now;


            await _context.Doctors.AddAsync(doctor).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var doctorDto = _mapper.Map<DoctorDto>(doctor);

            return doctorDto;
        }

        public async Task<List<DoctorDto>> GetAllDoctorsypesAsync()
        {
            var allDoctors = _context.Doctors.Select(s => new DoctorDto
            {
                Description = s.Description,
                FullName = s.FullName,
            }).OrderBy(a => a.FullName).ToList();

            return allDoctors;
        }

        public Task<List<DoctorDto>> GetAllTicketTypesAsync(DoctorDto filter)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorDto> GetAsync(string ticketTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> RemoveAsync(Guid DoctorId)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == DoctorId);

            doctor.IsActive = false;
            
            doctor.DeletedBy = _usersRepository.GetCurrentUserId();
            doctor.DeletedOn = DateTime.Now;
            if (doctor != null)
            {
                _context.Doctors.Update(doctor);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return doctor.Id;
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Retrive Doctor and update him
        /// </summary>
        /// <param name="DoctorId"></param>
        /// <returns></returns>
        public async Task<DoctorDto> UpdateAsync(DoctorUpdateDto updateDto)
        {
            var doctorMap = _mapper.Map<Doctor>(updateDto);
            var doctor =  _context.Doctors.FirstOrDefault(d => d.Id == updateDto.DoctorId);

            doctor.FullName = updateDto.FullName;
            doctor.SpecializationId = updateDto.SpecializationId;
            doctor.Phone1 = updateDto.Phone1;
            doctor.Phone2 = updateDto.Phone2;
            doctor.Description = updateDto.Description;
            doctor.CallCost = updateDto.CallCost;
            doctor.DiacnoseCost = updateDto.DiacnoseCost;
            doctor.ListCabacty = updateDto.ListCabacty;
            doctor.ModifiedBy = _usersRepository.GetCurrentUserId();
            doctor.ModifiedOn = DateTime.Now;
            if (doctor != null)
            {
                _context.Doctors.Update(doctor);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var doctorDto = _mapper.Map<DoctorDto>(doctorMap);

            return doctorDto;
        }
    }
}
