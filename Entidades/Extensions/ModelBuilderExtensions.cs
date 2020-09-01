using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureEstadoModel(this ModelBuilder modelBuilder)
        {
            // Só pode existir uma sigla para cada estado
            modelBuilder.Entity<Estado>().HasIndex(estado => estado.Sigla).HasName("IXEstado_Sigla").IsUnique();
        }

        public static void ConfigureCidadeModel(this ModelBuilder modelBuilder)
        {

            // Só pode existir uma sigla de cidade por estado
            modelBuilder.Entity<Cidade>().HasIndex(cidade => new { cidade.Sigla, cidade.IdEstado }).HasName("IXCidade_Sigla_Estado").IsUnique();
            // Indice para melhorar performace por um select em uma base muito grande de siglas
            modelBuilder.Entity<Cidade>().HasIndex(cidade => cidade.Sigla).HasName("IXCidade_Sigla");
            // Mapeamento da cidade com o estado
            modelBuilder.Entity<Cidade>().HasOne(cidade => cidade.Estado).WithMany(estado => estado.Cidades).IsRequired();
        }

        public static void ConfigureTrexoModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trexo>().HasOne(trexo => trexo.CidadePartida).WithMany(cidade => cidade.TrexosDePartida).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Trexo>().HasOne(trexo => trexo.CidadeDestino).WithMany(cidade => cidade.TrexosDeDestino).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Trexo>().HasQueryFilter(trexo => !trexo.IsDeleted);
        }
    }
}
