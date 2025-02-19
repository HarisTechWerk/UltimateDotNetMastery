using Microsoft.AspNetCore.Mvc;
using UltimateDotNetMastery.Core.Services;
using UltimateDotNetMastery.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace UltimateDotNetAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly UserService _userService;

  public UsersController(UserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  [Authorize(Roles = "Admin")]
  public IActionResult GetUsers()
  {
    return Ok(_userService.GetUsers());
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
