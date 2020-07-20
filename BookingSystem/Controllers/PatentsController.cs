using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.DTOs.Patents;
using BookingSystem.Repositories.Patents;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PatentsController : ControllerBase
    {
        private readonly IPatentsRepository _patentsRepository;
        public PatentsController(IPatentsRepository patentsRepository)
        {
            _patentsRepository = patentsRepository;
        }

        /// <summary>
        /// Create New Patent
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] PatentCreationDto model)
        {
            if (model == null)
                return NotFound();
            var patent = await _patentsRepository.AddAsync(model).ConfigureAwait(false);
            return Ok(patent);
        }

        [HttpPut("Update/{PatentId}")]
        public async Task<ActionResult> Update([FromBody] PatentUpdateDto updateDto, Guid PatentId)
        {
            if (PatentId != updateDto.PatentId)
            {
                return BadRequest();
            }
            if (updateDto.PatentId == null)
            {
                return NotFound();
            }

            var patent = await _patentsRepository.UpdateAsync(updateDto);
            return Ok(patent);
        }

        [HttpDelete("Delete/{PatentId}")]
        public async Task<ActionResult> Delete(Guid PatentId)
        {
            if (PatentId == null)
                return NotFound();

            var patent = await _patentsRepository.RemoveAsync(PatentId);
            return Ok(patent);
        }
    }
}