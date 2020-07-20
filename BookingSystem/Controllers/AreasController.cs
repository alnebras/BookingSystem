using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.DTOs.Areas;
using BookingSystem.Repositories.Areas;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AreasController : ControllerBase
    {
        private readonly IAreasRepository _areasRepository;
        public AreasController(IAreasRepository areasRepository)
        {
            _areasRepository = areasRepository;
        }

        /// <summary>
        /// Create New Area
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] AreaCreationDto model)
        {
            if (model == null)
                return NotFound();
            var area = await _areasRepository.AddAsync(model).ConfigureAwait(false);
            return Ok(area);
        }


        [HttpPut("Update/{AreaId}")]
        public async Task<ActionResult> Update([FromBody] AreaUpdateDto updateDto, Guid AreaId)
        {
            if (AreaId != updateDto.AreaId)
            {
                return BadRequest();
            }
            if (updateDto.AreaId == null)
            {
                return NotFound();
            }

            var area = await _areasRepository.UpdateAsync(updateDto);
            return Ok(area);
        }

        [HttpDelete("Delete/{AreaId}")]
        public async Task<ActionResult> Delete(Guid AreaId)
        {
            if (AreaId == null)
                return NotFound();

            var area = await _areasRepository.RemoveAsync(AreaId);
            return Ok(area);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<AreaDto>> GetAll()
        {
            var area = await _areasRepository.GetAllAreasAsync();
            return Ok(area);
        }
    }
}