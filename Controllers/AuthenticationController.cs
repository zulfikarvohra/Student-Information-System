using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using StudentInformationSystem.Helper;
using Microsoft.Extensions.Options;

namespace StudentInformationSystem.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/authenticate")]
    public class AuthenticationController :Controller
    {
        private UserManager<ApplicationUser> userManager;
        private readonly MyConfiguration _myConfiguration;
        public AuthenticationController(UserManager<ApplicationUser> userManager, IOptions<MyConfiguration> myConfiguration)
        {
            this.userManager = userManager;
            this._myConfiguration = myConfiguration.Value;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_myConfiguration.SecretKey));

                var token = new JwtSecurityToken(
                    issuer: "http://qualitynet.net",
                    audience: "http://qualitynet.net",
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }); 
            }
            return Unauthorized();
        }
    } 
}
