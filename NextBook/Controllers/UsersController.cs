using Microsoft.AspNetCore.Mvc;
using NextBook.Repository;
using System.Threading.Tasks;

namespace NextBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await userRepository.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var user = await userRepository.GetUserAsync(id);
            return Ok(user);
        }
    }
}