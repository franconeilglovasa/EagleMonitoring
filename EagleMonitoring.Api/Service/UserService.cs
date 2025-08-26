using EagleMonitoring.Api.Abstract;
using EagleMonitoring.Api.Data;
using EagleMonitoring.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace EagleMonitoring.Api.Service;

public class UserService : BaseService<User>, IUserService
{
    public UserService(EagleManagementContext context) : base(context) { }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email)
            ?? throw new InvalidOperationException("User not found");
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public override async Task<User> CreateAsync(User user)
    {
        if (await EmailExistsAsync(user.Email))
        {
            throw new InvalidOperationException("Email already exists");
        }

        return await base.CreateAsync(user);
    }
}