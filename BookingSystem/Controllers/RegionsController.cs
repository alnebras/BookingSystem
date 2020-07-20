using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.DTOs.Areas;
using BookingSystem.Repositories.Regions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionsRepository _regionsRepository;
        public RegionsController(IRegionsRepository regionsRepository)
        {
            _regionsRepository = regionsRepository;
        }

        [HttpGet("GetRegionsInArea/{AreaId}")]

        public async Task<ActionResult<RegionDto>> GetRegionsInArea(Guid AreaId)
        {
            var region = await _regionsRepository.GetAllRegionsAsync(AreaId);
            return Ok(region);
        }

        /// <summary>
        /// Create New Region
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] RegionCreationDto model)
        {
            if (model == null)
                return NotFound();
            var region = await _regionsRepository.AddAsync(model).ConfigureAwait(false);
            return Ok(region);
        }

        [HttpPut("Update/{RegionId}")]
        public async Task<ActionResult> Update([FromBody] RegionUpdateDto updateDto, Guid RegionId)
        {
            if (RegionId != updateDto.RegionId)
            {
                return BadRequest();
            }
            if (updateDto.RegionId == null)
            {
                return NotFound();
            }

            var region = await _regionsRepository.UpdateAsync(updateDto);
            return Ok(region);
        }

        [HttpDelete("Delete/{RegionId}")]
        public async Task<ActionResult> Delete(Guid RegionId)
        {
            if (RegionId == null)
                return NotFound();

            var region = await _regionsRepository.RemoveAsync(RegionId);
            return Ok(region);
        }
    }
}