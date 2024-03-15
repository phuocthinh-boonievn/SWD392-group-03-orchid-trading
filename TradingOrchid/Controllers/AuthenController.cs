using Application.Common.Dto.Authen;
using Application.Common.Dto.Exception;
using Application.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TradingOrchid.Controllers
{
    [Route("trading-orchid/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService userService;
        public AuthenController
            (IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<Token>> Login(LoginDto loginDto)
        {
            var user = await userService.Login(loginDto);

            user.UserToken = CreateToken(user, out DateTime from, out DateTime to);
            user.TokenCreated = from;
            user.TokenExpires = to;

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = to,
            };

            Response.Cookies.Append("token", user.UserToken, cookieOptions);

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            await userService.Register(registerDto);
            throw new MyException("Thành công.", 200);
        }

        private string CreateToken(Token user, out DateTime from, out DateTime to)
        {
                List<Claim> claims = new List<Claim>{
                    new Claim("userId", user.UserId.ToString()),
                    new Claim("userName", user.UserName is not null ? user.UserName : ""),
                    new Claim("userEmail", user.Email is not null ? user.Email : ""),
                    new Claim(ClaimTypes.Role, user.Role)};

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Key"],
                    audience: _configuration["Jwt:Key"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(5),
                    signingCredentials: cred
                );

                from = token.ValidFrom;
                to = token.ValidTo;

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
        }
    }
}
