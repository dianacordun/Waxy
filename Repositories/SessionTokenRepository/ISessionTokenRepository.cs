using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities;

namespace Waxy.Repositories.SessionTokenRepository
{
    public interface ISessionTokenRepository : IGenericRepository<SessionToken>
    {
        Task<SessionToken> GetByJTI(string jti);
    }
}
