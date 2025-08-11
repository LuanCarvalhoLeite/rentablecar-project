
using RAC.Domain.Repositories;

namespace RAC.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly RentAbleCarDbContext _context;

    public UnitOfWork(RentAbleCarDbContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
         await _context.SaveChangesAsync();
    }
}
