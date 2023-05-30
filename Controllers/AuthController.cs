 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using project_demo_1.DAL.Models.Authentication;

namespace project_demo_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly SignInManager<MyUser> signInManager ;
        private readonly IConfiguration configuration;
        private readonly UserManager<MyUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        //
        public AuthController(SignInManager<MyUser> signInManager, IConfiguration configuration, UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager) 
        { 
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        //register page for users to register with username and pwd
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestModel registerRequestModel)
        {
            var user = new MyUser
            {
                FirstName = registerRequestModel.FirstName,
                LastName = registerRequestModel.LastName,
                Gender = registerRequestModel.Gender,
                Email = registerRequestModel.Email,
                UserName = registerRequestModel.Email,
                RoleAlloted = registerRequestModel.RoleAlloted
            };
            var result = await userManager.CreateAsync(user, registerRequestModel.Password) ;

            if(result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync(registerRequestModel.RoleAlloted))
                    await roleManager.CreateAsync(new IdentityRole(registerRequestModel.RoleAlloted));

                if (await roleManager.RoleExistsAsync(registerRequestModel.RoleAlloted))
                    await userManager.AddToRoleAsync(user, registerRequestModel.RoleAlloted);

                return Ok("Success");
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }


        //Login task which will login users and check for authentication
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequest)
        {
            var result = await signInManager.PasswordSignInAsync(loginRequest.UserName,loginRequest.Password, false, false);
            if(result.Succeeded)
            {

                //return the JWT
                var theUser = await userManager.FindByEmailAsync(loginRequest.UserName);
                var theRole = await userManager.GetRolesAsync(theUser);

                var token = GenerateToken(theUser.Id, theUser.UserName, String.Join(',', theRole));


                return Ok(token);
            }
            return BadRequest(new { message = "Invalid Username or Password" });
        }


        //To generate a unique jwt token for authentication
        private string GenerateToken(string userId, string userName, string roleInfo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("ZIkKq2Vr4zuq789E8lOJquNGeh");
            var expiresAt = DateTime.Now.AddDays(30);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userName),
                        new Claim("Id", userId),
                        new Claim(ClaimTypes.Role, roleInfo)
                    }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
