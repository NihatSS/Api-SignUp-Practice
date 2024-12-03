using Microsoft.AspNetCore.Mvc;
using Service.Helper.DTOs.Regions;
using Service.Services.Interfaces;

namespace CompanyApi.Controllers.Admin
{
    public class RegionController : BaseController
    {
        private readonly IRegionService _service;

        public RegionController(IRegionService service)
        {
            _service = service;
        }


        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }


        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegionCreateDto region)
        {
            await _service.CreataAsync(region);
            return CreatedAtAction(nameof(Create), "Successfully created");
        }

        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] RegionEditDto region)
        {
            await _service.EditAsync(id, region);
            return Ok();
        }


        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
