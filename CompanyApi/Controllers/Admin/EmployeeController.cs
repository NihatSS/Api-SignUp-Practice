using Microsoft.AspNetCore.Mvc;
using Service.Helper.DTOs.Employees;
using Service.Services.Interfaces;


namespace CompanyApi.Controllers.Admin
{

    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }


        [ProducesResponseType(typeof(EmployeeCreateDto), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateDto request)
        {
            await _service.CreateAsync(request);
            return CreatedAtAction(nameof(Create), "Successfully created");
        }





        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }




        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }




        [ProducesResponseType(typeof(EmployeeEditDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] EmployeeEditDto request)
        {
            await _service.EditAsync(id, request);
            return Ok();
        }




        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchText)
        {
            var datas = await _service.SearchAsync(searchText);
            return Ok(datas);
        }
    }
}
