using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Entities;
using Waxy.Models.Entities;
using Waxy.Repositories.GenericRepository;

namespace Waxy.Repositories.SessionTokenRepository
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(WaxyContext context) : base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
