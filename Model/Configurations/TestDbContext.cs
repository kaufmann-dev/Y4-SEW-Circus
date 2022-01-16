using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations; 

public class TestDbContext : DbContext {

    public DbSet<Clown> Clowns { get; set; }
    public DbSet<Circus> Circuses { get; set; }
    
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options){
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Circus>().HasIndex(c => c.Name).IsUnique();
        builder.Entity<Clown>()
            .HasOne(c => c.Circus)
            .WithMany(c=>c.ClownList)
            .HasForeignKey(c => c.CircusId);
    }
}