using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities;

namespace Waxy.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);
        Task<User> GetByIdWithRoles(int id);
    }
}
