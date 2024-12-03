using Microsoft.AspNetCore.Mvc;
using Service.Helper.DTOs.Cities;
using Service.Helper.DTOs.Jobs;
using Service.Services.Interfaces;

namespace CompanyApi.Controllers.Admin
{
    public class JobController : BaseController
    {
        private readonly IJobService _service;
        public JobController(IJobService service)
        {
            _service = service;
        }

        [ProducesResponseType(typeof(JobDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }


        [ProducesResponseType(typeof(JobDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }


        [ProducesResponseType(typeof(JobDto), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobCreateDto request)
        {
            await _service.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Successfully created");
        }


        [ProducesResponseType(typeof(JobDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] JobEditDto request)
        {
            await _service.EditAsync(id, request);
            return Ok();
        }


        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
