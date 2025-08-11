
using Microsoft.EntityFrameworkCore;
using RAC.Domain.Entities;
using RAC.Domain.Repositories.Car;

namespace RAC.Infrastructure.Data.Repositories;

internal class CarRepository : ICarRepository
{
    private readonly RentAbleCarDbContext _context;

    public CarRepository(RentAbleCarDbContext context)
    {
        _context = context;
    }

    public async Task AddCar(Car car)
    {
        await _context.Cars.AddAsync(car);
    }

    public async Task<List<Car>> GetAllCars()
    {
        return await _context.Cars.AsNoTracking().ToListAsync();
    }

    public async Task<Car?> GetById(long id)
    {
        return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Car?> GetCarById(long id)
    {
        return await _context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> RemoveCar(long id)
    {
        var result = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

        if (result is null) return false;

        _context.Cars.Remove(result);
        return true;
    }

    public void UpdateCar(Car car)
    {
        _context.Cars.Update(car);
    }
}
