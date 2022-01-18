using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities;

namespace Waxy.Repositories.CreatorRepository
{
    public interface ICreatorRepository : IGenericRepository<Creator>
    {
        Task<Creator> GetByName(string firstName, string lastName);
        Task<List<Creator>> GetAllCreatorsAsync();
    }
}
