using AutoMapper;
using BookingSystem.Data;
using BookingSystem.DTOs.Doctors.Specializations;
using BookingSystem.Models.DoctorDomain;
using BookingSystem.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.DoctorsRepository.Specializations
{
    public class SpecializationsRepository : ISpecializationsRepository
    {
        private readonly DoctorBookingContext _context;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public SpecializationsRepository(DoctorBookingContext context, IUsersRepository usersRepository, IMapper mapper)
        {
            _context = context;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<SpecializationDto> AddAsync(SpecializationCreationDto model)
        {

            var specialization = _mapper.Map<Specialization>(model);

            specialization.CreatedBy = _usersRepository.GetCurrentUserId();
            specialization.CreatedOn = DateTime.Now;

            await _context.Specializations.AddAsync(specialization).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var specializationDto = _mapper.Map<SpecializationDto>(specialization);

            return specializationDto;
        }

        public List<SpecializationDto> GetAllSpecializations(SpecializationDto filter)
        {
            return _context.Specializations.Select(s => new SpecializationDto
            {
                Description = s.Description,
                Name = s.Name,
                SpecializationId = s.Id
            }).ToList();
        }

        public async Task<List<SpecializationDto>> GetAllSpecializationsAsync()
        {
            return _context.Specializations.Select(s => new SpecializationDto
            {
                Description = s.Description,
                Name = s.Name,
                SpecializationId = s.Id
            }).OrderBy(a => a.Name).ToList();
        }

        public Task<SpecializationDto> GetAsync(string ticketTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> RemoveAsync(Guid SpecializationId)
        {
            var specialization = _context.Specializations.FirstOrDefault(d => d.Id == SpecializationId);

            specialization.IsActive = false;

            specialization.DeletedBy = _usersRepository.GetCurrentUserId();
            specialization.DeletedOn = DateTime.Now;
            if (specialization != null)
            {
                _context.Specializations.Update(specialization);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return specialization.Id;
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Retrive Specialization and update him
        /// </summary>
        /// <param name="SpecializationId"></param>
        /// <returns></returns>
        public async Task<SpecializationDto> UpdateAsync(SpecializationUpdateDto updateDto)
        {
            var specializationMap = _mapper.Map<Specialization>(updateDto);
            var specialization = _context.Specializations.FirstOrDefault(d => d.Id == updateDto.SpecializationId);

            specialization.Name = updateDto.Name;
            specialization.Description = updateDto.Description;

            specialization.ModifiedBy = _usersRepository.GetCurrentUserId();
            specialization.ModifiedOn = DateTime.Now;
            if (specialization != null)
            {
                _context.Specializations.Update(specialization);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var specializationDto = _mapper.Map<SpecializationDto>(specializationMap);

            return specializationDto;
        }


    }
}
