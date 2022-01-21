using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Waxy.Models.Constants;
using Waxy.Models.Entities;
using Waxy.Models.Entities.DTOs;
using Waxy.Repositories.SessionTokenRepository;
using Waxy.Repositories.UserRepository;

namespace Waxy.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        
        private readonly IUserRepository _repository;

        private readonly ISessionTokenRepository _repository2;

        public UserService( UserManager<User> userManager, IUserRepository repository, ISessionTokenRepository tokenrepository)
        {
            _userManager = userManager;
            _repository = repository;
            _repository2 = tokenrepository;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.Email = dto.Email;
            registerUser.UserName = dto.Email;
            registerUser.FirstName = dto.FirstName;
            registerUser.LastName = dto.LastName;


            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.User);

                return true;
            }

            return false;
        }

        public async Task<bool> RegisterAdminAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.Email = dto.Email;
            registerUser.UserName = dto.Email;
            registerUser.FirstName = dto.FirstName;
            registerUser.LastName = dto.LastName;


            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleType.Admin);

                return true;
            }

            return false;
        }

        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
                user = await _repository.GetByIdWithRoles(user.Id);

                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
                
                var newJti = Guid.NewGuid().ToString();

                var tokenHandler = new JwtSecurityTokenHandler();
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("custom secret key for auth"));

                var token = GenerateJwtToken(signinkey, user, roles, tokenHandler, newJti);

                //trebuie salvat token-ul in baza de date
                _repository2.Create(new SessionToken(newJti, user.Id, token.ValidTo));
                await _repository2.SaveAsync();
                
                //writetoken -> transforma token intr-un tip de date recunoscut
                return tokenHandler.WriteToken(token);
            }

            return "";
        }
        
        //metoda prin care generam token-ul
        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinKey, User user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            //clasa care are toate informatiile despre token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };

            //tokenDescriptor -> ce detalii sa include in token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
