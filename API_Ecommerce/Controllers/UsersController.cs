using API_Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly db_api_ecommerceContext _context;

        public UsersController(db_api_ecommerceContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] User user)
        {
            //_context.Teams.Add(team);
            var returnedUser = _context.Users.Where(x => x.Name == user.Name && x.Password == user.Password).FirstOrDefault();

            if (returnedUser == null)
                return NotFound(new { message = "Usuário ou senha inválidos." });

            var token = TokenService.GenerateToken(returnedUser);

            return new
            {
                user = returnedUser,
                token = "aaaaaa",
            };

            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTeam", new { id = user.Id }, user);
        }
    }
}
