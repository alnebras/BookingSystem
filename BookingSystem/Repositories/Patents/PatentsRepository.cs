using AutoMapper;
using BookingSystem.Data;
using BookingSystem.DTOs.Patents;
using BookingSystem.Models.PatentsDomain;
using BookingSystem.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.Patents
{
    public class PatentsRepository : IPatentsRepository
    {
        private readonly DoctorBookingContext _context;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public PatentsRepository(DoctorBookingContext context, IUsersRepository usersRepository, IMapper mapper)
        {
            _context = context;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<PatentDto> AddAsync(PatentCreationDto model)
        {

            var patent = _mapper.Map<Patent>(model);

            patent.CreatedBy = _usersRepository.GetCurrentUserId();
            patent.CreatedOn = DateTime.Now;

            await _context.Patents.AddAsync(patent).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var patentDto = _mapper.Map<PatentDto>(patent);

            return patentDto;
        }

        public Task<List<PatentDto>> GetAllPatentsypesAsync(PatentDto filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<PatentDto>> GetAllTicketTypesAsync(PatentDto filter)
        {
            throw new NotImplementedException();
        }

        public Task<PatentDto> GetAsync(string ticketTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> RemoveAsync(Guid PatentId)
        {
            var patent = _context.Patents.FirstOrDefault(d => d.Id == PatentId);

            patent.IsActive = false;

            patent.DeletedBy = _usersRepository.GetCurrentUserId();
            patent.DeletedOn = DateTime.Now;
            if (patent != null)
            {
                _context.Patents.Update(patent);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return patent.Id;
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Retrive Patent and update him
        /// </summary>
        /// <param name="PatentId"></param>
        /// <returns></returns>
        public async Task<PatentDto> UpdateAsync(PatentUpdateDto updateDto)
        {
            var patentMap = _mapper.Map<Patent>(updateDto);
            var patent = _context.Patents.FirstOrDefault(d => d.Id == updateDto.PatentId);

            patent.Name = updateDto.Name;
            patent.Address = updateDto.Address;
            patent.Phone1 = updateDto.Phone1;
            patent.Phone2 = updateDto.Phone2;          
            patent.ModifiedBy = _usersRepository.GetCurrentUserId();
            patent.ModifiedOn = DateTime.Now;
            if (patent != null)
            {
                _context.Patents.Update(patent);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var patentDto = _mapper.Map<PatentDto>(patentMap);

            return patentDto;
        }
    }
}
