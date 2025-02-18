using Microsoft.AspNetCore.Identity;

namespace UltimateDotNetMastery.Core.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}
