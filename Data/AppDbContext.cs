using CRUDEmpreendimentosSC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDEmpreendimentosSC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmpreendimentoSC> EmpreendimentosSC { get; set; }
    }
}
