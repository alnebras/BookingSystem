using AutoMapper;
using BookingSystem.Data;
using BookingSystem.DTOs.Areas;
using BookingSystem.Models.Areas;
using BookingSystem.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.Areas
{

    public class AreasRepository : IAreasRepository
    {
        private readonly DoctorBookingContext _context;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public AreasRepository(DoctorBookingContext context, IUsersRepository usersRepository, IMapper mapper)
        {
            _context = context;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<AreaDto> AddAsync(AreaCreationDto model)
        {

            var area = _mapper.Map<Area>(model);

            area.CreatedBy = _usersRepository.GetCurrentUserId();
            area.CreatedOn = DateTime.Now;

            await _context.Areas.AddAsync(area).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var areaDto = _mapper.Map<AreaDto>(area);

            return areaDto;
        }

        public async Task<List<AreaDto>> GetAllAreasAsync()
        {
            return _context.Areas.Select(a => new AreaDto
            {
                AreaId = a.Id,
                Name = a.Name,
                Description = a.Description
            }).OrderBy(a => a.Name).ToList();
        }

        public Task<List<AreaDto>> GetAllTicketTypesAsync(AreaDto filter)
        {
            throw new NotImplementedException();
        }

        public Task<AreaDto> GetAsync(string ticketTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> RemoveAsync(Guid AreaId)
        {
            var area = _context.Areas.FirstOrDefault(d => d.Id == AreaId);

            area.IsActive = false;

            area.DeletedBy = _usersRepository.GetCurrentUserId();
            area.DeletedOn = DateTime.Now;
            if (area != null)
            {
                _context.Areas.Update(area);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return area.Id;
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Retrive Area and update him
        /// </summary>
        /// <param name="AreaId"></param>
        /// <returns></returns>
        public async Task<AreaDto> UpdateAsync(AreaUpdateDto updateDto)
        {
            var areaMap = _mapper.Map<Area>(updateDto);
            var area = _context.Areas.FirstOrDefault(d => d.Id == updateDto.AreaId);

            area.Name = updateDto.Name;
            area.Description = updateDto.Description;

            area.ModifiedBy = _usersRepository.GetCurrentUserId();
            area.ModifiedOn = DateTime.Now;
            if (area != null)
            {
                _context.Areas.Update(area);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var areaDto = _mapper.Map<AreaDto>(areaMap);

            return areaDto;
        }
    }
}
