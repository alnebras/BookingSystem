using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.DTOs.Doctors.Specializations;
using BookingSystem.Repositories.DoctorsRepository.Specializations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class SpecializationsController : ControllerBase
    {
        private readonly ISpecializationsRepository _specializationsRepository;
        public SpecializationsController(ISpecializationsRepository specializationsRepository)
        {
            _specializationsRepository = specializationsRepository;
        }

        //[Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<SpecializationDto>> GetAll()
        {
            var sps = await _specializationsRepository.GetAllSpecializationsAsync();
            return Ok(sps);
        }

        /// <summary>
        /// Create New Specialization
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] SpecializationCreationDto model)
        {
            if (model == null)
                return NotFound();
            var specialization = await _specializationsRepository.AddAsync(model).ConfigureAwait(false);
            return Ok(specialization);
        }

        [HttpPut("Update/{SpecializationId}")]
        public async Task<ActionResult> Update([FromBody] SpecializationUpdateDto updateDto, Guid SpecializationId)
        {
            if (SpecializationId != updateDto.SpecializationId)
            {
                return BadRequest();
            }
            if (updateDto.SpecializationId == null)
            {
                return NotFound();
            }

            var specialization = await _specializationsRepository.UpdateAsync(updateDto);
            return Ok(specialization);
        }

        [HttpDelete("Delete/{SpecializationId}")]
        public async Task<ActionResult> Delete(Guid SpecializationId)
        {
            if (SpecializationId == null)
                return NotFound();

            var specialization = await _specializationsRepository.RemoveAsync(SpecializationId);
            return Ok(specialization);
        }
    }
}
 