using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.API.Models.DataTransferObjects;
using ProjectManagement.API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Login(UserLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.ValidateUser(request.Username, request.Password);
                if (user == null)
                {
                    return Unauthorized();
                }

                SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("bu-alan-token-icinde-sifrelenecek"));

                SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                Claim[] claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)

                };

                JwtSecurityToken tokenOptions = new JwtSecurityToken(
                    issuer: "server",
                    audience: "client",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    notBefore: DateTime.Now,                  
                    signingCredentials: signingCredentials
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(tokenOptions) });
            }

            return BadRequest(ModelState);



        }
    }
}
