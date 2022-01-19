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
        }//pot sa dau si include Candles tot aici

        //metoda custom ca sa mi ia si info despre label sau alte tabele care nu apar in db
        public async Task<Container> GetByIdWithLabel(int id)
        {
            return await _context.Containers.Include(c => c.Label).Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Container> GetByColor(string color)
        {
            return await _context.Containers.Where(c => c.Color.Equals(color)).FirstOrDefaultAsync();
                //selectez tabela pe care vr sa execut
                //c = predicat, instanta de container
                //aici am folosit linq where
        }

     //   problema--intorarce obiect anonim
        /* public List<object> GetAllContainersWithQuote()
        {
            var containersWithQuotes = _context.Labels.Join(_context.Containers, l => l.ContainerId, c => c.Id, (l, c) => new
            {
                c.Id,
                c.Color,
                c.Material,
                l.Quote
            }).ToList();
            return containersWithQuotes;
        }*/
    }
}
