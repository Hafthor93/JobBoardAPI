using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using JobBoardAPI.Models;
using JobBoardAPI.Data.Interfaces;
using System.Security.Claims;

namespace JobBoardAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Profile")]
    public class UserProfile : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserProfile(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            
            var user = await _userRepository.GetUserById(int.Parse(userId));

            if (user == null)
            {
                return NotFound("User not found");
            }

            
            var Profile = new Profile
            {
                Id = userId,
                Username = user.Username
            };

            return Ok(Profile);
        }
    }
}
