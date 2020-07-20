using BookingSystem.DTOs.Patents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.Patents
{
    public interface IPatentsRepository
    {
        Task<List<PatentDto>> GetAllPatentsypesAsync(PatentDto filter);
        Task<PatentDto> AddAsync(PatentCreationDto model);
        Task<Guid> RemoveAsync(Guid patentId);
        Task<PatentDto> GetAsync(string ticketTypeId);
        Task<PatentDto> UpdateAsync(PatentUpdateDto updateDto);
        Task SaveAsync();
    }
}
