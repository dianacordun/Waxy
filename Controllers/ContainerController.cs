using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities;
using Waxy.Models.Entities.DTOs;
using Waxy.Repositories.ContainerRepository;

namespace Waxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IContainerRepository _repository;
        //Dependency injection : injectam in controller repository ul
        public ContainerController(IContainerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContainers()
        {
            var containers = await _repository.GetAllContainersWithLabel();

            var containersToReturn = new List<ContainerDTO>();

            foreach (var container in containers)
            {
                containersToReturn.Add(new ContainerDTO(container));
            }

            return Ok(containersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContainerById(int id)
        {
            var container = await _repository.GetByIdAsync(id);
            //var container = await _repository.GetByIdWithLabel(id);
            return Ok(new ContainerDTO(container));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            var container = await _repository.GetByIdAsync(id);

            if (container == null)
            {
                return NotFound("Container does not exist.");
            }

            _repository.Delete(container);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContainer(CreateContainerDTO dto)
        {
            Container contaierNew = new Container();

            contaierNew.Color = dto.Color;
            //contaierNew.Label = dto.Label;

            _repository.Create(contaierNew);

            await _repository.SaveAsync();

            return Ok(new ContainerDTO(contaierNew));

        }
    
    //DTO-> eu din controller nu vreau sa returnez direct entitatea din db
    //mapez datele de la o entitate 
    }


}
