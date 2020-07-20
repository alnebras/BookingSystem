using BookingSystem.DTOs.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.Areas
{
    public interface IAreasRepository
    {
        Task<List<AreaDto>> GetAllAreasAsync();
        Task<AreaDto> AddAsync(AreaCreationDto model);
        Task<Guid> RemoveAsync(Guid patentId);
        Task<AreaDto> GetAsync(string ticketTypeId);
        Task<AreaDto> UpdateAsync(AreaUpdateDto updateDto);
        Task SaveAsync();
    }
}
