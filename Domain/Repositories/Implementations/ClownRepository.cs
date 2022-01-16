using Domain.Repositories.Interfaces;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations; 

public class ClownRepository : ARepository<Clown> {
    public ClownRepository(TestDbContext testDbContext) : base(testDbContext) {
        
    }
}