using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class CircusRepository : ARepository<Circus>
{
    public CircusRepository(TestDbContext testDbContext) : base(testDbContext)
    {
    }
}