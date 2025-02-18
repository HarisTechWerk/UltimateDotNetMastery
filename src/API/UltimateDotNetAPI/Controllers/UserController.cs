using Microsoft.AspNetCore.Mvc;
using UltimateDotNetMastery.Core.Services;
using UltimateDotNetMastery.Core.Models;

namespace UltimateDotNetAPI.Controllers;

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
  public IActionResult GetUsers()
  {
    return Ok(_userService.GetUsers());
  }

  [HttpPost]
  public IActionResult CreateUser([FromBody] User user)
  {
    if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
    {
      return BadRequest("Invalid user data.");
    }

    var createdUser = _userService.CreateUser(user.Name, user.Email);
    return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Id }, createdUser);
  }
}
