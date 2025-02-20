using Microsoft.AspNetCore.Mvc;
using UltimateDotNetMastery.Core.Services;
using UltimateDotNetMastery.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace UltimateDotNetAPI.Controllers;

[Authorize] // ✅ All routes require authentication by default
[ApiController]
// [Route("api/[controller]")]
[Route("api/Users")] // ✅ Use a more descriptive route
public class UsersController : ControllerBase
{
  private readonly UserService _userService;
  private readonly UserManager<ApplicationUser> _userManager;

  public UsersController(UserService userService, UserManager<ApplicationUser> userManager)
  {
    _userService = userService;
    _userManager = userManager;
  }

  // ✅ Get All Users (Requires Admin Role)
  [HttpGet]
  // [Authorize(Roles = "Admin")] // ✅ Uncomment to require Admin role
  public IActionResult GetUsers()
  {
    return Ok(_userService.GetUsers());
  }

  // ✅ Get Profile (Authenticated Users)
  [HttpGet("profile")]
  [Authorize]
  public async Task<IActionResult> GetProfile()
  {
    Console.WriteLine("🍊 GetProfile Endpoint Hit in UserController"); // DEBUG LOG

    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (userId == null)
    {
      Console.WriteLine("🛑 Token invalid or missing userId"); // DEBUG LOG
      return Unauthorized("Invalid Token or Expired");
    }

    var user = await _userManager.FindByIdAsync(userId);
    if (user == null)
    {
      Console.WriteLine("🛑 User not found in DB"); // DEBUG LOG
      return NotFound("User not found.");
    }

    Console.WriteLine($"🟢 Returning profile for user: {user.Email}"); // DEBUG LOG
    return Ok(new { FullName = user.FullName, Email = user.Email, UserName = user.UserName });
  }
}
