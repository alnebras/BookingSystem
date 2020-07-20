using BookingSystem.DTOs.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.Regions
{
    public interface IRegionsRepository
    {
        Task<List<RegionDto>> GetAllRegionsAsync(Guid areaId);
        Task<RegionDto> AddAsync(RegionCreationDto model);
        Task<Guid> RemoveAsync(Guid patentId);
        Task<RegionDto> GetAsync(string ticketTypeId);
        Task<RegionDto> UpdateAsync(RegionUpdateDto updateDto);
        Task SaveAsync();
    }
}
