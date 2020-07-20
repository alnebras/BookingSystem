using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.DTOs.Doctors;
using BookingSystem.Repositories.DoctorsRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository _doctorsRepository;
        public DoctorsController(IDoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        //[Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<DoctorDto>> GetAll()
        {
            var sps = await _doctorsRepository.GetAllDoctorsypesAsync();
            return Ok(sps);
        }

        /// <summary>
        /// Create New Doctor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] DoctorCreationDto model)
        {
            if(model == null)
                return NotFound();
            var doctor = await _doctorsRepository.AddAsync(model).ConfigureAwait(false);
            return Ok(doctor);
        }

        [HttpPut("Update/{DoctorId}")]
        public async Task<ActionResult> Update([FromBody] DoctorUpdateDto updateDto,Guid DoctorId)
        {
            if (DoctorId != updateDto.DoctorId)
            {
                return BadRequest();
            }
            if(updateDto.DoctorId == null)
            {
                return NotFound();
            }

            var doctor = await _doctorsRepository.UpdateAsync(updateDto);
            return Ok(doctor);
        }

        [HttpDelete("Delete/{DoctorId}")]
        public async Task<ActionResult> Delete( Guid DoctorId)
        {
            if (DoctorId == null)         
                return NotFound();
            
            var doctor = await _doctorsRepository.RemoveAsync(DoctorId);
            return Ok(doctor);
        }
    }
}