
using Microsoft.EntityFrameworkCore;
using RAC.Domain.Entities;
using RAC.Domain.Repositories.User;

namespace RAC.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RentAbleCarDbContext _context;

    public UserRepository(RentAbleCarDbContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistActiveUserEmail(string email)
    {
        return await _context.Users.AnyAsync(user => user.Email.Equals(email));
    }
}
