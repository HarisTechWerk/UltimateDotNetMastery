using Xunit;
using Moq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using UltimateDotNetAPI.Controllers;
using UltimateDotNetMastery.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UltimateDotNetTests.AuthTests
{
  public class AuthControllerTests
  {
    private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
    private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;
    private readonly Mock<IConfiguration> _configMock;
    private readonly AuthController _authController;

    public AuthControllerTests()
    {
      var store = new Mock<IUserStore<ApplicationUser>>();
      _userManagerMock = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
      _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
          _userManagerMock.Object,
          new Mock<IHttpContextAccessor>().Object,
          new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
          null, null, null, null);
      _configMock = new Mock<IConfiguration>();

      _authController = new AuthController(_userManagerMock.Object, _signInManagerMock.Object, _configMock.Object);
    }

    [Fact]
    public async Task Register_ReturnsOk_WhenUserIsCreated()
    {
      // Arrange
      var registerModel = new RegisterModel
      {
        FullName = "John Doe",
        Email = "johndoe@example.com",
        Password = "Test@12345"
      };

      _userManagerMock
          .Setup(u => u.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
          .ReturnsAsync(IdentityResult.Success);

      // Act
      var result = await _authController.Register(registerModel);

      // Assert
      var okResult = Assert.IsType<OkObjectResult>(result);
      Assert.Equal("User registered successfully!", okResult.Value);
    }

    [Fact]
    public async Task Login_ReturnsToken_WhenCredentialsAreValid()
    {
      // Arrange
      var loginModel = new LoginModel
      {
        Email = "johndoe@example.com",
        Password = "Test@12345"
      };

      var user = new ApplicationUser { Id = "1", Email = loginModel.Email, UserName = loginModel.Email };

      _userManagerMock
          .Setup(u => u.Users)
          .Returns((new List<ApplicationUser> { user }).AsQueryable());

      _signInManagerMock
          .Setup(s => s.CheckPasswordSignInAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), false))
          .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

      _configMock
          .Setup(c => c["Jwt:Key"])
          .Returns("ThisIsAStrongSecretKeyWithAtLeast32Characters!");

      _configMock
          .Setup(c => c["Jwt:Issuer"])
          .Returns("Issuer");

      _configMock
          .Setup(c => c["Jwt:Audience"])
          .Returns("Audience");

      // Act
      var result = await _authController.Login(loginModel);

      // Assert
      var okResult = Assert.IsType<OkObjectResult>(result);
      var token = okResult.Value?.GetType().GetProperty("Token")?.GetValue(okResult.Value, null);
      Assert.NotNull(token);
    }

  }
}
