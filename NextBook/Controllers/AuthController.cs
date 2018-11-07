using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NextBook.Dto;
using NextBook.Models;
using NextBook.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NextBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _repository;

        public IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _repository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]UserForRegisterDto user)
        {
            try
            {
                user.Username = user.Username.ToLower();
                if (await _repository.UserExistsAsync(user.Username))
                    return BadRequest("Username already exists");

                var userToCreate = new User
                {
                    UserName = user.Username
                };

                var createdUser = await _repository.RegisterAsync(userToCreate, user.Password);

                return StatusCode(201);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]UserLoginDto user)
        {
            try
            {
                user.Username = user.Username.ToLower();
                var userForRepo = await _repository.LoginAsync(user.Username, user.Password);
                if (userForRepo == null)
                    return Unauthorized();
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier,userForRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userForRepo.UserName.ToString())
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = cred
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new
                {
                    token = tokenHandler.WriteToken(token)
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}