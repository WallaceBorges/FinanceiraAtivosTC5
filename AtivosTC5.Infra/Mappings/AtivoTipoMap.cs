using AtivosTC5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Mappings
{
    public class AtivoTipoMap : IEntityTypeConfiguration<AtivoTipo>
    {
        public void Configure(EntityTypeBuilder<AtivoTipo> builder)
        {
            builder.ToTable("ATIVOTIPO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Nome)
                .HasMaxLength(150)
                .IsRequired();

            #region Colunas
            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(100)")
                .IsRequired();


            builder.HasData(
                 new AtivoTipo { Id = 1, Nome = "Ação" },
                 new AtivoTipo { Id = 2, Nome = "Cripto Moeda" },
                 new AtivoTipo { Id = 3, Nome = "Dinheiro" },
                 new AtivoTipo { Id = 4, Nome = "Titulo" }
                );
            #endregion
        }
    }
}
