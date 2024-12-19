using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Models;
using System.Linq;

namespace MultiShop.IdentityServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public StatisticsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetUserCount()
        {
            var values = _userManager.Users.Count();
            return Ok(values);
        }
    }
}
