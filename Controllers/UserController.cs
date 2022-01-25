using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Repositories.UserRepository;

namespace Waxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        //Authorize-doar sa fie autentificat
        //Anonymous - oricine (Roles = "User")
        //[Authorize]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();

            return Ok(new { users });
        }
    }
}
