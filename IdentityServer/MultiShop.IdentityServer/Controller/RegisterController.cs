using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controller
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public RegisterController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpPost]
		public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
		{
			var values = new ApplicationUser()
			{
				UserName = userRegisterDto.Username,
				Email = userRegisterDto.Email,
				Name = userRegisterDto.Name,
				Surname = userRegisterDto.Surname
			};
			var result = await _userManager.CreateAsync(values, userRegisterDto.Password);
			if (result.Succeeded)
			{
				return Ok("Kullanıcı Eklendi");
			}
			else
			{
				return Ok("Hata oluştu tekrar deneyiniz.");
			}
		}
	}
}
