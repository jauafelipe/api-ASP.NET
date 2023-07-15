using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<Person> Pessoas { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Person>(table => {
                table.HasKey(e => e.id);
                table.HasMany(e => e.contrato).WithOne().HasForeignKey(k => k.pessoaId);
            });
            builder.Entity<Contract>(table => {
                table.HasKey(e => e.id);
            });

        }
    }
}