using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities;
using Waxy.Repositories.GenericRepository;

namespace Waxy.Repositories.ContainerRepository
{
    public interface IContainerRepository : IGenericRepository<Container>
    {
        Task<Container> GetByColor(string color);
        Task<Container> GetByIdWithLabel(int id);
        Task<List<Container>> GetAllContainersWithLabel();
    }
}
