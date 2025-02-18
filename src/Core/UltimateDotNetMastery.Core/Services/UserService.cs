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

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public User CreateUser(string name, string email)
    {
        var user = new User { Name = name, Email = email };
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
}