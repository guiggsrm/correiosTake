using Entidades.Extensions;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Context
{
    public class CorreiosContext : DbContext
    {
        public CorreiosContext(DbContextOptions<CorreiosContext> options)
            : base(options)
        {
        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Trexo> Trexos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureEstadoModel();
            modelBuilder.ConfigureCidadeModel();
            modelBuilder.ConfigureTrexoModel();
        }
    }
}
