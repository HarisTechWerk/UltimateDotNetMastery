using Microsoft.AspNetCore.Mvc;
using UltimateDotNetMastery.Core.Services;
using UltimateDotNetMastery.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace UltimateDotNetAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly UserService _userService;
  private readonly UserManager<ApplicationUser> _userManager;

  public UsersController(UserService userService, UserManager<ApplicationUser> userManager)
  {
    _userService = userService;
    _userManager = userManager;
  }

  [HttpGet]
  [Authorize(Roles = "Admin")]
  public IActionResult GetUsers()
  {
    return Ok(_userService.GetUsers());
  }

  [HttpGet("profile")]
  [Authorize]
  public async Task<IActionResult> GetProfile()
  {
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (userId == null)
    {
      return Unauthorized();
    }

    var user = await _userManager.FindByIdAsync(userId);
    if (user == null)
    {
      return NotFound("User not found.");
    }

    return Ok(new { user.FullName, user.Email });
  }

  [HttpPost]
  [AllowAnonymous]
  public async Task<IActionResult> CreateUser([FromBody] ApplicationUser user)
  {
    if (user == null || string.IsNullOrEmpty(user.FullName) || string.IsNullOrEmpty(user.Email))
    {
      return BadRequest("Invalid user data.");
    }

    var createdUser = await _userService.CreateUser(user);
    if (createdUser == null)
    {
      return BadRequest("User creation failed.");
    }
    return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Id }, createdUser);
  }
}
