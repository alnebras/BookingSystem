using BookingSystem.DTOs.Doctors.Specializations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.DoctorsRepository.Specializations
{
    public interface ISpecializationsRepository
    {
        Task<List<SpecializationDto>> GetAllSpecializationsAsync();
        Task<SpecializationDto> AddAsync(SpecializationCreationDto model);
        Task<Guid> RemoveAsync(Guid patentId);
        Task<SpecializationDto> GetAsync(string ticketTypeId);
        Task<SpecializationDto> UpdateAsync(SpecializationUpdateDto updateDto);
        Task SaveAsync();
    }
}
