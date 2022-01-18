using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Entities;
using Waxy.Models.Entities;
using Waxy.Repositories.GenericRepository;

namespace Waxy.Repositories.CreatorRepository
{
    public class CreatorRepository : GenericRepository<Creator>, ICreatorRepository
    {
        public CreatorRepository(WaxyContext context) : base(context) { }

        public async Task<Creator> GetByName(string firstName, string lastName)
        {
            return await _context.Creators.Where(c => c.FirstName.Equals(firstName) && c.LastName.Equals(lastName)).FirstOrDefaultAsync();
        }
        public async Task<List<Creator>> GetAllCreatorsAsync()
        {
            return await _context.Creators.ToListAsync();
        }
    }
}
