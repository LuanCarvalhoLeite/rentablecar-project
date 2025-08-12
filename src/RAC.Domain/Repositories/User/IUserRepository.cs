
namespace RAC.Domain.Repositories.User;

public interface IUserRepository
{
    Task<bool> ExistActiveUserEmail(string email);
}
