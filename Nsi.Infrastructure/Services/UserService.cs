using Nsi.Application.Common.Interfaces;
using Nsi.Domain.Entities;

namespace Nsi.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly INsiDbContext _context;

    public UserService(INsiDbContext context)
    {
        _context = context;
    }

    public async Task<ApplicationUser?> FindById(string id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }

    public Task<ApplicationUser?> FindByUserName(string userName)
    {
        var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
        return Task.FromResult(user);
    }
}