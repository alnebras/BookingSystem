using AutoMapper;
using BookingSystem.Data;
using BookingSystem.DTOs.Areas;
using BookingSystem.Models.Areas;
using BookingSystem.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.Regions
{
    public class RegionsRepository : IRegionsRepository
    {
        private readonly DoctorBookingContext _context;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public RegionsRepository(DoctorBookingContext context, IUsersRepository usersRepository, IMapper mapper)
        {
            _context = context;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<RegionDto> AddAsync(RegionCreationDto model)
        {

            var area = _mapper.Map<Region>(model);

            area.CreatedBy = _usersRepository.GetCurrentUserId();
            area.CreatedOn = DateTime.Now;

            await _context.Regions.AddAsync(area).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var areaDto = _mapper.Map<RegionDto>(area);

            return areaDto;
        }

        public async Task<List<RegionDto>> GetAllRegionsAsync(Guid AreaId)
        {
            return _context.Regions.Where(r => r.AreaId == AreaId)
               .Select(r => new RegionDto
               {
                   AreaId = r.Id,
                   Name = r.Name,
                   Description = r.Description,
                   RegionId = r.AreaId
               }).OrderBy(r => r.Name).ToList();
        }

        public Task<List<RegionDto>> GetAllTicketTypesAsync(RegionDto filter)
        {
            throw new NotImplementedException();
        }

        public Task<RegionDto> GetAsync(string ticketTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> RemoveAsync(Guid RegionId)
        {
            var area = _context.Regions.FirstOrDefault(d => d.Id == RegionId);

            area.IsActive = false;

            area.DeletedBy = _usersRepository.GetCurrentUserId();
            area.DeletedOn = DateTime.Now;
            if (area != null)
            {
                _context.Regions.Update(area);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return area.Id;
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Retrive Region and update him
        /// </summary>
        /// <param name="RegionId"></param>
        /// <returns></returns>
        public async Task<RegionDto> UpdateAsync(RegionUpdateDto updateDto)
        {
            var areaMap = _mapper.Map<Region>(updateDto);
            var area = _context.Regions.FirstOrDefault(d => d.Id == updateDto.RegionId);

            area.Name = updateDto.Name;
            area.Description = updateDto.Description;

            area.ModifiedBy = _usersRepository.GetCurrentUserId();
            area.ModifiedOn = DateTime.Now;
            if (area != null)
            {
                _context.Regions.Update(area);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);

            var areaDto = _mapper.Map<RegionDto>(areaMap);

            return areaDto;
        }
    }
}
