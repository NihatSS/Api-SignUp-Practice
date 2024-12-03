using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Exceptions;
using Service.Helper.DTOs.Account;
using Service.Helper.Responses;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager,
                              IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task DeletetUsersAsync()
        {
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                await _userManager.DeleteAsync(user);
            }
        }

        public async Task DeleteUserByIdAsync(string userId)
        {
            var existUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId)
                                    ?? throw new NotFoundException(ExceptionMessages.NotFoundMessage);
            await _userManager.DeleteAsync(existUser);
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id)
                            ?? throw new NotFoundException(ExceptionMessages.NotFoundMessage);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userManager.Users.ToListAsync());
        }

        public async Task<SignUpResponse> SignUpAsync(SignUpDto model)
        {
            var identityResponse = await _userManager.CreateAsync(_mapper.Map<AppUser>(model));
            if (!identityResponse.Succeeded)
            {
                return new SignUpResponse { IsSuccessed = false, Errors = identityResponse.Errors.Select(x => x.Description) };
            }
            return new SignUpResponse { IsSuccessed = true, Errors = null };
        }
    }
}
