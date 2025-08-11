
namespace RAC.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
