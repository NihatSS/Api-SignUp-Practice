using Service.Helper.DTOs.Account;
using Service.Helper.Responses;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<SignUpResponse> SignUpAsync(SignUpDto model);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(string id);
        Task DeletetUsersAsync();
        Task DeleteUserByIdAsync(string userId);
    }
}
