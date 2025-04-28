using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Dto.LoginDto;
using BlogProject.Dto.RegisterDto;
using BlogProject.Dto.TokenResponseDto;
using BlogProject.Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlogProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }
        [HttpDelete("delete-user/{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = "Kullanıcı başarıyla silindi." });
        }


        [HttpPost("register")]
        public IActionResult Register(RegsiterDto regsiterDto)
        {
            if (string.IsNullOrEmpty(regsiterDto.Password))
            {
                return BadRequest("Password cannot be null or empty.");
            }
            var user = new AppUser
            {
                UserName = regsiterDto.Username,
                FullName = regsiterDto.FullName,
                Email = regsiterDto.Email

            };
            var result = _userManager.CreateAsync(user, regsiterDto.Password).GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            if (!_roleManager.RoleExistsAsync("User").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new AppRole { Name = "User" }).GetAwaiter().GetResult();
            }

            _userManager.AddToRoleAsync(user, "User").GetAwaiter().GetResult();

            return Ok(new { message = "Kullanıcı başarıyla oluşturuldu." });

        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Username))
            {
                return Unauthorized("Kullanıcı adı gereklidir.");
            }

            var user = _userManager.FindByNameAsync(loginDto.Username).GetAwaiter().GetResult();
            if (user == null)
            {
                return Unauthorized("Geçersiz kullanıcı adı veya şifre");
            }

            if (string.IsNullOrEmpty(loginDto.Password))
            {
                return Unauthorized("Şifre gereklidir.");
            }

            var result = _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false).GetAwaiter().GetResult();
            if (!result.Succeeded)
            {
                return Unauthorized("Geçersiz kullanıcı adı veya şifre");
            }

            if (string.IsNullOrEmpty(user.UserName))
            {
                return Unauthorized("Kullanıcı adı geçersiz.");
            }

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id)
    };

            var secretKey = _configuration["JWTSecurity:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new Exception("JWT SecretKey ayarı bulunamadı.");
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWTSecurity:Issuer"],
                audience: _configuration["JWTSecurity:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new TokenResponseDto { Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }


    }
}