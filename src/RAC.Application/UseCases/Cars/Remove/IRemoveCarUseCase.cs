
namespace RAC.Application.UseCases.Cars.Remove;

public interface IRemoveCarUseCase
{
    Task Execute(long id);
}
