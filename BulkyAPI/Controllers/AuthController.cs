using BulkyAPI.CustomFilterActions;
using BulkyAPI.Models.DTO.Auth;
using BulkyAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BulkyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepo;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository repo)
        {
            this.userManager = userManager;
            this.tokenRepo = repo;
        }

        // POST: /api/Auth/Register

        [HttpPost]
        [Route("Register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            var identityUser = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.UserName,
            };

           var identityResult = await userManager.CreateAsync(identityUser, request.Password);

            if (identityResult.Succeeded)
            {
                if (request.Roles != null && request.Roles.Any())
                {
                 identityResult =  await userManager.AddToRolesAsync(identityUser, request.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login.");
                    }
                }
            }

            return BadRequest("Error : 2312 (Numbers mean nothing)");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var user = await userManager.FindByEmailAsync(request.Username);
            if (user != null)
            {
                var check = await userManager.CheckPasswordAsync(user, request.Password);
                if (check)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null) {
                      var token = tokenRepo.CreateJWTToken(user, roles);
                      return Ok(new LoginResponseDTO(token));
                    }
                    return BadRequest("Bad Permissions - Contact Joe Biden for assistance.");
                }
            }
            return BadRequest("~Incorrect Information!~");
        }



    }
}
