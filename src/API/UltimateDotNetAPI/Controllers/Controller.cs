using Microsoft.AspNetCore.Mvc;

namespace UltimateDotNetAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetUsers()
    {
      var users = new List<object>
      {
        new { Id = 1, Name = "John Doe", Email = "tim@email.com" },
        new { Id = 2, Name = "Jane Doe", Email = "bob@email.com" }
      };

      return Ok(users);
    }
  }
}
