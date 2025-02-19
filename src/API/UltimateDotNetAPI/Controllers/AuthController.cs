using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UltimateDotNetMastery.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace UltimateDotNetAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;

    }

    // ✅ User Registration Endpoint
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            return BadRequest("Email and password are required");

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FullName = model.FullName ?? "unknown"
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("User registered successfully!");
    }

    // ✅ User Login Endpoint
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            return BadRequest("Email and password are required");

        // var user = await _userManager.FindByEmailAsync(model.Email);
        var normalizedEmail = model.Email.ToUpper();
        // var user = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == normalizedEmail);
        var user = await _userManager.Users
    .AsQueryable() // ✅ Ensure it's IQueryable
    .FirstOrDefaultAsync(u => u.NormalizedEmail == normalizedEmail);

        if (user == null)
            return Unauthorized("Invalid email or password");

        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
            return Unauthorized("Invalid email or password");

        var token = GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    // ✅ Get User Profile (Protected Route)
    [HttpGet("profile")]
    [Authorize] // 🔒 Only logged-in users can access
    public async Task<IActionResult> GetProfile()
    {
        Console.WriteLine("🍊 GetProfile Endpoint Hit"); // DEBUG LOG
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            Console.WriteLine("🛑 Token invalid or missing userId"); // DEBUG LOG
            return Unauthorized("Invalid Token or Expired");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            Console.WriteLine("🛑 User not found in DB"); // DEBUG LOG
            return NotFound("User not found");
        }

        Console.WriteLine("🟢 Returning profile for user: {user.Email}"); // DEBUG LOG
        return Ok(new { FullName = user.FullName, Email = user.Email, UserName = user.UserName });
    }

    // ✅ JWT Token Generation Method
    private string GenerateJwtToken(ApplicationUser user)
    {
        var jwtKey = _configuration["Jwt:Key"];
        var keyBytes = Encoding.UTF8.GetBytes(jwtKey ?? "YourLongSecureFallbackKey_32+Characters!");

        var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? ""),
        new Claim(ClaimTypes.NameIdentifier, user.Id) // 🔥 Required for profile retrieval
    };

        // ✅ Fix: Use keyBytes correctly here
        var securityKey = new SymmetricSecurityKey(keyBytes);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

// ✅ Models
public class RegisterModel
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class LoginModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
