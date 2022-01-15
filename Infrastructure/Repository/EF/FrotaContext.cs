using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.EF
{
    public class FrotaContext : DbContext
    {
        public FrotaContext(DbContextOptions<FrotaContext> options)
            : base(options)
        {
        } 
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
