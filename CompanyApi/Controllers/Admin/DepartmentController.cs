using Microsoft.AspNetCore.Mvc;
using Service.Helper.DTOs.Departments;
using Service.Helper.DTOs.Locations;
using Service.Services.Interfaces;

namespace CompanyApi.Controllers.Admin
{
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [ProducesResponseType(typeof(DepartmentDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            return Ok(await _service.GetAllAsync());
        }


        [ProducesResponseType(typeof(DepartmentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DepartmentDto), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }


        [ProducesResponseType(typeof(DepartmentCreateDto), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateDto request)
        {
            await _service.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Successfully created");
        }


        [ProducesResponseType(typeof(DepartmentEditDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] DepartmentEditDto request)
        {
            await _service.EditAsync(id, request);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
