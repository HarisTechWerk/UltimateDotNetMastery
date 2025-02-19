using Microsoft.AspNetCore.Identity;

namespace UltimateDotNetMastery.Core.Models;

public class ApplicationUser : IdentityUser
{
    public required string FullName { get; set; }
}
