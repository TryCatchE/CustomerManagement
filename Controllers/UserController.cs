using CustomerManagement.Models.DTOs;
using CustomerManagement.Models.DTOs.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private IConfiguration configuration { get; }
        public UserController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost]//login
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            IdentityUser user = await userManager.FindByNameAsync(loginModel.UserName);
            //οχι var, δες τι γυρναει η μεθοδος

            if (user == null)
            {
                return NotFound(new ErrorResponseModel
                {
                    Message = "User not found!",
                });
            }
            else
            {
                bool passwordIsCorrect = await userManager.CheckPasswordAsync(user, loginModel.Password);
                if (!passwordIsCorrect)
                {
                    return BadRequest(new ErrorResponseModel
                    {
                        Message = "Wrong password",
                        AdditionalInfo = "Maybe Caps is On",
                    });
                }
                else
                {
                    string token = GetToken(user);
                    return Ok(new
                    {
                        Token = token
                    });
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            IdentityUser user = await userManager.FindByNameAsync(register.UserName);
            if (user != null)
            {
                return BadRequest(new ErrorResponseModel
                {
                    Message = "Name already taken"
                });
            }
            else
            {
                var newUser = new IdentityUser()
                {
                    UserName = register.UserName
                };

                IdentityResult result = await userManager.CreateAsync(newUser, register.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(new ErrorResponseModel
                    {
                        Message = "Something went wrong"
                    });
                }
                return Ok();
            }
        }

        private string GetToken(IdentityUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenSettings:Secret"]));

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var token = new JwtSecurityToken(
                    issuer: configuration["TokenSettings:ValidIssuer"],
                    audience: configuration["TokenSettings:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
