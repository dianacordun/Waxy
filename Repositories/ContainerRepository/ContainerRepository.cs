using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Entities;
using Waxy.Models.Entities;
using Waxy.Repositories.GenericRepository;

namespace Waxy.Repositories.ContainerRepository
{
    public class ContainerRepository : GenericRepository<Container>, IContainerRepository
    {
        public ContainerRepository(WaxyContext context) : base(context) {}

        public async Task<List<Container>> GetAllContainersWithLabel()
        {
            return await _context.Containers.Include(c => c.Label).ToListAsync();
        }

       
        public async Task<Container> GetByIdWithLabel(int id)
        {
            return await _context.Containers.Include(c => c.Label).Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Container> GetByColor(string color)
        {
            return await _context.Containers.Where(c => c.Color.Equals(color)).FirstOrDefaultAsync();
               
        }

    }
}
