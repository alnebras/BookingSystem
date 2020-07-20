using BookingSystem.DTOs.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Repositories.DoctorsRepository
{
    public interface IDoctorsRepository
    {
        Task<List<DoctorDto>> GetAllDoctorsypesAsync();
        Task<DoctorDto> AddAsync(DoctorCreationDto model);
        Task<Guid> RemoveAsync(Guid DoctorId);
        Task<DoctorDto> GetAsync(string ticketTypeId);
        Task<DoctorDto> UpdateAsync(DoctorUpdateDto  updateDto);
        Task SaveAsync();
    }
}
