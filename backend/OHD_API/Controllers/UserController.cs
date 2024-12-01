using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace OHD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);
                if (isPasswordCorrect)
                {
                    var tokenString = await GenerateJWTTokenAsync(user);
                    dynamic result = new ExpandoObject();
                    result.token = tokenString;
                    result.message = "Login thanh cong!";

                    return Ok(result);
                }
            }
            return BadRequest("Co loi xay ra, vui long thu lai!");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string username, string password, string role = "USER")
        {
            await this.InitRole();
            var existingUser = await _userManager.FindByNameAsync(username);
            if (existingUser != null)
            {
                return BadRequest("Tai khoan da ton tai!");
            }

            var newUser = new IdentityUser(username);
            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                //phan quyen cho user
                await _userManager.AddToRoleAsync(newUser, role);

                var tokenString = await GenerateJWTTokenAsync(newUser);

                dynamic loginResult = new ExpandoObject();
                loginResult.token = tokenString;
                loginResult.message = "Dang ki thanh cong!";
                return Ok(loginResult);
            }

            return BadRequest("Co loi xay ra, vui long thu lai!");
        }

        private async Task<string> GenerateJWTTokenAsync(IdentityUser user)
        {
            var secretKey = _configuration.GetSection("JWT")["Secret"];
            var audithen = _configuration.GetSection("JWT")["Audithen"];
            var isuser = _configuration.GetSection("JWT")["Isuser"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, string.Join(",", roles)),
        new Claim(ClaimTypes.Email, user.Email ?? "")
    };

            // Use configuration for expiration
            int expirationDays = _configuration.GetValue<int>("JWT:ExpirationInDays", 1);

            var token = new JwtSecurityToken(
                issuer: isuser,
                audience: audithen,
                claims: claims,
                expires: DateTime.Now.AddDays(expirationDays),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task InitRole()
        {
            // init data cho role
            var roleAdmin = new IdentityRole("ADMIN");
            var roleManager = new IdentityRole("FACILITY_HEAD");
            var roleUser = new IdentityRole("USER");
            var roleAssignee = new IdentityRole("ASSIGNEE");
            if (await _roleManager.RoleExistsAsync("ADMIN") == false)
            {
                await _roleManager.CreateAsync(roleAdmin);
            }
            if (await _roleManager.RoleExistsAsync("FACILITY_HEAD") == false)
            {
                await _roleManager.CreateAsync(roleManager);
            }
            if (await _roleManager.RoleExistsAsync("ASSIGNEE") == false)
            {
                await _roleManager.CreateAsync(roleAssignee);
            }
            if (await _roleManager.RoleExistsAsync("USER") == false)
            {
                await _roleManager.CreateAsync(roleUser);
            }
        }

        // Method to generate a cryptographically strong secret key
        public static string GenerateSecureJwtSecret(int lengthInBytes = 32)
        {
            using (var randomNumberGenerator = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[lengthInBytes];
                randomNumberGenerator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
    }
}
