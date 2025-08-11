
using Microsoft.EntityFrameworkCore;
using RAC.Domain.Entities;

namespace RAC.Infrastructure.Data;

public class RentAbleCarDbContext : DbContext
{
    public RentAbleCarDbContext(DbContextOptions<RentAbleCarDbContext> options) : base(options) {}

    public DbSet<Car> Cars { get; set; }

}
