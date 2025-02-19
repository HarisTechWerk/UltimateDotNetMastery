using UltimateDotNetMastery.Core.Data;
using UltimateDotNetMastery.Core.Models;

namespace UltimateDotNetMastery.Core.Services;

public class UserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public List<ApplicationUser> GetUsers()
    {
        return _context.Users.ToList();
    }

    public async Task<ApplicationUser?> CreateUser(ApplicationUser user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}