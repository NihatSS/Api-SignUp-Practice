using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;
using Service.Helper.DTOs.Account;
using Service.Services.Interfaces;

namespace CompanyApi.Controllers.Admin
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto request)
        {
            var response = await _accountService.SignUpAsync(request);

            if(response.IsSuccessed)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _accountService.GetUsersAsync());
        }

        [HttpGet] 
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                return Ok(await _accountService.GetUserByIdAsync(userId));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsers()
        {
            await _accountService.DeletetUsersAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserbyId([FromQuery] string userId)
        {
            await _accountService.DeleteUserByIdAsync(userId);
            return Ok();
        }
    }
}
