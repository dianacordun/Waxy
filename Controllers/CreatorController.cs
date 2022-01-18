using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities;
using Waxy.Models.Entities.DTOs;
using Waxy.Repositories.CreatorRepository;

namespace Waxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CreatorController : ControllerBase
    {
        private readonly ICreatorRepository _repository;
        //Dependency injection : injectam in controller repository ul
        public CreatorController(ICreatorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCreators()
        {
            var creators = await  _repository.GetAllCreatorsAsync();

            var creatorsToReturn = new List<CreatorDTO>();

            foreach (var creator in creators)
            {
                creatorsToReturn.Add(new CreatorDTO(creator));
            }

            return Ok(creatorsToReturn);
        }

        [HttpGet("{firstname}/{lastname}")]
        public async Task<IActionResult> GetCreatorByFullName(string fname, string lname)
        {
            var creator = await _repository.GetByName(fname, lname);

            if (creator == null)
            {
                return NotFound("Creator does not exist.");
            }

            return Ok(new CreatorDTO(creator));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreator(int id)
        {
            var creator = await _repository.GetByIdAsync(id);

            if (creator == null)
            {
                return NotFound("Creator does not exist.");
            }

            _repository.Delete(creator);

            await _repository.SaveAsync();

            return NoContent();
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateCreator([FromBody] CreateCreatorDTO dto)
        {
            Creator newCreator = new Creator();

            newCreator.FirstName = dto.FirstName;
            newCreator.LastName = dto.LastName;
            newCreator.Email = dto.Email;

            _repository.Create(newCreator);

            await _repository.SaveAsync();

            return Ok(new CreatorDTO(newCreator));

        }

        [HttpPut("{id}-{email}")]
        public async Task<IActionResult> UpdateCreator(int id, string email)
        {

            var updatedCreator = await _repository.GetByIdAsync(id);
            updatedCreator.Email = email;

            _repository.Update(updatedCreator);

            await _repository.SaveAsync();

            return Ok(new CreatorDTO(updatedCreator));

        }
    }
}
