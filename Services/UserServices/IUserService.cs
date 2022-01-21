using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities.DTOs;

namespace Waxy.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO dto);
        Task<bool> RegisterAdminAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
