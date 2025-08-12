
namespace RAC.Domain.Repositories.User;

public interface IUserRepository
{
    Task<bool> ExistActiveUserEmail(string email);
    Task AddUser(Entities.User user);
    Task<Entities.User?> GetUserByEmail(string email);
}
