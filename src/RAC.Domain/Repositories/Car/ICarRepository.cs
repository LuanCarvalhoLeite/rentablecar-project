using RAC.Domain.Entities;

namespace RAC.Domain.Repositories.Car;

public interface ICarRepository
{
    public Task AddCar(RAC.Domain.Entities.Car car);
    public Task<List<Entities.Car>> GetAllCars();
    public Task<Entities.Car?> GetCarById(long id);
    public Task<Entities.Car?> GetById(long id);
    /// <summary>
    /// The function returns TRUE if the deletion was successful, otherwise FALSE.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> RemoveCar(long id);
    void UpdateCar(Entities.Car car);
}
